using GraphicsEngine;
using PhysicsEngine;
using System.Drawing;

namespace UI
{
    internal class RenderPresenter : IRenderPresenter
    {
        private Space2D     _space;
        private IRenderView _renderView;
        private Graphics    _graphics;
        private Renderer2D  _renderer;

        public RenderPresenter(IRenderView renderView)
        {
            InitializeSpace();
            InitializeRenderView(renderView);
            InitializeGraphics(renderView);
            InitializeRenderer(_graphics);
        }

        public Renderer2D GetRenderer => _renderer;

        private void InitializeSpace()
        {
            _space = new Space2D();
        }
        private void InitializeRenderView(IRenderView renderView)
        {
            _renderView = renderView;
            _renderView.SetSize(PhysicalConstants.DefaultSpaceSizeX, PhysicalConstants.DefaultSpaceSizeY);
        }
        private void InitializeGraphics(IRenderView renderView)
        {
            _graphics = _renderView.GetGraphics();
            _graphics.Clip.MakeEmpty();
            _graphics.Clip.Union(new Rectangle(0, 0, _space.Width, _space.Height));
        }
        private void InitializeRenderer(Graphics graphics)
        {
            _renderer = new Renderer2D(_graphics);
        }
    }
}
