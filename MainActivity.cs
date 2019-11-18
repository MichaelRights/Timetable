using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Preferences;
using Android.Content;
using Android.Gms.Ads;
namespace Timetable
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", Icon = "@drawable/timetable_icon", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button mButton;
        AdView adView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.main_Menu);


            MobileAds.Initialize(this, "ca-app-pub-5131184764831509~8873327557");
            ShowBannerAd();

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();

            if (prefs.Contains("IKM 1") || prefs.Contains("IKM 2") || prefs.Contains("IKM 3") || prefs.Contains("IKM 4") || prefs.Contains("QKG 4") || prefs.Contains("QKG 3"))
            {
                Intent I = new Intent(this, typeof(Activity1));
                StartActivity(I);
                Finish();
            }
            

            mButton = FindViewById<Button>(Resource.Id.OkButton);
            RadioButton Ikm1 = FindViewById<RadioButton>(Resource.Id.radioButton1);
            RadioButton Ikm2 = FindViewById<RadioButton>(Resource.Id.radioButton2);
            RadioButton Ikm3 = FindViewById<RadioButton>(Resource.Id.radioButton3);
            RadioButton Ikm4 = FindViewById<RadioButton>(Resource.Id.radioButton4);
            RadioButton Qgk3 = FindViewById<RadioButton>(Resource.Id.radioButton5);
            RadioButton Qgk4 = FindViewById<RadioButton>(Resource.Id.radioButton6);

            Ikm1.Click += (sender, e) =>
            {
                editor.Clear();
                editor.PutString("IKM 1", "1");
                editor.Apply();
            };
            Ikm2.Click += (sender, e) =>
            {
                editor.Clear();
                editor.PutString("IKM 2", "1");
                editor.Apply();
            };
            Ikm3.Click += (sender, e) =>
            {
                editor.Clear();
                editor.PutString("IKM 3", "1");
                editor.Apply();
            };
            Ikm4.Click += (sender, e) =>
            {
                editor.Clear();
                editor.PutString("IKM 4", "1");
                editor.Apply();
            };
            Qgk3.Click += (sender, e) =>
            {
                editor.Clear();
                editor.PutString("QKG 3", "1");
                editor.Apply();
            };
            Qgk4.Click += (sender, e) =>
            {
                editor.Clear();
                editor.PutString("QKG 4", "1");
                editor.Apply();
            };

            mButton.Click += delegate
            {
                if (prefs.Contains("IKM 2") || prefs.Contains("IKM 3") || prefs.Contains("IKM 4") || prefs.Contains("QKG 3") || prefs.Contains("QKG 4"))
                {
                    Intent I = new Intent(this, typeof(Activity1));
                    StartActivity(I);
                    Finish();
                }
                else
                {
                    editor.Clear();
                    editor.PutString("IKM 1", "1");
                    editor.Apply();
                    Intent I = new Intent(this, typeof(Activity1));
                    StartActivity(I);
                    Finish();
                }
            };

        }

        private void ShowBannerAd()
        {
            adView = FindViewById<AdView>(Resource.Id.adViewResult);
            AdRequest adRequest = new AdRequest.Builder().Build();
            adView.LoadAd(adRequest);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}