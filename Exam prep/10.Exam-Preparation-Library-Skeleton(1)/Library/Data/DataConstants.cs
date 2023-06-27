namespace Library.Data
{
    public static class DataConstants
    {
        public static class Book
        {
            public const int TITLE_MAX_LENGTH = 50;
            public const int TITLE_MIN_LENGTH = 10;

            public const int AUTHOR_MAX_LENGTH = 50;
            public const int AUTHOR_MIN_LENGTH = 5;

            public const int DESCRIPTION_MAX_LENGTH = 5000;
            public const int DESCRIPTION_MIN_LENGTH = 5;

            public const decimal RATING_MAX_LENGTH = 10.0m;
            public const decimal RATING_MIN_LENGTH = 0.0m;
        }

        public static class Category
        {
            public const int NAME_MAX_LENGTH = 50;
            public const int NAME_MIN_LENGTH = 5;
        }
    }
}
