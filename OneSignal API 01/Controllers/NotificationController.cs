using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using Newtonsoft.Json.Linq;
using OneSignal_API_01.Helper;
using OneSignal_API_01.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OneSignal_API_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : Controller
    {
        private readonly IConfiguration _configuration;

        public NotificationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromForm] CreateNotificationModel request)
        {
            Guid appId = Guid.Parse(_configuration.GetSection(OneSignalSettings.AppId).Value);
            string restKey = _configuration.GetSection(OneSignalSettings.APIKey).Value;
            string result = await OneSignalPushNotificationHelper.OneSignalPushNotification(request, appId, restKey);
            return Ok(result);
        }
        [HttpPost("displayed")]
        public async Task<IActionResult> CatchNotificationDisplayed([FromForm] NotificationDislayedRequest request)
        {
            return Ok(await OneSignalPushNotificationHelper.WebhooksDisplayed(request));
        }

    }
}

