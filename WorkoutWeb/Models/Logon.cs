using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkoutWeb.Models
{
  public class Logon
  {
    [Required]
    public string UserName { get; set; }
    public string Password { get; set; }
    [DisplayName("Remember me")]
    public bool RememberMe { get; set; }
  }
}