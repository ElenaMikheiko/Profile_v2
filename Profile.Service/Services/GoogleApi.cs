using System;
using System.IO;
using System.Threading;

namespace Profile.Service.Services
{
    public class GoogleApi
    {
        //private SheetsService _sheetsService;

        //public GoogleApi(string[] scopes)
        //{
        //    UserCredential userCredential;

        //    using (FileStream stream = new FileStream("google_sheets_oauth_id.json", FileMode.Open, FileAccess.Read))
        //    {

        //        //create/read credentials at/from 'My Documents/.ProfilerAppCredentials/sheets.googleapis.com.json/'
        //        string credentialPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //        credentialPath = Path.Combine(credentialPath, ".ProfilerAppCredentials/sheets.googleapis.com.json");

        //        userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
        //            GoogleClientSecrets.Load(stream).Secrets,
        //            scopes,
        //            "user",
        //            CancellationToken.None,
        //            new FileDataStore(credentialPath, true)
        //            ).Result;
        //    }

        //    _sheetsService = new SheetsService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = userCredential,
        //        ApplicationName = "Profiler v2"
        //    });
        //}

        //public SheetsService GetSheetsService() => _sheetsService;
    }
}
