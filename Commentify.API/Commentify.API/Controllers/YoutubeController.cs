using System;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3.Data;
using Google.Apis.Services;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.YouTube.v3;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text.Json;
using System.Web.Helpers;
using System.Collections;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Auth.AspNetCore3;

namespace Commentify.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class YoutubeController : ControllerBase
    {
        //clientID   :    769305163719-hvjhct885vebfajqpngmbkimpo4ar5hr.apps.googleusercontent.com
        //Secratecode  :   DEeHAKxqjMMzIhiXn2yT1K8X


        YouTubeService service;

        //[GoogleScopedAuthorize(YouTubeService.ScopeConstants.Youtube)]
        //public async Task index([FromServices] IGoogleAuthProvider auth)
        //{
        //    GoogleCredential cred = await auth.GetCredentialAsync();

        //    //UserCredential credential;


        //    //using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
        //    //{
        //    //    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
        //    //        GoogleClientSecrets.Load(stream).Secrets,
        //    //        new[] { YouTubeService.Scope.Youtube },
        //    //        "user",
        //    //        CancellationToken.None
        //    //    );
        //    //}

        //    var channelid = "UCARsZhL9rw5uZH-NRqs2kHg";


        //     service = new YouTubeService(new BaseClientService.Initializer
        //    {

        //        HttpClientInitializer = cred,
        //        ApplicationName = "Comment fetcher",

        //        //ApplicationName = "Comment fetcher",
        //        //ApiKey = "AIzaSyD3-GDrZybg3t0NMJOk8nQ8D1I6TQJ2rC0",
        //    });


        //    var channelList = service.Channels.List("snippet");
        //    channelList.Id = channelid;
        //    channelList.MaxResults = 50;
            

        //    var responsechannel = await channelList.ExecuteAsync();


            

        //   // var comments = service.CommentThreads.List("snippet");
        //   //// comments.ChannelId = "UC3lFOGszLThAICPQRs0VgZQ";
        //   // comments.VideoId = "UOGWADxyDuo";
        //   // comments.MaxResults = 50;
        //   // var responseComments = await comments.ExecuteAsync();



        //    var allchannelList = service.Search.List("snippet");
        //    allchannelList.ChannelType = SearchResource.ListRequest.ChannelTypeEnum.Any;
        //    allchannelList.MaxResults = 100;

        //    var responseVedio = await allchannelList.ExecuteAsync();

        //    var vedioList = service.Search.List("snippet");
        //    vedioList.ChannelId = channelid;
        //    vedioList.MaxResults = 100;
            
        //    var responseChannelvedios = await vedioList.ExecuteAsync();
        //    //var cc = Run();

        //    getChannelDetails();


        //  //  return Result.ToArray();
        //}


        private async Task<List<string>> Run()
        {
            // Create the service.
            var service = new YouTubeService(new BaseClientService.Initializer
            {
                ApplicationName = "Comment fetcher",
                ApiKey = "AIzaSyD3-GDrZybg3t0NMJOk8nQ8D1I6TQJ2rC0",
            });


            var videoList = service.CommentThreads.List("snippet");

            videoList.VideoId = "WCAfAGw5fLw";
            videoList.MaxResults = 50;

            var searchListResponse = await videoList.ExecuteAsync();

            List<string> CommentList = new List<string>();

            foreach (var item in searchListResponse.Items)
            {
                CommentList.Add(item.Snippet.TopLevelComment.Snippet.TextOriginal.ToString());
            }

            return CommentList;
        }
        private async Task<string> getChannelDetails()
        {
           

          var channelList = service.Channels.List("snippet");

            channelList.Id = "UC3lFOGszLThAICPQRs0VgZQ";
            channelList.MaxResults = 50;
            //channelList.Mine = true;
            //channelList.MySubscribers = true;

            var responsechannel = await channelList.ExecuteAsync();

            // var d = channelList.Items;

            //   var chan = new Channel();

            // chan.

            //Channel cc = new Channel();

            //cc.Id = "UC3lFOGszLThAICPQRs0VgZQ";

            //var Channeldetails = await cc.


            return "";
        }


        
        public async Task Index()
        {
            return;
        }
    }
}
