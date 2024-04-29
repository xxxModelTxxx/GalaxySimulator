namespace PhysicsEngine
{
    /// <summary>
    /// Static class containing basic parameters to run the space simulation. 
    /// </summary>
    public static class PhysicalConstants
    {
        private const float DefaultGravityConstant = 1;
        private const float DefaultLightSpeed = 100;
        private const float DefaultTimeStep = 1;
        private const int ModificationMultiplier = 10;

        private static float _gravityConstant;
        private static float _lightSpeed;
        private static float _timeStep;

        /// <summary>
        /// Returns gravity constant.
        /// </summary>
        public static float GravityConstant => _gravityConstant;
        /// <summary>
        /// Returns speed of light value;
        /// </summary>
        public static float LightSpeed => _lightSpeed;

        /// <summary>
        /// Returns time length of single simulation step.
        /// </summary>
        public static float TimeStep => _timeStep;

        /// <summary>
        /// Constructor.
        /// </summary>
        static PhysicalConstants()
        {
            _gravityConstant = DefaultGravityConstant;
            _lightSpeed = DefaultLightSpeed;
            _timeStep = DefaultTimeStep;
        }

        /// <summary>
        /// Increases gravity contant by xMultiplier.
        /// </summary>
        public static void IncreaseGravity()
        {
            _gravityConstant = _gravityConstant * ModificationMultiplier;
        }
        /// <summary>
        /// Decreases gravity contant by xMultiplier.
        /// </summary>
        public static void DecreaseGravity()
        {
            _gravityConstant = _gravityConstant / ModificationMultiplier;
        }
        /// <summary>
        /// Increases speed of light by xMultiplier.
        /// </summary>
        public static void IncreaseLightSpeed()
        {
            _lightSpeed = _lightSpeed * ModificationMultiplier;
        }
        /// <summary>
        /// Decreases speed of light by xMultiplier.
        /// </summary>
        public static void DecreaseLightSpeed()
        {
            _lightSpeed = _lightSpeed / ModificationMultiplier;
        }
        /// <summary>
        /// Increases time step by xMultiplier.
        /// </summary>
        public static void IncreaseSimulationSpeed()
        {
            _timeStep = _timeStep * ModificationMultiplier;
        }
        /// <summary>
        /// Decreases time step by xMultiplier.
        /// </summary>
        public static void DecreaseSimulationSpeed()
        {
            _timeStep = _timeStep / ModificationMultiplier;
        }

    }
}
