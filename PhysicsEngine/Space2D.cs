using System.Drawing;
using System.Numerics;

namespace PhysicsEngine
{
    /// <summary>
    /// Represents 2D space (universe)
    /// </summary>
    public class Space2D
    {
        public const int DefaultSpaceSizeX = 600;
        public const int DefaultSpaceSizeY = 400;
        public const float DefaultStarGenerationProbability = 0.002f;

        private Size _size;
        private List<Star2D> _stars;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width"> Width of space</param>
        /// <param name="height"> Height of space</param>
        /// <param name="stars"> Collection of stars</param>
        public Space2D(int width = DefaultSpaceSizeX, int height = DefaultSpaceSizeY)
        {
            _size = new Size(width, height);
            _stars = new List<Star2D>();
        }

        /// <summary>
        /// Returns width of the 2D space
        /// </summary>
        public int Width => _size.Width;
        /// <summary>
        /// Returns height of 2D space
        /// </summary>
        public int Height => _size.Height;
        /// <summary>
        /// Returns collection of stars located in space
        /// </summary>
        public IEnumerable<Star2D> Stars => _stars;

        /// <summary>
        /// Calculates next step of the simulation state.
        /// </summary>
        public void SimulationStepForward()
        {
            CalculateGravitationalForces();
            UpdateSimulationState();
        }
        /// <summary>
        /// Deletes all stars and clears space.
        /// </summary>
        public void ClearStars()
        {
            _stars.Clear();
        }
        /// <summary>
        /// Generates stars and fills the space.
        /// </summary>
        /// <param name="starGenerationProbability">Probability of generation of star in specific point of space.</param>
        /// <param name="massMin">Minimum possible mass of new star.</param>
        /// <param name="massMax">Maximum possible mass of new star.</param>
        public void GenerateStars(float starGenerationProbability, float massMin, float massMax)
        {
            Random rnd = new Random();
            float m;

            for (int w = 0; w < _size.Width; w++)
            {
                for (int h = 0; h < _size.Height; h++)
                {
                    if (rnd.NextSingle() <= starGenerationProbability)
                    {
                        m = Star2D.DefaultStarMassMin + ((Star2D.DefaultStarMassMax-Star2D.DefaultStarMassMin) * rnd.NextSingle());
                        _stars.Add(new Star2D(w, h, m));
                    }
                }
            }
        }
        private void CalculateGravitationalForces()
        {
            foreach (Star2D star in _stars)
            {
                star.ForceVector = CalculateResultantGravitationalForceVector(star);
            }
        }
        private Vector2 CalculateGravitationalForceVector(Star2D star1, Star2D star2)
        {
            // F = -G * (m1*m2)/r^2 * r12norm
            return ((-1 * PhysicalConstants.GravityConstant * star1.Mass * star2.Mass) / Vector2.DistanceSquared(star1.PositionVector, star2.PositionVector)) * Vector2.Normalize(star1.PositionVector - star2.PositionVector);
        }
        private Vector2 CalculateResultantGravitationalForceVector(Star2D star1)
        {
            Vector2 fResultant = Vector2.Zero;
            Vector2 fIndividual = Vector2.Zero;

            foreach (Star2D star2 in _stars)
            {
                try
                {
                    fIndividual = CalculateGravitationalForceVector(star1, star2);
                }
                catch
                {
                    fIndividual = Vector2.Zero;
                }
                finally
                {
                    fResultant += fIndividual;
                }
            }

            return fResultant;
        }
        private void UpdateSimulationState()
        {
            foreach (Star2D star in _stars)
            {
                star.UpdateState(PhysicalConstants.TimeStep, PhysicalConstants.LightSpeed);
            }
        }
    }
}
