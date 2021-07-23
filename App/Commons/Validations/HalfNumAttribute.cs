namespace SuperSimpleStudySample.App.Commons.Validations
{
  public class HalfNumAttribute : AbstractValidationAttribute
  {

    public HalfNumAttribute()
    {
      ErrorMessage = "{0}は半角数値で入力してください。";
    }

    protected override bool IsValidString(string value)
    {
      foreach (char c in value)
      {
        if ('0' <= c && c <= '9')
        {
            //next char
        }
        else
        {
          return false;
        }
      }

      return true;
    }
  }
}