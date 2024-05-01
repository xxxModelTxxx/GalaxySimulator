namespace UI
{
    public interface IRenderView
    {
        Graphics    GetGraphics();
        void        SetSize(int width, int height);
        void        Redraw();
    }
}
