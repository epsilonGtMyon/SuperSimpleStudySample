using System.Text.RegularExpressions;

namespace SuperSimpleStudySample.App.Commons.Validations
{
  public class HalfAlphaNumAttribute : AbstractValidationAttribute
  {
    public HalfAlphaNumAttribute()
    {
      ErrorMessage = "{0}は半角英数で入力してください。";
    }

    protected override bool IsValidString(string value)
    {
      return Regex.IsMatch(value, "^[0-9a-zA-Z]+$");
    }
  }
}