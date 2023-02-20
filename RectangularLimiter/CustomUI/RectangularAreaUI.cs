using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RectangularLimiter.CustomUI
{
    /// <summary>
    /// Класс для опрделения прямоугольной области
    /// </summary>
    public class RectangularAreaUI
    {
        Rectangle rectangle;

        Point? firstPoint;

        Canvas cnv;

        public RectangularAreaUI(Canvas canvas)
        {
            rectangle = new Rectangle()
            {
                Stroke = new SolidColorBrush(Colors.Salmon),
                StrokeThickness = 3,
                Width = 20,
                Height = 20,
                StrokeDashArray = new DoubleCollection(new double[] { 2, 2 }),
                SnapsToDevicePixels = true
            };

            cnv = canvas;

            cnv.Children.Add(rectangle);
        }

        /// <summary>
        /// Метод для определения (перемещения) первой из двух точек, определяющих область
        /// </summary>
        /// <param name="position"></param>
        public void MoveFirstPoint(Point position) 
        {
            Canvas.SetLeft(rectangle, position.X);
            Canvas.SetTop(rectangle, position.Y);
        }

        /// <summary>
        /// Метод фиксации первой точки области
        /// </summary>
        public void FixFirstPoint()
        {
            firstPoint = new Point(x: Canvas.GetLeft(rectangle), y: Canvas.GetTop(rectangle));
        }

        /// <summary>
        /// Метод для определения (перемещения) второй из двух точек, определяющих область
        /// </summary>
        /// <param name="position"></param>
        public void MoveSecondPoint(Point position)
        {
            Canvas.SetLeft(rectangle, Math.Min(firstPoint.Value.X, position.X));
            Canvas.SetTop(rectangle, Math.Min(firstPoint.Value.Y, position.Y));
            rectangle.Width = Math.Abs(firstPoint.Value.X - position.X);
            rectangle.Height = Math.Abs(firstPoint.Value.Y - position.Y);
        }

        /// <summary>
        /// Получение характеристик, определяющих область
        /// </summary>
        /// <param name="position"></param>
        public (double MinX, double MaxX, double MinY, double MaxY) GetCoordinates()
        {
            double minX = Canvas.GetLeft(rectangle);
            double minY = Canvas.GetTop(rectangle);
            return (minX, minX + rectangle.Width,
                minY, minY + rectangle.Height);
        }

        /// <summary>
        /// Сброс информации о первой и второй точках, определяющих область
        /// </summary>
        /// <param name="position"></param>
        public void Reset()
        {
            rectangle.Height = 20;
            rectangle.Width = 20;

            firstPoint = null;
        }
    }
}
