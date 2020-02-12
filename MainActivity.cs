using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Content;
using System.Collections.Generic;

namespace Draper_CIT414_Assignment2_Intents
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button callButton;
        Button emailButton;
        Button mapsButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.Main);

            callButton = FindViewById<Button>(Resource.Id.callButton);
            callButton.Click += CallButton_Click;

            emailButton = FindViewById<Button>(Resource.Id.emailButton);
            emailButton.Click += EmailButton_Click;

            mapsButton = FindViewById<Button>(Resource.Id.mapsButton);
            mapsButton.Click += MapsButton_Click;
          }

        //send email
        private void EmailButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent();
            intent.PutExtra(Android.Content.Intent.ExtraEmail, new String[] {
                "maurod@marshall.edu"
            });
            intent.PutExtra(Android.Content.Intent.ExtraSubject, "Testing an email from Xamarin");
            intent.PutExtra(Android.Content.Intent.ExtraText, "Testing Body of the email message.");
            intent.SetType("message/rfc822");
            StartActivity(intent);
        }

        //open second activity which then leads to making the phone call
        private void CallButton_Click(object sender, EventArgs e)
        {
            //Create an intent and start an activity
            var intent = new Intent(this, typeof(PhoneActivity));
            StartActivity(intent);
        }

        //open maps to morrow library
        private void MapsButton_Click(object sender, EventArgs e)
        {
            //Create an intent and start an activity
            var intent = new Intent();
            intent.SetAction(Intent.ActionView);
            intent.SetData(Android.Net.Uri.Parse("geo:0,0?q=Morrow+Library+Huntington+WV"));
            if (intent.ResolveActivity(PackageManager)!= null)
                {
                    StartActivity(intent);
                }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

