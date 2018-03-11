using System;

namespace BalanceMerger
{
    class BalanceItem : IEquatable<BalanceItem>
    {
        private string bill;
        private string name;
        private double rest;
        private int count;
        private string description;
        private string document;

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
    }
}
