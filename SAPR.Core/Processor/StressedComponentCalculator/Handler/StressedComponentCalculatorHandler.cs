using MediatR;
using SAPR.Core.Processor.StressedComponentCalculator.Query;
using SAPR.Model;

namespace SAPR.Core.Processor.StressedComponentCalculator.Handler;

public class StressedComponentCalculatorHandler : AsyncRequestHandler<StressedComponentCalculatorRequest>
{
    private List<bool>?      Displacements { get; set; }
    private LinkedList<Bar>? Bars          { get; set; }

    protected override Task Handle(
        StressedComponentCalculatorRequest request,
        CancellationToken                  cancellationToken
    )
    {
        if (request?.Construction == null)
        {
            return Task.CompletedTask;
        }

        if (request.Construction.Bars == null)
        {
            return Task.CompletedTask;
        }

        this.Bars = new LinkedList<Bar>(request.Construction.Bars);
        var bars = this.Bars;
        if (bars == null)
        {
            return Task.CompletedTask;
        }

        var barsMatrixA    = new double [bars.Count + 1, bars.Count + 1];
        var barsMatrixB    = new double[bars.Count  + 1, 1];
        var extendedMatrix = new double[bars.Count  + 1, bars.Count + 2];
        for (var i = 0; i < bars.Count + 1; i++)
        {
            for (var j = 0; j < bars.Count + 1; j++)
            {
                barsMatrixA[i, j] = 0;
                barsMatrixB[i, 0] = 0;
            }
        }

        var bar = bars.First;

        var g = 0;
        for (var i = 0; i <= bars.Count - 1; i++, g++)
        {
            if (bar == null)
            {
                continue;
            }

            barsMatrixA[i, g] =
                (double)
                (bar.Value.Elastic * bar.Value.Area / bar.Value.Length +
                 this.PrevNodeCheckAndReturnK(bar.ValueRef));
            barsMatrixA[i + 1, g] = (double) (-1 * bar.Value.Elastic *
                bar.Value.Area / bar.Value.Length);
            barsMatrixA[i, g + 1] = (double) (-1 * bar.Value.Elastic *
                bar.Value.Area / bar.Value.Length);
            barsMatrixA[i + 1, g + 1] =
                (double)
                ((bar.Value.Elastic * bar.Value.Area / bar.Value.Length) +
                 this.NextNodeCheckAndReturnK(bar.Value));
            bar = bar.Next;
        }


        return Task.CompletedTask;
    }

    private decimal? PrevNodeCheckAndReturnK(Bar? bar)
    {
        if (bar == null)
        {
            throw new NullReferenceException();
        }

        return (decimal?) 0.0;
    }

    private decimal? NextNodeCheckAndReturnK(Bar bar)
    {
        if (bar == null)
        {
            throw new NullReferenceException();
        }

        return (decimal?) 0.0;
    }
}