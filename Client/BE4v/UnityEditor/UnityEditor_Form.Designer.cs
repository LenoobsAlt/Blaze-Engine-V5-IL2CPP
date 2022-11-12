
namespace BE4v.UnityEditor
{
    partial class UnityEditor_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView_ObjectsList = new System.Windows.Forms.TreeView();
            this.buttonScanWorld = new System.Windows.Forms.Button();
            this.buttonScanSelf = new System.Windows.Forms.Button();
            this.labelScanners = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView_ObjectsList
            // 
            this.treeView_ObjectsList.Location = new System.Drawing.Point(12, 31);
            this.treeView_ObjectsList.Name = "treeView_ObjectsList";
            this.treeView_ObjectsList.Size = new System.Drawing.Size(396, 407);
            this.treeView_ObjectsList.TabIndex = 0;
            this.treeView_ObjectsList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // buttonScanWorld
            // 
            this.buttonScanWorld.Location = new System.Drawing.Point(73, 6);
            this.buttonScanWorld.Name = "buttonScanWorld";
            this.buttonScanWorld.Size = new System.Drawing.Size(49, 19);
            this.buttonScanWorld.TabIndex = 1;
            this.buttonScanWorld.Text = "World";
            this.buttonScanWorld.UseVisualStyleBackColor = true;
            // 
            // buttonScanSelf
            // 
            this.buttonScanSelf.Location = new System.Drawing.Point(128, 6);
            this.buttonScanSelf.Name = "buttonScanSelf";
            this.buttonScanSelf.Size = new System.Drawing.Size(51, 19);
            this.buttonScanSelf.TabIndex = 2;
            this.buttonScanSelf.Text = "Self";
            this.buttonScanSelf.UseVisualStyleBackColor = true;
            // 
            // labelScanners
            // 
            this.labelScanners.AutoSize = true;
            this.labelScanners.Location = new System.Drawing.Point(12, 8);
            this.labelScanners.Name = "labelScanners";
            this.labelScanners.Size = new System.Drawing.Size(55, 13);
            this.labelScanners.TabIndex = 3;
            this.labelScanners.Text = "Scanners:";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(185, 5);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(166, 20);
            this.textBoxSearch.TabIndex = 4;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(357, 5);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(51, 19);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // UnityEditor_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelScanners);
            this.Controls.Add(this.buttonScanSelf);
            this.Controls.Add(this.buttonScanWorld);
            this.Controls.Add(this.treeView_ObjectsList);
            this.Name = "UnityEditor_Form";
            this.Text = "UnityEditor_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_ObjectsList;
        private System.Windows.Forms.Button buttonScanWorld;
        private System.Windows.Forms.Button buttonScanSelf;
        private System.Windows.Forms.Label labelScanners;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
    }
}