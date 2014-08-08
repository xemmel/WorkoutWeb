using System;
using System.Collections.Generic;
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

    public ActionResult GetPieData()
    {
      List<PieValue> data = db.PieValues.ToList();
      return Json(data, JsonRequestBehavior.AllowGet);
    }
  }
}
