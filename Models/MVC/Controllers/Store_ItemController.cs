using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;
using ViewModel;

namespace MVC.Controllers
{
    public class Store_ItemController : Controller
    {
        public Store_ItemManager Manager;
        public StoreManager StoreManager;
        public ItemManager ItemManager;
        public UniteOfWork uniteOfWork;
        public Store_ItemController(Store_ItemManager manager,
            UniteOfWork unite, 
            StoreManager storeManager ,
            ItemManager itemManager)
        {
            Manager = manager;
            uniteOfWork = unite;
            StoreManager = storeManager;
            ItemManager = itemManager;
        }

        public IActionResult GetAll()
        {
            var result = Manager.Get();
            if(result != null)
            {
                ViewData["Orders"] = result;
                return View();
            }
            return new JsonResult("no Orders");
        }

        [HttpGet]
        public IActionResult Add()   //when purchase
        {
            ViewData["Stores"] = GetStores();
            ViewData["Items"] = GetItems();
            return View();
        }
      
        [HttpPost]
        public IActionResult Add(addOrderViewModel viewModel)  // for Action  
        {
            Manager.AddStock(viewModel);
            uniteOfWork.Save();
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public IActionResult Sell()
        {
            ViewData["Stores"] = GetStores();
            ViewData["Items"] = GetItems();
            return View();
        }
        [HttpPost]
        public IActionResult Sell(addOrderViewModel viewModel)  // For Action
        {
            Manager.Sell(viewModel);
            uniteOfWork.Save();
            return RedirectToAction("GetAll");
        }
     
        [HttpGet]
        public JsonResult GetStock(int store_id , int item_id)   // JQuery call 
        {
           var stock =  Manager.GetStock(store_id, item_id);

            //return  Json(stock , System.Web.Mvc.JsonRequestBehavior.AllowGet);
            return new JsonResult(stock);
        }
        private List<SelectListItem> GetStores()   // for drop down list 
        {
            return StoreManager.Get().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            }).ToList();
        }
        private List<SelectListItem> GetItems()     // for drop down list 
        {
            return ItemManager.Get().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            }).ToList();
        }
    }
}
