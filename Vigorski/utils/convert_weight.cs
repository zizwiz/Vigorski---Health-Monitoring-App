namespace convert
{
    class weight
    {
        public static double PoundsToKilogram(double pounds)
        {
            return (pounds * 0.45359237);
        }

        public static double PoundsToStones(double pounds)
        {
            return (pounds * 0.071428571);
        }

        public static double KilogramsToPounds(double kilogram)
        {
            return (kilogram * 2.206226);
        }

        public static double KilogramsToStones(double kilogram)
        {
            return (kilogram * 0.15747304);
        }

        public static double StonesToPounds(double stones)
        {
            return (stones * 14);
        }

        public static double StonesToKilogram(double stones)
        {
            return (stones * 6.3502932);
        }
    }
}
