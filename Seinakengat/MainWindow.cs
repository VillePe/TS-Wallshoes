using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Tekla.Structures.Model;
using TSM = Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Catalogs;
using System.Threading;
using Tekla.Structures.Solid;
using System.Text;
using System.Xml;
using System.IO;

namespace ComponentCatalog {
    public partial class MainWindow : Tekla.Structures.Dialog.ApplicationFormBase {

        List<string> StackTraces = new List<string>();
        List<string> ExceptionMessages = new List<string>();
        Dictionary<string, string> selectedComponents = new Dictionary<string, string>() {
            { "leftShoe","" },
            { "rightShoe","" },
            { "leftBolt","" },
            { "rightBolt","" }
        };
        List<ComponentItem> allComponents = new List<ComponentItem>();
        Model model;
        Tekla.Structures.Dialog.UIControls.ComponentCatalog ca = new Tekla.Structures.Dialog.UIControls.ComponentCatalog();
        WorkPlaneHandler wHandler;


        public MainWindow() {
            InitializeComponent();
            model = new Model();
            if (!model.GetConnectionStatus()) {
                MessageBox.Show("Yhteyden luonti epäonnistui!");
                Environment.Exit(0);
            }
            SetInfoText("");
            ListAllCustomComponents();
            wHandler = model.GetWorkPlaneHandler();
        }

        public void SetInfoText(string s) {
            lock (tssInfo.Text) {
                tssInfo.Text = s;
            }
        }

        private void bSet_Click(object sender, EventArgs e) {
            Thread setter = new Thread(SetShoes);
            setter.Start();
        }

        private void SetShoes() {
            try {
                Picker picker = new Picker();
                ModelObject mObj = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
                Part part = null;
                if (mObj is Part) {
                    part = mObj as Part;
                } else {
                    return;
                }
                List<TSM.Component> components = CreateComponents();
                InsertComponents(part, components);
                model.CommitChanges();
            } catch (ApplicationException) {
                // User interrupt mostly
            } catch (Exception ex) {
                ExceptionOccured(ex.Message, ex.StackTrace);
                SetInfoText("Toiminta aiheutti poikkeuksen!");
            }
        }

        private List<TSM.Component> CreateComponents() {
            List<TSM.Component> components = new List<TSM.Component>();
            components.Add(new TSM.Component());
            components.Add(new TSM.Component());
            components.Add(new TSM.Component());
            components.Add(new TSM.Component());
            if (tbShoeLeft.Text == "") {
                tbShoeLeft.Text = "EB_ASL30";
            }
            if (tbShoeRight.Text == "") {
                tbShoeRight.Text = "EB_ASL30";
            }
            if (tbBoltLeft.Text == "") {
                tbBoltLeft.Text = "EB_AHP30";
            }
            if (tbBoltRight.Text == "") {
                tbBoltRight.Text = "EB_AHP30";
            }
            components[0].Name = tbShoeLeft.Text;
            components[1].Name = tbShoeRight.Text;
            components[2].Name = tbBoltLeft.Text;
            components[3].Name = tbBoltRight.Text;
            foreach (TSM.Component c in components) {
                c.Number = TSM.Component.CUSTOM_OBJECT_NUMBER;
            }
            return components;
        }

