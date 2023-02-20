using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RectangularLimiter.CustomUI
{
    /// <summary>
    /// Класс для опрделения отрезка
    /// </summary>
    public class SegmentUI
    {
        private Ellipse startEllipse;
        private Line segmentLine;

        private Canvas cnv;

        public double X1 => segmentLine.X1;
        public double X2 => segmentLine.X2;
        public double Y1 => segmentLine.Y1;
        public double Y2 => segmentLine.Y2;

        public SegmentUI(Point startPoint, Canvas canvas)
        {
            startEllipse = new Ellipse
            {
                Fill = new SolidColorBrush(Colors.Green),
                Height = 7,
                Width = 7
            };

            segmentLine = new Line
            {
                Stroke = new SolidColorBrush(Colors.Green),
                StrokeThickness = 2
            };

            cnv = canvas;

            cnv.Children.Add(startEllipse);
            cnv.Children.Add(segmentLine);

            MoveStart(startPoint);
        }

        /// <summary>
        /// Метод для определения начала отрезка (перемещение начальной точки)
        /// </summary>
        /// <param name="position"></param>
        public void MoveStart(Point position)
        {
            Canvas.SetLeft(startEllipse, position.X - startEllipse.Width / 2);
            Canvas.SetTop(startEllipse, position.Y - startEllipse.Height / 2);

            segmentLine.X1 = position.X;
            segmentLine.Y1 = position.Y;
            segmentLine.X2 = position.X;
            segmentLine.Y2 = position.Y;
        }

        /// <summary>
        /// Метод для определения конца отрезка (перемещение конечной точки)
        /// </summary>
        /// <param name="position"></param>
        public void MoveEnd(Point position)
        {
            segmentLine.X2 = position.X;
            segmentLine.Y2 = position.Y;
        }

        /// <summary>
        /// Метод для маркировки отрезка (окрашивания его в другой цвет)
        /// </summary>
        public void Mark()
        {
            startEllipse.Fill = new SolidColorBrush(Colors.Yellow);
            segmentLine.Stroke = new SolidColorBrush(Colors.Yellow);
        }

        /// <summary>
        /// Метод для отмены маркировки
        /// </summary>
        public void Unmark()
        {
            startEllipse.Fill = new SolidColorBrush(Colors.Green);
            segmentLine.Stroke = new SolidColorBrush(Colors.Green);
        }

        /// <summary>
        ///  Сброс информации о начальной и конечной точках, определяющих отрезок
        /// </summary>
        public void Resete()
        {
            segmentLine.X2 = segmentLine.X1;
            segmentLine.Y2 = segmentLine.Y1;
        }

        /// <summary>
        /// Метод для удаления отрезка из области
        /// </summary>
        public void Delete()
        {
            cnv.Children.Remove(startEllipse);
            cnv.Children.Remove(segmentLine);
        }
    }
}