﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkoutWeb.Models;

namespace WorkoutWeb.Controllers
{
  public class GraphController : Controller
  {
    //
    // GET: /Graph/
    private WWDataContext db = new WWDataContext();

    public ActionResult Index()
    {
      return View();
    }
    
    public ActionResult ShowGraph(int id)
    {
      var model = db.Categories.Find(id);
      
      return View(model);
    }

    [HttpPost]
    public ActionResult PostPieData(PieValue p)
    {
      db.PieValues.Add(p);
      db.SaveChanges();
      return Json(p, JsonRequestBehavior.AllowGet);
    }

    [HttpDelete]
    public ActionResult DelPie(int id)
    {
      PieValue p = db.PieValues.Find(id);
      db.PieValues.Remove(p);
      db.SaveChanges(); 

      return Json(p);
    }

    [HttpPut]
    public ActionResult UpdatePie(int id, PieValue p)
    {
      db.Entry(p).State = EntityState.Modified;
      db.SaveChanges();
      return Json(p);
    }
    
    public ActionResult GetPieData(int id)
    {
      List<PieValue> data = db.PieValues.Where(p => (p.Category == id)).ToList();
      return Json(data, JsonRequestBehavior.AllowGet);
    }
  }
}
