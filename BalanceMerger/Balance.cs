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
                int iCount = FindField(Helper.COUNT, row, objWorksheet);
                if (iCount == -1)
                    return false;
                int iDesc = FindField(Helper.DESC, row, objWorksheet);
                if (iDesc == -1)
                    return false;
                int iRest = FindField(Helper.REST, row, objWorksheet);
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
                sheet.Name = Resources.Strings.sSheetName;


                sheet.Name = Resources.Strings.sSheetName;
                //if (FormatSheet(ref sheet))
                //{
                //    SaveData(ref sheet);
                //    sheet.SaveAs(fileName);
                //}   

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

        //private Boolean FormatSheet(ref Excel.Worksheet sheet)
        //{
        //    int row = FindRow(sheet);
        //    if (row == -1)
        //        return false;
        //    int i = FindField(Helper.CURRENCY_CODE, row, sheet);
        //    if (i != -1)
        //        sheet.Columns[i].Delete();
        //    i = FindField(Helper.UNITS, row, sheet);
        //    if (i != -1)
        //        sheet.Columns[i].Delete();
        //    sheet.Cells[row, Helper.F_FIELD] = Resources.Strings.sDoc;
        //    sheet.Cells[row, Helper.G_FIELD] = Resources.Strings.sStatus;
        //    sheet.Cells[row, Helper.H_FIELD] = Resources.Strings.sTip;
        //    return true;
        //}

        private void SaveData(ref Excel.Worksheet sheet)
        {
            MakeHeader(ref sheet);
            for (int i = 2; i < ItemsCount(); i++)
            {
                string status = "";
                BalanceItem balanceItem = GetItem(i - 2);
                sheet.Cells[i, Helper.A_FIELD].NumberFormat = "@";
                sheet.Cells[i, Helper.A_FIELD] = balanceItem.Bill;
                sheet.Cells[i, Helper.B_FIELD] = balanceItem.Name;
                sheet.Cells[i, Helper.C_FIELD] = balanceItem.Rest;
                sheet.Cells[i, Helper.D_FIELD] = balanceItem.Count;
                sheet.Cells[i, Helper.E_FIELD] = balanceItem.Description;
                sheet.Cells[i, Helper.F_FIELD] = balanceItem.Document;
                sheet.Cells[i, Helper.G_FIELD] = balanceItem.Comment;
                sheet.Cells[i, Helper.H_FIELD] = status;
            }
            sheet.Columns["A:H"].AutoFit();
            //string r = "H" + ItemsCount();
            //Excel.Range range1 = sheet.Range[r];
            //sheet.Range["A1", range1].AutoFit();
        }

        private void MakeHeader(ref Excel.Worksheet sheet)
        {
            sheet.Cells[1, Helper.A_FIELD] = Helper.BILL;
            sheet.Cells[1, Helper.B_FIELD] = Helper.NAME;
            sheet.Cells[1, Helper.C_FIELD] = Helper.REST;
            sheet.Cells[1, Helper.D_FIELD] = Helper.COUNT;
            sheet.Cells[1, Helper.E_FIELD] = Helper.DESC;
            sheet.Cells[1, Helper.F_FIELD] = Resources.Strings.sDoc;
            sheet.Cells[1, Helper.G_FIELD] = Resources.Strings.sStatus;
            sheet.Cells[1, Helper.H_FIELD] = Resources.Strings.sTip;
            //sheet.Cells[Helper.A_FIELD + "1", Helper.H_FIELD + "1"].EntireRow.Font.Bold = true;
            sheet.Rows["1"].EntireRow.Font.Bold = true;
        }

    }
}
