using RectangularLimiter.CustomUI;
using RectangularLimiter.MathModel;
using System.Linq;
using System.Windows;

namespace RectangularLimiter.States
{
    /// <summary>
    /// Класс состояния - "Ставим конечную точку отрезка"
    /// </summary>
    public class PutPointForEndOfSegment : States.AreaState
    {
        public PutPointForEndOfSegment(Area area) : base(area) { }

        public override void MouseMove(Point position)
        {
            area.CurrentSegment.MoveEnd(position);
        }

        public override void MouseLeftButtonDown(Point position)
        {
            if (IsSegmentInRecArea(area.CurrentSegment, area.RectangularArea))
                area.CurrentSegment.Mark();
            area.Segments.Add(area.CurrentSegment);

            area.CurrentSegment = new SegmentUI(position, area.Cnv);
        }

        public override void KeyLeftDown()
        {
            if (area.Segments.Count == 0)
            {
                area.CurrentSegment.Resete();
                area.ChangeState(new PutPointForStartSegment(area));
                return;
            }

            area.CurrentSegment.Delete();
            area.CurrentSegment = area.Segments.Last();
            area.CurrentSegment.Unmark();
            area.Segments.Remove(area.CurrentSegment);
        }

        private bool IsSegmentInRecArea(SegmentUI s, RectangularAreaUI rectangularArea)
        {
            var ra = rectangularArea.GetCoordinates();

            return MathOp.IsSegmentInRecArea(segmentX1: s.X1, segmentY1: s.Y1, segmentX2: s.X2, segmentY2: s.Y2,
                areaMinX: ra.MinX, areaMaxX: ra.MaxX, areaMinY: ra.MinY, areaMaxY: ra.MaxY);
        }
    }
}
;