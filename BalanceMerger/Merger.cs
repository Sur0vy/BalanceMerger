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
        #region Public events
        public event MergerHandler Progress;
        #endregion

        #region Private declarations
        private Balance balance;
        private Journal journal;
        #endregion

        #region ctor
        public Merger(Balance balance, Journal journal)
        {
            this.balance = balance;
            this.journal = journal;
        }
        #endregion

        #region Main function
        public void DoMerge()
        {
            BalanceItem bi;
            for (int i = 1; i <= balance.ItemsCount() - 1; ++i)
            {
                bi = balance.GetItem(i);                 
                List<int> indexes = new List<int>();
                
                ItemState itemState = journal.HasItem(bi.Description, bi.Rest, ref indexes);
                bi.Status = itemState;

                switch (itemState)
                {
                    case ItemState.isFound:
                        bi.Document = journal.GetItem(indexes[0]).Document;
                        break;                    
                    case ItemState.isCollect:                        
                        for (int j = 0; j < indexes.Count; j++)
                        {                            
                            if (bi.Document != "")
                                bi.Document = bi.Document + " ";
                            bi.Document = bi.Document + journal.GetItem(indexes[j]).Document;
                            if (bi.Comment != "")
                                bi.Comment = bi.Comment + " ";
                            bi.Comment = bi.Comment + journal.GetItem(indexes[j]).Description;
                        }                        
                        break;
                    case ItemState.isCollectMissing:
                        for (int j = 0; j < indexes.Count; j++)
                        {                            
                            if (bi.Comment != "")
                                bi.Comment = bi.Comment + " ";
                            bi.Comment = bi.Comment + journal.GetItem(indexes[j]).Description + " (" +
                                                      journal.GetItem(indexes[j]).Rest.ToString() + ")";
                        }                        
                        break;
                    case ItemState.isDifBalance:
                        bi.Comment = Resources.Strings.stJournalDif + journal.GetItem(indexes[0]).Rest;
                        break;
                    default:                        
                        break;
                }
                Progress?.Invoke(i);
                Thread.Sleep(5);
            }
        }
        #endregion
    }
}
