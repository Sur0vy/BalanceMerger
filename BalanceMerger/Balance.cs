using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

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

        public int ItemsCount()
        {
            return items.Count;
        }

        public BalanceItem GetItem(int index)
        {
            return items[index];
        }

        private bool LoadFromXLS()
        {
            Excel.Application application = new Excel.Application
            {
                Visible = false
            };
            try
            {
                Excel.Worksheet objWorksheet;
                objWorksheet = GetActiveSheet(application, fileName);

                int row = FindRow(objWorksheet);
                if (row == -1)
                    return false;
                int iBill = FindField(Helper.BILL, row, objWorksheet);
                if (iBill == -1)
                    return false;
                int iName = FindField(Helper.NAME, row, objWorksheet);
                if (iName == -1)
                    return false;
                int iCount = FindField(Helper.COUNT + " " + Helper.PER_END, row, objWorksheet);
                if (iCount == -1)
                    return false;
                int iDesc = FindField(Helper.DESC, row, objWorksheet);
                if (iDesc == -1)
                    return false;
                int iRest = FindField(Helper.REST + " " + Helper.PER_END, row, objWorksheet);
                if (iRest == -1)
                    return false;

                int i = 0;

                while (i < Helper.TRY_COUNT)
                {
                    row++;
                    BalanceItem BI = new BalanceItem
                    {
                        Bill = objWorksheet.Cells[row, iBill].Text.ToString()
                    };
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
                //application.Workbooks.Close();
                application.Quit();
            }
        }

        public bool LoadFromFile(string fileName)
        {
            this.fileName = fileName;
            bool res = LoadFromXLS();
            return res;
        }


        private int FindRow(Excel.Worksheet workSheet)
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

        public bool Merge(Journal journal)
        {
            return true;
        }

        public bool Save(string fileName)
        {
            Excel.Application application = new Excel.Application
            {
                Visible = false
            };
            try
            {
                application.SheetsInNewWorkbook = 1;
                application.Workbooks.Add(Missing.Value);
                Excel.Sheets worksheets = application.Workbooks[application.Workbooks.Count].Worksheets;
                Excel.Worksheet sheet = worksheets[1];
                sheet.Name = Resources.Strings.stSheetName;


                sheet.Name = Resources.Strings.stSheetName;

                SaveData(ref sheet);
                sheet.SaveAs(fileName);

            }
            finally
            {
                application.Workbooks.Close();
                application.Quit();
            }

            return true;
        }

        private Excel.Worksheet GetActiveSheet(Excel.Application objExcel, string fileName)
        {
            objExcel.Workbooks.Open(fileName);
            return (Excel.Worksheet)objExcel.ActiveWorkbook.Worksheets[1];
        }

        private void SaveData(ref Excel.Worksheet sheet)
        {
            int skipCount = 0;
            int row;

            MakeHeader(ref sheet);
            for (int i = 1; i <= ItemsCount(); i++)
            {                
                BalanceItem balanceItem = GetItem(i - 1);
                if ((balanceItem.Count == 0) || (balanceItem.Rest == 0))
                {
                    skipCount++;
                    continue;
                }
                row = i + 1 - skipCount;
                sheet.Cells[row, Helper.A_FIELD].NumberFormat = "@";
                sheet.Cells[row, Helper.A_FIELD] = balanceItem.Bill;
                sheet.Cells[row, Helper.B_FIELD] = balanceItem.Name;
                sheet.Cells[row, Helper.C_FIELD] = balanceItem.Rest;
                sheet.Cells[row, Helper.D_FIELD] = balanceItem.Count;
                sheet.Cells[row, Helper.E_FIELD] = balanceItem.Description;
                sheet.Cells[row, Helper.F_FIELD] = balanceItem.Document;
                sheet.Cells[row, Helper.G_FIELD] = BalanceItem.GetStatus(balanceItem);
                sheet.Cells[row, Helper.G_FIELD].Interior.Color = BalanceItem.GetStatusColor(balanceItem);
                sheet.Cells[row, Helper.H_FIELD] = balanceItem.Comment;
            }
            sheet.Columns[Helper.A_FIELD + ":" + Helper.H_FIELD].AutoFit();            
        }

        private void MakeHeader(ref Excel.Worksheet sheet)
        {
            sheet.Cells[1, Helper.A_FIELD] = Helper.BILL;
            sheet.Cells[1, Helper.B_FIELD] = Helper.NAME;
            sheet.Cells[1, Helper.C_FIELD] = Helper.REST + " " + Helper.PER_END; 
            sheet.Cells[1, Helper.D_FIELD] = Helper.COUNT + " " + Helper.PER_END;
            sheet.Cells[1, Helper.E_FIELD] = Helper.DESC;
            sheet.Cells[1, Helper.F_FIELD] = Resources.Strings.stDoc;
            sheet.Cells[1, Helper.G_FIELD] = Resources.Strings.stStatus;
            sheet.Cells[1, Helper.H_FIELD] = Resources.Strings.stTip;            
            sheet.Rows["1"].EntireRow.Font.Bold = true;
        }



    }
}
