namespace BeeSoft.Common;

public class DataAttributeConstants
{
    public class Paging
    {
        public const int ItemsPerPage = 10;
    }

    public class Apiary
    {
        public const int NameMinLength = 1;
        public const int NameMaxLength = 100;
        public const int LocationMinLength = 1;
        public const int LocationMaxLength = 100;
    }

    public class Hive
    {
        public const int NumberMinValue = 1;
        public const int NumberMaxValue = 1000;
        public const int TypeMinLength = 3;
        public const int TypeMaxLength = 100;
        public const int StatusMinLength = 3;
        public const int StatusMaxLength = 100;
        public const int ColorMaxLength = 100;
        public const int TimesUsedCountMinValue = 1;
        public const int TimesUsedCountMaxValue = 50;
    }

    public class BeeQueen
    {
        public const int AgeMinValue = 0;
        public const int AgeMaxValue = 10;
    }

    public class Inspection
    {
        public const int WeatherConditionsMaxLength = 100;
        public const int ObservationsMaxLength = 500;
        public const int ActionsTakenMaxLength = 500;
    }

    public class Disease
    {
        public const int NameMaxLength = 100;
        public const int DescriptionMaxLength = 100;
        public const int TreatmentMaxLength = 100;
    }

    public class Harvest
    {
        public const int HarvestedProductMaxLength = 100;
    }

    public class Expense
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 100;
    }
}
