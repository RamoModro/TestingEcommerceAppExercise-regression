namespace TestingEcommerceAppExercise.Helpers;

internal class Messages
{
    public static List<string> RequiredErrorMessages = new()
    {
        "This is a required field.",
        "This is a required field.",
        "This is a required field.",
        "This is a required field.",
        "This is a required field."
    };

    public static List<string> CustomerFormInvalidDataErrorMessages = new()
    {
        "Please enter a valid email address (Ex: johndoe@domain.com).",
        "Minimum length of this field must be equal or greater than 8 symbols. Leading and trailing spaces will be ignored.",
    };
}
