namespace NSE.Shared.Configurations
{
    public class AppSettings
    {
        public string Secret { get;  set; }
        public ushort ExpiresInHours { get; set; }
        public string AudienceIn { get; set; }
        public string Issue { get; set; }
    }
}
