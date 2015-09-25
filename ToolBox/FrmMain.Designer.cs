using System.ComponentModel;
using System.Windows.Forms;

namespace ToolBox
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnNext = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUncheck = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.cbProgramList = new System.Windows.Forms.CheckedListBox();
            this.progressDownloaded = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(209, 13);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Download";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.progressDownloaded);
            this.panel1.Controls.Add(this.btnUncheck);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnCheck);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 67);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnUncheck
            // 
            this.btnUncheck.Location = new System.Drawing.Point(91, 13);
            this.btnUncheck.Name = "btnUncheck";
            this.btnUncheck.Size = new System.Drawing.Size(75, 23);
            this.btnUncheck.TabIndex = 2;
            this.btnUncheck.Text = "Uncheck All";
            this.btnUncheck.UseVisualStyleBackColor = true;
            this.btnUncheck.Click += new System.EventHandler(this.btnUncheck_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(8, 13);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Check All";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // cbProgramList
            // 
            this.cbProgramList.FormattingEnabled = true;
            this.cbProgramList.Location = new System.Drawing.Point(5, 4);
            this.cbProgramList.Name = "cbProgramList";
            this.cbProgramList.Size = new System.Drawing.Size(280, 229);
            this.cbProgramList.TabIndex = 2;
            this.cbProgramList.SelectedIndexChanged += new System.EventHandler(this.cbProgramList_SelectedIndexChanged);
            // 
            // progressDownloaded
            // 
            this.progressDownloaded.Location = new System.Drawing.Point(8, 42);
            this.progressDownloaded.Name = "progressDownloaded";
            this.progressDownloaded.Size = new System.Drawing.Size(276, 20);
            this.progressDownloaded.TabIndex = 3;
            this.progressDownloaded.Click += new System.EventHandler(this.progressDownloaded_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 305);
            this.Controls.Add(this.cbProgramList);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Tolik\'s Tiny Toolbox";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnNext;
        private Panel panel1;
        private Button btnCheck;
        private Button btnUncheck;
        private CheckedListBox cbProgramList;
        private ProgressBar progressDownloaded;
    }
}

