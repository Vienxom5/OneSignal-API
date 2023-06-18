using OneSignal.RestAPIv3.Client;
using OneSignal.RestAPIv3.Client.Resources;
using OneSignal.RestAPIv3.Client.Resources.Notifications;
using OneSignal_API_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneSignal_API_01.Helper
{
    public class OneSignalPushNotificationHelper
    {
        public static async Task<string> OneSignalPushNotification(CreateNotificationModel request, Guid appId, string restKey)
        {
            OneSignalClient client = new OneSignalClient(restKey);
            var opt = new NotificationCreateOptions()
            {
                AppId = appId,
                IncludePlayerIds = request.PlayerIds,
                SendAfter = DateTime.Now.AddSeconds(10)
            };
            opt.Headings.Add(LanguageCodes.English, request.Title);
            opt.Contents.Add(LanguageCodes.English, request.Content);
            opt.Headings.Add(LanguageCodes.Vietnamese, request.Title);
            opt.Contents.Add(LanguageCodes.Vietnamese, request.Content);
            NotificationCreateResult result = await client.Notifications.CreateAsync(opt);
            return result.Id;
        }
        public static async Task<string> OneSignalCancelPushNotification(string id, string appId, string restKey)
        {
            var client = new OneSignalClient(restKey);
            var opt = new NotificationCancelOptions()
            {
                AppId = appId,
                Id = id
            };
            NotificationCancelResult result = await client.Notifications.CancelAsync(opt);
            return result.Success;
        }
        public static async Task<NotificationDislayedRequest> WebhooksDisplayed(NotificationDislayedRequest request)
        {
            await Task.Yield();
            
            return request;
        }
    }
}
