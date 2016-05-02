using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CVCreator.Data;
using log4net;


namespace RecruitmentApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        /// <summary>
        /// This page is useful to insert,update and delete data in Category controller.
        /// </summary>.        

         #region Declare Variable
         private CVCreatorEntities db = new CVCreatorEntities();
         public ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
         #endregion

         #region Create Methods

         // GET: /Category/Create
         public ActionResult Create()
         {
             return View();
         }

         // POST: /Category/Create
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create([Bind(Include = "Id,Name,IsActive")] Category category)
         {
             try
             {
                 if (ModelState.IsValid)
                 {
                     logger.Info("In CategoryController Create method starts at " + DateTime.UtcNow);
                     db.Categories.Add(category);
                     db.SaveChanges();
                     logger.Info("Category Inserted " + User.Identity.Name + " at " + DateTime.UtcNow);
                     return RedirectToAction("Index");
                 }
             }
             catch(Exception ex)
             {
                 logger.Error("Category Create Data Error "+ User.Identity.Name +" at : " + DateTime.UtcNow);
                 throw ex;
                 
             }
             return View(category);
         }

         #endregion

         #region Fetch Data
         // GET: /Category/
         public ActionResult Index()
         {
             logger.Info("In CategoryController fetch called at" + DateTime.UtcNow);
             return View(db.Categories.ToList());
         }

         // GET: /Category/Details/5
         public ActionResult Details(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             logger.Info("Category Detail Data Fetched  " + User.Identity.Name + " at " + DateTime.UtcNow);
             Category category = db.Categories.Find(id);
             if (category == null)
             {
                 return HttpNotFound();
             }
             return View(category);
         }
         #endregion

         #region Edit Data

         // GET: /Category/Edit/5
         public ActionResult Edit(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Category category = db.Categories.Find(id);
             if (category == null)
             {
                 return HttpNotFound();
             }
             logger.Info("Category Edit  at " + DateTime.UtcNow);
             return View(category);
         }

         // POST: /Category/Edit
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Edit([Bind(Include = "Id,Name,IsActive")] Category category)
         {
             try
             {
                 if (ModelState.IsValid)
                 {
                     logger.Info("In CategoryController Update method starts at " + DateTime.UtcNow);
                     db.Entry(category).State = EntityState.Modified;
                     db.SaveChanges();
                     logger.Info("Category Update " + User.Identity.Name + " at " + DateTime.UtcNow);
                     return RedirectToAction("Index");
                 }
             }
             catch(Exception ex)
             {
                 logger.Error("Category Error in  Update data  " + User.Identity.Name + " at " + DateTime.UtcNow);
                 throw ex;
             }
             return View(category);
         }
         #endregion

         #region Delete Data
         // GET: /Category/Delete/5
         public ActionResult Delete(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Category category = db.Categories.Find(id);
             if (category == null)
             {
                 return HttpNotFound();
             }
             return View(category);
         }

         // POST: /Category/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public ActionResult DeleteConfirmed(int id)
         {
             try
             {
                 logger.Info("In CategoryController Delete method starts at " + DateTime.UtcNow);
                 Category category = db.Categories.Find(id);
                 db.Categories.Remove(category);
                 db.SaveChanges();
                 logger.Info("Category Delete  " + User.Identity.Name + "at " + DateTime.UtcNow);
             }
             catch(Exception ex)
             {
                 logger.Error("Category Delete Error " + User.Identity.Name + "  at " + DateTime.UtcNow);
                 throw ex;
             }
             return RedirectToAction("Index");
         }
         #endregion

         #region Despose Data
         protected override void Dispose(bool disposing)
         {
             if (disposing)
             {
                 db.Dispose();
             }
             base.Dispose(disposing);
         }
         #endregion
      
    }
}
