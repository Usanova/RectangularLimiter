using System.Windows;

namespace RectangularLimiter.States
{
    /// <summary>
    /// Класс состояния - "Ставим первую точку прямоугольной области"
    /// </summary>
    public class PutFirstAreaPoint : AreaState
    {
        public PutFirstAreaPoint(Area area) : base(area) { }

        public override void MouseMove(Point position)
        {
            area.RectangularArea.MoveFirstPoint(position);
        }

        public override void MouseLeftButtonDown(Point position)
        {
            area.RectangularArea.FixFirstPoint();
            area.ChangeState(new PutSecondAreaPoint(area));
        }

        public override void KeyLeftDown()
        { }
    }
}
