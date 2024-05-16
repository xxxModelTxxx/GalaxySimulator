using PhysicsEngine;
using UI.Control;

namespace UI
{
    public partial class ControlView : Form, IControlView
    {
        private IControlPresenter _controlPresenter;

        public ControlView()
        {
            InitializeComponent();
            InitializeControlPresenter();
        }

        public void SetGravityConstantDisplay(string text)
        {
            throw new NotImplementedException();
        }
        public void SetLightSpeedDisplay(string text)
        {
            throw new NotImplementedException();
        }
        public void SetLightSpeedRatioDisplay(string text)
        {
            throw new NotImplementedException();
        }
        public void SetTimeStepDisplay(string text)
        {
            throw new NotImplementedException();
        }

        private void InitializeControlPresenter()
        {
            _controlPresenter = new ControlPresenter(this);
        }

        private void gravityTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _controlPresenter.SetGravityConstant(float.Parse(gravityTextBox.Text));
            }
            catch
            {
                gravityTextBox.Text = PhysicalConstants.GravityConstant.ToString();
            }
        }
        private void lightSpeedTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _controlPresenter.SetLightSpeed(float.Parse(lightSpeedTextBox.Text));
            }
            catch
            {
                lightSpeedTextBox.Text = PhysicalConstants.LightSpeed.ToString();
            }
        }
        private void lightSpeedRatioTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _controlPresenter.SetLightSpeedRatio(float.Parse(lightSpeedRatioTextBox.Text));
            }
            catch
            {
                lightSpeedRatioTextBox.Text = PhysicalConstants.NearLightSpeedRatio.ToString();
            }
        }
        private void timeStepTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _controlPresenter.SetTimeStep(float.Parse(timeStepTextBox.Text));
            }
            catch
            {
                timeStepTextBox.Text = PhysicalConstants.TimeStep.ToString();
            }
        }
    }
}
