using GraphicsEngine;
using PhysicsEngine;
using System.Drawing;

namespace UI
{
    internal class RenderPresenter : IRenderPresenter
    {
        private Space2D     _space;
        private IRenderView _renderView;
        private Renderer2D  _renderer;

        public RenderPresenter(IRenderView renderView)
        {
            _space = InitializeSpace();
            _renderView = InitializeRenderView(renderView);
            _renderer = InitializeRenderer(_renderView.GetGraphics());
        }

        public Renderer2D GetRenderer => _renderer;

        private Space2D InitializeSpace()
        {
            return new Space2D();
        }
        private IRenderView InitializeRenderView(IRenderView renderView)
        {
            _renderView = renderView;
            _renderView.SetSize(_space.Width, _space.Height);
            return _renderView;
        }
        private Renderer2D InitializeRenderer(Graphics graphics)
        {
            return new Renderer2D(graphics, _space.Width, _space.Height, Color.White);
        }
    }
}
