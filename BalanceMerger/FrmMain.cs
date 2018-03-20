using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace BalanceMerger
{
    public partial class FrmMain : Form
    {
        private Balance balance;

        private Journal journal;

        public FrmMain()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("ru");
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("ru");
            InitializeComponent();
        }

        private void BtnOpenJournal_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = Resources.Strings.stOpenJHeader;
            openFileDialog.Filter = Resources.Strings.stFilterXls;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenJournal(openFileDialog.FileName);
                CheckSourceData();
            }                
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMerge_Click(object sender, EventArgs e)
        {
            MergeBalance();                
        }

        private void SaveBalance()
        {            
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(balance.fileName) + Resources.Strings.stMerge;
            saveFileDialog.Title = Resources.Strings.stSaveHeader;
            saveFileDialog.Filter = Resources.Strings.stFilterXlsx;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                balance.Save(saveFileDialog.FileName);                
            }
        }

        private void OpenBalance(string fileName)
        {
            balance = new Balance();
            if (balance.LoadFromFile(fileName))
            {
                labelBalance.Text = balance.fileName;
            }            
        }

        private void OpenJournal(string fileName)
        {
            journal = new Journal();            
            if (journal.LoadFromFile(fileName))
            {
                labelJournal.Text = journal.fileName;
            }
        }

        private void CheckSourceData()
        {
            if ((balance != null) & (journal != null))            
                if ((balance.ItemsCount() > 0) & (journal.ItemsCount() > 0))
                {
                    btnMerge.Enabled = true;   
                }
        }

        private void BtnOpenBalance_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = Resources.Strings.stOpenBHeader;
            openFileDialog.Filter = Resources.Strings.stFilterXls;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenBalance(openFileDialog.FileName);
                CheckSourceData();
            }
        }

        private void MergeBalance()
        {            
            StartProcess();

            var processor = new Merger(balance, journal);
            processor.Progress += ProcessorProgress;
            var thread = new Thread(processor.DoMerge);
            thread.Start();
        }

        void ProcessorProgress(int progress)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new MergerHandler(ProcessorProgress), progress);
            }
            else
            {
                progressBar.Value = progress;
                if (progress == progressBar.Maximum)
                {
                    StopProcess();
                    SaveBalance();
                }
            }
        }

        private void StopProcess()
        {
            lblStatus.Text = Resources.Strings.stDone;
            Cursor = Cursors.Default;
            btnClose.Enabled = true;
            btnMerge.Enabled = true;
            btnOpenBalance.Enabled = true;
            btnOpenJournal.Enabled = true;
        }

        private void StartProcess()
        {
            lblStatus.Text = Resources.Strings.stProcess;
            progressBar.Maximum = balance.ItemsCount() - 1;
            progressBar.Value = 0;
            progressBar.Step = 1;
            Cursor = Cursors.WaitCursor;
            btnClose.Enabled = false;
            btnMerge.Enabled = false;
            btnOpenBalance.Enabled = false;
            btnOpenJournal.Enabled = false;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            //AboutBox1.ActiveForm.Visible = true;
        }
    }
}
