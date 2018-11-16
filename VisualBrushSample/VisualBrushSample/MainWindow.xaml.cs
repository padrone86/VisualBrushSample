using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VisualBrushSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Brush[] tmp = new Brush[] { Brushes.Orange, Brushes.Violet, Brushes.Green, Brushes.Yellow };
        Random r = new Random();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idx = r.Next(tmp.Length);

            Thumb rect = new Thumb();
            rect.Margin = new Thickness(10, 0, 10, 0);
            rect.Width = 30;
            rect.Height = 30;
            Canvas.SetTop(rect, 0);
            Canvas.SetLeft(rect, 0);
            rect.Background = tmp[idx];
            rect.DragDelta += Rect_DragDelta;
            srcChild.Children.Add(rect);
        }

        private void Rect_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Thumb rect = sender as Thumb;

            Canvas.SetTop(rect, Canvas.GetTop(rect) + e.VerticalChange);
            Canvas.SetLeft(rect, Canvas.GetLeft(rect) + e.HorizontalChange);
        }
    }
}
