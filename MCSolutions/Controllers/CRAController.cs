using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MCSolutions.CustomAuthentication;
using MCSolutions.DataAccess;
using MCSolutions.DataAccess.db;

namespace MCSolutions.Controllers
{
    public class CRAController : Controller
    {
        private AuthenticationDB db = new AuthenticationDB();
        private CraDB g_cradb = new CraDB();
        private CRA_ActiviteDetailDB g_craADdb = new CRA_ActiviteDetailDB();
        private CRA_ActiviteDB g_craAdb = new CRA_ActiviteDB();
        private CRA_LibeleColDB g_craALCdb = new CRA_LibeleColDB();
        private CRA_TypeDB g_craTYPEdb = new CRA_TypeDB();

        // GET: Home  
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            var truc = ((CustomPrincipal)User);

            return Json(g_cradb.GetListByUserId(truc.UserId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(CRA p_cra)
        {
            var truc = ((CustomPrincipal)User);
            p_cra.FK_IDCONSULTANT = truc.UserId;
            return Json(g_cradb.Add(p_cra), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCRAByID(int p_craId)
        {
            //var Employee = g_cradb.GetListByUserId(p_userId).Find(x => x.FK_IDCONSULTANT.Equals(p_userId));

            var truc = ((CustomPrincipal)User);
            var Employee = g_cradb.GetListByUserId(truc.UserId, p_craId);
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(CRA p_cra)
        {
            return Json(g_cradb.Update(p_cra), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int ID)
        {
            return Json(g_cradb.Delete(ID), JsonRequestBehavior.AllowGet);
        }




        public JsonResult CRAActiviteList()
        {
            var truc = ((CustomPrincipal)User);

            return Json(g_craAdb.GetCRAActiviteListByUserId(truc.UserId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddCRAActivite(CRA_ActiviteMODEL p_cra)
        {
            var truc = ((CustomPrincipal)User);
            p_cra.UsersId = truc.UserId;
            return Json(g_craAdb.AddCRAActivite(p_cra), JsonRequestBehavior.AllowGet);
        }



        // GET: Home  
        public ActionResult SaisirCRA(int? idCRA = null)
        {
            //charger cra activité
            //charger les colonnes
            ViewData["currentCRA"] = idCRA;

            return View();
        }


        public JsonResult SaisirCRAList(int? idCRA = null)
        {
            DataTable dt = new DataTable();
            dt = g_craADdb.GetActivitesListByCraId(idCRA.HasValue ? idCRA.Value : 0);
            string test = ConvertDataTableToHTML(dt, idCRA.Value);
            return Json(test, JsonRequestBehavior.AllowGet);
            //return Json(g_craADdb.GetActivitesListByCraId(idCRA.HasValue ? idCRA.Value : 0), JsonRequestBehavior.AllowGet);
        }


        public static string ConvertDataTableToHTML(DataTable dt, int idCRA)
        {
            //string html = "<table>";
            string html = string.Empty;
            //add header row
            html += "<tr>";
            //for (int i = 0; i < dt.Columns.Count; i++)
            //    html += "<td>" + dt.Columns[i].ColumnName + "</td>";
            //html += "</tr>";
            //add rows
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    int _cralibelecolid = Int32.Parse( dt.Rows[i][0].ToString());
                    string _datebegin = dt.Rows[i][1].ToString();
                    float _quantity = 0;


                    if (j > 1)  //0)
                    {
                        //html += "<td><input type=\"text\" style=\"text-align:center;\" value=\"" + dt.Rows[i][j].ToString() + "\" readonly/></td>";


                        //html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                        if (j == 2) //1)
                            html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                        else
                        {
                            _quantity = !string.IsNullOrEmpty(dt.Rows[i][j].ToString()) ? float.Parse(dt.Rows[i][j].ToString()) : 0;
                            html += "<td>";
                            html += "<input type=\"text\" style=\"text-align:center;\" value=\"" + dt.Rows[i][j].ToString() + "\" readonly/>";
                            //html += "<input type=\"button\" id=\"btn\" value=\"Change\" onclick=\"test();\" data-toggle=\"modal\" data-target=\"#myModal\" onclick=\"clearTextBox();\"/>";
                            ////html += "<img src = '~/assets/images/modify.png' />";
                            //html += "<img src = \"~/assets/images/modify.png\" data-toggle=\"modal\" data-target=\"#myModal\" onclick=\"clearTextBox();\"/>";
                            //html += "&nbsp;<i class=\"fa fa-file - text - o\" data-toggle=\"modal\" data-target=\"#myModal\" onclick=\"clearTextBox();\">&nbsp;</i>";
                            html += "&nbsp;<i class=\"fa fa-file-text\" data-toggle=\"modal\" data-target=\"#myModal\" onclick=\"clearTextBox('"+ _cralibelecolid + "', '" + _datebegin + "', '" + _quantity + "');\">&nbsp;</i>";

                            //html += "<div class=\"dropdown\">";
                            ////html += "	<button class=\"btn btn-primary\" type=\"button\" id=\"dropdownMenuButton\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">";
                            //html += "		<img src = '~/assets/images/modify.png' />";
                            ////html += "	</button>";
                            //html += "	<div class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuButton\">";
                            //html += "		<a class=\"dropdown-item\" href=\"#\">Transmettre pour signature</a>";
                            //html += "		<a class=\"dropdown-item\" href=\"#\">Supprimer ce CRA</a>";
                            //html += "	</div>";
                            //html += "</div>";

                            html += "</td>";
                        }
                    }
                }
                html += "</tr>";
            }

            for (int i = dt.Rows.Count - 1; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j == 0)
                        html += "<th>Total</th>";
                    else if (j > 2) //1)
                        html += "<td><input type=\"text\" style=\"text-align:center;font-weight: bold;\" class=\"form - control form - control - xs\" id=\"input\" value=\"" + dt.Rows[i][j].ToString() + "\" disabled/></td>";
                }
                html += "</tr>";

                //i = dt.Rows.Count;
            }
            //html += "</table>";
            return html;
        }



        public JsonResult AddActivite(CRA_ActiviteDetailMODEL p_craAD)
        {
            var truc = ((CustomPrincipal)User);
            p_craAD.CreationBY = truc.FirstName + "_" + truc.LastName;
            return Json(g_cradb.AddActivite(p_craAD), JsonRequestBehavior.AllowGet);
        }



        public JsonResult UpdateActivite(CRA_ActiviteDetailMODEL p_craAD)
        {
            var truc = ((CustomPrincipal)User);
            p_craAD.ModificationBY = truc.FirstName + "_" + truc.LastName;
            return Json(g_cradb.UpdateActivite(p_craAD), JsonRequestBehavior.AllowGet);
        }

        public JsonResult LibColList()
        {
            return Json(g_craALCdb.GetLibColList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult LibColListByCRA(int idCRA)
        {
            return Json(g_craALCdb.GetLibColListByCraID(idCRA), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CRAtypeList()
        {
            return Json(g_craTYPEdb.GetCRATypeList(), JsonRequestBehavior.AllowGet);
        }

        //// GET: CRA
        //public ActionResult Index()
        //{
        //    var list = db.CRAs;
        //    return View(list);
        //    //return View(db.CRAs.ToList());
        //}


        //public ActionResult Admin()
        //{
        //    var list = db.CRAs;
        //    return View(list);
        //    //return View(db.CRAs.ToList());
        //}


        //public ActionResult Param()
        //{
        //    var list = db.CRAs;
        //    return View(list);
        //    //return View(db.CRAs.ToList());
        //}

        //// GET: CRA/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CRA cRA = db.CRAs.Find(id);
        //    if (cRA == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cRA);
        //}

        //// GET: CRA/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: CRA/Create
        //// Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        //// plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CRAId,LIBELLE,NUMCRA,MOIS,NBTOTALJOURS,FK_IDCONSULTANT,FK_IDCLIENT,LIB_CLIENT,FK_IDRESPONSABLE,LIB_RESPONSABLE,FK_IDSTATUT,SIGNECONSULTANT,DTSIGNECONSULTANT,SIGNECLIENTFINAL,DTSIGNECLIENTFINAL,SIGNEAGENT,DTSIGNEAGENT")] CRA cRA)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CRAs.Add(cRA);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(cRA);
        //}

        //// GET: CRA/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CRA cRA = db.CRAs.Find(id);
        //    if (cRA == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cRA);
        //}

        //// POST: CRA/Edit/5
        //// Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        //// plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CRAId,LIBELLE,NUMCRA,MOIS,NBTOTALJOURS,FK_IDCONSULTANT,FK_IDCLIENT,LIB_CLIENT,FK_IDRESPONSABLE,LIB_RESPONSABLE,FK_IDSTATUT,SIGNECONSULTANT,DTSIGNECONSULTANT,SIGNECLIENTFINAL,DTSIGNECLIENTFINAL,SIGNEAGENT,DTSIGNEAGENT")] CRA cRA)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(cRA).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(cRA);
        //}

        //// GET: CRA/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CRA cRA = db.CRAs.Find(id);
        //    if (cRA == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cRA);
        //}

        //// POST: CRA/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CRA cRA = db.CRAs.Find(id);
        //    db.CRAs.Remove(cRA);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
