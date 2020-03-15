using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace lokpok_v2
{
    //public class HpBarView : UIElement
    //{
    //    float _width;
    //    float _heigth;
    //    float _currentHP;
    //    public HpBarView(float width, float heigth)
    //    {
    //        _width = width;
    //        _heigth = heigth;
    //        _currentHP = 1;
    //    }

    //    protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
    //    {
    //        base.OnRender(drawingContext);
    //        drawingContext.DrawRectangle(new SolidColorBrush(Colors.Red), new Pen(new SolidColorBrush(Colors.Black), 1), new Rect(new Size(_width, _heigth)));
    //        drawingContext.DrawRectangle(new SolidColorBrush(Colors.Green), new Pen(new SolidColorBrush(Colors.Black), 1), new Rect(new Size(_width*_currentHP, _heigth)));
    //    }

    //    void RePaint()
    //    {
    //        this.InvalidateVisual();
    //    }

    //    public void UpdateHpBar(Live live)
    //    {
    //        _currentHP = (live.CurrentHealthPoints / live.MaxHealthPoints) < 0 ? 0 : live.CurrentHealthPoints / live.MaxHealthPoints;
    //        this.RePaint();
    //    }
    //}

    public class NewHpBar : FrameworkElement
    {
        private string _name;
        private HealthPoints _healthPoints;
        public static readonly DependencyProperty HealthProperty;

        static NewHpBar()
        {
            HealthProperty = DependencyProperty.Register("Health", typeof(float), typeof(NewHpBar),
                new FrameworkPropertyMetadata(1f, FrameworkPropertyMetadataOptions.AffectsRender));
        }

        public float Health
        {
            get { return (float)GetValue(HealthProperty); }
            set { SetValue(HealthProperty, value); }
        }

        public NewHpBar(float width, float heigth, HealthPoints healthPoints)
        {
            this.Width = width;
            this.Height = heigth;
            _healthPoints = healthPoints;
            _healthPoints.HpChanged += UpdateHpBar;
            _name = healthPoints.Name;
        }

        void UpdateHpBar()
        {
            this.Health = _healthPoints.CurrentValue / _healthPoints.MaxValue < 0 ? 0 : _healthPoints.CurrentValue / _healthPoints.MaxValue;
        }

        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            drawingContext.DrawRectangle(new SolidColorBrush(Colors.Red), new Pen(new SolidColorBrush(Colors.Black), 1), new Rect(new Size(this.Width, this.Height)));
            drawingContext.DrawRectangle(new SolidColorBrush(Colors.Green), new Pen(new SolidColorBrush(Colors.Black), 1), new Rect(new Size(this.Width * Health, this.Height)));
            drawingContext.DrawText(new FormattedText(_name, System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 10, new SolidColorBrush(Colors.White)), new Point(0, 0));
        }
    }
}
