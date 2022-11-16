using System.Text;

namespace SAPR.Model;

public class Matrix<T>
{
    private T[,] Matrix_ { get; set; }

    public Matrix(T[,] matrix) => this.Matrix_ = matrix;

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (var i = 0; i < this.Matrix_.GetLongLength(0); i++)
        {
            for (var j = 0; j < this.Matrix_.GetLongLength(1); j++)
            {
                sb.Append($"{this.Matrix_[i, j]} ");
                
            }

            sb.Append('\n');
        }

        return sb.ToString();
    }
}