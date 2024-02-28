namespace Store.EntityConfigurations.Constants;

/// <summary>
/// Настройки конфигурирования сущностей
/// </summary>
internal static class ConfigurationSettings
{    
    internal static class Answer
    {
        public const string TableName = "Answers";
    }

    internal static class Interview
    {
        public const string TableName = "Interviews";
    }

    internal static class Question
    {
        public const string TableName = "Questions";
    }

    internal static class Result
    {
        public const string TableName = "Results";
    }

    internal static class Survey
    {
        public const string TableName = "Surveys";
        public const int MaxDescriptionLength = 255;
    }
}
