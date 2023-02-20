using System.Windows;

namespace RectangularLimiter.States
{
    /// <summary>
    /// Класс состояния, в котором в данный момент находится область для отрисовки
    /// </summary>
    public abstract class AreaState
    {
        public AreaState(Area area)
        {
            this.area = area;
        }

        protected Area area { get; set; }

        /// <summary>
        /// Действие, при определенном состоянии, совершающееся при придвижении мыши по экрану
        /// </summary>
        /// <param name="position"></param>
        public abstract void MouseMove(Point position);
        /// <summary>
        /// Действие, при определенном состоянии, совершающееся при нажатии левой кнопки мыши
        /// </summary>
        /// <param name="position"></param>
        public abstract void MouseLeftButtonDown(Point position);
        /// <summary>
        /// Действие, при определенном состоянии, совершающееся при нажатии стрелки "налево"
        /// </summary>
        public abstract void KeyLeftDown();
    }
}
