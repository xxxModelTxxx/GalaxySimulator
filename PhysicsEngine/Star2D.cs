using System.Numerics;

namespace PhysicsEngine
{
    /// <summary>
    /// Represents single star in 2D space.
    /// </summary>
    public class Star2D
    {
        public const float DefaultStarMassMin = 0.1f;
        public const float DefaultStarMassMax = 1.0f;

        private Vector2 _accelerationVector;
        private Vector2 _forceVector;
        private float _massRest;
        private float _massRelativistic;
        private Vector2 _positionVector;
        private Vector2 _velocityVector;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">Position X coordinate</param>
        /// <param name="y">Position Y coordinate</param>
        /// <param name="m">Mass</param>
        public Star2D(int x, int y, float m = DefaultStarMassMax)
        {
            _accelerationVector = Vector2.Zero;
            _forceVector = Vector2.Zero;
            _massRelativistic = m;
            _velocityVector = Vector2.Zero;
            _positionVector = new Vector2(x, y);
        }

        /// <summary>
        /// Returns acceleration vector.
        /// </summary>
        public Vector2 AccelerationVector => _accelerationVector;
        /// <summary>
        /// Returns or sets force vector.
        /// </summary>
        public Vector2 ForceVector
        {
            get
            {
                return _forceVector;
            }
            set
            {
                _forceVector = value;
            }
        }
        /// <summary>
        /// Returns mass of star.
        /// </summary>
        public float Mass => _massRelativistic;
        /// <summary>
        /// Returns position vector of the star.
        /// </summary>
        public Vector2 PositionVector => _positionVector;
        /// <summary>
        /// Returns position X coordinate.
        /// </summary>
        public float X => _positionVector.X;
        /// <summary>
        /// Returns position Y coordinate.
        /// </summary>
        public float Y => _positionVector.Y;
        /// <summary>
        /// Returns velocity vector.
        /// </summary>
        public Vector2 VelocityVector => _velocityVector;

        /// <summary>
        /// Calculates new position of the star including acceleration and velocity vectors.
        /// </summary>
        /// <param name="time">Time of force application.</param>
        public void UpdateState(float time, float lightSpeed)
        {
            _accelerationVector = CalculateAccelerationVector();
            _positionVector = CalculatePositionVector(time);
            _velocityVector = CalculateSpeedVector(time);
            _massRelativistic = CalculateRelativisticMass(lightSpeed);
        }
        /// <summary>
        /// Stops movement of the star and resets it's all dynamics.
        /// </summary>
        public void StopMovement()
        {
            _accelerationVector = Vector2.Zero;
            _forceVector = Vector2.Zero;
            _velocityVector = Vector2.Zero;
        }
        private Vector2 CalculateAccelerationVector()
        {
            // a = F/m
            return _forceVector / _massRelativistic;
        }
        private float CalculateRelativisticMass(float lightSpeed)
        {
            return _massRest / (float)Math.Sqrt(1.0f - (_velocityVector.LengthSquared() / (float)Math.Pow(lightSpeed, 2)));
        }
        private Vector2 CalculatePositionVector(float time)
        {
            // V = XY + V0t + 0.5at^2
            return _positionVector + (_velocityVector * time) + (_accelerationVector * (0.5f * (float)Math.Pow(time, 2))); 
        }
        private Vector2 CalculateSpeedVector(float time)
        {
            // V = V0 + at
            return _velocityVector + (_accelerationVector * time); 
        }

    }
}
