using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkoutWeb.Models
{
  public class PieValue
  {
    public int PieValueId { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public int? Category { get; set; }
    public string UserName { get; set; }
    public DateTime? DataDate { get; set; }
  }
}