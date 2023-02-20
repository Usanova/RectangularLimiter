using System;

namespace RectangularLimiter.MathModel
{
    public static class MathOp
    {
        public static double Threshold = 1e-8;
        /// <summary>
        /// Метод для проверки на равенство с учетом особенности типа "double"
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool DoubleEqual(double a, double b)
        {
            return Math.Abs(a - b) < Threshold;
        }

        /// <summary>
        /// Метод определения - находится ли хоть одна точка отрезка внутри прямоугольной области
        /// или касается ее
        /// </summary>
        /// <param name="segmentX1"></param>
        /// <param name="segmentY1"></param>
        /// <param name="segmentX2"></param>
        /// <param name="segmentY2"></param>
        /// <param name="areaMinX"></param>
        /// <param name="areaMaxX"></param>
        /// <param name="areaMinY"></param>
        /// <param name="areaMaxY"></param>
        /// <returns></returns>
        public static bool IsSegmentInRecArea(double segmentX1, double segmentY1, double segmentX2, double segmentY2,
            double areaMinX, double areaMaxX, double areaMinY, double areaMaxY)
        {
            Line line = new Line(x1: segmentX1, y1: segmentY1, x2: segmentX2, y2: segmentY2);

            var segmentMinX = Math.Min(segmentX1, segmentX2);
            var segmentMaxX = Math.Max(segmentX1, segmentX2);
            var segmentMinY = Math.Min(segmentY1, segmentY2);
            var segmentMaxY = Math.Max(segmentY1, segmentY2);

            var result = (line.SignInEquation(areaMinX, areaMinY) * line.SignInEquation(areaMaxX, areaMaxY) <= 0
                || line.SignInEquation(areaMinX, areaMaxY) * line.SignInEquation(areaMaxX, areaMinY) <= 0) // условия, определяющие пересекает ли прямая,
                                                                                                           // содержащая отрезок, прямоугольную область
                && !(segmentMinX > areaMaxX) && !(segmentMaxX < areaMinX)
                && !(segmentMinY > areaMaxY) && !(segmentMaxY < areaMinY); // условия, проверяющие, что отрезок яляется той частью
                                                                           // прямой, которая пересекает прямоугольную область

            return result;
        }
    }
}
