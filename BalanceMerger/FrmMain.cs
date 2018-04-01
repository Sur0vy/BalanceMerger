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
using Excel = Microsoft.Office.Interop.Excel;

namespace BalanceMerger
{
    public partial class FrmMain : Form
    {
        Excel.Application application = null;

        private Balance balance;

        private Journal journal;

        public FrmMain()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Helper.LANGUAGE);
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(Helper.LANGUAGE);
            InitializeComponent();
            this.Icon = Properties.Resources.BalanceMerger;
        }

        private void BtnOpenJournal_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = Resources.Strings.stOpenJHeader;
            openFileDialog.Filter = Resources.Strings.stFilterXls;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CreateExcel();
                journal = new Journal(application);
                Thread openJ = new Thread(OpenJournal);
                openJ.Start();
            }
        }

        private void SkipProgress()
        {
            SetLabelText(lblStatus, "");

            if (progressBar.InvokeRequired)
                progressBar.BeginInvoke(new Action<int>((value) => progressBar.Value = value), 0);
            else
                progressBar.Value = 0;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMerge_Click(object sender, EventArgs e)
        {
            MergeBalance();
        }

        private string SaveBalance()
        {
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(balance.fileName) + Resources.Strings.stMerge;
            saveFileDialog.Title = Resources.Strings.stSaveHeader;
            saveFileDialog.Filter = Resources.Strings.stFilterXlsx;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                balance.Save(saveFileDialog.FileName);
                //return Path.GetDirectoryName(saveFileDialog.FileName);
                return saveFileDialog.FileName;
            }
            return "";
        }

        private void OpenBalance()
        {
            ChangeCursor(Cursors.WaitCursor);
            if (balance.LoadFromFile(openFileDialog.FileName))
            {
                DoAfterOpen(labelBalance, balance.fileName);
            }
            else
            {
                balance = null;
                DoAfterOpen(labelBalance, Resources.Strings.stNoFile);
            }
            ChangeCursor(Cursors.Default);
        }

        private void OpenJournal()
        {
            ChangeCursor(Cursors.WaitCursor);
            if (journal.LoadFromFile(openFileDialog.FileName))
            {
                DoAfterOpen(labelJournal, journal.fileName);
            }
            else
            {
                journal = null;    
                DoAfterOpen(labelJournal, Resources.Strings.stNoFile);
            }
            ChangeCursor(Cursors.Default);
        }

        private void ChangeCursor(Cursor cursor)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new Action<Cursor>((s) => this.Cursor = s), cursor);
            else
                this.Cursor = cursor;
            Boolean state = !(cursor == Cursors.WaitCursor);
            SetButtonState(btnClose, state);
            SetButtonState(btnMerge, state);
            SetButtonState(btnOpenBalance, state);
            SetButtonState(btnOpenJournal, state);
        }

        private void SetButtonState(Button button, Boolean state)
        {
            if (button.InvokeRequired)
                button.BeginInvoke(new Action<Boolean>((s) => button.Enabled = s), state);
            else
                button.Enabled = state;
        }

        private void SetLabelText(Label label, string text)
        {
            if (label.InvokeRequired)
                label.BeginInvoke(new Action<string>((s) => label.Text = s), text);
            else
                label.Text = text;
        }

        private void DoAfterOpen(Label label, string fileName)
        {
            SetLabelText(label, fileName);
            CheckSourceData();
            SkipProgress();
        }

        private void CheckSourceData()
        {
            if ((balance != null) & (journal != null))            
                if ((balance.ItemsCount() > 0) & (journal.ItemsCount() > 0))
                {
                    SetButtonState(btnMerge, true);
                }
        }

        private void BtnOpenBalance_Click(object sender, EventArgs e)
        {

            openFileDialog.Title = Resources.Strings.stOpenBHeader;
            openFileDialog.Filter = Resources.Strings.stFilterXls;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CreateExcel();
                balance = new Balance(application);
                Thread openB = new Thread(OpenBalance);
                openB.Start();
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
                    string file = SaveBalance();
                    if (!file.Equals(""))
                        SelectFile(file);                    
                }
            }
        }

        private void SelectFile(string file)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", @"/select, " + file);
            }
            catch (Exception ex)
            {
            }
        }

        private void StopProcess()
        {
            lblStatus.Text = Resources.Strings.stDone;
            ChangeCursor(Cursors.Default);
        }

        private void StartProcess()
        {
            lblStatus.Text = Resources.Strings.stProcess;
            progressBar.Maximum = balance.ItemsCount() - 1;
            progressBar.Value = 0;
            progressBar.Step = 1;
            ChangeCursor(Cursors.WaitCursor);
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            FrmAbout about = new FrmAbout();            
            about.ShowDialog();
        }  
        
        private void CreateExcel()
        {
            if (application == null)
            {
                application = new Excel.Application
                {
                    Visible = false
                };
            };
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (application != null)
            application.Quit();
        }
    }
}