        private void InsertComponents(ModelObject mObj, List<TSM.Component> components) {
            TransformationPlane originalTransformationplane = null;
            try {
                lock (wHandler) {
                    originalTransformationplane = wHandler.GetCurrentTransformationPlane();
                }
                ComponentInput compInput = new ComponentInput();
                Part fatherpart = mObj as Part;
                Assembly assembly = fatherpart.GetAssembly();

                // Get the transformationplane from objects coordinate systems vectors and because objects coordinate system is not the same XY plane as of models, 
                // so cross product needs to be made for the Y-axis
                TransformationPlane fatherpartsTransformationPlane = new TransformationPlane(fatherpart.GetCoordinateSystem().Origin, fatherpart.GetCoordinateSystem().AxisX, Vector.Cross(fatherpart.GetCoordinateSystem().AxisY, fatherpart.GetCoordinateSystem().AxisX));
                lock (wHandler) {
                    wHandler.SetCurrentTransformationPlane(fatherpartsTransformationPlane);
                }
                double minX = fatherpart.GetSolid().MinimumPoint.X;
                double minY = fatherpart.GetSolid().MinimumPoint.Y;
                double minZ = fatherpart.GetSolid().MinimumPoint.Z;
                double maxX = fatherpart.GetSolid().MaximumPoint.X;
                double maxY = fatherpart.GetSolid().MaximumPoint.Y;
                double maxZ = fatherpart.GetSolid().MaximumPoint.Z;
                Solid s = fatherpart.GetSolid();
                FaceEnumerator fEnum = s.GetFaceEnumerator();
                StringBuilder sb = new StringBuilder();
                while (fEnum.MoveNext()) {
                    sb.AppendLine(fEnum.Current.Normal.ToString());
                }
                Point p1 = null;
                Point p2 = null;
                List<Point> cutPartPoints = new List<Point>() {
                    new Point(),
                    new Point(),
                    new Point(),
                    new Point()
                };
                ContourPlate cutpart = null;

                for (int i = 0; i < components.Count; i++) {
                    cutpart = new ContourPlate();
                    cutpart.Name = "Leikkaus";
                    cutpart.Position.Depth = Position.DepthEnum.MIDDLE;
                    cutpart.Position.Plane = Position.PlaneEnum.MIDDLE;
                    cutpart.Class = BooleanPart.BooleanOperativeClassName;
                    cutpart.Material.MaterialString = "Reikä";
                    cutpart.Profile.ProfileString = "PL135";
                    BooleanPart bPart = new BooleanPart();
                    compInput = new ComponentInput();
                    switch (i) {
                        case 0:
                            p1 = new Point(minX + 300, 0, minZ);
                            p2 = new Point(minX + 300, maxY, minZ);
                            cutpart.AddContourPoint(new ContourPoint(new Point(p1.X, p1.Y - 52, p1.Z + 40), null));
                            cutpart.AddContourPoint(new ContourPoint(new Point(p1.X, p1.Y - 52, p1.Z + 161.68), null));
                            cutpart.AddContourPoint(new ContourPoint(new Point(p1.X, maxY, p1.Z + 161.68 + (Math.Tan(9.88 * Math.PI / 180) * ((maxY - minY) / 2 + 52))), null));
                            cutpart.AddContourPoint(new ContourPoint(new Point(p1.X, maxY, p1.Z + 40), null));
                            cutpart.Insert();
                            bPart.Father = fatherpart;
                            bPart.SetOperativePart(cutpart);
                            if (!bPart.Insert()) {
                                SetInfoText("Leikkauksen (1) tekeminen epäonnistui!");
                            }
                            cutpart.Delete();
                            break;
                        case 1:
                            p1 = new Point(maxX - 300, 0, minZ);
                            p2 = new Point(maxX - 300, maxY, minZ);
                            cutpart.AddContourPoint(new ContourPoint(new Point(p1.X, p1.Y - 52, p1.Z + 40), null));
                            cutpart.AddContourPoint(new ContourPoint(new Point(p1.X, p1.Y - 52, p1.Z + 161.68), null));
                            cutpart.AddContourPoint(new ContourPoint(new Point(p1.X, maxY, p1.Z + 161.68 + (Math.Tan(9.88 * Math.PI / 180) * ((maxY - minY) / 2 + 52))), null));
                            cutpart.AddContourPoint(new ContourPoint(new Point(p1.X, maxY, p1.Z + 40), null));
                            cutpart.Insert();
                            bPart.Father = fatherpart;
                            bPart.SetOperativePart(cutpart);
                            if (!bPart.Insert()) {
                                SetInfoText("Leikkauksen (2) tekeminen epäonnistui!");
                            }
                            cutpart.Delete();
                            break;
                        case 2:
                            p1 = new Point(minX + 300, 0, maxZ + 135);
                            p2 = new Point(minX + 300, maxY, maxZ + 135);
                            break;
                        case 3:
                            p1 = new Point(maxX - 300, 0, maxZ + 135);
                            p2 = new Point(maxX - 300, maxY, maxZ + 135);
                            break;
                    }
                    compInput.AddOneInputPosition(p1);
                    compInput.AddOneInputPosition(p2);
                    components[i].SetComponentInput(compInput);
                    if (!components[i].Insert()) {
                        SetInfoText("Komponentin laittaminen epäonnistui!");
                    }
                }
                foreach (TSM.Component c in components) {
                    assembly.Add(c);
                    assembly.Modify();
                }
            } catch (Exception ex) {
                ExceptionOccured(ex.Message, ex.StackTrace);
                SetInfoText("Komponentin asettamisessa tapahtui virhe!");
            } finally {
                lock (wHandler) {
                    wHandler.SetCurrentTransformationPlane(originalTransformationplane);
                }
            }

        }

