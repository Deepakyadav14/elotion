using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elotion.Models;


namespace elotion.Controllers
{
    public class HomeController : Controller
    {

        DBlayer db = new DBlayer();
        public ActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Index(model cl)
        //{
        //    SqlParameter[] para = new SqlParameter[]
        //      {
        //        new SqlParameter("@id",cl.id),
        //        new SqlParameter("@product",cl.product),
        //        new SqlParameter("@category",cl.category),
        //        new SqlParameter("@price",cl.price),
        //        new SqlParameter("@quantity",cl.quantity),
        //        new SqlParameter("@total",cl.total),
        //        new SqlParameter("@action","update")

        //     };


        //     db.Execute("sp_stock", para);
        //    return View();
        //}
        [HttpPost]
        public ActionResult Insert(model cl)
        {
            SqlParameter[] para=new SqlParameter[]
              {
                new SqlParameter("@product",cl.product),
                new SqlParameter("@category",cl.category),
                new SqlParameter("@price",cl.price),
                new SqlParameter("@quantity",cl.quantity),
                new SqlParameter("@total",cl.total),
                new SqlParameter("@action","insert")
               
             };
          
            
           db.Execute("sp_stock", para);
            return Json("Record Added",JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult update(model cl)
        {
            SqlParameter[] para = new SqlParameter[]
              {
                new SqlParameter("@id",cl.id),
                new SqlParameter("@product",cl.product),
                new SqlParameter("@category",cl.category),
                new SqlParameter("@price",cl.price),
                new SqlParameter("@quantity",cl.quantity),
                new SqlParameter("@total",cl.total),
                new SqlParameter("@action","update")
             };
            db.Execute("sp_stock", para);
            return Json("update", JsonRequestBehavior.AllowGet);
        }


        public ActionResult Getdata()
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@action","select")
            };
            DataTable dt = db.Fetch("sp_stock",para);
            ViewBag.Data = dt;
            List<model> cls = new List<model>();
            foreach (DataRow d in ViewBag.Data.Rows)
            {
                cls.Add(new model
                {
                    id = Convert.ToInt32(d["id"]),
                    product = d["product"].ToString(),
                    category = d["category"].ToString(),
                    price = Convert.ToInt32(d["price"]),
                    quantity = Convert.ToInt32(d["quantity"]),
                    total = Convert.ToInt32(d["total"])
                });

            }

            return Json(cls, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int? a)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@action","delete"),
                new SqlParameter("@id",a)
            };
            db.Execute("sp_stock", para);
            return Json("Deleted successfully", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Getone(model m)
        {
            SqlParameter[] para = new SqlParameter[]
           {
                new SqlParameter("@action","selectone"),
                new SqlParameter("@id",m.id)
           };
            DataTable dt = db.Fetch("sp_stock", para);
            ViewBag.Data = dt;
            List<model> cls = new List<model>();
            foreach (DataRow d in ViewBag.Data.Rows)
            {
                cls.Add(new model
                {
                    id = Convert.ToInt32(d["id"]),
                    product = d["product"].ToString(),
                    category = d["category"].ToString(),
                    price = Convert.ToInt32(d["price"]),
                    quantity = Convert.ToInt32(d["quantity"]),
                    total = Convert.ToInt32(d["total"])
                });

            }

            return Json(cls, JsonRequestBehavior.AllowGet);


        }
    }
}
