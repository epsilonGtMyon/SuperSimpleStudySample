using System.ComponentModel;
using SuperSimpleStudySample.App.Commons.Validations;

namespace SuperSimpleStudySample.App.Pages.EmpEdit.Spec
{
  public class EmpEditRegisterRequest
  {

    [DisplayName("社員コード")]
    [AppRequired]
    [HalfAlphaNum]
    [AppMaxLength(5)]
    public string EmpCode { get; set; }

    [DisplayName("名")]
    [AppRequired]
    [AppMaxLength(5)]
    public string FirstName { get; set; }

    [DisplayName("姓")]
    [AppRequired]
    [AppMaxLength(5)]
    public string FamilyName { get; set; }

    [DisplayName("年齢")]
    [AppRequired]
    [HalfNum]
    [AppMaxLength(3)]
    public string Age { get; set; }

    [DisplayName("部署")]
    [AppRequired]
    [HalfAlphaNum]
    [AppMaxLength(5)]
    public string DeptCode { get; set; }
  }
}