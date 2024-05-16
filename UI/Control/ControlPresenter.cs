using PhysicsEngine;

namespace UI.Control
{
    public class ControlPresenter: IControlPresenter
    {
        private IControlView _controlView;

        public ControlPresenter(IControlView controlView)
        {
            _controlView = controlView;
        }

        public void SetGravityConstant(float value)
        {
            PhysicalConstants.GravityConstant = value;
            _controlView.SetGravityConstantDisplay(value.ToString());
        }
        public void SetLightSpeed(float value)
        {
            PhysicalConstants.LightSpeed = value;
            _controlView.SetLightSpeedDisplay(value.ToString());
        }
        public void SetLightSpeedRatio(float value)
        {
            PhysicalConstants.NearLightSpeedRatio = value;
            _controlView.SetLightSpeedRatioDisplay(value.ToString());
        }
        public void SetTimeStep(float value)
        {
            PhysicalConstants.TimeStep = value;
            _controlView.SetTimeStepDisplay(value.ToString());
        }
    }
}
