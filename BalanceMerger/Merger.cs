using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace BalanceMerger
{
    public delegate void MergerHandler(int progress);

    public class Merger
    {
        public event MergerHandler Progress;

        private Balance balance;
        private Journal journal;

        public Merger(Balance balance, Journal journal)
        {
            this.balance = balance;
            this.journal = journal;
        }

        public void DoMerge()
        {
            BalanceItem bi;
            int index;
            for (int i = 1; i <= balance.itemsCount() - 1; ++i)
            {
                bi = balance.GetItem(i);
                index = journal.HasItem(bi.Description, bi.Rest);
                if (index != -1)
                {
                    bi.Document = journal.GetItem(index).Document;
                    bi.Comment = Resources.Strings.stSuccess;
                }
                else
                {
                    bi.Comment = Resources.Strings.stFailure;
                }
                
                Progress?.Invoke(i);
                Thread.Sleep(0);
            }
        }
    }    
}
