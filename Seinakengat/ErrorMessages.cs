using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComponentCatalog {
    public partial class ErrorMessages : Form {

        List<string> messages;
        List<string> stackTraces;

        public ErrorMessages() {
            InitializeComponent();
        }

        public void InsertMessages(List<string> messages, List<string> stacktraces) {
            this.messages = messages;
            this.stackTraces = stacktraces;
            foreach (string m in messages) {
                listBox.Items.Add(m);
            }
            if (listBox.Items.Count != 0) {
                listBox.SelectedIndex = 0;
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                textBox.Text = stackTraces[listBox.SelectedIndex];
            } catch (Exception) {
            }
            
        }
    }
}
