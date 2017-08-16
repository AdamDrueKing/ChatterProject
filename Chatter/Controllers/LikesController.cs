using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Chatter.Models;

namespace Chatter.Controllers
{
    public class LikesController : Controller
    {
        private ChatterEntities db = new ChatterEntities();

        // GET: Likes
        public ActionResult Index()
        {
            var likes = db.Likes.Include(l => l.Like1).Include(l => l.Like2).Include(l => l.AspNetUser).Include(l => l.Chat);
            return View(likes.ToList());
        }

        // GET: Likes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Like like = db.Likes.Find(id);
            if (like == null)
            {
                return HttpNotFound();
            }
            return View(like);
        }

        // GET: Likes/Create
        public ActionResult Create()
        {
            ViewBag.LikeID = new SelectList(db.Likes, "LikeID", "UserID");
            ViewBag.LikeID = new SelectList(db.Likes, "LikeID", "UserID");
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ChatID = new SelectList(db.Chats, "ChatID", "UserID");
            return View();
        }

        // POST: Likes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LikeID,UserID,ChatID")] Like like)
        {
            if (ModelState.IsValid)
            {
                db.Likes.Add(like);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LikeID = new SelectList(db.Likes, "LikeID", "UserID", like.LikeID);
            ViewBag.LikeID = new SelectList(db.Likes, "LikeID", "UserID", like.LikeID);
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", like.UserID);
            ViewBag.ChatID = new SelectList(db.Chats, "ChatID", "UserID", like.ChatID);
            return View(like);
        }

        // GET: Likes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Like like = db.Likes.Find(id);
            if (like == null)
            {
                return HttpNotFound();
            }
            ViewBag.LikeID = new SelectList(db.Likes, "LikeID", "UserID", like.LikeID);
            ViewBag.LikeID = new SelectList(db.Likes, "LikeID", "UserID", like.LikeID);
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", like.UserID);
            ViewBag.ChatID = new SelectList(db.Chats, "ChatID", "UserID", like.ChatID);
            return View(like);
        }

        // POST: Likes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LikeID,UserID,ChatID")] Like like)
        {
            if (ModelState.IsValid)
            {
                db.Entry(like).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LikeID = new SelectList(db.Likes, "LikeID", "UserID", like.LikeID);
            ViewBag.LikeID = new SelectList(db.Likes, "LikeID", "UserID", like.LikeID);
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", like.UserID);
            ViewBag.ChatID = new SelectList(db.Chats, "ChatID", "UserID", like.ChatID);
            return View(like);
        }

        // GET: Likes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Like like = db.Likes.Find(id);
            if (like == null)
            {
                return HttpNotFound();
            }
            return View(like);
        }

        // POST: Likes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Like like = db.Likes.Find(id);
            db.Likes.Remove(like);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
