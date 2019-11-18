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

namespace Timetable
{
    public class DatePickerChangeHandler : Java.Lang.Object, DatePicker.IOnDateChangedListener
    {
        private Activity1 Activity1;
        public DatePickerChangeHandler(Activity1 mContext)
        {
            Activity1 = mContext;

        }
        public new IntPtr Handle => base.Handle;
        public new void Dispose()
        {
            base.Dispose();
        }

        public void OnDateChanged(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            Activity1.setOnDateChangedListener(monthOfYear, dayOfMonth);
        }
        
    }
}