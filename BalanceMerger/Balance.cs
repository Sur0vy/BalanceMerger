using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace BalanceMerger
{
    public class Balance
    {
        public string fileName;
        private List<BalanceItem> items;

        public Balance()
        {
            this.fileName = "";
            items = new List<BalanceItem>();
        }

        public int itemsCount()
        {
            return items.Count;
        }

        private bool loadFromXLS()
        {
            Excel.Application objExcel = new Excel.Application();
            try
            {
                Excel.Workbook objWorkbook;
                Excel.Worksheet objWorksheet;

                objExcel.Visible = false;
                objExcel.Workbooks.Open(fileName);

                objWorkbook = objExcel.ActiveWorkbook;
                objWorksheet = (Excel.Worksheet)objWorkbook.ActiveSheet;

                int row = findRow(objWorksheet);
                if (row == -1)
                    return false;
                int iBill = findField(Helper.BILL, row, objWorksheet);
                if (iBill == -1)
                    return false;
                int iName = findField(Helper.NAME, row, objWorksheet);
                if (iName == -1)
                    return false;
                int iCount = findField(Helper.COUNT, row, objWorksheet);
                if (iCount == -1)
                    return false;
                int iDesc = findField(Helper.DESC, row, objWorksheet);
                if (iDesc == -1)
                    return false;
                int iRest = findField(Helper.REST, row, objWorksheet);
                if (iRest == -1)
                    return false;

                int i = 0;

                while (i < Helper.TRY_COUNT)
                {
                    row++;
                    BalanceItem BI = new BalanceItem();
                    BI.Bill = objWorksheet.Cells[row, iBill].Text.ToString();
                    if (BI.Bill.Equals(""))
                    {
                        i++;
                    }
                    else
                    {
                        BI.Description = objWorksheet.Cells[row, iDesc].Text.ToString();
                        if (BI.Description.Equals(""))
                        {
                            i++;
                            continue;
                        }
                        BI.Name = objWorksheet.Cells[row, iName].Text.ToString();
                        if (BI.Name.Equals(""))
                        {
                            i++;
                            continue;
                        }
                        try
                        {
                            BI.Count = int.Parse(objWorksheet.Cells[row, iCount].Text.ToString());
                        }
                        catch (FormatException)
                        {
                            i++;
                            continue;
                        }
                        try
                        {
                            BI.Rest = double.Parse(objWorksheet.Cells[row, iRest].Text.ToString());
                        }
                        catch (FormatException)
                        {
                            i++;
                            continue;
                        }
                        items.Add(BI);
                        i = 1;
                        }                    
                }
                if (items.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                objExcel.Quit();
            }
        }

        public bool loadFromFile(string fileName)
        {
            this.fileName = fileName;
            bool res = loadFromXLS();
            return res;
        }


        private int findRow(Excel.Worksheet workSheet)
        {            
            int i = 1;
            string value = "";

            while (i < Helper.TRY_COUNT)
            {
                value = workSheet.Cells[i, 1].Text.ToString();
                if (value.Equals(""))
                {
                    i++;
                }
                else
                {
                    return i;                    
                }
            }
            return -1;
        }

        private int findField(string field, int row, Excel.Worksheet workSheet)
        {
            int i = 1;
            int col = 1;
            string value = "";

            while (i < Helper.TRY_COUNT)
            {
                value = workSheet.Cells[row, col].Text.ToString();
                value = value.Replace("\n", " ");

                if (value.Equals(""))
                {
                    i++;
                }
                else if (value.Equals(field))
                {
                    return col;
                }
                else
                {
                    i = 1;
                }
                col ++;
            }
            return -1;
        }

        public bool merge(Journal journal)
        {
            return true;
        }

        public bool save(string fileName)
        {

            return true;
        }
    }
}
