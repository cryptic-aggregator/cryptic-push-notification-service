using CrypticPushNotificationService;
using Grpc.Core;
using FirebaseAdmin.Messaging;

namespace CrypticPushNotificationService.Services
{
    public class PushNotificationService : PushNotification.PushNotificationBase
    {
        private readonly ILogger<PushNotificationService> _logger;
        private readonly FirebaseMessaging _messaging;

        public PushNotificationService(ILogger<PushNotificationService> logger)
        {
            _logger = logger;
            _messaging = FirebaseMessaging.DefaultInstance;
        }

        public override async Task<PushReply> Send(PushRequest request, ServerCallContext context)
        {
            try
            {
                var message = new Message
                {
                    Token = request.Token,
                    Notification = new Notification
                    {
                        Title = request.Title,
                        Body = request.Body
                    }
                };

                await _messaging.SendAsync(message);
                return new PushReply { Success = true };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send push notification");
                return new PushReply { Success = false, Error = ex.Message };
            }
        }
    }
}
