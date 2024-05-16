namespace UI.Control
{
    public interface IControlPresenter
    {
        void SetGravityConstant(float value);
        void SetLightSpeed(float value);
        void SetLightSpeedRatio(float value);
        void SetTimeStep(float value);
    }
}
