namespace BeeSoft.Common;

public sealed class ResourceNameConstants
{
    public sealed class ErrorMessage
    {
        public const string RequiredFieldErrorMessageName = "RequiredFieldErrorMessage";
        public const string StringLengthErrorMessageName = "StringLengthErrorMessage";
        public const string RangeErrorMessageName = "RangeErrorMessage";
        public const string NotExistingItemErrorMessageName = "NotExistingItemErrorMessage";
        public const string AlreadyExistingHiveNumberErrorMessageName = "AlreadyExistingHiveNumber";
    }

    public sealed class CommonResourceName
    {
        public const string Apiary = "Apiary";
        public const string Hive = "Hive";
        public const string Name = "Name";
        public const string Date = "Date";
    }

    public sealed class ApiaryResourceName
    {
        public const string Location = "Location";
    }

    public sealed class BeeQueenResourceName
    {
        public const string Year = "Year";
        public const string ColorMark = "ColorMark";
        public const string IsAlive = "IsAlive";
    }

    public sealed class DiseaseResourceName
    {
        public const string Description = "Description";
        public const string Treatment = "Treatment";
    }

    public sealed class ExpenseResourceName
    {
        public const string Price = "Price";
    }

    public sealed class HarvestResourceName
    {
        public const string Amount = "Amount";
        public const string Product = "Product";
    }

    public sealed class HiveResourceName
    {
        public const string Number = "Number";
        public const string Type = "Type";
        public const string Status = "Status";
        public const string Color = "Color";
        public const string BoughtDate = "BoughtDate";
        public const string TimesUsed = "TimesUsed";
    }

    public sealed class InspectionResourceName
    {
        public const string WeatherConditions = "WeatherConditions";
        public const string Observations = "Observations";
        public const string ActionsTaken = "ActionsTaken";

    }
}
