using System;
using System.Drawing;

namespace BalanceMerger
{
    public class BalanceItem : IEquatable<BalanceItem>
    {
        private string bill;
        private string name;
        private double rest;
        private int count;
        private string description;
        private string document;
        private ItemState status;
        private string comment;

        public string Bill
        {
            get
            {
                return bill;
            }

            set
            {
                bill = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public double Rest
        {
            get
            {
                return rest;
            }

            set
            {
                if (value >= 0)
                {
                    rest = value;
                }
                else
                {
                    rest = 0;
                }
            }
        }

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                if (value >= 0)
                {
                    count = value;
                }
                else
                {
                    count = 0;
                }
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Document
        {
            get
            {
                return document;
            }

            set
            {
                document = value;
            }
        }

        public ItemState Status { get => status; set => status = value; }

        public string Comment { get => comment; set => comment = value; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            JournalItem objAsPart = obj as JournalItem;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(BalanceItem other)
        {
            if (other == null) return false;
            return (this.Name.Equals(other.Name));
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public static string GetStatus(BalanceItem balanceItem)
        {
            switch (balanceItem.status)
            {
                case ItemState.isFound:
                    return Resources.Strings.stDone;
                case ItemState.isCollect:
                    return Resources.Strings.stCollect;
                case ItemState.isMissing:
                    return Resources.Strings.stFailure;
                case ItemState.isCollectMissing:
                    return Resources.Strings.stCollectMissing;
                default:
                    return Resources.Strings.stBalanceDif;
            }
        }

        public static Color GetStatusColor(BalanceItem balanceItem)
        {
            switch (balanceItem.status)
            {
                case ItemState.isFound:
                    return Color.LightGreen;
                case ItemState.isCollect:
                    return Color.LimeGreen;
                case ItemState.isMissing:
                    return Color.Red;
                case ItemState.isCollectMissing:
                    return Color.LightPink;
                default:
                    return Color.Yellow;
            }
        }
    }
}
