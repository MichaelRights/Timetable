using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using Android.Gms.Ads;

namespace Timetable
{
    [Activity(Label = "@string/app_name", ConfigurationChanges = ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Activity1 : AppCompatActivity {

        AdView adView;
        DatePicker DP;
        ExpandableListView mExListView;
        Dictionary<string, List<string>> myHeader;
        List<string> myChild;
        EListViewAdapter adapter;
        List<string> ChildData;
        DateTime DTNow;
        int IndexofDay;
        string[] day;
        Button mButton;
        int length;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            MobileAds.Initialize(this, "ca-app-pub-5131184764831509~8873327557");
            ShowBannerAd();
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();

            day = DataProvider.getdayInfo(this);
            length = day.Length - 1;

            mButton = FindViewById<Button>(Resource.Id.button1);
            mButton.Click += (sender, e) =>
            {


                editor.Clear();
                editor.Apply();

                Intent I = new Intent(this, typeof(MainActivity));
                StartActivity(I);
                Finish();
            };
            DatePickerChangeHandler datePickerChangeHandler = new DatePickerChangeHandler(this);
            DP = FindViewById<DatePicker>(Resource.Id.datePicker1);
            DTNow = DateTime.Now;
            DP.Init(DTNow.Year, DTNow.Month - 1, DTNow.Day, datePickerChangeHandler);
            
            
            IndexofDay = DTNow.Month == 9 ? (DTNow.Day - 1) % length : DTNow.Month == 10 ? (DTNow.Day + 1) % length : DTNow.Month == 11 ? (DTNow.Day + 4) % length : DTNow.Month == 12 ? (DTNow.Day + 6) % length : length;


            myHeader = DataProvider.getInfo(this);
            myChild = new List<string>();
            myChild.Add(day[IndexofDay]);
            mExListView = FindViewById<ExpandableListView>(Resource.Id.EListView);
            adapter = new EListViewAdapter(this, myHeader, myChild);
            mExListView.SetAdapter(adapter);
            mExListView.ExpandGroup(0);


            mExListView.ChildClick += (sender, e) =>
            {
                if(prefs.Contains("QKG 3") || prefs.Contains("QKG 4") )
                ChildData = DataProvider.getChildInfo(myHeader[day[IndexofDay]][e.ChildPosition],day[IndexofDay],this);
                else ChildData = DataProvider.getChildInfo(myHeader[day[IndexofDay]][e.ChildPosition], this);
                RegisterForContextMenu(mExListView);
                OpenContextMenu(mExListView);
            };
        }

        public void setOnDateChangedListener(int monthOfYear, int dayOfMonth)
        {
            IndexofDay = monthOfYear + 1 == 9 ? (dayOfMonth - 1) % length : monthOfYear + 1 == 10 ? (dayOfMonth + 1) % length : monthOfYear + 1 == 11 ? (dayOfMonth + 4) % length : monthOfYear + 1 == 12 ? (dayOfMonth + 6) % length : length;
            List<string> searchedClass = new List<string>();
            searchedClass.Add(day[IndexofDay]);
            adapter = new EListViewAdapter(this, myHeader, searchedClass);
            mExListView.SetAdapter(adapter);
            mExListView.ExpandGroup(0);
        }


        private void Button_Click(object sender, EventArgs e)
        {
            DP.Init(DTNow.Year, DTNow.Month - 1, DTNow.Day, null);
            IndexofDay = DTNow.Month == 9 ? (DTNow.Day - 1) % length : DTNow.Month == 10 ? (DTNow.Day + 1) % length : DTNow.Month == 11 ? (DTNow.Day + 4) % length : DTNow.Month == 12 ? (DTNow.Day + 6) % length : length;
            List<string> searchedClass = new List<string>();
            searchedClass.Add(day[IndexofDay]);
            adapter = new EListViewAdapter(this, myHeader, searchedClass);
            mExListView.SetAdapter(adapter);

        }


        public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
        {

            base.OnCreateContextMenu(menu, v, menuInfo);
            menu.SetHeaderTitle("Տվյալներ");
            if (ChildData != null)
            {
                menu.Add(0, v.Id, 0, ChildData[0]);
                menu.Add(0, v.Id, 0, ChildData[1]);
                menu.Add(0, v.Id, 0, ChildData[2]);
            }
            ChildData = null;

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



        public void OnDateChanged(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            throw new NotImplementedException();
        }
    }

}