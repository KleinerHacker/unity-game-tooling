namespace UnityGameTooling.Runtime.game_tooling.Scripts.Runtime
{
    internal static class UnityGameToolingConstants
    {
        public const string Root = "Unity Game Tooling";

        public static class Menu
        {
            public static class Asset
            {
                private const string RootMenu = Root;
                
                public const string GamingMenu = RootMenu + "/Gaming";

                public static class Gaming
                {
                    public const string TrafficMenu = GamingMenu + "/Traffic";

                    public static class Traffic
                    {
                        public const string TrafficLightMenu = TrafficMenu + "/Traffic Light";
                    }
                }
            }

            public static class Component
            {
                private const string RootMenu = Root;

                public const string CameraMenu = RootMenu + "/Camera";
                public const string GamingMenu = RootMenu + "/Gaming";

                public static class Gaming
                {
                    public const string TrafficMenu = GamingMenu + "/Traffic";

                    public static class Traffic
                    {
                        public const string TrafficLightMenu = TrafficMenu + "/Traffic Light";
                    }
                }
            }
        }

        public static class Script
        {
            public static class ExecutionOrder
            {
                public const int PreviewController = -99;
            }
        }
    }
}
