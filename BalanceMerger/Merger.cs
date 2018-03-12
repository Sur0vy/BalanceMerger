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
            for (int i = 1; i <= balance.itemsCount(); ++i)
            {
                Thread.Sleep(100);
                Progress?.Invoke(i);
            }
        }
    }    
}
