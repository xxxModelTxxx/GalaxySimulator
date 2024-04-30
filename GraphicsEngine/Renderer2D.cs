using System.Drawing;
using System.Numerics;

namespace GraphicsEngine
{
    public class Renderer2D
    {
        private Graphics    _graphicInstance;
        private Pen         _penInstance;

        public Renderer2D(Graphics graphics)
        {
            _graphicInstance = graphics;
            _penInstance = new Pen(Color.Red, 1.0f);
        }

        public void ClearGraphic()
        {
            _graphicInstance.Clear(Color.White);
        }
        public void RenderPoint(Point point)
        {
            _graphicInstance.DrawLine(_penInstance, point.X - 1, point.Y, point.X + 1, point.Y);
            _graphicInstance.DrawLine(_penInstance, point.X, point.Y - 1, point.X, point.Y + 1);
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

        private Point ConvertVectorToPoint(Vector2 vector)
        {
            return new Point((int)vector.X, (int)vector.Y);
        }
    }
}
