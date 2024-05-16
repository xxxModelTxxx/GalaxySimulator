namespace PhysicsEngine
{
    /// <summary>
    /// Static class containing basic parameters to run the space simulation. 
    /// </summary>
    public static class PhysicalConstants
    {
        private const float     DefaultGravityConstant = 10.01f;
        private const float     DefaultLightSpeed = 10.01f;
        private const float     DefaultTimeStep = 0.01f;
        private const float     DefaultNearLightSpeedRatio = 0.91f;
        private const int       ModificationMultiplier = 10;

        private static float    _gravityConstant;
        private static float    _lightSpeed;
        private static float    _nearLightSpeedRatio;
        private static float    _timeStep;

        /// <summary>
        /// Returns gravity constant.
        /// </summary>
        public static float GravityConstant
        {
            get
            {
                return _gravityConstant;
            }
            set
            {
                _gravityConstant = (float)value;
            }
        }
        /// <summary>
        /// Returns speed of light value;
        /// </summary>
        public static float LightSpeed
        {
            get
            {
                return _lightSpeed;
            }
            set
            {
                _lightSpeed = (float) value;
            }
        }
        /// <summary>
        /// Returns maximum allowable speed;
        /// </summary>
        public static float NearLightSpeed => _lightSpeed * NearLightSpeedRatio;
        /// <summary>
        /// Returns near light speed ratio
        /// Near light speed ratio determines maximum allowable speed of star in simulation.
        /// </summary>
        public static float NearLightSpeedRatio
        {
            get
            {
                return _nearLightSpeedRatio;
            }
            set
            {
                if (value >= 1.0f || value <= 0)
                {
                    _nearLightSpeedRatio = DefaultNearLightSpeedRatio;
                }
                else
                {
                    _nearLightSpeedRatio = (float) value;
                }
            }
        }
        /// <summary>
        /// Returns time length of single simulation step.
        /// </summary>
        public static float TimeStep
        {
            get
            {
                return _timeStep;
            }
            set
            {
                _timeStep = (float) value;
            }
        }
        /// <summary>
        /// Class static constructor.
        /// </summary>
        static PhysicalConstants()
        {
            _gravityConstant = DefaultGravityConstant;
            _lightSpeed = DefaultLightSpeed;
            _nearLightSpeedRatio = DefaultNearLightSpeedRatio;
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
