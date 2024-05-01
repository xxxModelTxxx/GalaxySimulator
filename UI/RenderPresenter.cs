using GraphicsEngine;
using PhysicsEngine;

namespace UI
{
    internal class RenderPresenter : IRenderPresenter
    {
        private bool _isSimulationRunning;
        private Space2D _space;
        private IRenderView _renderView;
        private Renderer2D _renderer;

        public RenderPresenter(IRenderView renderView)
        {
            _isSimulationRunning = false;
            _space = InitializeSpace();
            _renderView = InitializeRenderView(renderView);
            _renderer = InitializeRenderer(_renderView.GetGraphics());
        }

        public Renderer2D GetRenderer => _renderer;

        public Task[] Run()
        {
            _isSimulationRunning = true;
            Task PhysicsTask = new Task(CalculateSpace);
            Task RenderingTask = new Task(RenderSpace);

            PhysicsTask.Start();
            RenderingTask.Start();

            return [PhysicsTask, RenderingTask];
        }
        public void Stop()
        {
            _isSimulationRunning = false;
        }
        private void RenderSpace()
        {
            while (_isSimulationRunning)
            {
                ClearGraphics();
                RenderStars();
                _renderView.RefreshRender();
            }

            // Local functions
            void ClearGraphics()
            {
                _renderer.ClearGraphics();
            }
            void RenderStars()
            {
                foreach (Star2D s in _space.Stars)
                {
                    _renderer.RenderPointFromVector(s.PositionVector);
                }
            }
        }
        private void CalculateSpace()
        {
            while (_isSimulationRunning)
            {
                _space.SimulationStepForward();
            }
        }
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
            return new Renderer2D(graphics, _space.Width, _space.Height);
        }
    }
}
