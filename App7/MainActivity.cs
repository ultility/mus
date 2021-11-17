using Android;
using Android.App;
using Android.Media;
using Android.Widget;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Content;

namespace App6
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button start, stop, paino;
        SeekBar bar;
        MediaPlayer mp;
        AudioManager am;
        bool paused;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.layout1);
            start = FindViewById<Button>(Resource.Id.start);
            stop = FindViewById<Button>(Resource.Id.pause);
            bar = FindViewById<SeekBar>(Resource.Id.bar);
            paino = FindViewById<Button>(Resource.Id.piano);
            am = (AudioManager)GetSystemService(AudioService);
            int max = am.GetStreamMaxVolume(Stream.Music);
            bar.Max = max;
            am.SetStreamVolume(Stream.Music, max / 2, 0);
            bar.ProgressChanged += Bar_ProgressChanged;
            start.Click += Start_Click;
            stop.Click += Stop_Click;
            mp = MediaPlayer.Create(this, Resource.Raw.song);
            paused = false;
            paino.Click += Paino_Click;
        }

        private void Paino_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(PianoActivity));
            StartActivity(i);
        }

        private void Bar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            am.SetStreamVolume(Stream.Music, e.Progress / 2, 0);
        }

        private void Stop_Click(object sender, System.EventArgs e)
        {
            if (paused)
            {
                mp.Start();
            }
            else
            {
                mp.Pause();
            }
            paused = !paused;
        }

        private void Start_Click(object sender, System.EventArgs e)
        {
            mp.Start();
            paused = false;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}