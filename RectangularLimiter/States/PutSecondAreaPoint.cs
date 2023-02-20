using RectangularLimiter.CustomUI;
using System.Windows;

namespace RectangularLimiter.States
{
    /// <summary>
    /// Класс состояния - "Ставим вторую точку прямоугольной области"
    /// </summary>
    public class PutSecondAreaPoint : AreaState
    {
        public PutSecondAreaPoint(Area area) : base(area)
        { }

        public override void MouseMove(Point position)
        {
            area.RectangularArea.MoveSecondPoint(position);
        }

        public override void MouseLeftButtonDown(Point position)
        {
            area.CurrentSegment = new SegmentUI(position, area.Cnv);
            area.ChangeState(new PutPointForStartSegment(area));
        }

        public override void KeyLeftDown()
        {
            area.RectangularArea.Reset();
            area.ChangeState(new PutFirstAreaPoint(area));
        }
    }
}
