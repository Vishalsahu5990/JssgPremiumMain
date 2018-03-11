using System;
using System.Drawing;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using MvvmTest.CustomRenderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace MvvmTest.iOS.CustomRenderer
{
    public class CalendarDayView: UIView
    {
        /// <summary>
        /// The paragraph style
        /// </summary>
        private static NSMutableParagraphStyle paragraphStyle;

        /// <summary>
        /// The _text
        /// </summary>
        private string _text;

        /// <summary>
        /// The text dot.
        /// </summary>
        private string _textDot;

        /// <summary>
        /// The _old backgorund color
        /// </summary>
        private UIColor _oldBackgorundColor;

        /// <summary>
        /// The _active
        /// </summary>
        private bool _active, _today, _selected, _marked, _available, _highlighted;

        /// <summary>
        /// The _MV
        /// </summary>
        private readonly CalendarMonthView _mv;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarDayView"/> class.
        /// </summary>
        /// <param name="mv">The mv.</param>
        public CalendarDayView(CalendarMonthView mv)
        {
            _mv = mv;
            BackgroundColor = mv.StyleDescriptor.DateBackgroundColor;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CalendarDayView"/> is available.
        /// </summary>
        /// <value><c>true</c> if available; otherwise, <c>false</c>.</value>
        public bool Available { get { return _available; } set { _available = value; SetNeedsDisplay(); } }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get { return _text; } set { _text = value; SetNeedsDisplay(); } }

        //
        public string TextDot { get { return _textDot; } set { _textDot = value; SetNeedsDisplay(); } }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CalendarDayView"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active { get { return _active; } set { _active = value; SetNeedsDisplay(); } }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CalendarDayView"/> is today.
        /// </summary>
        /// <value><c>true</c> if today; otherwise, <c>false</c>.</value>
        public bool Today { get { return _today; } set { _today = value; SetNeedsDisplay(); } }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CalendarDayView"/> is selected.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        public bool Selected { get { return _selected; } set { _selected = value; SetNeedsDisplay(); } }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CalendarDayView"/> is marked.
        /// </summary>
        /// <value><c>true</c> if marked; otherwise, <c>false</c>.</value>
        public bool Marked { get { return _marked; } set { _marked = value; SetNeedsDisplay(); } }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CalendarDayView"/> is highlighted.
        /// </summary>
        /// <value><c>true</c> if highlighted; otherwise, <c>false</c>.</value>
        public bool Highlighted { get { return _highlighted; } set { _highlighted = value; SetNeedsDisplay(); } }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Draws the specified rect.
        /// </summary>
        /// <param name="rect">The rect.</param>

        public override void Draw(CGRect rect)
        {
            

            UIImage img = null;
            var color = _mv.StyleDescriptor.InactiveDateForegroundColor;
            BackgroundColor = _mv.StyleDescriptor.InactiveDateBackgroundColor;
            var backgroundStyle = CalendarView.BackgroundStyle.Fill;


            if (!Active || !Available)
            {
                if (Highlighted)
                {
                    BackgroundColor = _mv.StyleDescriptor.HighlightedDateBackgroundColor;
                }
                //color = UIColor.FromRGBA(0.576f, 0.608f, 0.647f, 1f);
                //img = UIImage.FromBundle("Resources/circle.png");
            }
            else if (Today && Selected)
            {
                color = _mv.StyleDescriptor.SelectedDateForegroundColor;
                BackgroundColor = _mv.StyleDescriptor.SelectedDateBackgroundColor;
                backgroundStyle = _mv.StyleDescriptor.SelectionBackgroundStyle;
                //img = UIImage.FromBundle("Resources/circle.png").CreateResizableImage(new UIEdgeInsets(4,4,4,4));
            }
            else if (Today)
            {
                color = _mv.StyleDescriptor.TodayForegroundColor;
                BackgroundColor = _mv.StyleDescriptor.TodayBackgroundColor;
                backgroundStyle = _mv.StyleDescriptor.TodayBackgroundStyle;
                //img = UIImage.FromBundle("Resources/circle.png").CreateResizableImage(new UIEdgeInsets(4,4,4,4));
            }
            else if (Selected || Marked)
            {
                //color = UIColor.White;
                color = _mv.StyleDescriptor.SelectedDateForegroundColor;
                BackgroundColor = _mv.StyleDescriptor.SelectedDateBackgroundColor;
                backgroundStyle = _mv.StyleDescriptor.SelectionBackgroundStyle;
                //img = UIImage.FromBundle("Resources/circle.png").CreateResizableImage(new UIEdgeInsets(4,4,4,4));
            }
           
            else if (Highlighted)
            {
                color = _mv.StyleDescriptor.HighlightedDateForegroundColor;
                BackgroundColor = _mv.StyleDescriptor.HighlightedDateBackgroundColor;
            }
            else
            {
                if(Date>DateTime.Now.Date)
                {
                    color = _mv.StyleDescriptor.DateForegroundColor;  
                }
                else
                {
                    color = _mv.StyleDescriptor.SelectedDateForegroundColor;
                    BackgroundColor = _mv.StyleDescriptor.SelectedDateBackgroundColor;
                    backgroundStyle = _mv.StyleDescriptor.SelectionBackgroundStyle;
                }
               
               
                img = UIImage.FromBundle("1Quarter.png").CreateResizableImage(new UIEdgeInsets(4,4,4,4));
            }
            //var smallerSide = Math.Min(_mv.BoxWidth, _mv.BoxHeight);
            //var center = new CGPoint(_mv.BoxWidth / 2, _mv.BoxHeight / 2);
            //if (img != null)
            //    img.Draw(new RectangleF((float)center.X - smallerSide / 2, (float)center.Y - smallerSide / 2, smallerSide, smallerSide));
            var context = UIGraphics.GetCurrentContext();
            if (_oldBackgorundColor != BackgroundColor)
            {
                if (backgroundStyle == CalendarView.BackgroundStyle.Fill)
                {
                    context.SetFillColor(BackgroundColor.CGColor);
                    context.FillRect(new CGRect(0, 0, _mv.BoxWidth, _mv.BoxHeight));
                }
                else
                {
                    context.SetFillColor(Highlighted
                        ? _mv.StyleDescriptor.HighlightedDateBackgroundColor.CGColor
                        : _mv.StyleDescriptor.DateBackgroundColor.CGColor);

                    context.FillRect(new CGRect(0, 0, _mv.BoxWidth, _mv.BoxHeight));

                    var smallerSide = Math.Min(_mv.BoxWidth, _mv.BoxHeight);
                    var center = new CGPoint(_mv.BoxWidth / 2, _mv.BoxHeight / 2);
                    var circleArea = new CGRect(center.X - smallerSide / 2, center.Y - smallerSide / 2, smallerSide, smallerSide);
                    var circleArea1 = new CGRect(center.X - smallerSide / 2, center.Y - smallerSide / 2, smallerSide, smallerSide);



                    if (backgroundStyle == CalendarView.BackgroundStyle.CircleFill)
                    {
                        context.SetFillColor(BackgroundColor.CGColor);
                        context.FillEllipseInRect(circleArea.Inset((nfloat)0.5, (nfloat)0.5));
                       
                     }
                    else
                    {
                        //Setting outline color and width in date
                        context.SetLineWidth(2);
                        //context.SetStrokeColor(Color.Black.ToCGColor());
                        context.StrokeEllipseInRect(circleArea.Inset(2, 2));
                        //context.DrawImage(circleArea,new UIImage.("circle.png"));

                    }
                }
            }


            color.SetColor();
            var inflated = new CGRect(0, 0, Bounds.Width, Bounds.Height);
            var inflatedDot = new CGRect(0, 7, Bounds.Width, Bounds.Height);
           
            DrawDateString((NSString)Text, color, inflated,_mv.StyleDescriptor.DateLabelFont);

            //Manually drawing Dot view just buttom of day view
            //Changing dot color according to conditions
            if (Date.Date == DateTime.Now.Date)
            {
                //_mv.StyleDescriptor.DotColor = Color.Red.ToUIColor();
                //BackgroundColor = _mv.StyleDescriptor.SelectedDateBackgroundColor;
            }
            else
            {
                //_mv.StyleDescriptor.DotColor = Color.FromHex("5856D6").ToUIColor();
                //BackgroundColor = UIColor.White;
            }
            
            DrawDateString((NSString)TextDot,_mv.StyleDescriptor.DotColor, inflatedDot, _mv.StyleDescriptor.DotLabelFont);

                
           
            _oldBackgorundColor = BackgroundColor;
            //Console.WriteLine("Drawing of cell took {0} msecs",(DateTime.Now-dt).TotalMilliseconds);
        }

        /// <summary>
        /// Draws the date string.
        /// </summary>
        /// <param name="dateString">The date string.</param>
        /// <param name="color">The color.</param>
        /// <param name="rect">The rect.</param>
        private void DrawDateString(NSString dateString, UIColor color, CGRect rect,UIFont styleDescriptor)
        {
           
            if (paragraphStyle == null)
            {
                paragraphStyle = (NSMutableParagraphStyle)NSParagraphStyle.Default.MutableCopy();
                paragraphStyle.LineBreakMode = UILineBreakMode.TailTruncation;
                paragraphStyle.Alignment = UITextAlignment.Center;

            }
            var attrs = new UIStringAttributes()
            {
                Font = styleDescriptor,
                ForegroundColor = color,
                ParagraphStyle = paragraphStyle,
            };
            var size = dateString.GetSizeUsingAttributes(attrs);
            var targetRect = new CGRect(
                rect.X + (float)Math.Floor((rect.Width - size.Width) / 2f),
                rect.Y + (float)Math.Floor((rect.Height - size.Height) / 2f),
                                        size.Width,
                                        size.Height
                                    );
            dateString.DrawString(targetRect, attrs);
        }

       
    }
}
