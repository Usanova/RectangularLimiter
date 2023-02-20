namespace RectangularLimiter.MathModel
{
    /// <summary>
    /// Класс для определения прямой по двум точкам
    /// </summary>
    public class Line
    {
        public double x1;
        public double y1;
        public double x2;
        public double y2;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x1">x кордината первой точки на прямой</param>
        /// <param name="y1">y кордината первой точки на прямой</param>
        /// <param name="x2">x кордината второй точки на прямой</param>
        /// <param name="y2">y кордината второй точки на прямой</param>
        public Line(double x1, double y1, double x2, double y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }


        /// <summary>
        /// Метод опредляющий, как точка располагается относительно прямой ("на прямой", выше, ниже)
        /// за счет определения знака, при подстановки точки в уравнение прямой
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double SignInEquation(double x, double y)
        {
            var value = (x - x1) * (y2 - y1) + (y1 - y) * (x2 - x1);

            if (MathOp.DoubleEqual(value, 0))
                return 0;

            return value > 0 ? 1 : -1;
        }
    }
}
