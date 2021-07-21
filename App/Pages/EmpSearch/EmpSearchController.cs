using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using SuperSimpleStudySample.App.Commons.Dbs;
using SuperSimpleStudySample.App.Pages.EmpSearch.Spec;

namespace SuperSimpleStudySample.App.Pages.EmpSearch
{
  [Route("empsearch")]
  public class EmpSearchController : Controller
  {
    private DbHelper _dbHelper;

    private EmpSearchDao _empSearchDao;

    public EmpSearchController(
        DbHelper dbHelper,
       EmpSearchDao empSearchDao
    )
    {
      _dbHelper = dbHelper;
      _empSearchDao = empSearchDao;
    }

    [HttpGet("")]
    [HttpGet("index")]
    public IActionResult Index() => View();


    [HttpGet("search")]
    public IActionResult Search(EmpSearchRequest req)
    {
      using (IDbConnection con = _dbHelper.GetConnection())
      using (IDbTransaction tran = con.BeginTransaction())
      {
        List<EmpSearchResponseRow> rows = _empSearchDao.Search(con, tran, req);

        return Ok(new EmpSearchRespnse
        {
          Rows = rows
        });
      }

    }
  }
}