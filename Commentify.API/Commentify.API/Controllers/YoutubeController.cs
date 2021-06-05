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

namespace Commentify.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class YoutubeController : ControllerBase
    {
        public IEnumerable Index()
        {

            var cc = Run();

          

            return cc.Result.ToArray();
        }
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
    }
}
