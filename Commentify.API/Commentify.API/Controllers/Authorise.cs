using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commentify.API.Controllers
{
    public class Authorise
    {

        //GoogleCredential cred = await auth.GetCredentialAsync();

        public YouTubeService Service { get; set; }

        public Authorise([FromServices] IGoogleAuthProvider auth)
        {
            Service = new YouTubeService(new BaseClientService.Initializer
            {
                HttpClientInitializer = GetCredentials(auth).Result,
                ApplicationName = "Comment fetcher",
            });
        }

        public async Task<GoogleCredential> GetCredentials([FromServices] IGoogleAuthProvider auth)
        {
            GoogleCredential cred = await auth.GetCredentialAsync();

            return cred;
        }
    }
}
