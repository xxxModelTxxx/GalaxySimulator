using System.Drawing;
using System.Numerics;

namespace PhysicsEngine
{
    /// <summary>
    /// Represents single star in 2D space.
    /// </summary>
    public class Star2D
    {
        public const float  DefaultStarMassMin = 0.1f;
        public const float  DefaultStarMassMax = 1.0f;

        private Vector2     _accelerationVector;
        private Vector2     _forceVector;
        private float       _massRest;
        private float       _massRelativistic;
        private Vector2     _positionVector;
        private Vector2     _velocityVector;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="x">Position X coordinate</param>
        /// <param name="y">Position Y coordinate</param>
        /// <param name="mass">Mass</param>
        public Star2D(int x, int y, float mass = DefaultStarMassMax)
        {
            _accelerationVector = Vector2.Zero;
            _forceVector = Vector2.Zero;
            _massRest = mass;
            _massRelativistic = mass;
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
        /// <param name="lightSpeed">Value of light speed.</param>
        public void UpdateState(float time, float lightSpeed)
        {
            _accelerationVector = CalculateAccelerationVector();
            _positionVector = CalculatePositionVector();
            _velocityVector = CalculateVelocityVector();
            _massRelativistic = CalculateRelativisticMass(_massRest, _velocityVector, lightSpeed);

            // Local functions
            Vector2 CalculateAccelerationVector()
            {
                // a = F/m
                return _forceVector / _massRelativistic;
            }
            Vector2 CalculatePositionVector()
            {
                // V = XY + V0t + 0.5at^2
                return _positionVector + (_velocityVector * time) + (_accelerationVector * (0.5f * (float)Math.Pow(time, 2)));
            }
            Vector2 CalculateVelocityVector()
            {
                // V = V0 + at
                return _velocityVector + (_accelerationVector * time);
            }
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
        private float CalculateRelativisticMass(float mass, float velocity, float lightSpeed)
        {
            return mass / (float)Math.Sqrt(1.0f - ((float)Math.Pow(velocity, 2) / (float)Math.Pow(lightSpeed, 2)));
        }
        private float CalculateRelativisticMass(float mass, Vector2 velocityVector, float lightSpeed)
        {
            return mass / (float)Math.Sqrt(1.0f - (velocityVector.LengthSquared() / (float)Math.Pow(lightSpeed, 2)));
        }

    }
}
