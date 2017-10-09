using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BookKeeper.Models;

namespace BookKeeper.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookContext _db = new BookContext();
        
        [HttpGet]
        public ActionResult Index(int? id)
        {
            ViewBag.Id = id;
            ViewBag.Books = _db.Books;
            var book = _db.Books.Find(id);
            if (book != null)
                return View(book);
            return View();
        }

        [HttpPost]
        public ActionResult Index(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(book).State = EntityState.Modified;
                _db.SaveChanges();
                TempData["m"] = $"Книгу з назвою '{book.Name}' успішно змінено!";
                ViewBag.Books = _db.Books;
                return View();
            }
            TempData["e"] = $"Книгу з назвою '{book.Name}' не змінено!";
            ViewBag.Books = _db.Books;
            return View(book);
        }


        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var book = _db.Books.Find(id);
            if (book != null)
                return View(book);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(book).State = EntityState.Modified;
                _db.SaveChanges();
                TempData["m"] = $"Книгу з назвою '{book.Name}' успішно змінено!";
                return RedirectToAction("Index");
            }
            return View(book);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Add(book);
                _db.SaveChanges();
                TempData["m"] = $"Книгу з назвою '{book.Name}' успішно додано до колекції!";
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var b = _db.Books.Find(id);
            if (b == null) return RedirectToAction("Index");
            return View(b);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var b = _db.Books.Find(id);
            if (b == null) return RedirectToAction("Index");

            TempData["m"] = $"Книгу з назвою '{_db.Books.ToList().Find(m => m.Id == id).Name}' успішно видалено!";
            _db.Books.Remove(b);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}