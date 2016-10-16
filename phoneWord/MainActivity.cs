using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Runtime;
using Android.Views;

namespace phoneWord
{
	[Activity(Label = "phoneWord", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			//Button button = FindViewById<Button>(Resource.Id.myButton);

			//button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
			EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
			Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
			Button callButton = FindViewById<Button>(Resource.Id.CallButton);


			callButton.Enabled = false;
			string translatedNumber = string.Empty;

			translateButton.Click += (object sender, System.EventArgs e) =>
			{
				translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
				if (translatedNumber.Length > 14 || string.IsNullOrWhiteSpace(translatedNumber) || translatedNumber.Length == 0)
				{
					callButton.Text = ("ascii value of B is: " + Convert.ToString(Convert.ToInt32(Convert.ToChar("B"))));
					callButton.Enabled = false;
				}
				else
				{
					callButton.Text = ("Do you wish to call :" + translatedNumber + "?");
					callButton.Enabled = true;
				}
			};

			callButton.Click += (object sender, System.EventArgs e) =>
			{
				callButton.Text = ("Now completing the call...");
				callButton.Enabled = false;
				var callDialog = new AlertDialog.Builder(this);
				callDialog.SetMessage("Call" + translatedNumber + "?");
				callDialog.SetNeutralButton("Call", delegate {
					var callIntent = new Intent(Intent.ActionCall);
					callIntent.SetData(Android.Net.Uri.Parse("tel:" + translatedNumber));
					StartActivity(callIntent);
			    });
				callDialog.SetNegativeButton("Cancel?", delegate { });

				callDialog.Show();
					
			};
		}
	}
}

