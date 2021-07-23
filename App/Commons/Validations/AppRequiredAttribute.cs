using System.ComponentModel.DataAnnotations;

namespace SuperSimpleStudySample.App.Commons.Validations
{
  public class AppRequiredAttribute : AbstractValidationAttribute
  {

    public AppRequiredAttribute()
    {
      ErrorMessage = "{0}は必須です。";
    }

    public override bool IsValid(object value)
    {
      if (value == null)
      {
        return false;
      }

      string stringValue = value as string;
      if (stringValue != null)
      {
        return stringValue.Length != 0;
      }

      return true;
    }
  }
}