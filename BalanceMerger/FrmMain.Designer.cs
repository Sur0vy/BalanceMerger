namespace BalanceMerger
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
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBoxJournal = new System.Windows.Forms.GroupBox();
            this.labelJournal = new System.Windows.Forms.Label();
            this.btnOpenJournal = new System.Windows.Forms.Button();
            this.groupBoxBalance = new System.Windows.Forms.GroupBox();
            this.labelBalance = new System.Windows.Forms.Label();
            this.btnOpenBalance = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxJournal.SuspendLayout();
            this.groupBoxBalance.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(282, 167);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBoxJournal
            // 
            this.groupBoxJournal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxJournal.Controls.Add(this.labelJournal);
            this.groupBoxJournal.Controls.Add(this.btnOpenJournal);
            this.groupBoxJournal.Location = new System.Drawing.Point(12, 12);
            this.groupBoxJournal.Name = "groupBoxJournal";
            this.groupBoxJournal.Size = new System.Drawing.Size(345, 52);
            this.groupBoxJournal.TabIndex = 4;
            this.groupBoxJournal.TabStop = false;
            this.groupBoxJournal.Text = "Journal";
            // 
            // labelJournal
            // 
            this.labelJournal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelJournal.AutoEllipsis = true;
            this.labelJournal.Location = new System.Drawing.Point(6, 25);
            this.labelJournal.Name = "labelJournal";
            this.labelJournal.Size = new System.Drawing.Size(300, 13);
            this.labelJournal.TabIndex = 1;
            this.labelJournal.Text = "...";
            // 
            // btnOpenJournal
            // 
            this.btnOpenJournal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenJournal.Location = new System.Drawing.Point(312, 20);
            this.btnOpenJournal.Name = "btnOpenJournal";
            this.btnOpenJournal.Size = new System.Drawing.Size(27, 23);
            this.btnOpenJournal.TabIndex = 0;
            this.btnOpenJournal.Text = "...";
            this.btnOpenJournal.UseVisualStyleBackColor = true;
            this.btnOpenJournal.Click += new System.EventHandler(this.btnOpenJournal_Click);
            // 
            // groupBoxBalance
            // 
            this.groupBoxBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBalance.Controls.Add(this.labelBalance);
            this.groupBoxBalance.Controls.Add(this.btnOpenBalance);
            this.groupBoxBalance.Location = new System.Drawing.Point(12, 70);
            this.groupBoxBalance.Name = "groupBoxBalance";
            this.groupBoxBalance.Size = new System.Drawing.Size(345, 57);
            this.groupBoxBalance.TabIndex = 5;
            this.groupBoxBalance.TabStop = false;
            this.groupBoxBalance.Text = "Balance";
            // 
            // labelBalance
            // 
            this.labelBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBalance.AutoEllipsis = true;
            this.labelBalance.Location = new System.Drawing.Point(6, 25);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(300, 13);
            this.labelBalance.TabIndex = 2;
            this.labelBalance.Text = "...";
            // 
            // btnOpenBalance
            // 
            this.btnOpenBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenBalance.Location = new System.Drawing.Point(312, 20);
            this.btnOpenBalance.Name = "btnOpenBalance";
            this.btnOpenBalance.Size = new System.Drawing.Size(27, 23);
            this.btnOpenBalance.TabIndex = 0;
            this.btnOpenBalance.Text = "...";
            this.btnOpenBalance.UseVisualStyleBackColor = true;
            this.btnOpenBalance.Click += new System.EventHandler(this.btnOpenBalance_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Enabled = false;
            this.btnMerge.Location = new System.Drawing.Point(12, 133);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 6;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(93, 133);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(264, 23);
            this.progressBar.Step = 100;
            this.progressBar.TabIndex = 7;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 202);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.groupBoxBalance);
            this.Controls.Add(this.groupBoxJournal);
            this.Controls.Add(this.btnClose);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimumSize = new System.Drawing.Size(370, 240);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balance merger";
            this.groupBoxJournal.ResumeLayout(false);
            this.groupBoxBalance.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBoxJournal;
        private System.Windows.Forms.Button btnOpenJournal;
        private System.Windows.Forms.GroupBox groupBoxBalance;
        private System.Windows.Forms.Button btnOpenBalance;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Label labelJournal;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

