namespace gui_ai_beveiliging
{
    partial class Form1
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
            opnfldrbtn = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            TBfolder = new TextBox();
            LBresults = new ListBox();
            LBitem = new ListBox();
            SuspendLayout();
            // 
            // opnfldrbtn
            // 
            opnfldrbtn.Location = new Point(387, 25);
            opnfldrbtn.Name = "opnfldrbtn";
            opnfldrbtn.Size = new Size(94, 29);
            opnfldrbtn.TabIndex = 0;
            opnfldrbtn.Text = "open folder";
            opnfldrbtn.UseVisualStyleBackColor = true;
            opnfldrbtn.Click += opnfldrbtn_Click;
            // 
            // TBfolder
            // 
            TBfolder.Location = new Point(516, 24);
            TBfolder.Name = "TBfolder";
            TBfolder.Size = new Size(229, 27);
            TBfolder.TabIndex = 1;
            // 
            // LBresults
            // 
            LBresults.FormattingEnabled = true;
            LBresults.ItemHeight = 20;
            LBresults.Location = new Point(63, 75);
            LBresults.Name = "LBresults";
            LBresults.Size = new Size(150, 264);
            LBresults.TabIndex = 2;
            LBresults.SelectedIndexChanged += LBresults_SelectedIndexChanged;
            // 
            // LBitem
            // 
            LBitem.FormattingEnabled = true;
            LBitem.ItemHeight = 20;
            LBitem.Location = new Point(387, 75);
            LBitem.Name = "LBitem";
            LBitem.Size = new Size(150, 204);
            LBitem.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LBitem);
            Controls.Add(LBresults);
            Controls.Add(TBfolder);
            Controls.Add(opnfldrbtn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button opnfldrbtn;
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox TBfolder;
        private ListBox LBresults;
        private ListBox LBitem;
    }
}