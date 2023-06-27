namespace TaskBoard.App.Data
{
    public static class DataConstants
    {
        public static class Task
        {
            public const int TITLE_MIN_LENGTH = 5;
            public const int TITLE_MAX_LENGTH = 70;

            public const int DESCRIPTION_MAX_LENGTH = 1000;
            public const int DESCRIPTION_MIN_LENGTH = 10;
        }

        public static class Board
        {
            public const int BOARD_MAX_NAME = 30;
            public const int BOARD_MIN_NAME = 3;
        }

        public static class User
        {
            public const int USER_MAX_FIRST_NAME = 15;

            public const int USER_MAX_LAST_NAME = 15;
        }
    }
}
