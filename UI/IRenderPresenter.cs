using GraphicsEngine;
using PhysicsEngine;

namespace UI
{
    public interface IRenderPresenter
    {
        bool IsSimulationRunning { get; }
        Renderer2D GetRenderer { get; }
        Space2D GetSpace { get; }

        void RenderSpace(Graphics graphics);
        void Run();
        void Stop();
    }
}
