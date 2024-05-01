namespace UI
{
    public partial class RenderView : Form, IRenderView
    {
        private IRenderPresenter _renderPresenter;

        public RenderView()
        {
            InitializeComponent();
            _renderPresenter = new RenderPresenter(this);
        }

        public Graphics GetGraphics()
        {
            return pictureBox1.CreateGraphics();
        }
        public void SetSize(int width, int height)
        {
            pictureBox1.Width = width;
            pictureBox1.Height = height;
            pictureBox1.Refresh();
            this.Refresh();
        }
        public void Redraw()
        {
            pictureBox1.Refresh();
        }
        private void RenderView_Load(object sender, EventArgs e)
        {

        }
    }
}
