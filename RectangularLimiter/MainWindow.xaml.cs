using RectangularLimiter.States;
using System.Windows;
using System.Windows.Input;

namespace RectangularLimiter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Area area;
        public MainWindow()
        {
            InitializeComponent();

            area = new Area(cnvMain);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = Mouse.GetPosition(cnvMain);
            area.State.MouseMove(p);
        }

        private void cnvMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = Mouse.GetPosition(cnvMain);

            area.State.MouseLeftButtonDown(p);
        }

        private void cnvMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Left)
                return;

            area.State.KeyLeftDown();
        }
    }
}
