using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using ToDoList.Models;


namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    private readonly ToDoListContext _db;

    public ItemsController(ToDoListContext db)
    {
      _db = db;
    }

    // /items - GET
    public ActionResult Index()
    {
      List<Item> model = _db.Items
                      .Include(item => item.Category)
                      .ToList();

      return View(model);
    }

    // /items/create - GET
    public ActionResult Create()
    {
      return View();
    }

    // /items/create - POST
    [HttpPost]
    public ActionResult Create(Item item)
    {
      _db.Items.Add(item);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // /items/details/{id} - GET
    public ActionResult Details(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      return View(thisItem);
    }

    // /items/edit/{id} - GET
    public ActionResult Edit(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      return View(thisItem);
    }

    // /items/edit/{id} - POST
    [HttpPost]
    public ActionResult Edit(Item item)
    {
      _db.Items.Update(item);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // /items/delete/{id} - GET
    public ActionResult Delete(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      return View(thisItem);
    }

    // /items/delete/{id} - POST
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      _db.Items.Remove(thisItem);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}