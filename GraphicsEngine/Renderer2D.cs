using System.Drawing;
using System.Numerics;
using System.Runtime.Versioning;

namespace GraphicsEngine
{
    [SupportedOSPlatform("windows")]
    public class Renderer2D
    {
        public const float              DefaultPenWidth         = 1.0f;

        public static readonly Color    DefaultBackgroundColor  = Color.White;
        public static readonly Color    DefaultPenColor         = Color.Red;

        private Pen         _penInstance;
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="graphics">Reference to Graphics class, being used for rendering.</param>
        /// <param name="width">Width of the rendering area.</param>
        /// <param name="height">Height of the rendering area</param>
        public Renderer2D()
        {
            _penInstance = new Pen(DefaultPenColor, DefaultPenWidth);
        }

        /// <summary>
        /// Clears rendering area with current background color.
        /// </summary>
        public void ClearGraphics(Graphics graphics)
        {
            graphics.Clear(DefaultBackgroundColor);
        }
        /// <summary>
        /// Clears background and sets provided background color.
        /// </summary>
        /// <param name="color">Color to be applied to background.</param>
        public void ClearGraphics(Graphics graphics, Color color)
        {
            graphics.Clear(color);
        }
        /// <summary>
        /// Renders single point from Point structure.
        /// </summary>
        /// <param name="point">Point structure to be rendered</param>
        public void RenderPoint(Graphics graphics, Point point)
        {
            graphics.DrawLine(_penInstance, point.X - 1, point.Y, point.X + 1, point.Y);
            graphics.DrawLine(_penInstance, point.X, point.Y - 1, point.X, point.Y + 1);
        }
        /// <summary>
        /// Renders multiple points from collection of Point structures.
        /// </summary>
        /// <param name="points">Reference to enumerable collection containing Point structures to be rendered.</param>
        public void RenderPoints(Graphics graphics, IEnumerable<Point> points)
        {
            foreach(Point p in points)
            {
                RenderPoint(graphics, p);
            }
        }
        /// <summary>
        /// Renders single point from Vector2 structure.
        /// </summary>
        /// <param name="vector">Vector2 structure to be rendered.</param>
        public void RenderPointFromVector(Graphics graphics, Vector2 vector)
        {
            Point p = ConvertVectorToPoint(vector);
            RenderPoint(graphics, p);
        }
        /// <summary>
        /// Renders multiple points from collection of Vector structures.
        /// </summary>
        /// <param name="vectors">Reference to enumerable collection of Vector2 structures.</param>
        public void RenderPointsFromVectors(Graphics graphics, IEnumerable<Vector2> vectors)
        {
            foreach (Vector2 v in vectors)
            {
                RenderPointFromVector(graphics, v);
            }
        }
        
        private Point ConvertVectorToPoint(Vector2 vector)
        {
            return new Point((int)vector.X, (int)vector.Y);
        }
    }
}
