using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DotNETMVCProject.Models;
using Newtonsoft.Json;

namespace DotNETMVCProject.Controllers
{
    public class ProductController : Controller
    {
        //Hosted web API REST Service base url  
        string Baseurl = "http://localhost:8080/";
       
        public async Task<ActionResult> Product()
        {
            List<Product> products = new List<Product>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/products");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ProdResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    products = JsonConvert.DeserializeObject<List<Product>>(ProdResponse);

                }
                //returning the employee list to view  
                return View(products);
            }
        }


        public ActionResult Myorder()
        {

            return View((List<Product>)Session["cart"]);

        }
        public ActionResult AddToCart(Product product)
        {
            if (Session["cart"] == null)
            {
                List<Product> li = new List<Product>();

                li.Add(product);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = 1;
            }
            else
            {
                List<Product> li = (List<Product>)Session["cart"];
                li.Add(product);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            }
            return RedirectToAction("Product", "Product");
        }

        public ActionResult RemoveFromCart(Product product)
        {
            List<Product> li = (List<Product>)Session["cart"];
            li.RemoveAll(x => x._id == product._id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Product", "Product");

        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
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

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
    }
}
