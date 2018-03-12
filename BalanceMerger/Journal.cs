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

        public int ItemsCount()
        {
            return items.Count;
        }

        public ItemState HasItem(string name, double rest, ref List<int> indexes)
        {
            int index;
            for (int i = 0; i < items.Count - 1; i++)
            {
                index = items[i].Description.IndexOf(name);
                if (index > -1)
                {
                    indexes.Add(i);
                    //itemState = ItemState.isFound;
                    //return i;
                }
            }
            if (indexes.Count == 0)
            {                
                return ItemState.isMissing;
            }
            else if (indexes.Count == 1)
            {
                return ItemState.isFound;                
            }
            else
            {
                return ItemState.isCollect;
            }            
        }

        public JournalItem GetItem(int index)
        {
            return items[index];
        }

        private bool LoadFromXLS()
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

                int row = FindRow(Helper.CONTENT, objWorksheet);
                if (row == -1)
                    return false;
                int iCont = FindField(Helper.CONTENT, row, objWorksheet);
                if (iCont == -1)
                    return false;
                int iDoc = FindField(Helper.DOC, row, objWorksheet);
                if (iDoc == -1)
                    return false;
                int iAmount = FindField(Helper.AMOUNT, row, objWorksheet);
                if (iAmount == -1)
                    return false;

                int i = 0;

                while (i < Helper.TRY_COUNT)
                {
                    row = row + 2;
                    JournalItem JI = new JournalItem
                    {
                        Description = objWorksheet.Cells[row, iCont].Text.ToString()
                    };
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

        public bool LoadFromFile(string fileName)
        {
            this.fileName = fileName;
            bool res = LoadFromXLS();
            return res;
        }

        private int FindRow(string field, Excel.Worksheet workSheet)
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

        private int FindField(string field, int row, Excel.Worksheet workSheet)
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
