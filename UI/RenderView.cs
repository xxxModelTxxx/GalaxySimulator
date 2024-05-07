namespace UI
{
    public partial class RenderView : Form, IRenderView
    {
        IRenderPresenter _renderPresenter;

        public RenderView()
        {
            InitializeComponent();
            InitializeRenderPresenter();
        }

        public IRenderPresenter RenderPresenter => _renderPresenter;

        public void SetSize(int width, int height)
        {
            pictureBox1.Width = width;
            pictureBox1.Height = height;
            RefreshRender();
        }
        public void RefreshRender()
        {
            pictureBox1.Refresh();
        }


        private void InitializeRenderPresenter()
        {
            _renderPresenter = new RenderPresenter(this);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            _renderPresenter.RenderSpace(e.Graphics);
        }

        private void RenderView_Load(object sender, EventArgs e)
        {
            _renderPresenter.Run();
        }

        private void RenderView_FormClosing(object sender, FormClosingEventArgs e)
        {
            _renderPresenter.Stop();
        }
    }
}
