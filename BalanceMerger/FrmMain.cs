using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BalanceMerger
{
    public partial class FrmMain : Form
    {
        private Balance balance;

        private Journal journal;

        public FrmMain()
        {
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
            if (balance.merge(journal))
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    balance.save(saveFileDialog.FileName);    
            }
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
    }
}
