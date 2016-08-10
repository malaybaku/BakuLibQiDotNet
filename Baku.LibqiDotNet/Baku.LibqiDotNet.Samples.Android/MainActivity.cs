using Android.App;
using Android.Widget;
using Android.OS;
using Baku.LibqiDotNet.Service;
using System.Threading.Tasks;

namespace Baku.LibqiDotNet.Samples.Android
{
    [Activity(Label = "Baku.LibqiDotNet.Samples.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        Task t = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += (_, __) =>
            {
                button.Text = string.Format("{0} clicks!", count++);

                t = Task.Run(() =>
                {
                    var s = new QiSessionFactory().CreateSocketIoSession();
                    s.Connect("192.168.1.3");
                    var tts = ALTextToSpeech.CreateService(s);
                    tts.Say("Hello, I am from android, Xamarin. Where are you from?");
                });
            };
        }
    }
}

