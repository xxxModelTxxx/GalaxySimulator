using System.Drawing;
using System.Numerics;

namespace PhysicsEngine
{
    /// <summary>
    /// Represents 2D space (universe)
    /// </summary>
    public class Space2D: ICloneable
    {
        private Size                _size;
        private List<Star2D>        _stars;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="width"> Width of space</param>
        /// <param name="height"> Height of space</param>
        /// <param name="stars"> Collection of stars</param>
        public Space2D(int width, int height)
        {
            _size = new Size(width, height);
            _stars = new List<Star2D>();
        }

        // Implementation of ICloneable interface
        /// <summary>
        /// Creates deep copy of Space2D
        /// </summary>
        /// <returns>object representing clone of Space2D object</returns>
        public object Clone()
        {
            Space2D clone = new Space2D(0, 0);
            clone._size = this._size;
            foreach(Star2D s in this._stars)
            {
                clone._stars.Add((Star2D)s.Clone());
            }
            return clone;
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
        /// Adds signgle star to the space.
        /// </summary>
        /// <param name="x">X coordinate of the star to be added.</param>
        /// <param name="y">Y coordinate of the star to be added.</param>
        /// <param name="mass">Mass of the star to be added.</param>
        public void AddStar(int x, int y, float mass)
        {
            _stars.Add(new Star2D(x, y, mass));
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

            // Iterate throuht every point of Space (w x h).
            for (int w = 0; w < _size.Width; w++)
            {
                for (int h = 0; h < _size.Height; h++)
                {
                    if (IsStarGenerated())
                    {
                        m = GenerateStarMass();
                        AddStar(w, h, m);
                    }
                }
            }

            // Local functions.
            bool IsStarGenerated()
            {
                return rnd.NextSingle() <= starGenerationProbability;
            }
            float GenerateStarMass()
            {
                return m = massMin + ((massMax - massMin) * rnd.NextSingle());
            }
        }
        /// <summary>
        /// Deletes all stars and clears space.
        /// </summary>
        public void ClearStars()
        {
            _stars.Clear();
        }
        /// <summary>
        /// Calculates next step of the simulation state.
        /// </summary>
        public void SimulationStepForward()
        {
            CalculateGravitationalForces();
            UpdateSimulationState();

            // Local functions
            void CalculateGravitationalForces()
            {
                foreach (Star2D star in _stars)
                {
                    star.ForceVector = CalculateResultantGravitationalForceVector(star);
                }

                // Local functions
                Vector2 CalculateResultantGravitationalForceVector(Star2D star1)
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

                    // Local functions
                    Vector2 CalculateGravitationalForceVector(Star2D star1, Star2D star2)
                    {
                        if (star1 == star2)
                        {
                            return Vector2.Zero;
                        }
                        else
                        {
                            // F = -G * (m1*m2)/r^2 * r12norm
                            return ((-1 * PhysicalConstants.GravityConstant * star1.Mass * star2.Mass) / Vector2.DistanceSquared(star1.PositionVector, star2.PositionVector)) * Vector2.Normalize(star1.PositionVector - star2.PositionVector);

                        }
                    }
                }
            }
            void UpdateSimulationState()
            {
                foreach (Star2D star in _stars)
                {
                    star.UpdateState(PhysicalConstants.TimeStep, PhysicalConstants.LightSpeed);
                }
            }
        }
    }
}
