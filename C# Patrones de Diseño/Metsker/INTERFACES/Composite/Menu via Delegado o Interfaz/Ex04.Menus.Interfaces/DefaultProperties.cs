namespace Ex04.Menus.Interfaces
{
    public static class DefaultProperties
    {
        private static readonly int sr_BackOrExitIndex = 0;
        private static readonly int sr_FirstLevelIndex = 1;
        private static readonly string sr_ExitSign = "Exit";
        private static readonly string sr_BackSign = "Back";

        public static int BackOrExitIndex
        {
            get
            {
                return sr_BackOrExitIndex;
            }
        }

        public static int FirstLevelIndex
        {
            get
            {
                return sr_FirstLevelIndex;
            }
        }

        public static string Exit
        {
            get
            {
                return sr_ExitSign;
            }
        }

        public static string Back
        {
            get
            {
                return sr_BackSign;
            }
        }
    }
}
