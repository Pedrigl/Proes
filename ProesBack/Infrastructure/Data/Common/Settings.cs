namespace ProesBack.Infrastructure.Data.Common
{
    public static class Settings
    {
        public static string ProesFilesUrl { get; private set; }
        public static string Key { get; private set; }

        public static void Setup(IConfiguration configuration)
        {
            var settings = configuration.GetSection("MySettings");
            ProesFilesUrl = settings.GetConnectionString("ProesFilesUrl");
            Key = settings.GetValue<string>("Key");
        }
    }
}
