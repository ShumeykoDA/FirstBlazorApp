namespace FirstBlazorApp.Services;

public class DateTimeService
{
    public string DateTimeToString(DateTime? dateTime, string format = "dd-MM-yyyy")
    {
        if (dateTime != null)
        {
            return ((DateTime) dateTime).ToString(format);
        }
        return "";
    }
}