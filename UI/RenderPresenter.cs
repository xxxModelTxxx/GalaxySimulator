using Config;
using GraphicsEngine;
using PhysicsEngine;


namespace UI
{
    public class RenderPresenter : IRenderPresenter
    {
        private bool _isSimulationRunning;
        private Space2D _space;
        private Queue<Space2D> _spaceBuffer;
        private IRenderView _renderView;
        private Renderer2D _renderer;

        public RenderPresenter(IRenderView renderView)
        {
            _isSimulationRunning = false;
            _renderView = InitializeRenderView(renderView, Param.SpaceWidth, Param.SpaceHeight);
            _space = InitializeSpace(Param.SpaceWidth, Param.SpaceHeight, Param.NoOfStars, Param.StarMassMin, Param.StarMassMax);
            _spaceBuffer = new Queue<Space2D>(Param.SpaceBufferSize);
            _renderer = new Renderer2D();
        }

        public bool IsSimulationRunning => _isSimulationRunning;
        public Renderer2D GetRenderer => _renderer;
        public Space2D GetSpace => _space;

        public void RenderSpace(Graphics graphics)
        {
            ClearGraphics();
            RenderStars();

            // Local functions
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
        public async Task Run()
        {
            _isSimulationRunning = true;
            // rozpocznij task renderowania
            // rozpocznij task rysowania
            Task RenderingTask = new Task(RenderSpace);
            Task PhysicsTask = new Task(CalculateSpace);
            PhysicsTask.Start();
        }
        public void Stop()
        {
            _isSimulationRunning = false;
        }
        private void CalculateSpace()
        {
            while (_isSimulationRunning)
            {
                _space.SimulationStepForward();
            }
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
