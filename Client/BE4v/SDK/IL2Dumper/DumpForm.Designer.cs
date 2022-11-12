
namespace BE4v.SDK.IL2Dumper
{
    partial class DumpForm
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
            this.components = new System.ComponentModel.Container();
            this.TreeDumpLib = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // TreeDumpLib
            // 
            this.TreeDumpLib.Location = new System.Drawing.Point(3, 15);
            this.TreeDumpLib.Margin = new System.Windows.Forms.Padding(5);
            this.TreeDumpLib.Name = "TreeDumpLib";
            this.TreeDumpLib.Size = new System.Drawing.Size(358, 434);
            this.TreeDumpLib.TabIndex = 0;
            this.TreeDumpLib.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeDumpLib_AfterSelect);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(366, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(430, 434);
            this.textBox1.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DumpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TreeDumpLib);
            this.Name = "DumpForm";
            this.Text = "DumpForm";
            this.Load += new System.EventHandler(this.DumpForm_Load);
            this.ResizeBegin += new System.EventHandler(this.DumpForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.DumpForm_ResizeEnd);
            this.Resize += new System.EventHandler(this.DumpForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TreeDumpLib;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
    }
}