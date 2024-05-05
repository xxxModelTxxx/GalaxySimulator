using System.Drawing;
using System.Numerics;
using System.Runtime.Versioning;

namespace GraphicsEngine
{
    [SupportedOSPlatform("windows")]
    public class Renderer2D
    {
        private static readonly Color    DefaultBackgroundColor = Color.White;

        private Color       _backgroundColor;
        private Graphics    _graphics;
        private Pen         _penInstance;
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="graphics">Reference to Graphics class, being used for rendering.</param>
        /// <param name="width">Width of the rendering area.</param>
        /// <param name="height">Height of the rendering area</param>
        public Renderer2D(Graphics graphics, int width, int height)
        {
            _backgroundColor = DefaultBackgroundColor;
            _graphics = InitializeGraphics(graphics, width, height, _backgroundColor);
            _penInstance = new Pen(Color.Red, 1.0f);
        }

        /// <summary>
        /// Gets or sets rendering area background color.
        /// </summary>
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        /// <summary>
        /// Clears rendering area with current background color.
        /// </summary>
        public void ClearGraphics()
        {
            _graphics.Clear(_backgroundColor);
        }
        /// <summary>
        /// Clears background and sets provided background color.
        /// </summary>
        /// <param name="color">Color to be applied to background.</param>
        public void ClearGraphics(Color color)
        {
            _backgroundColor = color;
            ClearGraphics();
        }
        /// <summary>
        /// Renders single point from Point structure.
        /// </summary>
        /// <param name="point">Point structure to be rendered</param>
        public void RenderPoint(Point point)
        {
            _graphics.DrawLine(_penInstance, point.X - 1, point.Y, point.X + 1, point.Y);
            _graphics.DrawLine(_penInstance, point.X, point.Y - 1, point.X, point.Y + 1);
        }
        /// <summary>
        /// Renders multiple points from collection of Point structures.
        /// </summary>
        /// <param name="points">Reference to enumerable collection containing Point structures to be rendered.</param>
        public void RenderPoints(IEnumerable<Point> points)
        {
            foreach(Point p in points)
            {
                RenderPoint(p);
            }
        }
        /// <summary>
        /// Renders single point from Vector2 structure.
        /// </summary>
        /// <param name="vector">Vector2 structure to be rendered.</param>
        public void RenderPointFromVector(Vector2 vector)
        {
            Point p = ConvertVectorToPoint(vector);
            RenderPoint(p);
        }
        /// <summary>
        /// Renders multiple points from collection of Vector structures.
        /// </summary>
        /// <param name="vectors">Reference to enumerable collection of Vector2 structures.</param>
        public void RenderPointsFromVectors(IEnumerable<Vector2> vectors)
        {
            foreach (Vector2 v in vectors)
            {
                RenderPointFromVector(v);
            }
        }
        
        private Graphics InitializeGraphics(Graphics graphics, int width, int height, Color color)
        {
            _graphics = graphics;
            _graphics.Clip.MakeEmpty();
            _graphics.Clip.Union(new Rectangle(0, 0, width, height));
            _graphics.Clear(color);
            return _graphics;
        }
        private Point ConvertVectorToPoint(Vector2 vector)
        {
            return new Point((int)vector.X, (int)vector.Y);
        }
    }
}
