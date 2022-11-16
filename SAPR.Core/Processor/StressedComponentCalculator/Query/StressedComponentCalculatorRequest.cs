using MediatR;
using SAPR.Model;

namespace SAPR.Core.Processor.StressedComponentCalculator.Query;

public class StressedComponentCalculatorRequest: IRequest
{
    public Construction Construction { get; set; }
}