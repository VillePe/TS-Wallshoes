using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tekla.Structures.Catalogs;

namespace Seinäkengät {
    public partial class ComponentCatalog : Form {

        string[] wallshoeNames = new string[] {
            "ASL",
            "SUMO",
            "SSK",
        };

        string[] columnshoeNames = new string[] {
            "HPKM",
            "PEC",
            "OPK",
            "APK",
            "AHK",
            "AK",
        };

        string[] boltNames = new string[] {
            "ALP",
            "AHP",
            "ATP",
            "AET",
            "AES",
            "HPM",
            "PPM",
            "SUJ",
            "SELP"
        };

        string selectedItem;

        public string SelectedItem {
            get { return selectedItem; }
            set { selectedItem = value; }
        }
        
        string keyForComponent;
        Dictionary<string, string> selectedComponents = new Dictionary<string, string>();
        List<ComponentItem> allComponents = new List<ComponentItem>();

        public ComponentCatalog(string keyForComponent, List<ComponentItem> components, SortOrder sortOrder = SortOrder.Wall) {
            InitializeComponent();
            this.keyForComponent = keyForComponent;
            this.allComponents = components;
            listView.Groups.Add(new ListViewGroup("Kengat_Seina", "Seinäkengät"));
            listView.Groups.Add(new ListViewGroup("Kengat_Pilari", "Pilarikengät"));
            listView.Groups.Add(new ListViewGroup("Pultit", "Pultit"));
            listView.Groups.Add(new ListViewGroup("Muut", "Muut"));
            FillList();
            SortGroups(sortOrder);
            
        }

        public void FillList() {
            foreach (ComponentItem cItem in allComponents) {
                bool itemFound = false;
                foreach (string s in wallshoeNames) {
                    if (cItem.Name.Contains(s)) {
                        AddListViewItem(cItem.Name, "Kengat_Seina", Color.LightGreen);
                        itemFound = true;
                    }
                }
                if (itemFound) continue;
                foreach (string s in columnshoeNames) {
                    if (cItem.Name.Contains(s)) {
                        AddListViewItem(cItem.Name, "Kengat_Pilari", Color.LightBlue);
                        itemFound = true;
                    }
                }
                if (itemFound) continue;
                foreach (string s in boltNames) {
                    if (cItem.Name.Contains(s)) {
                        AddListViewItem(cItem.Name, "Pultit", Color.LightCoral);
                        itemFound = true;
                    }
                }
                if (itemFound) continue;
                AddListViewItem(cItem.Name, "Muut");
            }
        }

        private void SortGroups(SortOrder sortOrder) {
            List<ListViewGroup> tempGroup = new List<ListViewGroup>();
            foreach (ListViewGroup g in listView.Groups) {
                tempGroup.Add(g);
            }
            listView.Groups.Clear();
            switch (sortOrder) {
                case SortOrder.Wall:
                    listView.Groups.Add(FindGroup(tempGroup, "Kengat_Seina"));
                    listView.Groups.Add(FindGroup(tempGroup, "Kengat_Pilari"));
                    listView.Groups.Add(FindGroup(tempGroup, "Pultit"));
                    listView.Groups.Add(FindGroup(tempGroup, "Muut"));
                    break;
                case SortOrder.Column:
                    listView.Groups.Add(FindGroup(tempGroup, "Kengat_Pilari"));
                    listView.Groups.Add(FindGroup(tempGroup, "Kengat_Seina"));                    
                    listView.Groups.Add(FindGroup(tempGroup, "Pultit"));
                    listView.Groups.Add(FindGroup(tempGroup, "Muut"));
                    break;
                case SortOrder.Bolt:
                    listView.Groups.Add(FindGroup(tempGroup, "Pultit"));
                    listView.Groups.Add(FindGroup(tempGroup, "Kengat_Pilari"));
                    listView.Groups.Add(FindGroup(tempGroup, "Kengat_Seina"));                    
                    listView.Groups.Add(FindGroup(tempGroup, "Muut"));
                    break;
            }
        }

        public enum SortOrder {
            Wall = 1,
            Column = 2,
            Bolt = 3

        }

        private ListViewGroup FindGroup(List<ListViewGroup> collection, string name) {
            ListViewGroup lGroup = new ListViewGroup();

            foreach (ListViewGroup g in collection) {
                if (g.Name.Equals(name)) {
                    lGroup = g;
                    break;
                }
            }

            return lGroup;
        }

        private void AddListViewItem(string name, string group) {
            AddListViewItem(name, group, Color.White);
        }

        private void AddListViewItem(string name, string group, Color backColor) {
            ListViewGroup lGroup = new ListViewGroup(group, group);
            if (!listView.Groups.Contains(lGroup)) {
                listView.Groups.Add(lGroup);
            }
            ListViewItem lItem;
            lItem = new ListViewItem(name);
            lItem.Group = listView.Groups[group];
            lItem.BackColor = backColor;
            listView.Items.Add(lItem);
        }

        public void ConnectComponentDictionaries(Dictionary<string, string> dict) {
            selectedComponents = dict;
        }

        private void button1_Click(object sender, EventArgs e) {
            selectedItem = listView.SelectedItems[0].Text;
            selectedComponents[keyForComponent] = selectedItem;
            Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e) {
            if (listView.View == View.Details) {
                listView.View = View.LargeIcon;
            } else {
                listView.View = View.Details;
            }
            
        }

        private void ComponentCatalog_SizeChanged(object sender, EventArgs e) {
            bConvert.Location = new Point(this.Size.Width / 2 - 23, this.Size.Height - 73);
        }

        private void listView_DoubleClick(object sender, EventArgs e) {
            selectedItem = listView.SelectedItems[0].Text;
            selectedComponents[keyForComponent] = selectedItem;
            Close();
        }

        private void Search_Click(object sender, EventArgs e) {
            listView.Items.Clear();
            foreach(ComponentItem compItem in allComponents) {
                string compName = compItem.Name.ToUpper();
                string searchString = tbFind.Text.ToUpper();
                if (compName.Contains(searchString)) {
                    AddListViewItem(compItem.Name, "Löydetyt");
                }
            }
        }

        private void Revert_Click(object sender, EventArgs e) {
            listView.Items.Clear();
            FillList();
        }
    }
}
