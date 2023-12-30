using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace MVC.Controllers
{
    public class StoreController : Controller
    {
        public StoreManager StoreManager;
        public UniteOfWork UniteOfWork;
        public StoreController(StoreManager storeManager, UniteOfWork uniteOfWork)
        {
            StoreManager = storeManager;
            UniteOfWork = uniteOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAll() 
        {
            ViewData["stores"] = StoreManager.Get();
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Store store)
        {
            StoreManager.Add(store);
            UniteOfWork.Save();
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var store = StoreManager.GetById(id);
            if (store != null)
            {
                ViewData["store"] = store;
                return View();
            }
            return new JsonResult("No Store result");
        }
        [HttpPost]
        public IActionResult Edit(Store store)
        {
            var result = StoreManager.Update(store);
            if (result)
            {
                UniteOfWork.Save();
                return RedirectToAction("GetAll");
            }
            return new JsonResult("No Store result");
        }
        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var item = StoreManager.GetById(id);
            if (item != null)
            {
                StoreManager.Delete(item);
                UniteOfWork.Save();
                return RedirectToAction("GetAll");
            }
            return new JsonResult("No Store result");
        }
    }
}
