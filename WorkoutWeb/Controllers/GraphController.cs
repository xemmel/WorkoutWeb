using System;
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
    
    public ActionResult ShowGraph()
    {
      return View();
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
    
    public ActionResult GetPieData()
    {
      List<PieValue> data = db.PieValues.ToList();
      return Json(data, JsonRequestBehavior.AllowGet);
    }
  }
}
