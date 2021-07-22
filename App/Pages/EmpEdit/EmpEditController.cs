using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using SuperSimpleStudySample.App.Commons.Dbs;
using SuperSimpleStudySample.App.Commons.Dbs.Dao;
using SuperSimpleStudySample.App.Pages.EmpEdit.Spec;
using SuperSimpleStudySample.App.Commons.SelectItems;
using SuperSimpleStudySample.App.Commons.Dbs.Entity;

namespace SuperSimpleStudySample.App.Pages.EmpEdit
{
  [Route("empedit")]
  public class EmpEditController : Controller
  {
    private DbHelper _dbHelper;


    private DeptDao _deptDao;
    private EmpDao _empDao;

    public EmpEditController(
        DbHelper dbHelper,
        DeptDao deptDao,
         EmpDao empDao
    )
    {
      _dbHelper = dbHelper;
      _deptDao = deptDao;
      _empDao = empDao;
    }

    [HttpGet("")]
    [HttpGet("index")]
    public IActionResult Index() => View();

    [HttpGet("init")]
    public IActionResult Init(EmpEditInitRequest req)
    {
      EmpEditInitResponse resp = new EmpEditInitResponse();

      using (IDbConnection con = _dbHelper.GetConnection())
      using (IDbTransaction tx = con.BeginTransaction())
      {
        resp.DeptCodeItems = _deptDao.FindAll(con, tx).AsSelectItem(x => x.DeptCode, x => x.DeptName);
        resp.DeptCode = resp.DeptCodeItems[0].Value;

        if (!string.IsNullOrEmpty(req.EmpCode))
        {
          Emp emp = _empDao.FindById(con, tx, req.EmpCode);
          if (emp != null)
          {
            resp.EmpCode = emp.EmpCode;
            resp.FirstName = emp.FirstName;
            resp.FamilyName = emp.FamilyName;
            resp.Age = emp.Age;
            resp.DeptCode = emp.DeptCode;
          }
        }

        return Ok(resp);
      }

    }

    [HttpPost("register")]
    public IActionResult Register()
    {
      //TODO
      return Ok();
    }
  }
}