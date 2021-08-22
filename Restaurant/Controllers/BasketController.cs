using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;
using Restaurant.DataAccess;
using Restaurant.Models.ViewModels;
using System.Data;

namespace Restaurant.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        public ActionResult Index()
        {
            return View();
        }
        #region Insert

        [Authorize(Roles = "User")]
        public ActionResult InsertBasket()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult InsertBasket(BasketViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("InsertBasket");
                }

                if (model != null)
                {
                    Basket basket = new Basket();
                    bool result;
                    result = Restaurant.DataAccess.BasketService.BasketInsert(model.ConvertToModel());
                    if (result)
                        return RedirectToAction("Index", "Home");
                    else
                        return View("InsertBasket");
                }
                return View("InsertBasket");

            }
            catch (Exception)
            {
                throw new Exception("خطا در سیستم !");
            }
        }
        #endregion
        #region Select
        public static Basket SelectBasketByID(int id = 0)
        {
            DataTable dataTable = Restaurant.DataAccess.BasketService.BasketSelect(id: id);
            return Models.Basket.Convert(dataTable)[0];
        }

        //bayad vorodi haye dg ham ezafe konim
        public ActionResult SelectBasket(int ID)
        {
            DataTable dataTable = Restaurant.DataAccess.BasketService.BasketSelect(id: ID);
            List<Basket> list = Models.Basket.Convert(dataTable);
            return View(list);

        }
        #endregion
        #region Edit
        public ActionResult EditBasket(int id)
        {
            Basket basket = SelectBasketByID(id);
            return View(basket);
        }
        [HttpPost]
        public ActionResult EditBasket(BasketViewModel model)
        {
            Basket basket = new Basket();
            basket = model.ConvertToModel();
            if (Restaurant.DataAccess.BasketService.BasketEdit(basket))
                return RedirectToAction("Index", "Home");
            return View("EditBasket");
        }
        #endregion
        #region Delete
        public ActionResult DeleteBasket(int id)
        {
            if (BasketService.BasketDelete(id))
                return RedirectToAction("Index", "Home");
            else
                return View("DeleteBasket");

        }
        #endregion
    }
}