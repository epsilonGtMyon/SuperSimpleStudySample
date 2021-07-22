namespace SuperSimpleStudySample.App.Commons.SelectItems
{
  public class SelectItem
  {
    public string Value { get; set; }

    public string Text { get; set; }

    public SelectItem(){
    }
    public SelectItem(string value, string text){
        Value = value;
        Text = text;
    }
  }
}