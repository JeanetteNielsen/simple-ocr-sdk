namespace SimpleGoogleOcrSDK
{
    public interface IGoogleOcrConfigurations
    {
        string CredentialsJsonFile { get; }
    }

    public class GoogleOcrConfigurations : IGoogleOcrConfigurations
    {
        public GoogleOcrConfigurations(string credentialsFile)
        {
            CredentialsJsonFile = credentialsFile;
        }

        public string CredentialsJsonFile { get; }
    }
}