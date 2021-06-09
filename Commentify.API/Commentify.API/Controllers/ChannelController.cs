using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commentify.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChannelController : Controller
    {

        //have the global variable for auto and service
        public YouTubeService service;

        public ChannelController()
        {
            
        }

        [GoogleScopedAuthorize(YouTubeService.ScopeConstants.Youtube)]
        public async Task<string> Index([FromServices] IGoogleAuthProvider auth,string channelId = "UC3lFOGszLThAICPQRs0VgZQ")
        {
            GoogleCredential cred = await auth.GetCredentialAsync();

            service = new YouTubeService(new BaseClientService.Initializer
            {
                HttpClientInitializer = cred,
                ApplicationName = "Comment fetcher",
            });

            //get the channel Details
            var channelList = service.Channels.List("snippet, statistics, contentDetails");
            channelList.Id = channelId;
            channelList.MaxResults = 50;


            var responsechannel = await channelList.ExecuteAsync();

            return JsonConvert.SerializeObject(responsechannel);
        }
    }
}
