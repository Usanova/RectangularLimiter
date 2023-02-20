using RectangularLimiter.CustomUI;
using System.Collections.Generic;
using System.Windows.Controls;

namespace RectangularLimiter.States
{
    /// <summary>
    /// Класс области экрана, на которой происходит отрисовка элементов
    /// </summary>
    public sealed class Area
    {
        public Area(Canvas canvas)
        {
            Cnv = canvas;
            RectangularArea = new RectangularAreaUI(Cnv);
            State = new PutFirstAreaPoint(this);
        }

        public Canvas Cnv { get; set; }
        public RectangularAreaUI RectangularArea { get; set; }
        public List<SegmentUI> Segments { get; set; } = new List<SegmentUI>();
        public SegmentUI CurrentSegment { get; set; }

        public AreaState State { get; private set; }

        public void ChangeState(AreaState newState)
        {
            State = newState;
        }
    }
}
