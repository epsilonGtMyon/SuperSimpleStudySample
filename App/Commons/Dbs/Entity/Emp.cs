namespace SuperSimpleStudySample.App.Commons.Dbs.Entity
{
  public class Emp
  {
    public string EmpCode { get; set; }

    public string FirstName { get; set; }

    public string FamilyName { get; set; }

    public int? Age { get; set; }

    public string DeptCode { get; set; }

    public override string ToString()
    {
      return $"Emp[EmpCode={EmpCode}, FirstName={FirstName}, FamilyName={FamilyName}, Age={Age}, DeptCode={DeptCode}]";
    }
  }
}