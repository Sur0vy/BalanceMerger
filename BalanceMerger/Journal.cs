using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace BalanceMerger
{
    public class Journal
    {
        public string fileName;
        private List<JournalItem> items;

        public Journal()
        {
            this.fileName = "";
            items = new List<JournalItem>();
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

                int row = findRow(Helper.CONTENT, objWorksheet);
                if (row == -1)
                    return false;
                int iCont = findField(Helper.CONTENT, row, objWorksheet);
                if (iCont == -1)
                    return false;
                int iDoc = findField(Helper.DOC, row, objWorksheet);
                if (iDoc == -1)
                    return false;
                int iAmount = findField(Helper.AMOUNT, row, objWorksheet);
                if (iAmount == -1)
                    return false;

                int i = 0;

                while (i < Helper.TRY_COUNT)
                {
                    row = row + 2;
                    JournalItem JI = new JournalItem();
                    JI.Description = objWorksheet.Cells[row, iCont].Text.ToString();
                    if (JI.Description.Equals(""))
                    {
                        i++;
                    }
                    else
                    {
                        JI.Document= objWorksheet.Cells[row - 1, iDoc].Text.ToString();
                        if (JI.Document.Equals(""))
                        {
                            i++;
                            continue;
                        }
                        try
                        {
                            JI.Rest = double.Parse(objWorksheet.Cells[row, iAmount].Text.ToString());
                        }
                        catch (FormatException)
                        {
                            i++;
                            continue;
                        }
                        items.Add(JI);
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

        private int findRow(string field, Excel.Worksheet workSheet)
        {
            int iRow = 1;            
            int row = 1;            
            string value = "";

            while (iRow < Helper.TRY_COUNT)
            {
                int col = 1;
                int iCol = 1;

                while (iCol < Helper.TRY_COUNT)
                {
                    value = workSheet.Cells[row, col].Text.ToString();
                    if (value.Equals(""))
                    {
                        iCol++;
                    }
                    else if (value.Equals(field))
                    {
                        return row;
                    }
                    else
                    {
                        iCol = 1;
                    }
                    col++;
                }
                row++;
                value = workSheet.Cells[iRow, 1].Text.ToString();
                if (value.Equals(""))
                {
                    iRow++;
                }
                else
                {
                    iRow = 1;
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
                col++;
            }
            return -1;
        }
    }
}
