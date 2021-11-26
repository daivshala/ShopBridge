using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {


            IEnumerable<mvcItemModel> itemList;
            HttpResponseMessage response = GlobalVariables.ShopBridgeClient.GetAsync("Item").Result;
            itemList = response.Content.ReadAsAsync<IEnumerable<mvcItemModel>>().Result;
            return View(itemList);


          
        }



        public ActionResult AddOrEdit(int id = 0)
        {
           if (id == 0)
                return View(new mvcItemModel());
            else
           {

               HttpResponseMessage response = GlobalVariables.ShopBridgeClient.GetAsync("Item/" + id.ToString()).Result;
              return View(response.Content.ReadAsAsync<mvcItemModel>().Result);
           }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcItemModel item)
        {
           if (item.ItemID == 0)
           {
                HttpResponseMessage response = GlobalVariables.ShopBridgeClient.PostAsJsonAsync("Item", item).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
          }
           else
           {
               HttpResponseMessage response = GlobalVariables.ShopBridgeClient.PutAsJsonAsync("Item/" + item.ItemID, item).Result;
               TempData["SuccessMessage"] = "Updated Successfully";
           }
           return RedirectToAction("Index");
           
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.ShopBridgeClient.DeleteAsync("Item/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}