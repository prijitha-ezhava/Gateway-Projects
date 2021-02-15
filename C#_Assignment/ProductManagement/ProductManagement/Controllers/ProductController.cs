using log4net;
using ProductManagement.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        //log4net
        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(ProductController));

        // GET: Product
        IEnumerable<tbl_Products> productList;
        db_ProductsEntities dbObj = new db_ProductsEntities();
        public ActionResult Product(tbl_Products tblObj)
        {
            //lognet messages
            log.Debug("Debug message");
            log.Warn("Warn message");
            log.Error("Error message");
            log.Fatal("Fatal message");

            if (tblObj != null)
            {
                return View(tblObj);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddProduct(tbl_Products model)
        {
   
            if(ModelState.IsValid)
            { 
                tbl_Products obj = new tbl_Products();
                obj.Prod_ID = model.Prod_ID;
                obj.Prod_Name = model.Prod_Name;
                obj.Prod_Category = model.Prod_Category;
                obj.Prod_Price = model.Prod_Price;
                obj.Prod_Quantity = model.Prod_Quantity;
                obj.Prod_Short_Des = model.Prod_Short_Des;
                obj.Prod_Long_Des = model.Prod_Long_Des;

                String fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                String fileExtension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtension;
                model.Prod_Small_Image = "~/Images/" + fileName;
                model.Prod_Large_Image = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                model.ImageFile.SaveAs(fileName);

                obj.Prod_Small_Image = model.Prod_Small_Image;
                obj.Prod_Large_Image = model.Prod_Large_Image;
           
                if(model.Prod_ID == 0)
                {
                    /*dbObj.tbl_Products.Add(obj);
                    dbObj.SaveChanges();*/
                    HttpResponseMessage response = GlobalVariables.webApiCLient.PostAsJsonAsync("tbl_Products", obj).Result;
                    TempData["successMsg"] = "Record Saved Successfully";
                    return Redirect("/Product/ProductList");
                }

                else
                {
                    //dbObj.Entry(obj).State = EntityState.Modified;
                    HttpResponseMessage response = GlobalVariables.webApiCLient.PutAsJsonAsync("tbl_Products/" + model.Prod_ID, obj).Result;
                    TempData["successMsg"] = "Record Updated Successfully";
                    dbObj.SaveChanges();
                }
                
            }
            
            HttpResponseMessage responses = GlobalVariables.webApiCLient.GetAsync("tbl_Products").Result;
            productList = responses.Content.ReadAsAsync<IEnumerable<tbl_Products>>().Result;
            return View("ProductList", productList);
        }

        public ActionResult ProductList()
        {
            //var res = dbObj.tbl_Products.ToList();
            HttpResponseMessage response = GlobalVariables.webApiCLient.GetAsync("tbl_Products").Result;
            productList = response.Content.ReadAsAsync<IEnumerable<tbl_Products>>().Result;
            return View(productList);
        }

        public ActionResult DeleteProduct(int id)
        {
            /*var res = dbObj.tbl_Products.Where(x => x.Prod_ID == Prod_ID).First();
            dbObj.tbl_Products.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.tbl_Products.ToList();*/

            HttpResponseMessage delresponse = GlobalVariables.webApiCLient.DeleteAsync("tbl_Products/" + id.ToString()).Result;

            HttpResponseMessage response = GlobalVariables.webApiCLient.GetAsync("tbl_Products").Result;
            productList = response.Content.ReadAsAsync<IEnumerable<tbl_Products>>().Result;
            TempData["successMsg"] = "Deleted Successfully";
            return View("ProductList", productList);
        }
    }
}