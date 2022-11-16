using System.Text;

namespace SAPR.Model;

public abstract class BaseClass
{
    public override string ToString() => this.GetType().GetProperties()
        .Select(info
            => (info.Name, Value: info.GetValue(this, null) ?? "(null)"))
        .Aggregate(
            new StringBuilder(),
            (sb, pair) => sb.AppendLine($"{pair.Name}: {pair.Value}"),
            sb => sb.ToString());
}