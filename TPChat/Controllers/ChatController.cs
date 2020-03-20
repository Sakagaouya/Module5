using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPChat.Models;
using TPChat.Utils;

namespace TPChat.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            return View(FakeDbCat.Instance.Chats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            //ou utiliser requete SQL
            Chat chat = FakeDbCat.Instance.Chats.FirstOrDefault(c => c.Id == id);
            if (chat != null)
            {
                return View(chat);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            //ou utiliser requete SQL
            Chat chat = FakeDbCat.Instance.Chats.FirstOrDefault(c => c.Id == id);
            if (chat != null)
            {
                return View(chat);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Chat chat = FakeDbCat.Instance.Chats.FirstOrDefault(c => c.Id == id);
                FakeDbCat.Instance.Chats.Remove(chat);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