        private void ListAllCustomComponents() {
            Tekla.Structures.Catalogs.CatalogHandler catHandler = new Tekla.Structures.Catalogs.CatalogHandler();
            Tekla.Structures.Catalogs.ComponentItemEnumerator cEnum = catHandler.GetComponentItems();
            if (!catHandler.GetConnectionStatus()) {
                SetInfoText("Ei yhteyttä CatalogHandler:in kanssa!");
                return;
            }
            while (cEnum.MoveNext()) {
                ComponentItem componentItem = cEnum.Current as ComponentItem;
                if (componentItem.Name == "" || componentItem.Number > 0) continue;
                allComponents.Add(componentItem);
            }
        }

        private void bLeftBolt_Click(object sender, EventArgs e) {
            ComponentCatalog catalog = new ComponentCatalog(allComponents, ComponentCatalog.SortOrder.Bolt);
            catalog.ShowDialog();
            if (!string.IsNullOrEmpty(catalog.SelectedItem)) {
                tbBoltLeft.Text = catalog.SelectedItem;
            }
        }

        private void bRightBolt_Click(object sender, EventArgs e) {
            ComponentCatalog catalog = new ComponentCatalog(allComponents, ComponentCatalog.SortOrder.Bolt);
            catalog.ShowDialog();
            if (!string.IsNullOrEmpty(catalog.SelectedItem)) {
                tbBoltRight.Text = catalog.SelectedItem;
            }
        }

        private void bLeftShoe_Click(object sender, EventArgs e) {
            ComponentCatalog catalog = new ComponentCatalog(allComponents);
            catalog.ShowDialog();
            if (!string.IsNullOrEmpty(catalog.SelectedItem)) {
                tbShoeLeft.Text = catalog.SelectedItem;
            }
        }

        private void bRightShoe_Click(object sender, EventArgs e) {
            ComponentCatalog catalog = new ComponentCatalog(allComponents);
            catalog.ShowDialog();
            if (!string.IsNullOrEmpty(catalog.SelectedItem)) {
                tbShoeRight.Text = catalog.SelectedItem;
            }

        }

        private void bErrorMessages_Click(object sender, EventArgs e) {
            ErrorMessages err = new ErrorMessages();
            err.InsertMessages(ExceptionMessages, StackTraces);
            err.ShowDialog();
        }

        private void ExceptionOccured(string message, string stacktrace) {
            StackTraces.Add(stacktrace);
            ExceptionMessages.Add(message);
            bErrorMessages.Enabled = true;
        }

        private void bRotate_Click(object sender, EventArgs e) {

        }

        private void MainWindow_Load(object sender, EventArgs e) {
            cbDirection.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e) {
            string modelpath = model.GetInfo().ModelPath;
            XmlTextReader reader = new XmlTextReader(Path.Combine(modelpath, "ComponentCatalog.xml"));
        }
    }
}
