namespace SAPR.Model;

public class BarStrainingCharacteristic: BaseClass
{
    public decimal? Nx              { get; set; }
    public decimal? NormalStraining { get; set; }
    public decimal? Ux              { get; set; }

    public BarStrainingCharacteristic(decimal nx, decimal normalStraining, decimal ux)
    {
        this.Nx              = nx;
        this.NormalStraining = normalStraining;
        this.Ux              = ux;
    }
}