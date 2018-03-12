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

        private void btnOpenJournal_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openJournal(openFileDialog.FileName);
                checkSourceData();
            }                
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            MergeBalance();
        }

        private void openBalance(string fileName)
        {
            balance = new Balance();
            if (balance.loadFromFile(fileName))
            {
                labelBalance.Text = balance.fileName;
            }            
        }

        private void openJournal(string fileName)
        {
            journal = new Journal();            
            if (journal.loadFromFile(fileName))
            {
                labelJournal.Text = journal.fileName;
            }
        }

        private void checkSourceData()
        {
            if ((balance != null) & (journal != null))            
                if ((balance.itemsCount() > 0) & (journal.itemsCount() > 0))
                {
                    btnMerge.Enabled = true;   
                }
        }

        private void btnOpenBalance_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openBalance(openFileDialog.FileName);
                checkSourceData();
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
            progressBar.Maximum = balance.itemsCount() - 1;
            progressBar.Value = 0;
            progressBar.Step = 1;
            Cursor = Cursors.WaitCursor;
            btnClose.Enabled = false;
            btnMerge.Enabled = false;
            btnOpenBalance.Enabled = false;
            btnOpenJournal.Enabled = false;
        }


    }
}
