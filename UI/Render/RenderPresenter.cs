using Config;
using GraphicsEngine;
using PhysicsEngine;


namespace UI
{
    public class RenderPresenter : IRenderPresenter
    {
        private bool _isSimulationRunning;
        private Space2D _space;
        private IRenderView _renderView;
        private Renderer2D _renderer;

        public RenderPresenter(IRenderView renderView)
        {
            _isSimulationRunning = false;
            _renderView = InitializeRenderView(renderView, Param.SpaceWidth, Param.SpaceHeight);
            _space = InitializeSpace(Param.SpaceWidth, Param.SpaceHeight, Param.NoOfStars, Param.StarMassMin, Param.StarMassMax);
            _renderer = new Renderer2D();
        }

        public bool IsSimulationRunning => _isSimulationRunning;
        public Renderer2D GetRenderer => _renderer;
        public Space2D GetSpace => _space;

        public void RenderSpace(Graphics graphics)
        {
            ClearGraphics();
            RenderStars();
            void ClearGraphics()
            {
                _renderer.ClearGraphics(graphics);
            }
            void RenderStars()
            {
                foreach (Star2D s in _space.Stars)
                {
                    _renderer.RenderPointFromVector(graphics, s.PositionVector);
                }
            }
        }
        public async void Run()
        {
            _isSimulationRunning = true;
            while (_isSimulationRunning)
            {
                CalculateSpace();
                _renderView.RefreshRender();
                //await Task.Delay(1000 / Param.RenderingFramesPerSecond);
                await Task.Delay(10);
            }
        }
        public void Stop()
        {
            _isSimulationRunning = false;
        }
        private void CalculateSpace()
        {
                Task.Run(() => _space.SimulationStepForward());
        }
        private void Timer()
        {
            Task.Delay(1000 / Param.RenderingFramesPerSecond);
        }
        private IRenderView InitializeRenderView(IRenderView renderView, int width, int height)
        {
            renderView.SetSize(width, height);
            return renderView;
        }
        private Space2D InitializeSpace(int width, int height, int noOfStars, float massMin, float massMax)
        {
            Space2D space = new Space2D(width, height);
            float rnd = (float)noOfStars / (width * height);
            space.GenerateStars((float)noOfStars/(width*height), massMin, massMax);
            return space;
        }
    }
}
