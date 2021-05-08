
namespace DatabaseRedactorUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.host = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.adressBox = new System.Windows.Forms.TextBox();
            this.tableBox = new System.Windows.Forms.TextBox();
            this.databaseBox = new System.Windows.Forms.TextBox();
            this.connection = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.portBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.sendChanges = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.sendChanges);
            this.splitContainer1.Size = new System.Drawing.Size(786, 471);
            this.splitContainer1.SplitterDistance = 365;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(786, 365);
            this.dataGridView1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "table";
            // 
            // host
            // 
            this.host.AutoSize = true;
            this.host.Location = new System.Drawing.Point(14, 81);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(30, 15);
            this.host.TabIndex = 5;
            this.host.Text = "host";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "bd";
            // 
            // adressBox
            // 
            this.adressBox.Location = new System.Drawing.Point(83, 78);
            this.adressBox.Name = "adressBox";
            this.adressBox.Size = new System.Drawing.Size(156, 23);
            this.adressBox.TabIndex = 3;
            // 
            // tableBox
            // 
            this.tableBox.Location = new System.Drawing.Point(83, 49);
            this.tableBox.Name = "tableBox";
            this.tableBox.Size = new System.Drawing.Size(156, 23);
            this.tableBox.TabIndex = 2;
            // 
            // databaseBox
            // 
            this.databaseBox.Location = new System.Drawing.Point(83, 18);
            this.databaseBox.Name = "databaseBox";
            this.databaseBox.Size = new System.Drawing.Size(156, 23);
            this.databaseBox.TabIndex = 1;
            // 
            // connection
            // 
            this.connection.Location = new System.Drawing.Point(46, 173);
            this.connection.Name = "connection";
            this.connection.Size = new System.Drawing.Size(81, 62);
            this.connection.TabIndex = 0;
            this.connection.Text = "Connect";
            this.connection.UseVisualStyleBackColor = true;
            this.connection.Click += new System.EventHandler(this.connection_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 505);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 477);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.portBox);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.host);
            this.tabPage2.Controls.Add(this.connection);
            this.tabPage2.Controls.Add(this.databaseBox);
            this.tabPage2.Controls.Add(this.adressBox);
            this.tabPage2.Controls.Add(this.tableBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 477);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(83, 115);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(156, 23);
            this.portBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "port";
            // 
            // sendChanges
            // 
            this.sendChanges.Location = new System.Drawing.Point(19, 14);
            this.sendChanges.Name = "sendChanges";
            this.sendChanges.Size = new System.Drawing.Size(104, 23);
            this.sendChanges.TabIndex = 0;
            this.sendChanges.Text = "Send Changes";
            this.sendChanges.UseVisualStyleBackColor = true;
            this.sendChanges.Click += new System.EventHandler(this.SendData);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button connection;
        private System.Windows.Forms.TextBox tableBox;
        private System.Windows.Forms.TextBox databaseBox;
        private System.Windows.Forms.TextBox adressBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label host;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown portBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button sendChanges;
    }
}

