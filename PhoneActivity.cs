using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Draper_CIT414_Assignment2_Intents
{
    [Activity(Label = "PhoneActivity")]
    public class PhoneActivity : Activity
    {
        Button makeCallButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Phone);
            makeCallButton = FindViewById<Button>(Resource.Id.makeCallButton);
            makeCallButton.Click += MakeCallButton_Click;
        }
        //make phone call 
        private void MakeCallButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(Intent.ActionDial, Android.Net.Uri.Parse("tel:8323739909"));
            StartActivity(intent);
        }

    }
}