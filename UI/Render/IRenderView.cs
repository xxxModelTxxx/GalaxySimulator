namespace UI
{
    public interface IRenderView
    {
        IRenderPresenter RenderPresenter { get; }

        void    SetSize(int width, int height);
        void    RefreshRender();
    }
}
