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
    public class CRAController : Controller
    {
        private AuthenticationDB db = new AuthenticationDB();

        // GET: CRA
        public ActionResult Index()
        {
            var list = db.CRAs;
            return View(list);
            //return View(db.CRAs.ToList());
        }


        public ActionResult Admin()
        {
            var list = db.CRAs;
            return View(list);
            //return View(db.CRAs.ToList());
        }


        public ActionResult Param()
        {
            var list = db.CRAs;
            return View(list);
            //return View(db.CRAs.ToList());
        }

        // GET: CRA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRA cRA = db.CRAs.Find(id);
            if (cRA == null)
            {
                return HttpNotFound();
            }
            return View(cRA);
        }

        // GET: CRA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRA/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CRAId,LIBELLE,NUMCRA,MOIS,NBTOTALJOURS,FK_IDCONSULTANT,FK_IDCLIENT,LIB_CLIENT,FK_IDRESPONSABLE,LIB_RESPONSABLE,FK_IDSTATUT,SIGNECONSULTANT,DTSIGNECONSULTANT,SIGNECLIENTFINAL,DTSIGNECLIENTFINAL,SIGNEAGENT,DTSIGNEAGENT")] CRA cRA)
        {
            if (ModelState.IsValid)
            {
                db.CRAs.Add(cRA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cRA);
        }

        // GET: CRA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRA cRA = db.CRAs.Find(id);
            if (cRA == null)
            {
                return HttpNotFound();
            }
            return View(cRA);
        }

        // POST: CRA/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CRAId,LIBELLE,NUMCRA,MOIS,NBTOTALJOURS,FK_IDCONSULTANT,FK_IDCLIENT,LIB_CLIENT,FK_IDRESPONSABLE,LIB_RESPONSABLE,FK_IDSTATUT,SIGNECONSULTANT,DTSIGNECONSULTANT,SIGNECLIENTFINAL,DTSIGNECLIENTFINAL,SIGNEAGENT,DTSIGNEAGENT")] CRA cRA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cRA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cRA);
        }

        // GET: CRA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRA cRA = db.CRAs.Find(id);
            if (cRA == null)
            {
                return HttpNotFound();
            }
            return View(cRA);
        }

        // POST: CRA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CRA cRA = db.CRAs.Find(id);
            db.CRAs.Remove(cRA);
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
