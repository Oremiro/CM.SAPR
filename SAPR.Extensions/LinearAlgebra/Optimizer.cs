namespace SAPR.Extensions.LinearAlgebra;

public class Optimizer
{
    public static double[] Gauss(double[,] matrix)
    {
        var n           = matrix.GetLength(0);
        var matrixClone = new double[n, n + 1];

        for (var i = 0; i < n; i++)
            for (var j = 0; j < n + 1; j++)
                matrixClone[i, j] = matrix[i, j];

        for (var k = 0; k < n; k++)
        {
            for (var i = 0; i < n + 1; i++)
                matrixClone[k, i] /= matrix[k, k];
            for (var i = k + 1; i < n; i++)
            {
                var k_ = matrixClone[i, k] / matrixClone[k, k];
                for (var j = 0; j < n + 1; j++)
                    matrixClone[i, j] -= matrixClone[k, j] * k_;
            }
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n + 1; j++)
                    matrix[i, j] = matrixClone[i, j];
        }


        for (var k = n - 1; k > -1; k--)
        {
            for (var i = n; i > -1; i--)
                matrixClone[k, i] /= matrix[k, k];
            for (var i = k - 1; i > -1; i--)
            {
                var k_ = matrixClone[i, k] / matrixClone[k, k];
                for (var j = n; j > -1; j--)
                    matrixClone[i, j] -= matrixClone[k, j] * k_;
            }
        }

        var answer = new double[n];
        for (var i = 0; i < n; i++)
            answer[i] = matrixClone[i, n];

        return answer;
    }
}