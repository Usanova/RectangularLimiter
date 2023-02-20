using System.Windows;

namespace RectangularLimiter.States
{
    /// <summary>
    /// Класс состояния - "Ставим начальную точку отрезка"
    /// </summary>
    public class PutPointForStartSegment : States.AreaState
    {
        public PutPointForStartSegment(Area area) : base(area) { }

        public override void MouseMove(Point position)
        {
            area.CurrentSegment.MoveStart(position);
        }

        public override void MouseLeftButtonDown(Point position)
        {
            area.ChangeState(new PutPointForEndOfSegment(area));
        }

        public override void KeyLeftDown()
        {
            area.CurrentSegment.Delete();
            area.RectangularArea.Reset();
            area.ChangeState(new PutFirstAreaPoint(area));
        }
    }
}
