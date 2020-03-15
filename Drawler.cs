using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Drawing;
using System.Windows;
using System.Windows.Media;


namespace lokpok_v2
{
    static class Drawler
    {
        static public void DrawPlease(LIVE_TYPE _type)
        {
            switch (_type)
            {
                case LIVE_TYPE.HUMANOID:
                    //_graphics.DrawEllipse(new Pen(new SolidBrush(Color.Red)), new Rectangle(15, 6, 3, 3));
                    //_graphics.DrawEllipse(new Pen(new SolidBrush(Color.Red)), new Rectangle(15, 15, 3, 5));

                    //_graphics.DrawEllipse(new SolidColorBrush(Colors.Red), new Pen(new SolidColorBrush(Colors.Black), 1), new System.Windows.Point(15, 6), 3, 3);
                    //_graphics.DrawEllipse(new SolidColorBrush(Colors.Red), new Pen(new SolidColorBrush(Colors.Black), 1), new System.Windows.Point(15, 15), 3, 5);
                    //_graphics.DrawLine(new Pen(new SolidColorBrush(Colors.Black), 1), new Point(14, 20), new Point(12, 27));
                    //_graphics.DrawLine(new Pen(new SolidColorBrush(Colors.Black), 1), new Point(16, 20), new Point(18, 27));
                    //_graphics.DrawLine(new Pen(new SolidColorBrush(Colors.Black), 1), new Point(14, 11), new Point(7, 13));
                    //_graphics.DrawLine(new Pen(new SolidColorBrush(Colors.Black), 1), new Point(16, 11), new Point(23, 13));
                    break;
            }
        }

        public static void GetDrContext(System.Windows.Media.DrawingContext drawingContext, LIVE_TYPE type, bool isSelect, string name)
        {
            if (type == LIVE_TYPE.HUMANOID)
            {
                drawingContext.DrawEllipse(new SolidColorBrush(Colors.Red), new Pen(new SolidColorBrush(Colors.Black), 1), new System.Windows.Point(15, 6), 3, 3);
                drawingContext.DrawEllipse(new SolidColorBrush(Colors.Red), new Pen(new SolidColorBrush(Colors.Black), 1), new System.Windows.Point(15, 15), 3, 5);
                drawingContext.DrawLine(new Pen(new SolidColorBrush(Colors.Black), 1), new Point(14, 20), new Point(12, 27));
                drawingContext.DrawLine(new Pen(new SolidColorBrush(Colors.Black), 1), new Point(16, 20), new Point(18, 27));
                drawingContext.DrawLine(new Pen(new SolidColorBrush(Colors.Black), 1), new Point(14, 11), new Point(7, 13));
                drawingContext.DrawLine(new Pen(new SolidColorBrush(Colors.Black), 1), new Point(16, 11), new Point(23, 13));
                drawingContext.DrawText(new FormattedText(name, System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 12, new SolidColorBrush(Colors.Green)), new Point(0,30));
                if (isSelect)
                    drawingContext.DrawLine(new Pen(new SolidColorBrush(Colors.Green), 1), new Point(7, 11), new Point(7, 27));
            }
            if (type == LIVE_TYPE.DOG)
            {
                drawingContext.DrawEllipse(new SolidColorBrush(Colors.Blue), new Pen(new SolidColorBrush(Colors.Black), 1), new System.Windows.Point(10, 15), 3, 3);
                drawingContext.DrawEllipse(new SolidColorBrush(Colors.Blue), new Pen(new SolidColorBrush(Colors.Black), 1), new System.Windows.Point(15, 20), 5, 3);
                drawingContext.DrawLine(new Pen(new SolidColorBrush(Colors.Black), 1), new Point(12, 23), new Point(10, 27));
                drawingContext.DrawLine(new Pen(new SolidColorBrush(Colors.Black), 1), new Point(12, 23), new Point(14, 27));
                drawingContext.DrawLine(new Pen(new SolidColorBrush(Colors.Black), 1), new Point(18, 23), new Point(16, 27));
                drawingContext.DrawLine(new Pen(new SolidColorBrush(Colors.Black), 1), new Point(18, 23), new Point(20, 27));
                drawingContext.DrawLine(new Pen(new SolidColorBrush(Colors.Black), 1), new Point(20, 20), new Point(23, 14));
                drawingContext.DrawText(new FormattedText(name, System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 12, new SolidColorBrush(Colors.Green)), new Point(0, 30));
                if (isSelect)
                    drawingContext.DrawLine(new Pen(new SolidColorBrush(Colors.Green), 1), new Point(7, 11), new Point(7, 27));
            }
        }
        static public void Draw3D()
        {
        }
    }
}
