using System;

namespace Laba1Remastered
{
    public static class MatrixControler
    {
        public static void InitializeMatrix(CMatrix matrix)
        {
            var randomizer = new Random();
            for (var i = 0; i < matrix.NumberOfRows; i++)
            {
                for (var i1 = 0; i1 < matrix.NumberOfColumns; i1++)
                {
                    matrix.Content[i, i1] = randomizer.Next(1, 10);
                }
            }
        }

        public static double ScalarMult(CMatrix V1, CMatrix V2)
        {
            if (V1.NumberOfRows == V2.NumberOfRows && V1.NumberOfColumns == V2.NumberOfColumns)
            {
                return V1[0, 0] * V2[0, 0] + V1[1, 0] * V2[1, 0] + V1[2, 0] * V2[2, 0];
            }
            throw new Exception("Ошибка скадярного вычесления");
        }

        public static double ModVec(CMatrix V)                            // модуль вектора
        {
            return V.NumberOfRows == 3 && V.NumberOfColumns == 1 ?
                Math.Sqrt((double)(V[0, 0] * V[0, 0] + V[1, 0] * V[1, 0] + V[2, 0] * V[2, 0]))
                : 0.0;
        }

        public static CMatrix VectorMult(CMatrix V1, CMatrix V2)     // векторное произведение векторов
        {
            if (V1.NumberOfColumns == 1 && V2.NumberOfColumns == 1 && V1.NumberOfRows == V2.NumberOfRows)
            {
                CMatrix multVector = new CMatrix(3);
                multVector[0, 0] = V1[1, 0] * V2[2, 0] - V2[1, 0] * V1[2, 0];
                multVector[1, 0] = (-1) * (V1[0, 0] * V2[2, 0] - V2[0, 0] * V1[2, 0]);
                multVector[2, 0] = V1[0, 0] * V2[1, 0] - V2[0, 0] * V1[1, 0];
                return multVector;
            }
            else
            {
                return null;
            }
        }

        public static double CosV1V2(CMatrix V1, CMatrix V2)             // косинус угла между векторами
        {
            return V1.NumberOfColumns == 1 && V2.NumberOfColumns == 1 && V1.NumberOfRows == 3 && V2.NumberOfRows == 3 ?
                (ScalarMult(V1, V2) / (ModVec(V1) * ModVec(V2))) :
                0.0;
        }

        public static CMatrix SphereToCart(CMatrix PView)             // преобразует сферические координаты точки в декартовы
        {
            CMatrix R = new CMatrix(3);
            R[0] = PView[0] * Math.Cos(PView[1]) * Math.Sin(PView[2]);
            R[1] = PView[0] * Math.Sin(PView[1]) * Math.Sin(PView[2]);
            R[2] = PView[0] * Math.Cos(PView[2]);
            return R;
        }
    }
}