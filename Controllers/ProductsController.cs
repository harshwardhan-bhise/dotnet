using DotNetLabExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace DotNetLabExam.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> prdlist = new List<Product>();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=LabExamDb;Integrated Security=True";
            conn.Open();

            SqlCommand camnd = new SqlCommand();
            camnd.Connection = conn;
            camnd.CommandType = System.Data.CommandType.StoredProcedure;
            camnd.CommandText = "SelectAllIndex";

            try
            {
                SqlDataReader dr = camnd.ExecuteReader();
                
                while(dr.Read())
                {
                    prdlist.Add(new Product
                    {
                        ProductId = (int)dr["ProductId"],
                        ProductName = dr["ProductName"].ToString(),
                        Rate = (decimal)dr["Rate"],
                        Description = dr["Description"].ToString(),
                        CategoryName = dr["CategoryName"].ToString()
                    });

                   
                }
                dr.Close();


            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = e;
            }
            finally
            {
                conn.Close();
            }

            return View(prdlist);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=LabExamDb;Integrated Security=True";
            conn.Open();

            SqlCommand camnd = new SqlCommand();
            camnd.Connection = conn;
            camnd.CommandType = System.Data.CommandType.StoredProcedure;
            camnd.CommandText = "SelectOneFromProductId";
            camnd.Parameters.AddWithValue("@ProductId", id);
            Product prd = null;
            try
            {
                SqlDataReader dr = camnd.ExecuteReader();
                
                dr.Read();

                prd = new Product
                {
                    ProductId = (int)dr["ProductId"],
                    ProductName = dr["ProductName"].ToString(),
                    Rate = (decimal)dr["Rate"],
                    Description = dr["Description"].ToString(),
                    CategoryName = dr["CategoryName"].ToString()
                };
              
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = e;
            }

            finally
            {
                conn.Close();
            }

            return View(prd);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product PrdObj)
        {


            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=LabExamDb;Integrated Security=True";
            conn.Open();

            SqlCommand camnd = new SqlCommand();
            camnd.Connection = conn;
            camnd.CommandType = System.Data.CommandType.StoredProcedure;
            camnd.CommandText = "UpdateOneProduct";
            camnd.Parameters.AddWithValue("ProductId", id);
            camnd.Parameters.AddWithValue("ProductName", PrdObj.ProductName);
            camnd.Parameters.AddWithValue("Rate", PrdObj.Rate);
            camnd.Parameters.AddWithValue("Description", PrdObj.Description);
            camnd.Parameters.AddWithValue("CategoryName", PrdObj.CategoryName);

            try
            {
                camnd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch(Exception e )
            {
                ViewBag.ErrorMessage = e;
                return View();
            }
            finally
            {
                conn.Close();
            }

            
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [ChildActionOnly]
        public ActionResult MyPartialView()
        {
            return View();
        }
    }
}
