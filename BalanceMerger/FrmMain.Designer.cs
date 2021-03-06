﻿namespace BalanceMerger
{
    partial class FrmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBoxBalance = new System.Windows.Forms.GroupBox();
            this.labelBalance = new System.Windows.Forms.Label();
            this.btnOpenBalance = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.panelJournal = new System.Windows.Forms.Panel();
            this.groupBoxJournal = new System.Windows.Forms.GroupBox();
            this.labelJournal = new System.Windows.Forms.Label();
            this.btnOpenJournal = new System.Windows.Forms.Button();
            this.groupBoxBalance.SuspendLayout();
            this.panelJournal.SuspendLayout();
            this.groupBoxJournal.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // groupBoxBalance
            // 
            resources.ApplyResources(this.groupBoxBalance, "groupBoxBalance");
            this.groupBoxBalance.Controls.Add(this.labelBalance);
            this.groupBoxBalance.Controls.Add(this.btnOpenBalance);
            this.groupBoxBalance.Name = "groupBoxBalance";
            this.groupBoxBalance.TabStop = false;
            // 
            // labelBalance
            // 
            resources.ApplyResources(this.labelBalance, "labelBalance");
            this.labelBalance.AutoEllipsis = true;
            this.labelBalance.Name = "labelBalance";
            // 
            // btnOpenBalance
            // 
            resources.ApplyResources(this.btnOpenBalance, "btnOpenBalance");
            this.btnOpenBalance.Name = "btnOpenBalance";
            this.btnOpenBalance.UseVisualStyleBackColor = true;
            this.btnOpenBalance.Click += new System.EventHandler(this.BtnOpenBalance_Click);
            // 
            // btnMerge
            // 
            resources.ApplyResources(this.btnMerge, "btnMerge");
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.BtnMerge_Click);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            this.progressBar.Step = 100;
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
            // 
            // btnAbout
            // 
            resources.ApplyResources(this.btnAbout, "btnAbout");
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // panelJournal
            // 
            this.panelJournal.AllowDrop = true;
            this.panelJournal.Controls.Add(this.groupBoxJournal);
            resources.ApplyResources(this.panelJournal, "panelJournal");
            this.panelJournal.Name = "panelJournal";
            this.panelJournal.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelJournal_DragDrop);
            this.panelJournal.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelJournal_DragEnter);
            // 
            // groupBoxJournal
            // 
            this.groupBoxJournal.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxJournal.Controls.Add(this.labelJournal);
            this.groupBoxJournal.Controls.Add(this.btnOpenJournal);
            resources.ApplyResources(this.groupBoxJournal, "groupBoxJournal");
            this.groupBoxJournal.Name = "groupBoxJournal";
            this.groupBoxJournal.TabStop = false;
            // 
            // labelJournal
            // 
            resources.ApplyResources(this.labelJournal, "labelJournal");
            this.labelJournal.AutoEllipsis = true;
            this.labelJournal.Name = "labelJournal";
            // 
            // btnOpenJournal
            // 
            resources.ApplyResources(this.btnOpenJournal, "btnOpenJournal");
            this.btnOpenJournal.Name = "btnOpenJournal";
            this.btnOpenJournal.UseVisualStyleBackColor = true;
            this.btnOpenJournal.Click += new System.EventHandler(this.BtnOpenJournal_Click);
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelJournal);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.groupBoxBalance);
            this.Controls.Add(this.btnClose);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Name = "FrmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.groupBoxBalance.ResumeLayout(false);
            this.panelJournal.ResumeLayout(false);
            this.groupBoxJournal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBoxBalance;
        private System.Windows.Forms.Button btnOpenBalance;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label lblStatus;
        internal System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Panel panelJournal;
        private System.Windows.Forms.GroupBox groupBoxJournal;
        private System.Windows.Forms.Label labelJournal;
        private System.Windows.Forms.Button btnOpenJournal;
    }
}

