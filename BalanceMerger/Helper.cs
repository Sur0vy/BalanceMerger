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


        public const int TRY_COUNT = 10;

    }

    public enum ItemState {isFound, isMissing, isZero, isCollect};
}
