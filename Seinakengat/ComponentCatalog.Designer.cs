namespace Seinäkengät {
    partial class ComponentCatalog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bConvert = new System.Windows.Forms.Button();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.bSearch = new System.Windows.Forms.Button();
            this.bRevert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(37, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(153, 402);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView.Location = new System.Drawing.Point(2, 1);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(261, 369);
            this.listView.TabIndex = 3;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nimi";
            this.columnHeader1.Width = 1000;
            // 
            // bConvert
            // 
            this.bConvert.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bConvert.Location = new System.Drawing.Point(118, 402);
            this.bConvert.Name = "bConvert";
            this.bConvert.Size = new System.Drawing.Size(29, 23);
            this.bConvert.TabIndex = 4;
            this.bConvert.UseVisualStyleBackColor = true;
            this.bConvert.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbFind
            // 
            this.tbFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFind.Location = new System.Drawing.Point(37, 376);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(81, 20);
            this.tbFind.TabIndex = 5;
            // 
            // bSearch
            // 
            this.bSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSearch.Location = new System.Drawing.Point(124, 375);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(37, 21);
            this.bSearch.TabIndex = 7;
            this.bSearch.Text = "Hae";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.Search_Click);
            // 
            // bRevert
            // 
            this.bRevert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bRevert.Location = new System.Drawing.Point(167, 375);
            this.bRevert.Name = "bRevert";
            this.bRevert.Size = new System.Drawing.Size(61, 21);
            this.bRevert.TabIndex = 8;
            this.bRevert.Text = "Palauta";
            this.bRevert.UseVisualStyleBackColor = true;
            this.bRevert.Click += new System.EventHandler(this.Revert_Click);
            // 
            // ComponentCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 437);
            this.Controls.Add(this.bRevert);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.tbFind);
            this.Controls.Add(this.bConvert);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximumSize = new System.Drawing.Size(800, 2000);
            this.MinimumSize = new System.Drawing.Size(280, 475);
            this.Name = "ComponentCatalog";
            this.Text = "ComponentCatalog";
            this.SizeChanged += new System.EventHandler(this.ComponentCatalog_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button bConvert;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button bRevert;
    }
}