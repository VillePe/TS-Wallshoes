namespace ComponentCatalog {
    partial class MainWindow {
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
            this.bSet = new System.Windows.Forms.Button();
            this.tbDistLeft = new System.Windows.Forms.TextBox();
            this.tbDistRight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbShoeLeft = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bRightBolt = new System.Windows.Forms.Button();
            this.bLeftBolt = new System.Windows.Forms.Button();
            this.bRightShoe = new System.Windows.Forms.Button();
            this.bLeftShoe = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBoltRight = new System.Windows.Forms.TextBox();
            this.tbBoltLeft = new System.Windows.Forms.TextBox();
            this.tbShoeRight = new System.Windows.Forms.TextBox();
            this.bErrorMessages = new System.Windows.Forms.Button();
            this.cbDirection = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bSet
            // 
            this.bSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.structuresExtender.SetAttributeName(this.bSet, null);
            this.structuresExtender.SetAttributeTypeName(this.bSet, null);
            this.structuresExtender.SetBindPropertyName(this.bSet, null);
            this.bSet.Location = new System.Drawing.Point(104, 406);
            this.bSet.Name = "bSet";
            this.bSet.Size = new System.Drawing.Size(75, 23);
            this.bSet.TabIndex = 0;
            this.bSet.Text = "Aseta";
            this.bSet.UseVisualStyleBackColor = true;
            this.bSet.Click += new System.EventHandler(this.bSet_Click);
            // 
            // tbDistLeft
            // 
            this.structuresExtender.SetAttributeName(this.tbDistLeft, null);
            this.structuresExtender.SetAttributeTypeName(this.tbDistLeft, null);
            this.structuresExtender.SetBindPropertyName(this.tbDistLeft, null);
            this.tbDistLeft.Location = new System.Drawing.Point(16, 49);
            this.tbDistLeft.Name = "tbDistLeft";
            this.tbDistLeft.Size = new System.Drawing.Size(100, 20);
            this.tbDistLeft.TabIndex = 1;
            // 
            // tbDistRight
            // 
            this.structuresExtender.SetAttributeName(this.tbDistRight, null);
            this.structuresExtender.SetAttributeTypeName(this.tbDistRight, null);
            this.structuresExtender.SetBindPropertyName(this.tbDistRight, null);
            this.tbDistRight.Location = new System.Drawing.Point(135, 49);
            this.tbDistRight.Name = "tbDistRight";
            this.tbDistRight.Size = new System.Drawing.Size(100, 20);
            this.tbDistRight.TabIndex = 2;
            // 
            // label1
            // 
            this.structuresExtender.SetAttributeName(this.label1, null);
            this.structuresExtender.SetAttributeTypeName(this.label1, null);
            this.label1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label1, null);
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Vasen";
            // 
            // label3
            // 
            this.structuresExtender.SetAttributeName(this.label3, null);
            this.structuresExtender.SetAttributeTypeName(this.label3, null);
            this.label3.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label3, null);
            this.label3.Location = new System.Drawing.Point(132, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Oikea";
            // 
            // groupBox1
            // 
            this.structuresExtender.SetAttributeName(this.groupBox1, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox1, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox1, null);
            this.groupBox1.Controls.Add(this.tbDistLeft);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbDistRight);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Etäisyydet";
            // 
            // statusStrip1
            // 
            this.structuresExtender.SetAttributeName(this.statusStrip1, null);
            this.structuresExtender.SetAttributeTypeName(this.statusStrip1, null);
            this.structuresExtender.SetBindPropertyName(this.statusStrip1, null);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 446);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(316, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssInfo
            // 
            this.tssInfo.Name = "tssInfo";
            this.tssInfo.Size = new System.Drawing.Size(118, 17);
            this.tssInfo.Text = "toolStripStatusLabel1";
            // 
            // tbShoeLeft
            // 
            this.structuresExtender.SetAttributeName(this.tbShoeLeft, null);
            this.structuresExtender.SetAttributeTypeName(this.tbShoeLeft, null);
            this.structuresExtender.SetBindPropertyName(this.tbShoeLeft, null);
            this.tbShoeLeft.Location = new System.Drawing.Point(76, 51);
            this.tbShoeLeft.Name = "tbShoeLeft";
            this.tbShoeLeft.Size = new System.Drawing.Size(145, 20);
            this.tbShoeLeft.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.structuresExtender.SetAttributeName(this.groupBox2, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox2, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox2, null);
            this.groupBox2.Controls.Add(this.bRightBolt);
            this.groupBox2.Controls.Add(this.bLeftBolt);
            this.groupBox2.Controls.Add(this.bRightShoe);
            this.groupBox2.Controls.Add(this.bLeftShoe);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbBoltRight);
            this.groupBox2.Controls.Add(this.tbBoltLeft);
            this.groupBox2.Controls.Add(this.tbShoeRight);
            this.groupBox2.Controls.Add(this.tbShoeLeft);
            this.groupBox2.Location = new System.Drawing.Point(28, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 180);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Komponentit";
            // 
            // bRightBolt
            // 
            this.structuresExtender.SetAttributeName(this.bRightBolt, null);
            this.structuresExtender.SetAttributeTypeName(this.bRightBolt, null);
            this.structuresExtender.SetBindPropertyName(this.bRightBolt, null);
            this.bRightBolt.Location = new System.Drawing.Point(225, 153);
            this.bRightBolt.Name = "bRightBolt";
            this.bRightBolt.Size = new System.Drawing.Size(27, 21);
            this.bRightBolt.TabIndex = 27;
            this.bRightBolt.Tag = "rightBolt";
            this.bRightBolt.Text = "...";
            this.bRightBolt.UseVisualStyleBackColor = true;
            this.bRightBolt.Click += new System.EventHandler(this.bRightBolt_Click);
            // 
            // bLeftBolt
            // 
            this.structuresExtender.SetAttributeName(this.bLeftBolt, null);
            this.structuresExtender.SetAttributeTypeName(this.bLeftBolt, null);
            this.structuresExtender.SetBindPropertyName(this.bLeftBolt, null);
            this.bLeftBolt.Location = new System.Drawing.Point(225, 126);
            this.bLeftBolt.Name = "bLeftBolt";
            this.bLeftBolt.Size = new System.Drawing.Size(27, 21);
            this.bLeftBolt.TabIndex = 26;
            this.bLeftBolt.Tag = "leftBolt";
            this.bLeftBolt.Text = "...";
            this.bLeftBolt.UseVisualStyleBackColor = true;
            this.bLeftBolt.Click += new System.EventHandler(this.bLeftBolt_Click);
            // 
            // bRightShoe
            // 
            this.structuresExtender.SetAttributeName(this.bRightShoe, null);
            this.structuresExtender.SetAttributeTypeName(this.bRightShoe, null);
            this.structuresExtender.SetBindPropertyName(this.bRightShoe, null);
            this.bRightShoe.Location = new System.Drawing.Point(227, 76);
            this.bRightShoe.Name = "bRightShoe";
            this.bRightShoe.Size = new System.Drawing.Size(27, 21);
            this.bRightShoe.TabIndex = 25;
            this.bRightShoe.Tag = "rightShoe";
            this.bRightShoe.Text = "...";
            this.bRightShoe.UseVisualStyleBackColor = true;
            this.bRightShoe.Click += new System.EventHandler(this.bRightShoe_Click);
            // 
            // bLeftShoe
            // 
            this.structuresExtender.SetAttributeName(this.bLeftShoe, null);
            this.structuresExtender.SetAttributeTypeName(this.bLeftShoe, null);
            this.structuresExtender.SetBindPropertyName(this.bLeftShoe, null);
            this.bLeftShoe.Location = new System.Drawing.Point(227, 50);
            this.bLeftShoe.Name = "bLeftShoe";
            this.bLeftShoe.Size = new System.Drawing.Size(27, 21);
            this.bLeftShoe.TabIndex = 24;
            this.bLeftShoe.Tag = "leftShoe";
            this.bLeftShoe.Text = "...";
            this.bLeftShoe.UseVisualStyleBackColor = true;
            this.bLeftShoe.Click += new System.EventHandler(this.bLeftShoe_Click);
            // 
            // label8
            // 
            this.structuresExtender.SetAttributeName(this.label8, null);
            this.structuresExtender.SetAttributeTypeName(this.label8, null);
            this.label8.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label8, null);
            this.label8.Location = new System.Drawing.Point(8, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Oikea";
            // 
            // label7
            // 
            this.structuresExtender.SetAttributeName(this.label7, null);
            this.structuresExtender.SetAttributeTypeName(this.label7, null);
            this.label7.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label7, null);
            this.label7.Location = new System.Drawing.Point(6, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Oikea";
            // 
            // label6
            // 
            this.structuresExtender.SetAttributeName(this.label6, null);
            this.structuresExtender.SetAttributeTypeName(this.label6, null);
            this.label6.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label6, null);
            this.label6.Location = new System.Drawing.Point(6, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Vasen";
            // 
            // label5
            // 
            this.structuresExtender.SetAttributeName(this.label5, null);
            this.structuresExtender.SetAttributeTypeName(this.label5, null);
            this.label5.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label5, null);
            this.label5.Location = new System.Drawing.Point(6, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Vasen";
            // 
            // label4
            // 
            this.structuresExtender.SetAttributeName(this.label4, null);
            this.structuresExtender.SetAttributeTypeName(this.label4, null);
            this.label4.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label4, null);
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Pultit";
            // 
            // label2
            // 
            this.structuresExtender.SetAttributeName(this.label2, null);
            this.structuresExtender.SetAttributeTypeName(this.label2, null);
            this.label2.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label2, null);
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Kengät";
            // 
            // tbBoltRight
            // 
            this.structuresExtender.SetAttributeName(this.tbBoltRight, null);
            this.structuresExtender.SetAttributeTypeName(this.tbBoltRight, null);
            this.structuresExtender.SetBindPropertyName(this.tbBoltRight, null);
            this.tbBoltRight.Location = new System.Drawing.Point(74, 154);
            this.tbBoltRight.Name = "tbBoltRight";
            this.tbBoltRight.Size = new System.Drawing.Size(145, 20);
            this.tbBoltRight.TabIndex = 16;
            // 
            // tbBoltLeft
            // 
            this.structuresExtender.SetAttributeName(this.tbBoltLeft, null);
            this.structuresExtender.SetAttributeTypeName(this.tbBoltLeft, null);
            this.structuresExtender.SetBindPropertyName(this.tbBoltLeft, null);
            this.tbBoltLeft.Location = new System.Drawing.Point(74, 128);
            this.tbBoltLeft.Name = "tbBoltLeft";
            this.tbBoltLeft.Size = new System.Drawing.Size(145, 20);
            this.tbBoltLeft.TabIndex = 14;
            // 
            // tbShoeRight
            // 
            this.structuresExtender.SetAttributeName(this.tbShoeRight, null);
            this.structuresExtender.SetAttributeTypeName(this.tbShoeRight, null);
            this.structuresExtender.SetBindPropertyName(this.tbShoeRight, null);
            this.tbShoeRight.Location = new System.Drawing.Point(76, 77);
            this.tbShoeRight.Name = "tbShoeRight";
            this.tbShoeRight.Size = new System.Drawing.Size(145, 20);
            this.tbShoeRight.TabIndex = 12;
            // 
            // bErrorMessages
            // 
            this.structuresExtender.SetAttributeName(this.bErrorMessages, null);
            this.structuresExtender.SetAttributeTypeName(this.bErrorMessages, null);
            this.structuresExtender.SetBindPropertyName(this.bErrorMessages, null);
            this.bErrorMessages.Enabled = false;
            this.bErrorMessages.Location = new System.Drawing.Point(205, 372);
            this.bErrorMessages.Name = "bErrorMessages";
            this.bErrorMessages.Size = new System.Drawing.Size(91, 23);
            this.bErrorMessages.TabIndex = 14;
            this.bErrorMessages.Text = "Virheilmoitukset";
            this.bErrorMessages.UseVisualStyleBackColor = true;
            this.bErrorMessages.Click += new System.EventHandler(this.bErrorMessages_Click);
            // 
            // cbDirection
            // 
            this.structuresExtender.SetAttributeName(this.cbDirection, null);
            this.structuresExtender.SetAttributeTypeName(this.cbDirection, null);
            this.structuresExtender.SetBindPropertyName(this.cbDirection, null);
            this.cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirection.FormattingEnabled = true;
            this.cbDirection.Items.AddRange(new object[] {
            "y+",
            "y-"});
            this.cbDirection.Location = new System.Drawing.Point(123, 379);
            this.cbDirection.Name = "cbDirection";
            this.cbDirection.Size = new System.Drawing.Size(38, 21);
            this.cbDirection.TabIndex = 15;
            // 
            // label9
            // 
            this.structuresExtender.SetAttributeName(this.label9, null);
            this.structuresExtender.SetAttributeTypeName(this.label9, null);
            this.label9.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label9, null);
            this.label9.Location = new System.Drawing.Point(120, 363);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Suunta";
            // 
            // button1
            // 
            this.structuresExtender.SetAttributeName(this.button1, null);
            this.structuresExtender.SetAttributeTypeName(this.button1, null);
            this.structuresExtender.SetBindPropertyName(this.button1, null);
            this.button1.Location = new System.Drawing.Point(103, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainWindow
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(316, 468);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbDirection);
            this.Controls.Add(this.bErrorMessages);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bSet);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSet;
        private System.Windows.Forms.TextBox tbDistLeft;
        private System.Windows.Forms.TextBox tbDistRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssInfo;
        private System.Windows.Forms.TextBox tbShoeLeft;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBoltRight;
        private System.Windows.Forms.TextBox tbBoltLeft;
        private System.Windows.Forms.TextBox tbShoeRight;
        private System.Windows.Forms.Button bRightBolt;
        private System.Windows.Forms.Button bLeftBolt;
        private System.Windows.Forms.Button bRightShoe;
        private System.Windows.Forms.Button bLeftShoe;
        private System.Windows.Forms.Button bErrorMessages;
        private System.Windows.Forms.ComboBox cbDirection;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
    }
}

