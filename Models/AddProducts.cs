//using Ccog3nt_product_Management_4._0.Controllers;
//using OfficeOpenXml;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Ccog3nt_product_Management_4._0.Models
//{
//    public class AddProducts
//    {
//        public void ReadExcel()
//        {

//            using (FileStream fs = System.IO.File.Open("/path/to/file", FileMode.Open))
//            {
//                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
//                List<Product> orderItems = new List<Product>();
//                using (ExcelPackage package = new ExcelPackage(fs))
//                {
//                    ExcelWorkbook workbook = package.Workbook;
//                    if (workbook != null)
//                    {
//                        ExcelWorksheet worksheet = workbook.Worksheets.FirstOrDefault();
//                        if (worksheet != null)
//                        {
//                            int colCount = worksheet.Dimension.End.Column;
//                            int rowCount = worksheet.Dimension.End.Row;
//                            for (int row = 3; row <= rowCount; row++)
//                            {
//                                orderItems.Add(new Product()
//                                {
//                                    //        ID = int.TryParse(worksheet.Cells[row, 1].Value?.ToString().Trim(), out int cno) ? cno : null,
//                                    //        ProductId = int.TryParse(worksheet.Cells[row, 2].Value?.ToString().Trim(), out int pcode) ? pcode : null,
//                                    //        SKU = int.TryParse(worksheet.Cells[row, 1].Value?.ToString().Trim(), out int supid) ? supid : null
//                                    //    });
//                                    //    _context.Add(product);
//                                    //    await _context.SaveChangesAsync();
//                                    //}
//                                    //await _orderAppService.(orderItems);
//                                });
//                            }
//                        }
//                    }

//                }
//            }
//        }

//    } }
