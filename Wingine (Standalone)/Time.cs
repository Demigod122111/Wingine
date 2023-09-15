namespace Wingine
{
    public static class Time
    {
        public static double DeltaTime => Runner.App.dt;
        public static double FixedDeltaTime => 0.02f;
    }
}
