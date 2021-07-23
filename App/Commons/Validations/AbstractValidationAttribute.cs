using System;
using System.ComponentModel.DataAnnotations;

namespace SuperSimpleStudySample.App.Commons.Validations
{
  public class AbstractValidationAttribute : ValidationAttribute
  {
    public override bool IsValid(object value)
    {
      if (value == null)
      {
        return true;
      }
      string strValue = value.ToString();
      if (strValue.Length == 0)
      {
        return true;
      }

      return IsValidString(strValue);
    }

    protected virtual bool IsValidString(string value)
    {
      throw new NotImplementedException();
    }
  }
}