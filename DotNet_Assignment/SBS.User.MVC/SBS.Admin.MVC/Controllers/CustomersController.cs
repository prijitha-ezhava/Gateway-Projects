using OfficeOpenXml;
using SBS.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeOpenXml.Table;
using System.Data;
using System.IO;

namespace SBS.Admin.MVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerManager _customerManager;
        public CustomersController()
        {

        }

        public CustomersController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        // GET: Customers/Index
        public ActionResult Index()
        {
            var customers = _customerManager.getCustomers();
            return View(customers);
        }

        //To export the CustomerData to Excel
        public ActionResult ExportToExcel()
        {
            var customerData = _customerManager.getCustomers();

            //Adding the Customer data into DataTable row-wise
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Address", typeof(string));
                dt.Columns.Add("City", typeof(string));
                dt.Columns.Add("State", typeof(string));
                dt.Columns.Add("Zip Code", typeof(string));
                dt.Columns.Add("Email ID", typeof(string));
                dt.Columns.Add("Mobile Number", typeof(string));

                foreach(var data in customerData)
                {
                    DataRow row = dt.NewRow();
                    row[0] = data.CustomerName;
                    row[1] = data.Address;
                    row[2] = data.City;
                    row[3] = data.State;
                    row[4] = data.ZipCode;
                    row[5] = data.EmailID;
                    row[6] = data.Mobile;
                    dt.Rows.Add(row);
                }

                // LicenseContext of the ExcelPackage class:
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                //Load the data into Worksheet and added some styling
                var memoryStream = new MemoryStream();
                using(var excelPackage = new ExcelPackage(memoryStream))
                {
                    var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells["A1"].LoadFromDataTable(dt, true, TableStyles.None);
                    worksheet.Cells["A1:AZ1"].Style.Font.Bold = true;
                    worksheet.DefaultRowHeight = 18;


                    worksheet.Column(2).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    worksheet.Column(6).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.Column(7).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.DefaultColWidth = 20;
                    worksheet.Column(2).AutoFit();

                    Session["DownloadExcel_FileManager"] = excelPackage.GetAsByteArray();
                    return Json("", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Download the Excel Sheet
        public ActionResult Download()
        {
            if (Session["DownloadExcel_FileManager"] != null)
            {
                byte[] data = Session["DownloadExcel_FileManager"] as byte[];
                return File(data, "application/octet-stream", "CustomerReport.xlsx");
            }
            else
            {
                return new EmptyResult();
            }
        }


    }
}