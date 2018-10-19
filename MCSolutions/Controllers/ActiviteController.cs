using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MCSolutions.DataAccess;

namespace MCSolutions.Controllers
{
    public class ActiviteController : Controller
    {
        private AuthenticationDB db = new AuthenticationDB();

        // GET: Activite
        public ActionResult Index()
        {
            return View(db.CRAs_Activite.ToList());
        }

        // GET: Activite/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRA_Activite cRA_Activite = db.CRAs_Activite.Find(id);
            if (cRA_Activite == null)
            {
                return HttpNotFound();
            }
            return View(cRA_Activite);
        }

        // GET: Activite/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activite/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActiviteId,LIBELLE,JOURTRAVAILLE,NBHEURES,TAUX,CREATEDBY,DTCREATION,MODIFIEDBY,DTMODIF,FK_IDCRA,FK_IDTYPEACTIVITE")] CRA_Activite cRA_Activite)
        {
            if (ModelState.IsValid)
            {
                db.CRAs_Activite.Add(cRA_Activite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cRA_Activite);
        }

        // GET: Activite/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRA_Activite cRA_Activite = db.CRAs_Activite.Find(id);
            if (cRA_Activite == null)
            {
                return HttpNotFound();
            }
            return View(cRA_Activite);
        }

        // POST: Activite/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActiviteId,LIBELLE,JOURTRAVAILLE,NBHEURES,TAUX,CREATEDBY,DTCREATION,MODIFIEDBY,DTMODIF,FK_IDCRA,FK_IDTYPEACTIVITE")] CRA_Activite cRA_Activite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cRA_Activite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cRA_Activite);
        }

        // GET: Activite/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRA_Activite cRA_Activite = db.CRAs_Activite.Find(id);
            if (cRA_Activite == null)
            {
                return HttpNotFound();
            }
            return View(cRA_Activite);
        }

        // POST: Activite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CRA_Activite cRA_Activite = db.CRAs_Activite.Find(id);
            db.CRAs_Activite.Remove(cRA_Activite);
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
