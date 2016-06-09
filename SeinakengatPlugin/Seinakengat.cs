using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tekla.Structures.Model;
using TSM = Tekla.Structures.Model;
using Tekla.Structures.Plugins;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Solid;
using System.IO;
using Tekla.Structures.Model.UI;
using Tekla.Structures;
using Tekla.Structures.Catalogs;
using Seinakengat;

namespace SeinakengatPlugin {

    [Plugin("TS_Seinakengat_plugin")]
    [PluginUserInterface("SeinakengatPlugin.SeinakengatForm")]
    public class Seinakengat : PluginBase {

        public class StructuresData {
            [StructuresField("LeftShoeName")]
            public string LeftShoeName;
            [StructuresField("RightShoeName")]
            public string RightShoeName;
            [StructuresField("LeftBoltName")]
            public string LeftBoltName;
            [StructuresField("RightBoltName")]
            public string RightBoltName;
            [StructuresField("LeftShoeDist")]
            public double LeftShoeDist;
            [StructuresField("RightShoeDist")]
            public double RightShoeDist;
            [StructuresField("LeftBoltDist")]
            public double LeftBoltDist;
            [StructuresField("RightBoltDist")]
            public double RightBoltDist;
            [StructuresField("LeftBoltOffset")]
            public double LeftBoltOffset;
            [StructuresField("RightBoltOffset")]
            public double RightBoltOffset;
            [StructuresField("Direction")]
            public string Direction;
            [StructuresField("CreateLeftBolt")]
            public int CreateLeftBolt;
            [StructuresField("CreateRightBolt")]
            public int CreateRightBolt;
        }

        Model model;
        StructuresData data;
        Dictionary<string, string> selectedComponents = new Dictionary<string, string>() {
            { "leftShoe","" },
            { "rightShoe","" },
            { "leftBolt","" },
            { "rightBolt","" }
        };
        List<ComponentItem> allComponents = new List<ComponentItem>();

        public Seinakengat(StructuresData data) {

            this.data = data;
            this.model = new Model();
            if (!model.GetConnectionStatus()) {
                System.Windows.Forms.MessageBox.Show("Yhteyden luonti epäonnistui!");
                Environment.Exit(0);
            }
        }

        public override List<InputDefinition> DefineInput() {
            List<InputDefinition> input = new List<InputDefinition>();

            Picker picker = new Picker();
            ModelObject mObj = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Valitse kappale");
            InputDefinition inpDef = new InputDefinition(mObj.Identifier);
            input.Add(inpDef);

            return input;
        }

        public override bool Run(List<InputDefinition> Input) {
            try {
                Tekla.Structures.Model.Operations.Operation.DisplayPrompt(data.CreateLeftBolt.ToString());
                ModelObject mObj = model.SelectModelObject((Input[0].GetInput()) as Identifier);
                Part part = null;
                if (mObj is Part) {
                    part = mObj as Part;
                } else {
                    return false;
                }
                SetValues();
                List<TSM.Component> components = CreateComponents();
                InsertComponents(part, components);
            } catch (Exception ex) {
                WriteLog(ex.Message + "\n" + ex.StackTrace);
                return false;
            }
            return true;
        }

        private List<TSM.Component> CreateComponents() {
            List<TSM.Component> components = new List<TSM.Component>();
            components.Add(new TSM.Component());
            components.Add(new TSM.Component());
            components.Add(new TSM.Component());
            components.Add(new TSM.Component());
            if (IsDefaultValue(data.LeftShoeName)) {
                data.LeftShoeName = "EB_ASL30";
            }
            if (IsDefaultValue(data.RightShoeName)) {
                data.RightShoeName = "EB_ASL30";
            }
            if (IsDefaultValue(data.LeftBoltName)) {
                data.LeftBoltName = "EB_AHP30";
            }
            if (IsDefaultValue(data.RightBoltName)) {
                data.RightBoltName = "EB_AHP30";
            }

            for (int i = 0; i < components.Count; i++) {
                switch (i) {
                    case 0:
                        components[0].Name = data.LeftShoeName;
                        break;
                    case 1:
                        components[1].Name = data.RightShoeName;
                        break;
                    case 2:
                        if (data.CreateLeftBolt != 0) {
                            components[2].Name = data.LeftBoltName;
                        } else {
                            components[2].Name = "";
                        }
                        break;
                    case 3:
                        if (data.CreateRightBolt != 0) {
                            components[3].Name = data.RightBoltName;
                        } else {
                            components[3].Name = "";
                        }
                        break;
                }
            }
            foreach (TSM.Component c in components) {
                c.Number = TSM.Component.CUSTOM_OBJECT_NUMBER;
            }
            return components;
        }

