namespace Bmerketo_WebApp.Models;

public class CheckboxOptionModel
{
    public bool IsChecked { get; set; } = false;
    public string Description { get; set; } = null!;
    public int Value { get; set; }
}
