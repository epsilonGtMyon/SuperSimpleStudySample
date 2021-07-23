using System.Globalization;

namespace SuperSimpleStudySample.App.Commons.Validations
{
  public class AppMaxLengthAttribute : AbstractValidationAttribute
  {
    public int MaxLength { get; set; }
    public AppMaxLengthAttribute(int maxLength)
    {
      MaxLength = maxLength;
      ErrorMessage = "{0}は{1}文字以内で入力してください。";
    }
    
    public override string FormatErrorMessage(string name) =>
            string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, MaxLength);


    protected override bool IsValidString(string value)
    {
      return value.Length <= MaxLength;
    }

  }
}