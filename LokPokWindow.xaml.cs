using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lokpok_v2
{
    /// <summary>
    /// Логика взаимодействия для LokPokWindow.xaml
    /// </summary>
    public partial class LokPokWindow : Window
    {
        public delegate void ItsMove(DIRECTION Direction);
        public event ItsMove Move;

        private bool _onShiftDown = false;

        public LokPokWindow()
        {
            InitializeComponent();
            DataContext = Storage.SelectedHpBars;
            this.Visibility = Visibility.Visible;
        }

        public void PrintInLog(string text)
        {
            logTextBlock.Text += "\n" + DateTime.Now.ToLongTimeString() + " " + text;
            logScrollViewer.ScrollToEnd();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Key.Right) Move(DIRECTION.RIGHT);
            if (e.Key == Key.Left) Move(DIRECTION.LEFT);
            if (e.Key == Key.Up) Move(DIRECTION.UP);
            if (e.Key == Key.Down) Move(DIRECTION.DOWN);

            if (e.Key == Key.LeftShift || e.Key == Key.RightShift) _onShiftDown = true;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift) _onShiftDown = false;
        }

        public bool GetShiftDown()
        {
            return _onShiftDown;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
    }
}
