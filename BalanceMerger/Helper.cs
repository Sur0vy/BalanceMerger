using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceMerger
{
    public static class Helper
    {
        public const string BILL = "Счет";
        public const string NAME = "Артикул";
        public const string REST = "Остаток на окончание периода";
        public const string COUNT = "Количество на окончание периода";
        public const string DESC = "Номенклатура";
        public const string CONTENT = "Содержание";
        public const string DOC = "Документ";
        public const string AMOUNT = "Сумма";        
        public const string A_FIELD = "A";
        public const string B_FIELD = "B";
        public const string C_FIELD = "C";
        public const string D_FIELD = "D";
        public const string E_FIELD = "E";
        public const string F_FIELD = "F";        
        public const string G_FIELD = "G";
        public const string H_FIELD = "H";


        public const int TRY_COUNT = 10;

    }

    public enum ItemState {isFound, isMissing, isCollect, isDifBalance};
}