        private void SetValues() {
            if (IsDefaultValue(data.LeftShoeDist)) {
                data.LeftShoeDist = 300;
            }
            if (IsDefaultValue(data.RightShoeDist)) {
                data.RightShoeDist = 300;
            }
            if (IsDefaultValue(data.LeftBoltDist)) {
                data.LeftBoltDist = 300;
            }
            if (IsDefaultValue(data.RightBoltDist)) {
                data.RightBoltDist = 300;
            }
            if (IsDefaultValue(data.Direction)) {
                data.Direction = "y+";
            }
            if (IsDefaultValue(data.LeftBoltOffset)) {
                data.LeftBoltOffset = 135;
            }
            if (IsDefaultValue(data.RightBoltOffset)) {
                data.RightBoltOffset = 135;
            }
            if (IsDefaultValue(data.CreateLeftBolt)) {
                data.CreateLeftBolt = 1;
            }
            if (IsDefaultValue(data.CreateRightBolt)) {
                data.CreateRightBolt = 1;
            }
        }

        private void InsertComponents(ModelObject mObj, List<TSM.Component> components) {
            TransformationPlane originalTransformationplane = null;
            WorkPlaneHandler wHandler = null;
            try {
                wHandler = model.GetWorkPlaneHandler();
                originalTransformationplane = wHandler.GetCurrentTransformationPlane();
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
                bool changeDirection = false;

                if (data.Direction == "y-") {
                    double temp = maxY;
                    maxY = minY;
                    minY = temp;
                    changeDirection = true;
                }

                Solid s = fatherpart.GetSolid();
                FaceEnumerator fEnum = s.GetFaceEnumerator();
                StringBuilder sb = new StringBuilder();
                while (fEnum.MoveNext()) {

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
                    double[] variables;
                    switch (i) {
                        case 0:
                            p1 = new Point(maxX - data.LeftShoeDist, 0, minZ);
                            p2 = new Point(maxX - data.LeftShoeDist, maxY, minZ);
                            variables = WallShoeUtils.GetComponentVariables(components[i]);
                            if (variables[0] != 0) {
                                AddWallShoeCut(variables, p1, minY, maxY, changeDirection, fatherpart);
                            }
                            break;
                        case 1:
                            p1 = new Point(minX + data.RightShoeDist, 0, minZ);
                            p2 = new Point(minX + data.RightShoeDist, maxY, minZ);
                            variables = WallShoeUtils.GetComponentVariables(components[i]);
                            if (variables[0] != 0) {
                                AddWallShoeCut(variables, p1, minY, maxY, changeDirection, fatherpart);
                            }
                            break;
                        case 2:
                            p1 = new Point(maxX - data.LeftBoltDist, 0, maxZ + data.LeftBoltOffset);
                            p2 = new Point(maxX - data.LeftBoltDist, maxY, maxZ + data.LeftBoltOffset);
                            break;
                        case 3:
                            p1 = new Point(minX + data.RightBoltDist, 0, maxZ + data.RightBoltOffset);
                            sb.AppendLine(data.RightBoltDist + " " + data.RightBoltOffset);
                            p2 = new Point(minX + data.RightBoltDist, maxY, maxZ + data.RightBoltOffset);
                            break;
                    }
                    compInput.AddOneInputPosition(p1);
                    compInput.AddOneInputPosition(p2);
                    components[i].SetComponentInput(compInput);
                    if (!components[i].Insert()) {
                        TSM.Operations.Operation.DisplayPrompt("Komponentin " + i + " asettaminen epäonnistui!");
                        WriteLog("Komponentin " + i + " asettaminen epäonnistui!");
                    }
                }
                foreach (TSM.Component c in components) {
                    assembly.Add(c);
                    assembly.Modify();
                }
            } catch (Exception ex) {
                WriteLog(ex.Message + "\n" + ex.StackTrace);
            } finally {
                lock (wHandler) {
                    wHandler.SetCurrentTransformationPlane(originalTransformationplane);
                }
            }

        }

