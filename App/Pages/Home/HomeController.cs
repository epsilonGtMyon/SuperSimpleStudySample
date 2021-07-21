using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using SuperSimpleStudySample.App.Commons.Dbs;
using SuperSimpleStudySample.App.Commons.Dbs.Dao;
using SuperSimpleStudySample.App.Commons.Dbs.Entity;

namespace SuperSimpleStudySample.App.Pages.Home
{
  [Route("home")]
  public class HomeController : Controller
  {
    private HomeDao _homeDao;

    private DbHelper _dbHelper;
    private DeptDao _deptDao;
    private EmpDao _empDao;

    public HomeController(
        HomeDao homeDao,
        DbHelper dbHelper,
        DeptDao deptDao,
        EmpDao empDao
    )
    {
      _homeDao = homeDao;
      _dbHelper = dbHelper;
      _deptDao = deptDao;
      _empDao = empDao;
    }

    [HttpGet("")]
    [HttpGet("index")]
    public IActionResult Index() => View();


    [HttpPost("preparedb")]
    public IActionResult PrepareDb()
    {

      using (IDbConnection con = _dbHelper.GetConnection())
      using (IDbTransaction tx = con.BeginTransaction())
      {

        _homeDao.DropEmp(con, tx);
        _homeDao.DropDept(con, tx);

        _homeDao.CreateEmp(con, tx);
        _homeDao.CreateDept(con, tx);

        _empDao.Insert(con, tx, new Emp{
          EmpCode= "E001",
          FirstName = "一郎",
          FamilyName = "田中",
          Age = 35,
          DeptCode="D001",
        });
        _empDao.Insert(con, tx, new Emp{
          EmpCode= "E002",
          FirstName = "二郎",
          FamilyName = "伊藤",
          Age = 43,
          DeptCode="D001",
        });
        _empDao.Insert(con, tx, new Emp{
          EmpCode= "E003",
          FirstName = "三郎",
          FamilyName = "山本",
          Age = 31,
          DeptCode="D002",
        });

        _deptDao.Insert(con, tx, new Dept{
          DeptCode = "D001",
          DeptName = "管理部",
          Address = "大阪ビル１F"
        });
        _deptDao.Insert(con, tx, new Dept{
          DeptCode = "D002",
          DeptName = "営業部",
          Address = "大阪ビル２F"
        });


        tx.Commit();
      }


      return Ok();
    }

  }
}