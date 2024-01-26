namespace Core.Services.Implements
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime? Now { get => DateTime.Now; set => Now = DateTime.Now; }

    }
}
