namespace SAPR.Model;

public class Bar: BaseClass
{
    public decimal? Area            { get; set; }
    public decimal? Length          { get; set; }
    public decimal? Elastic         { get; set; }
    public decimal? LinearStraining { get; set; }
    public decimal? FirstNode       { get; set; }
    public decimal? LastNode        { get; set; }

    public Bar(decimal area, decimal length, decimal elastic, decimal linearStraining, decimal firstNode, decimal lastNode)
    {
        this.Area            = area;
        this.Length          = length;
        this.Elastic         = elastic;
        this.LinearStraining = linearStraining;
        this.FirstNode       = firstNode;
        this.LastNode        = lastNode;
    }
}