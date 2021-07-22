using System.Collections.Generic;
using SuperSimpleStudySample.App.Commons.SelectItems;

namespace SuperSimpleStudySample.App.Pages.EmpEdit.Spec
{
  public class EmpEditInitResponse
  {

    public List<SelectItem> DeptCodeItems { get; set; }

    public string EmpCode { get; set; }

    public string FirstName { get; set; }

    public string FamilyName { get; set; }

    public int? Age { get; set; }

    public string DeptCode { get; set; }
  }
}