using Android;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App6
{
    [Activity(Label = "PianoActivity")]
    public class PianoActivity : Activity
    {
        Button[] buttons;
        AudioManager am;
        MediaPlayer[] mp; 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layout2);
            buttons = new Button[7];
            buttons[0] = FindViewById<Button>(Resource.Id.dosound);
            buttons[1] = FindViewById<Button>(Resource.Id.re);
            buttons[2] = FindViewById<Button>(Resource.Id.mi);
            buttons[3] = FindViewById<Button>(Resource.Id.fa);
            buttons[4] = FindViewById<Button>(Resource.Id.sol);
            buttons[5] = FindViewById<Button>(Resource.Id.la);
            buttons[6] = FindViewById<Button>(Resource.Id.ci);
            mp = new MediaPlayer[7];
            mp[0] = MediaPlayer.Create(this, Resource.Raw.@do);
            mp[1] = MediaPlayer.Create(this, Resource.Raw.re);
            mp[2] = MediaPlayer.Create(this, Resource.Raw.mi);
            mp[3] = MediaPlayer.Create(this, Resource.Raw.fa);
            mp[4] = MediaPlayer.Create(this, Resource.Raw.so);
            mp[5] = MediaPlayer.Create(this, Resource.Raw.la);
            mp[6] = MediaPlayer.Create(this, Resource.Raw.ci);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += (object sender, EventArgs e) =>
                {
                    mp[i].Start();
                };
            }
        }

    }
}