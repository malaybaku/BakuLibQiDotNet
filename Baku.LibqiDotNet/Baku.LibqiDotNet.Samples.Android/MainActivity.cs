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

                Task.Run(() =>
                {
                    var targetIp = FindViewById<EditText>(Resource.Id.MyEditText).Text;
                    var session = new QiSessionFactory().CreateSocketIoSession();

                    //Connect with timeout 4sec
                    var connectFuture = session.ConnectAsync(targetIp);
                    connectFuture.Wait(4000);
                    if (connectFuture.IsFinished && !connectFuture.HasError)
                    {
                        var tts = ALTextToSpeech.CreateService(session);
                        tts.Say("Hello, from Xamarin!");
                    }

                    session.Close();
                });
            };
        }
    }
}

