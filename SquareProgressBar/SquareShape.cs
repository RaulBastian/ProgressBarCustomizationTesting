using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SquareProgressBar
{
    public class SquareShape : Shape
    {
        // Side count, could possibly use other side counts for poligons, instead of squares?
        private const int side_count = 4;

        public double Value
        {
            get
            {
                return (double)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }


        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value),
                                                                           typeof(double),
                                                                           typeof(SquareShape),
                                                                           new PropertyMetadata(0.0));


        public double MaxValue
        {
            get
            {
                return (double)GetValue(MaxValueProperty);
            }
            set
            {
                SetValue(MaxValueProperty, value);
            }
        }


        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(nameof(MaxValue),
                                                                           typeof(double),
                                                                           typeof(SquareShape),
                                                                           new PropertyMetadata(0.0));



        protected override Geometry DefiningGeometry
        {
            get
            {
                return GetShape();
            }
        }


        private Geometry GetShape()
        {
            var current = GetRelativeValue();
            var height = GetRelativeHeight();
            var width = GetRelativeWidth();

            var side = GetSide(this.Value);

            StreamGeometry geometryShape = new StreamGeometry();
            using (var context = geometryShape.Open())
            {
                context.BeginFigure(new Point(0, 0), false, false);

                context.LineTo(new Point(this.Width, this.Height), true, false);


                if (side == 0)
                {
                    context.LineTo(new Point(0, current), true, false);
                }
                else if (side == 1)
                {
                    context.LineTo(new Point(0, height), true, false);
                    context.LineTo(new Point(current, height), true, false);
                }
                else if (side == 2)
                {
                    context.LineTo(new Point(0, height), true, false);
                    context.LineTo(new Point(width, height), true, false);

                    var yPosition = height - (current - height - width);

                    context.LineTo(new Point(width, yPosition), true, false);
                }
                else if (side == 3)
                {
                    context.LineTo(new Point(0, height), true, false);
                    context.LineTo(new Point(width, height), true, false);
                    context.LineTo(new Point(width, 0), true, false);

                    var xPosition = width - (current - height - width - height);
                    context.LineTo(new Point(xPosition, 0), true, false);
                }

            }

            return geometryShape;

            //StreamGeometry geom = new StreamGeometry();
            //using (StreamGeometryContext gc = geom.Open())
            //{
            //    // isFilled = false, isClosed = true
            //    gc.BeginFigure(new Point(0, 0), false, true);
            //        gc.LineTo(new Point(this.RenderSize.Width, this.RenderSize.Height), false, false);
            //    //gc.ArcTo(new Point(75.0, 75.0), new Size(10.0, 20.0), 0.0, false, SweepDirection.Clockwise, true, true);
            //    //gc.ArcTo(new Point(100.0, 100.0), new Size(10.0, 20.0), 0.0, false, SweepDirection.Clockwise, true, true);
            //}

            //return geom;

        }


        private int GetSide(double value)
        {
            var current = GetRelativeValue();
            var height = GetRelativeHeight();
            var width = GetRelativeWidth();

            if (current < height)
            {
                return 0;
            }
            else if(current > height && current < (height + width))
            {
                return 1;
            }
            else if (current > (height + width) && current < ((height * 2) + width))
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        private double GetRelativeValue()
        {
            var perimeter = (this.Height * 2) + (this.Width * 2);
            return (this.Value * MaxValue) / perimeter;
        }


        private double GetRelativeHeight()
        {
          var perimeter = (this.Height * 2) + (this.Width * 2);
           return (this.Height * MaxValue) / perimeter;
        }

        private double GetRelativeWidth()
        {
            var perimeter = (this.Height * 2) + (this.Width * 2);
            return (this.Width * MaxValue) / perimeter;
        }

    }
}