        /// <summary>
        /// Adds the cut for the wallshoe components
        /// </summary>
        /// <param name="variables">List of doubles with dimensions of the component</param>
        /// <param name="p1">The point which gives the x position of the component on fatherpart</param>
        /// <param name="minY">Fatherparts solids miminum Y position</param>
        /// <param name="maxY">Fatherparts solids miminum Y position</param>
        /// <param name="changeDirection">Boolean to give the direction</param>
        /// <param name="fatherpart">Part to insert the cut to</param>
        private bool AddWallShoeCut(double[] variables, Point p1, double minY, double maxY, bool changeDirection, Part fatherpart) {
            try {
                ContourPlate cutpart = new ContourPlate();
                BooleanPart bPart = new BooleanPart();
                cutpart.Name = "Leikkaus";
                cutpart.Position.Depth = Position.DepthEnum.MIDDLE;
                cutpart.Position.Plane = Position.PlaneEnum.MIDDLE;
                cutpart.Class = BooleanPart.BooleanOperativeClassName;
                cutpart.Material.MaterialString = "Reikä";
                cutpart.Profile.ProfileString = "PL135";
                cutpart.Profile.ProfileString = "PL" + variables[4];
                if (!changeDirection) {
                    cutpart.AddContourPoint(new ContourPoint(new Point(p1.X, p1.Y - variables[0], p1.Z + variables[1]), null));
                    cutpart.AddContourPoint(new ContourPoint(new Point(p1.X, p1.Y - variables[0], p1.Z + variables[1] + variables[2]), null));
                    cutpart.AddContourPoint(new ContourPoint(new Point(p1.X, maxY, p1.Z + variables[1] + variables[2] + (Math.Tan(variables[3] * Math.PI / 180) * ((maxY - minY) / 2 + variables[0]))), null));
                } else {
                    cutpart.AddContourPoint(new ContourPoint(new Point(p1.X, p1.Y + variables[0], p1.Z + variables[1]), null));
                    cutpart.AddContourPoint(new ContourPoint(new Point(p1.X, p1.Y + variables[0], p1.Z + variables[1] + variables[2]), null));
                    cutpart.AddContourPoint(new ContourPoint(new Point(p1.X, maxY, p1.Z + variables[1] + variables[2] + (Math.Tan(variables[3] * Math.PI / 180) * ((minY - maxY) / 2 + variables[0]))), null));
                }
                cutpart.AddContourPoint(new ContourPoint(new Point(p1.X, maxY, p1.Z + variables[1]), null));
                cutpart.Insert();
                bPart.Father = fatherpart;
                bPart.SetOperativePart(cutpart);
                if (!bPart.Insert()) {
                    WriteLog("Leikkauksen (1) tekeminen epäonnistui!");
                }
                cutpart.Delete();
            } catch (Exception ex) {
                WriteLog(ex.Message + "\n" + ex.StackTrace);
                return false;
            }
            
            return true;
        }

        private void WriteLog(string s) {
            if (!Directory.Exists(@"C:\temp\Seinäkengät")) {
                Directory.CreateDirectory(@"C:\temp\Seinäkengät");
            }
            DateTime dt = DateTime.Now;
            File.AppendAllText(@"C:\temp\Seinäkengät\Loki.txt", "\n" + dt.ToString() + "\n" + s + "\n\n********************\n");
        }
    }
}
