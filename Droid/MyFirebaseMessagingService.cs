using System;
using Android.App;
using Android.Content;
using Android.Util;
using Firebase.Messaging;
using MvvmTest.Views;
using Xamarin.Forms;

namespace MvvmTest.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        
        const string TAG = "MyFirebaseMsgService";
        public override void OnMessageReceived(RemoteMessage message)
        {
            //Log.Debug(TAG, "From: " + message.Data);
            //var data = message.Data["post_id"];
          try
            {
                var data = message.Data;
                Console.WriteLine(data["memID"]);
                Console.WriteLine(data["type"]);
                Console.WriteLine(data["NotiDesc"]);
                string memId = data["memID"];
                string _type = data["type"];
                string text = data["NotiDesc"];
                //string title = data["title"];//0 anniversary,1 Birthday
                //if (!App.IsVisible)
                    //App.Current.MainPage = new NavigationPage(new NotificationsPage(true));
                Console.WriteLine("#######################");
                SendNotification(text,memId,_type,"");
            }
            catch (Exception ex)
            {
                Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            }
        }            

        void SendNotification(string messageBody,string memID,string _type,string title)
        {
            Random random = new Random();
            var id = random.Next(9999 - 1000) + 1000;

            var intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra("memID",memID);
            intent.PutExtra("type", _type);
            intent.AddFlags(ActivityFlags.ClearTop);

            var pendingIntent = PendingIntent.GetActivity(this, id, intent, PendingIntentFlags.OneShot);

            var notificationBuilder = new Notification.Builder(this)
                                                      .SetSmallIcon(Resource.Drawable.appicon)
                .SetContentTitle("JSSG Premium Main")
                                                      .SetContentText(messageBody)
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent);

            var notificationManager = NotificationManager.FromContext(this);
            notificationManager.Notify(id, notificationBuilder.Build());
        }
        public override void HandleIntent(Intent intent)
        {
            try
            {
                if (intent.Extras != null)
                {
                    var builder = new RemoteMessage.Builder("MyFirebaseMessagingService");

                    foreach (string key in intent.Extras.KeySet())
                    {
                        builder.AddData(key, intent.Extras.Get(key).ToString());
                    }

                    this.OnMessageReceived(builder.Build());
                }
                else
                {
                    base.HandleIntent(intent);
                }
            }
            catch (Exception)
            {
                base.HandleIntent(intent);
            }
            Console.WriteLine("Handle Intent @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

        }
    }
}   
