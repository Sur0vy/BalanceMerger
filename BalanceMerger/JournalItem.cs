using System;

namespace BalanceMerger
{
    public class JournalItem : IEquatable<JournalItem>
    {
        private double rest;
        private string description;
        private string document;
                    
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

        public bool Equals(JournalItem other)
        {
            if (other == null) return false;
            return (this.Description.Equals(other.Description));
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
