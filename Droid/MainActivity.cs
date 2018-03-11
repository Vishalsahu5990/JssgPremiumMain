using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Droid;
using CarouselView.FormsPlugin.Android;
using Firebase.Iid;
using Android.Gms.Common;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using MvvmTest.Helpers;
using Xamarin.Forms;
using Badge.Plugin;

namespace MvvmTest.Droid
{
    [Activity(Label = "JSSG Premium Main", Icon = "@drawable/ic_launcher", Theme = "@style/MyTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Acr.UserDialogs.UserDialogs.Init(this);
            //initializing carousel view
            CarouselViewRenderer.Init();
            CachedImageRenderer.Init(true);
            //Initializing ffimage loading control
            //CrossBadge.Current.SetBadge(10);
            IsPlayServicesAvailable();


            string memID = Intent.GetStringExtra("memID");
            string _type = Intent.GetStringExtra("type");
            Console.WriteLine("______________________"+memID+" "+_type);


            if(string.IsNullOrEmpty(memID))
                LoadApplication(new App(false)); 
            else
                LoadApplication(new App(true, memID, _type));
        }
        public bool IsPlayServicesAvailable()
        {
            try
            {
                int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
                if (resultCode != ConnectionResult.Success)
                {

                    if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    {
                        var code = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                    }
                    else
                    {
                        Console.WriteLine("This device is not supported");

                        Finish();
                    }
                    return false;
                }
                else
                {
                   System.Threading.Tasks.Task.Run(() =>
                    {
                        // FirebaseApp.InitializeApp(this);
                        var instanceid = FirebaseInstanceId.Instance;
                        //instanceid.DeleteInstanceId();
                        //Log.Debug("TAG", "{0} {1}", instanceid.Token, instanceid.GetToken(this.GetString(Resource.String.gcm_defaultSenderId), Firebase.Messaging.FirebaseMessaging.InstanceIdScope));
                        if(!string.IsNullOrEmpty(instanceid.Token))
                            CommonHelpers.DeviceToken = instanceid.Token;
                        Console.WriteLine("Google Play Services is available.");

                    });
                    return true;
                }
            }
            catch (Exception ex)
            {
                //StaticMethods.ShowToast(ex.Message);
                return false;
            }
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
             
            //if(intent.GetStringExtra())

            Console.WriteLine("From background###########@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
           
        }
       
    }
}
