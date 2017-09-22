using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FTPServer.Entities;
using FTPServer.FTPContext;

namespace FTPServer.Controllers
{
    public class FTPLoginsController : Controller
    {
        private FTPDbContext db = new FTPDbContext();

        // GET: FTPLogins
        public ActionResult Index()
        {
            return View(db.ftpLogins.ToList());
        }

        // GET: FTPLogins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FTPLogin fTPLogin = db.ftpLogins.Find(id);
            if (fTPLogin == null)
            {
                return HttpNotFound();
            }
            return View(fTPLogin);
        }

        // GET: FTPLogins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FTPLogins/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FtpServerIP,FtpRemotePath,FtpUserID,FtpPassword")] FTPLogin fTPLogin)
        {
            if (ModelState.IsValid)
            {
                db.ftpLogins.Add(fTPLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fTPLogin);
        }

        // GET: FTPLogins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FTPLogin fTPLogin = db.ftpLogins.Find(id);
            if (fTPLogin == null)
            {
                return HttpNotFound();
            }
            return View(fTPLogin);
        }

        // POST: FTPLogins/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FtpServerIP,FtpRemotePath,FtpUserID,FtpPassword")] FTPLogin fTPLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fTPLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fTPLogin);
        }

        // GET: FTPLogins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FTPLogin fTPLogin = db.ftpLogins.Find(id);
            if (fTPLogin == null)
            {
                return HttpNotFound();
            }
            return View(fTPLogin);
        }

        // POST: FTPLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FTPLogin fTPLogin = db.ftpLogins.Find(id);
            db.ftpLogins.Remove(fTPLogin);
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
