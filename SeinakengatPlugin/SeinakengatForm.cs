using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tekla.Structures.Dialog;
using Tekla.Structures.Plugins;

namespace SeinakengatPlugin {
    public partial class SeinakengatForm : PluginFormBase {

        public SeinakengatForm() {
            InitializeComponent();
        }

        private void okApplyModifyGetOnOffCancel1_ApplyClicked(object sender, EventArgs e) {
            Apply();
        }

        private void okApplyModifyGetOnOffCancel1_CancelClicked(object sender, EventArgs e) {
            Close();
        }

        private void okApplyModifyGetOnOffCancel1_GetClicked(object sender, EventArgs e) {
            Get();
        }

        private void okApplyModifyGetOnOffCancel1_ModifyClicked(object sender, EventArgs e) {
            Modify();
        }

        private void okApplyModifyGetOnOffCancel1_OkClicked(object sender, EventArgs e) {
            Apply();
            Close();
        }

        private void okApplyModifyGetOnOffCancel1_OnOffClicked(object sender, EventArgs e) {
            ToggleSelection();
        }

        private void bLeftShoe_Click(object sender, EventArgs e) {
            ComponentCatalog.ComponentCatalog catalog = new ComponentCatalog.ComponentCatalog(TSUtilsLibrary.TSUtils.ListAllCustomComponents(), ComponentCatalog.ComponentCatalog.SortOrder.Wall);
            catalog.ShowDialog();
            if (!string.IsNullOrEmpty(catalog.SelectedItem)) {
                tbLeftShoeName.Text = catalog.SelectedItem;
                tbLeftShoeName.Select();
            }
        }

        private void bRightShoe_Click(object sender, EventArgs e) {
            ComponentCatalog.ComponentCatalog catalog = new ComponentCatalog.ComponentCatalog(TSUtilsLibrary.TSUtils.ListAllCustomComponents(), ComponentCatalog.ComponentCatalog.SortOrder.Wall);
            catalog.ShowDialog();
            if (!string.IsNullOrEmpty(catalog.SelectedItem)) {
                tbRightShoeName.Text = catalog.SelectedItem;
                tbRightShoeName.Select();
            }
        }

        private void bLeftBolt_Click(object sender, EventArgs e) {
            ComponentCatalog.ComponentCatalog catalog = new ComponentCatalog.ComponentCatalog(TSUtilsLibrary.TSUtils.ListAllCustomComponents(), ComponentCatalog.ComponentCatalog.SortOrder.Bolt);
            catalog.ShowDialog();
            if (!string.IsNullOrEmpty(catalog.SelectedItem)) {
                tbLeftBoltName.Text = catalog.SelectedItem;
                tbLeftBoltName.Select();
            }
        }

        private void bRightBolt_Click(object sender, EventArgs e) {
            ComponentCatalog.ComponentCatalog catalog = new ComponentCatalog.ComponentCatalog(TSUtilsLibrary.TSUtils.ListAllCustomComponents(), ComponentCatalog.ComponentCatalog.SortOrder.Bolt);
            catalog.ShowDialog();
            if (!string.IsNullOrEmpty(catalog.SelectedItem)) {
                tbRightBoltName.Text = catalog.SelectedItem;
                tbRightBoltName.Select();
            }
        }

        private void cboxRightBoltDist_CheckedChanged(object sender, EventArgs e) {

        }

        private void cboxRightBoltName_CheckedChanged(object sender, EventArgs e) {

        }

        private void tbRightBoltName_TextChanged(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e) {

        }

        private void bCopyToLShoe_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(tbRightShoeName.Text)) {
                tbLeftShoeName.Text = tbRightShoeName.Text;
                tbLeftShoeName.Select();
            }
        }

        private void bCopyToRShoe_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(tbLeftShoeName.Text)) {
                tbRightShoeName.Text = tbLeftShoeName.Text;
                tbRightShoeName.Select();
            }
        }

        private void bCopyToLBolt_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(tbRightBoltName.Text)) {
                tbLeftBoltName.Text = tbRightBoltName.Text;
                tbLeftBoltName.Select();
            }
        }

        private void bCopyToRBolt_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(tbLeftBoltName.Text)) {
                tbRightBoltName.Text = tbLeftBoltName.Text;
                tbRightBoltName.Select();
            }
        }
    }
}
