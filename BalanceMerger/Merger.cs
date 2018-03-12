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
            for (int i = 1; i <= balance.ItemsCount() - 1; ++i)
            {
                bi = balance.GetItem(i);
                ItemState itemState;
                List<int> indexes = new List<int>();
                itemState = journal.HasItem(bi.Description, bi.Rest, ref indexes);

                switch (itemState)
                {
                    case ItemState.isFound:
                        bi.Document = journal.GetItem(indexes[0]).Document;
                        bi.Comment = Resources.Strings.stSuccess;
                        break;                    
                    case ItemState.isCollect:

                        break;
                    default:
                        bi.Comment = Resources.Strings.stFailure;
                        break;
                }
                Progress?.Invoke(i);
                Thread.Sleep(0);
            }
        }
    }    
}
