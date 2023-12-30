using Azure.Messaging;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace MVC.Controllers
{
    public class ItemController : Controller
    {
        public ItemManager ItemManager;
        public UniteOfWork UniteOfWork;
        public ItemController(ItemManager itemManager, UniteOfWork uniteOfWork)
        {
            ItemManager = itemManager;
            UniteOfWork = uniteOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var List = ItemManager.Get();
            
            ViewData["items"] = List;
            return View();
        }
        [HttpGet]
        public IActionResult Add()   // for Form
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Item item)   //for Action
        {
            ItemManager.Add(item);
            UniteOfWork.Save();
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = ItemManager.GetById(id);
            if (item != null)
            {
                ViewData["item"] = item;
                return View();
            }
            return new JsonResult("No Item result");
        }
        [HttpPost]
        public IActionResult Edit(Item item)
        {
            var result = ItemManager.Update(item);
            
            if(result)
            {
                UniteOfWork.Save();
                return RedirectToAction("GetAll");
            }
            return new JsonResult("No Item result");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = ItemManager.GetById(id);
            if (item != null)
            {
                ItemManager.Delete(item);
                UniteOfWork.Save();
                return RedirectToAction("GetAll");
            }
            return new JsonResult("No Item result");
        }
    }
}
