namespace Config
{
    public static class Param
    {
        public const int SpaceWidth = 600;
        public const int SpaceHeight = 400;
        public const int NoOfStars = 10;
        public const float StarGenerationProbability = ((float)NoOfStars)/(SpaceWidth*SpaceHeight);
        public const float StarMassMin = 1.0f;
        public const float StarMassMax = 1.0f;
    }
}
