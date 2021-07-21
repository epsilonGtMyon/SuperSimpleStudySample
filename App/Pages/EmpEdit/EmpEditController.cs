using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using SuperSimpleStudySample.App.Commons.Dbs;

namespace SuperSimpleStudySample.App.Pages.EmpEdit
{
  [Route("empedit")]
  public class EmpEditController : Controller
  {
    private DbHelper _dbHelper;

    public EmpEditController(
        DbHelper dbHelper
    )
    {
      _dbHelper = dbHelper;
    }
    
    [HttpGet("")]
    [HttpGet("index")]
    public IActionResult Index() => View();
  }
}