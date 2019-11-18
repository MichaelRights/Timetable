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
    class EListViewAdapter : BaseExpandableListAdapter
    {
        Dictionary<string, List<string>> Child;
        List<string> Headers;
        Context mContext;

        public EListViewAdapter(Context context, Dictionary<string, List<string>> childs, List<string> headers)
        {
            mContext = context;
            Child = childs;
            Headers = headers;
        }

        public override int GroupCount => Headers.Count;

        public override bool HasStableIds => false;

        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            return Child[Headers[groupPosition]][childPosition];
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return groupPosition;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            return Child[Headers[groupPosition]].Count;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            string title = (string)GetChild(groupPosition, childPosition);
            if (convertView == null)
            {
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.ChildLayout, null);
            }
            TextView txt = convertView.FindViewById<TextView>(Resource.Id.idChild);
            txt.Text = title;
            return convertView;
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            return Headers[groupPosition];
        }

        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            string title = (string)GetGroup(groupPosition);
            if (convertView == null)
            {
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.HeaderLayout, null);
            }
            TextView txt = convertView.FindViewById<TextView>(Resource.Id.idHeader);
            txt.Text = title;
            return convertView;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }
    }
}