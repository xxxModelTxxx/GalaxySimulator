using System.Drawing;
using System.Numerics;
using System.Runtime.Versioning;

namespace GraphicsEngine
{
    [SupportedOSPlatform("windows")]
    public class Renderer2D
    {
        private Graphics    _graphics;
        private Pen         _penInstance;

        public Renderer2D(Graphics graphics, int width, int height, Color color)
        {
            _graphics = InitializeGraphics(graphics, width, height, color);
            _penInstance = new Pen(Color.Red, 1.0f);
        }

        public void ClearGraphic()
        {
            _graphics.Clear(Color.White);
        }
        public void ClearGraphic(Color color)
        {
            _graphics.Clear(color);
        }
        public void RenderPoint(Point point)
        {
            _graphics.DrawLine(_penInstance, point.X - 1, point.Y, point.X + 1, point.Y);
            _graphics.DrawLine(_penInstance, point.X, point.Y - 1, point.X, point.Y + 1);
        }
        public void RenderPoints(IEnumerable<Point> points)
        {
            foreach(Point p in points)
            {
                RenderPoint(p);
            }
        }
        public void RenderPointFromVector(Vector2 vector)
        {
            Point p = ConvertVectorToPoint(vector);
            RenderPoint(p);
        }
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
