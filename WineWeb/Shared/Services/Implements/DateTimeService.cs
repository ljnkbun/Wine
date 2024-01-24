namespace WineWeb.Shared.Services.Implements
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime? Now { get => DateTime.Now; set => Now = DateTime.Now; }

    }
}
