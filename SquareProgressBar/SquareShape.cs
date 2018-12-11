using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SquareProgressBar
{
    public class SquareShape : Shape
    {
        private double relativeWidth = 0;
        private double relativeHeight = 0;
        private double perimeter;


        public double Value {
            get {
                return (double)GetValue(ValueProperty);
            }
            set {
                SetValue(ValueProperty, value);
            }
        }


        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value),
                                                                           typeof(double),
                                                                           typeof(SquareShape),
                                                                           new FrameworkPropertyMetadata(0D, FrameworkPropertyMetadataOptions.AffectsRender));


        public double MaxValue {
            get {
                return (double)GetValue(MaxValueProperty);
            }
            set {
                SetValue(MaxValueProperty, value);
            }
        }


        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(nameof(MaxValue),
                                                                           typeof(double),
                                                                           typeof(SquareShape),
                                                                           new PropertyMetadata(0.0));



        protected override Geometry DefiningGeometry {
            get {
                return GetShape();
            }
        }

        /// <summary>
        /// Returns the geometry shape
        /// </summary>
        /// <returns></returns>
        private Geometry GetShape()
        {
            var currentPerimeterPosition = CurrentPerimeterPosition;
            var height = RenderSize.Height;
            var width = RenderSize.Width;

            var side = GetSide();

            StreamGeometry geometryShape = new StreamGeometry();
            using (var context = geometryShape.Open())
            {
                context.BeginFigure(new Point(0, 0), false, false);

                if (side == 0)
                {
                    context.LineTo(new Point(0, currentPerimeterPosition), true, false);
                }
                else if (side == 1)
                {
                    context.LineTo(new Point(0, height), true, false);
                    context.LineTo(new Point((currentPerimeterPosition - height), height), true, false);
                }
                else if (side == 2)
                {
                    context.LineTo(new Point(0, height), true, false);
                    context.LineTo(new Point(width, height), true, false);

                    var yPosition = height - (currentPerimeterPosition - height - width);

                    context.LineTo(new Point(width, yPosition), true, false);
                }
                else if (side == 3)
                {
                    context.LineTo(new Point(0, height), true, false);
                    context.LineTo(new Point(width, height), true, false);
                    context.LineTo(new Point(width, 0), true, false);

                    var p = Perimeter;
                    var xPosition = p - currentPerimeterPosition;

                    context.LineTo(new Point(xPosition, 0), true, false);
                }

            }

            return geometryShape;
        }

        /// <summary>
        /// Returns the side for the current perimeter position.
        /// 
        /// Sides go from left = 0, bottom = 1,right = 2, top = 3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int GetSide()
        {
            var perimterPosition = CurrentPerimeterPosition;

            var renderedHeight = RenderSize.Height;
            var renderedWidth = RenderSize.Width;

            if (perimterPosition < renderedHeight)
            {
                return 0;
            }
            else if (perimterPosition > renderedHeight && perimterPosition < (renderedHeight + renderedWidth))
            {
                return 1;
            }
            else if (perimterPosition > (renderedHeight + renderedWidth) && perimterPosition < ((renderedHeight * 2) + renderedWidth))
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        #region properties

        /// <summary>
        /// Returns the current perimeter position for the current value
        /// </summary>
        private double CurrentPerimeterPosition {
            get {
                var currentPerimeterPosition = (this.Value * Perimeter) / MaxValue;
                Console.WriteLine($"Total perimeter: {perimeter} -- Current perimter position: {currentPerimeterPosition} -- Current value: {Value}");
                return currentPerimeterPosition;
            }
        }



        /// <summary>
        /// Returns the width relative to the maximum value
        /// </summary>
        private double RelativeWidth {
            get {
                if (relativeWidth == 0)
                {
                    var rWidth = (this.RenderSize.Width * MaxValue) / Perimeter;
                    relativeWidth = double.IsNaN(rWidth) ? 0 : rWidth;
                }
                return relativeHeight;
            }
        }


        /// <summary>
        /// Returns the height relative to the maximum value
        /// </summary>
        private double RelativeHeight {
            get {
                if (relativeHeight == 0)
                {
                    var rHeight = (this.RenderSize.Height * MaxValue) / Perimeter;
                    relativeHeight = double.IsNaN(rHeight) ? 0 : rHeight;
                }
                return relativeHeight;
            }
        }

        

        /// <summary>
        /// Total perimter of the shape
        /// </summary>
        private double Perimeter {
            get {
                if (perimeter == 0)
                {
                    //- We continue to calculate the perimeter until it's larger than 0.
                    //- RenderSize is cero until it's rendered, so we need to continue calculating while it's cero.
                    perimeter = (this.RenderSize.Height * 2) + (this.RenderSize.Width * 2);
                }
                return perimeter;
            }
        }


        #endregion
    }
}