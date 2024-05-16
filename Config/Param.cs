namespace Config
{
    public static class Param
    {
        public const int SpaceWidth = 600;
        public const int SpaceHeight = 400;
        public const int NoOfStars = 100;
        public const int RenderingFramesPerSecond = 30;
        public const float StarGenerationProbability = ((float)NoOfStars)/(SpaceWidth*SpaceHeight);
        public const float StarMassMin = 10.0f;
        public const float StarMassMax = 10.0f;
    }
}
