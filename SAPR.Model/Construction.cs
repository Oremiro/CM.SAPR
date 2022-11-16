namespace SAPR.Model;

public class Construction: BaseClass
{
    public bool?       LeftBase         { get; set; }
    public bool?       RightBase        { get; set; }
    public decimal?    AllowedStraining { get; set; }
    public List<Bar>?  Bars             { get; set; }
}