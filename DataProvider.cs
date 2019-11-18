using System;
using System.Collections.Generic;
using Android.Preferences;
using Android.Content;

namespace Timetable
{
    class DataProvider
    {
        private static string[] T = { "09:15 - 10:40", "10:50 - 12:15", "12:35 - 14:00", "14:10 - 15:35" };
        public static string[] getdayInfo(Context mContext)
        {
            string[] result;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            ISharedPreferencesEditor editor = prefs.Edit();
            if (prefs.Contains("IKM 2") || prefs.Contains("QKG 4"))
            {
                result = new string[29]
            {
                "Կիրակի հյ/հյ", "Երկուշաբթի հմ/հմ", "Երեքշաբթի հմ/հմ", "Չորեքշաբթի հմ/հմ", "Հինգշաբթի հմ/հմ", "Ուրբաթ հմ/հմ", "Շաբաթ հմ/հմ", "Կիրակի հմ/հմ",
                "Երկուշաբթի հյ/հմ", "Երեքշաբթի հյ/հմ", "Չորեքշաբթի հյ/հմ", "Հինգշաբթի հյ/հմ", "Ուրբաթ հյ/հմ", "Շաբաթ հյ/հմ", "Կիրակի հյ/հմ",
                "Երկուշաբթի հմ/հյ", "Երեքշաբթի հմ/հյ", "Չորեքշաբթի հմ/հյ", "Հինգշաբթի հմ/հյ", "Ուրբաթ հմ/հյ", "Շաբաթ հմ/հյ", "Կիրակի հմ/հյ",
                "Երկուշաբթի հյ/հյ", "Երեքշաբթի հյ/հյ", "Չորեքշաբթի հյ/հյ", "Հինգշաբթի հյ/հյ", "Ուրբաթ հյ/հյ", "Շաբաթ հյ/հյ", "Դաս չկա"
            };
                return result;
            }
            if (prefs.Contains("IKM 3"))
            {
                result = new string[29]
            {
                "Կիրակի հյ", "Երկուշաբթի հմ/հմ", "Երեքշաբթի հմ/հմ", "Չորեքշաբթի հմ/հմ", "Հինգշաբթի հմ/հմ", "Ուրբաթ հմ/հմ", "Շաբաթ հմ/հմ", "Կիրակի հմ/հմ",
                "Երկուշաբթի հյ", "Երեքշաբթի հյ", "Չորեքշաբթի հյ", "Հինգշաբթի հյ", "Ուրբաթ հյ", "Շաբաթ հյ", "Կիրակի հյ",
                "Երկուշաբթի հմ/հյ", "Երեքշաբթի հմ/հյ", "Չորեքշաբթի հմ/հյ", "Հինգշաբթի հմ/հյ", "Ուրբաթ հմ/հյ", "Շաբաթ հմ/հյ", "Կիրակի հմ/հյ",
                "Երկուշաբթի հյ", "Երեքշաբթի հյ", "Չորեքշաբթի հյ", "Հինգշաբթի հյ", "Ուրբաթ հյ", "Շաբաթ հյ", "Դաս չկա"
            };
                return result;
            }
            else
            {
                result = new string[15]
            {
                "Կիրակի հյ", "Երկուշաբթի հմ", "Երեքշաբթի հմ", "Չորեքշաբթի հմ", "Հինգշաբթի հմ", "Ուրբաթ հմ", "Շաբաթ հմ", "Կիրակի հմ",
                "Երկուշաբթի հյ", "Երեքշաբթի հյ", "Չորեքշաբթի հյ", "Հինգշաբթի հյ", "Ուրբաթ հյ", "Շաբաթ հյ", "Դաս չկա"
            };
                return result;
            }
        }

        public static List<string> getChildInfo(string Class,Context mContext)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            ISharedPreferencesEditor editor = prefs.Edit();
            if (prefs.Contains("IKM 1")) return getIKM1ChildInfo(Class);
            if (prefs.Contains("IKM 2")) return getIKM2ChildInfo(Class);
            if (prefs.Contains("IKM 3")) return getIKM3ChildInfo(Class);
            else  return getIKM4ChildInfo(Class);

        }
        public static List<string> getChildInfo(string Class, string day,Context mContext)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            ISharedPreferencesEditor editor = prefs.Edit();
            if (prefs.Contains("QKG 3")) return getQKG3ChildInfo(Class, day);
            else return getQKG4ChildInfo(Class, day);
        }
        public static Dictionary<string,List<string>> getInfo(Context mContext)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            ISharedPreferencesEditor editor = prefs.Edit();
            if (prefs.Contains("IKM 1")) return getIKM1Info();
            if (prefs.Contains("IKM 2")) return getIKM2Info();
            if (prefs.Contains("IKM 3")) return getIKM3Info();
            if (prefs.Contains("IKM 4")) return getIKM4Info();
            if (prefs.Contains("QKG 3")) return getQKG3Info();
            else return getQKG4Info();
        }

        // ԻԿՄ 1
        public static List<string> getIKM1ChildInfo(string Class)
        {
            List<string> result = new List<string>();
            switch (Class.Substring(3))
            {
                case "Հայոց լեզու և խոսքի մշակույթ - 1 /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 1");
                        result.Add("Հասանյան Ա․ բ․գ․թ․ ասիստենտ");
                        break;
                    }
                case "Հայոց պատմություն հիմնահարցեր - 1 /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 1");
                        result.Add("Գյոզալյան Գ․ դասախոս");
                        break;
                    }
                case "Հայոց պատմություն հիմնահարցեր - 1 /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 1");
                        result.Add("Գյոզալյան Գ․ դասախոս");
                        break;
                    }
                case "Ռուսերեն - 1 /գ/ I Խումբ":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 1");
                        result.Add("Զարգարյան Ռ․ դասախոս");
                        break;
                    }
                case "Ռուսերեն - 1 /գ/ II Խումբ":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 1");
                        result.Add("Զարգարյան Ռ․ դասախոս");
                        break;
                    }
                case "Անգլերեն - 1 /գ/ I Խումբ":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 1");
                        result.Add("Սիմոնյան Ա․ դասախոս");
                        break;
                    }
                case "Անգլերեն - 1 /գ/ II Խումբ":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 1");
                        result.Add("Թեմրազյան Է․ դասախոս");
                        break;
                    }
                case "Անալիտիկ երկրաչ․ և հանրահաշվի տարրեր /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 1");
                        result.Add("Ցուցուլյան Ա․ ֆ․մ․գ․թ․, դոցենտ");
                        break;
                    }
                case "Անալիտիկ երկրաչ․ և հանրահաշվի տարրեր /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 1");
                        result.Add("Ցուցուլյան Ա․ ֆ․մ․գ․թ․, դոցենտ");
                        break;
                    }
                case "ԷՀՄ և ծրագրավորում /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 1");
                        result.Add("Դարբինյան Կ․ ֆ․մ․գ․թ․, դոցենտ");
                        break;
                    }
                case "ԷՀՄ և ծրագրավորում /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 1");
                        result.Add("Չիբուխչյան Ա․ ֆ․մ․գ․թ․, ասիստենտ");
                        break;
                    }
                case "Մաթ․ Անալիզ - 1 /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 1");
                        result.Add("Վարդազարյան Վ․ ֆ․մ․գ․թ․, դոցենտ");
                        break;
                    }
                case "Մաթ․ Անալիզ - 1 /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 1");
                        result.Add("Վարդազարյան Վ․ ֆ․մ․գ․թ․, դոցենտ");
                        break;
                    }
                    case "Ֆիզդաստիարակություն /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Մարզասրահ");
                        result.Add("Ղարիբյան Ն․, սպորտի վարպետ");
                        break;
                    }
                case "Դիսկրետ մաթեմատիկա - 1 /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 1");
                        result.Add("Հովակիմյան Ա․, ֆ․մ․գ․թ․, դոցենտ");
                        break;
                    }
                    case "Դիսկրետ մաթեմատիկա - 1 /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 1");
                        result.Add("Հովակիմյան Ա․, ֆ․մ․գ․թ․, դոցենտ");
                        break;
                    }
                default:
                    result = null;
                       break;
                }
               return result;
           }
        public static Dictionary<string, List<string>> getIKM1Info()
        {

            Dictionary<string, List<string>> HeaderDetials = new Dictionary<string, List<string>>();
            // hamarich
            List<string> ChildDetials1 = new List<string>();
            ChildDetials1.Add("1: Հայոց լեզու և խոսքի մշակույթ - 1 /գ/");
            ChildDetials1.Add("2: ԷՀՄ և ծրագրավորում /դ/");
            List<string> ChildDetials2 = new List<string>();
            ChildDetials2.Add("1։ Ռուսերեն - 1 /գ/ I Խումբ");
            ChildDetials2.Add("2։ Ռուսերեն - 1 /գ/ I Խումբ");
            ChildDetials2.Add("3։ Անգլերեն - 1 /գ/ I Խումբ");
            List<string> ChildDetials3 = new List<string>();
            ChildDetials3.Add("1։ Անգլերեն - 1 /գ/ I Խումբ");
            ChildDetials3.Add("1։ Ռուսերեն - 1 /գ/ II Խումբ");
            ChildDetials3.Add("2։ Անալիտիկ երկրաչ․ և հանրահաշվի տարրեր /դ/");
            ChildDetials3.Add("3։ Անալիտիկ երկրաչ․ և հանրահաշվի տարրեր /գ/");
            List<string> ChildDetials4 = new List<string>();
            ChildDetials4.Add("1։ Ռուսերեն - 1 /գ/ II Խումբ");
            ChildDetials4.Add("2։ Ռուսերեն - 1 /գ/ II Խումբ");
            List<string> ChildDetials5 = new List<string>();
            ChildDetials5.Add("1։ ԷՀՄ և ծրագրավորում /դ/");
            ChildDetials5.Add("2: Մաթ․ Անալիզ - 1 /դ/");
            ChildDetials5.Add("3: Մաթ․ Անալիզ - 1 /դ/");
            ChildDetials5.Add("4։ Մաթ․ Անալիզ - 1 /գ/");
            List<string> ChildDetials6 = new List<string>();
            ChildDetials6.Add("1: Մաթ․ Անալիզ - 1 /գ/");
            ChildDetials6.Add("2։ ԷՀՄ և ծրագրավորում /դ/");
            ChildDetials6.Add("3: Ֆիզդաստիարակություն /գ/");
            ChildDetials6.Add("4։ Ֆիզդաստիարակություն /գ/");
            List<string> ChildDetials7 = new List<string>();
            ChildDetials7.Add("Դաս չկա");
            // haytarar
            List<string> ChildDetials8 = new List<string>();
            ChildDetials8.Add("1։ ԷՀՄ և ծրագրավորում /դ/");
            ChildDetials8.Add("2։ Հայոց պատմություն հիմնահարցեր - 1 /դ/");
            List<string> ChildDetials9 = new List<string>();
            ChildDetials9.Add("1։ Հայոց պատմություն հիմնահարցեր - 1 /գ/");
            ChildDetials9.Add("2։ Հայոց լեզու և խոսքի մշակույթ - 1 /գ/");
            ChildDetials9.Add("3։ Անգլերեն - 1 /գ/ II Խումբ");
            ChildDetials9.Add("4։ Անգլերեն - 1 /գ/ II Խումբ");
            List<string> ChildDetials10 = new List<string>();
            ChildDetials10.Add("1։ Անալիտիկ երկրաչ․ և հանրահաշվի տարրեր /գ/");
            ChildDetials10.Add("2։ Անգլերեն - 1 /գ/ II Խումբ");
            ChildDetials10.Add("2։ Ռուսերեն - 1 /գ/ I Խումբ");
            ChildDetials10.Add("3։ Անգլերեն - 1 /գ/ II Խումբ");
            ChildDetials10.Add("3։ Ռուսերեն - 1 /գ/ I Խումբ");
            List<string> ChildDetials11 = new List<string>();
            ChildDetials11.Add("1։ Անալիտիկ երկրաչ․ և հանրահաշվի տարրեր /գ/");
            ChildDetials11.Add("2։ Անգլերեն - 1 /գ/ I Խումբ");
            ChildDetials11.Add("2։ Ռուսերեն - 1 /գ/ II Խումբ");
            ChildDetials11.Add("3։ Անգլերեն - 1 /գ/ I Խումբ");
            List<string> ChildDetials12 = new List<string>();
            ChildDetials12.Add("1։ Դիսկրետ մաթեմատիկա - 1 /դ/");
            ChildDetials12.Add("2։ Դիսկրետ մաթեմատիկա - 1 /գ/");
            ChildDetials12.Add("3։ Դիսկրետ մաթեմատիկա - 1 /գ/");
            ChildDetials12.Add("4: Մաթ․ Անալիզ - 1 /գ/");
            List<string> ChildDetials13 = new List<string>();
            ChildDetials13.Add("1: Մաթ․ Անալիզ - 1 /դ/");
            ChildDetials13.Add("2։ Դիսկրետ մաթեմատիկա - 1 /դ/");
            ChildDetials13.Add("3։ ԷՀՄ և ծրագրավորում /գ/");
            ChildDetials13.Add("3։ ԷՀՄ և ծրագրավորում /գ/");
            List<string> ChildDetials14 = new List<string>();
            ChildDetials14.Add("Դաս չկա");
            List<string> ChildDetials0 = new List<string>();
            ChildDetials0.Add("Դաս չկա");


            HeaderDetials["Երկուշաբթի հմ"] = ChildDetials1;
            HeaderDetials["Երեքշաբթի հմ"] = ChildDetials2;
            HeaderDetials["Չորեքշաբթի հմ"] = ChildDetials3;
            HeaderDetials["Հինգշաբթի հմ"] = ChildDetials4;
            HeaderDetials["Ուրբաթ հմ"] = ChildDetials5;
            HeaderDetials["Շաբաթ հմ"] = ChildDetials6;
            HeaderDetials["Կիրակի հմ"] = ChildDetials7;

            HeaderDetials["Երկուշաբթի հյ"] = ChildDetials8;
            HeaderDetials["Երեքշաբթի հյ"] = ChildDetials9;
            HeaderDetials["Չորեքշաբթի հյ"] = ChildDetials10;
            HeaderDetials["Հինգշաբթի հյ"] = ChildDetials11;
            HeaderDetials["Ուրբաթ հյ"] = ChildDetials12;
            HeaderDetials["Շաբաթ հյ"] = ChildDetials13;
            HeaderDetials["Կիրակի հյ"] = ChildDetials14;


            HeaderDetials["Դաս չկա"] = ChildDetials0;
            return HeaderDetials;

        }
        
        // ԻԿՄ 2
        public static List<string> getIKM2ChildInfo(string Class)
        {
            List<string> result = new List<string>();
            switch (Class.Substring(3))
            {
                case "Ֆիզդաստիարակություն /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Մարզասրահ");
                        result.Add("Կարապետյան Պ․ դասախոս");
                        break;
                    }
                case "Ֆիզիկա /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 2");
                        result.Add("Մարգարյան Ա․ ֆ․մ․գ․թ․, ասիստենտ");
                        break;
                    }
                case "Ֆիզիկա /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 2");
                        result.Add("Մարգարյան Ա․ ֆ․մ․գ․թ․, ասիստենտ");
                        break;
                    }
                case "Մասնագիտական Անգլերեն լեզու /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 2");
                        result.Add("Սիմոնյան Ա․ դասախոս");
                        break;
                    }
                case "Իրավունքի հիմունքներ /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 2");
                        result.Add("Բաբլումյան Գ․ դասախոս");
                        break;
                    }
                case "Հանրահաշիվ /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 2");
                        result.Add("Ցուցուլյան Ա․ ֆ․մ․գ․թ․, դոցենտ");
                        break;
                    }
                case "Հանրահաշիվ /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 2");
                        result.Add("Ցուցուլյան Ա․ ֆ․մ․գ․թ․, դոցենտ");
                        break;
                    }
                case "ԷՀՄ ճարտ․ և ասեմբլեր լեզու /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Համակարգչային սրահ 2");
                        result.Add("Օթարյան Ք․ դասախոս");
                        break;
                    }
                case "Մաթ․ անալիզ-3 /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 2");
                        result.Add("Գրիգորյան Գ․ ֆ․մ․գ․թ․, ասիստենտ");
                        break;
                    }
                case "Մաթ․ անալիզ-3 /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 2");
                        result.Add("Գրիգորյան Գ․ ֆ․մ․գ․թ․, ասիստենտ");
                        break;
                    }
                case "Կրոնագիտության հիմունքներ /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 2");
                        result.Add("Հակոբյան Գ․ դասախոս");
                        break;
                    }
                case "Տնտեսագիտության հիմունքներ /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 2");
                        result.Add("Գալստյան Գ․ դասախոս");
                        break;
                    }
                case "Տվյալների կառուցոածքներ /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 2");
                        result.Add("Դարբինյան Կ․ ֆ․մ․գ․թ․, դոցենտ");
                        break;
                    }
                case "Տվյալների կառուցոածքներ /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Համակարգչային սրահ 2");
                        result.Add("Դարբինյան Կ․ ֆ․մ․գ․թ․, դոցենտ");
                        break;
                    }
                case "ԷՀՄ ճարտ․ և ասեմբլեր լեզու /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 2");
                        result.Add("Յոյլչյան Ռ․ տեխ․գ․թ․, դոցենտ");
                        break;
                    }
                default:
                    result = null;
                    break;
            }
            return result;
        }
        public static Dictionary<string, List<string>> getIKM2Info()
        {

            Dictionary<string, List<string>> HeaderDetials = new Dictionary<string, List<string>>();
            // hamarichi hamarich
            List<string> ChildDetials1 = new List<string>();
            ChildDetials1.Add("Դաս չկա");
            List<string> ChildDetials2 = new List<string>();
            ChildDetials2.Add("1։ ԷՀՄ ճարտ․ և ասեմբլեր լեզու /գ/");
            ChildDetials2.Add("2։ Ֆիզիկա /դ/");
            ChildDetials2.Add("3։ Իրավունքի հիմունքներ /դ/");
            List<string> ChildDetials3 = new List<string>();
            ChildDetials3.Add("1։ Հանրահաշիվ /դ/");
            ChildDetials3.Add("2։ Մասնագիտական Անգլերեն լեզու /գ/");
            ChildDetials3.Add("3։ Ֆիզիկա /գ/");
            List<string> ChildDetials4 = new List<string>();
            ChildDetials4.Add("1։ Ֆիզդաստիարակություն /գ/");
            ChildDetials4.Add("2։ Հանրահաշիվ /դ/");
            ChildDetials4.Add("3։ Մաթ․ անալիզ-3 /դ/");
            ChildDetials4.Add("4։ Մաթ․ անալիզ-3 /գ/");
            List<string> ChildDetials5 = new List<string>();
            ChildDetials5.Add("1։ Մաթ․ անալիզ-3 /դ/");
            ChildDetials5.Add("2: Տվյալների կառուցոածքներ /դ/");
            ChildDetials5.Add("3: Տվյալների կառուցոածքներ /գ/");
            List<string> ChildDetials6 = new List<string>();
            ChildDetials6.Add("1: Տվյալների կառուցոածքներ /դ/");
            ChildDetials6.Add("2։ ԷՀՄ ճարտ․ և ասեմբլեր լեզու /դ/");
            ChildDetials6.Add("3: Տվյալների կառուցոածքներ /գ/");
            ChildDetials6.Add("4։ ԷՀՄ ճարտ․ և ասեմբլեր լեզու /դ/");
            List<string> ChildDetials7 = new List<string>();
            ChildDetials7.Add("Դաս չկա");
            // haytarari hamarich
            List<string> ChildDetials8 = new List<string>();
            ChildDetials8.Add("1։ Ֆիզդաստիարակություն /գ/");
            ChildDetials8.Add("2։ Ֆիզիկա /դ/");
            List<string> ChildDetials9 = new List<string>();
            ChildDetials9.Add("1։ Ֆիզիկա /գ/");
            ChildDetials9.Add("2։ Մասնագիտական Անգլերեն լեզու /գ/");
            ChildDetials9.Add("3։ Իրավունքի հիմունքներ /դ/");
            ChildDetials9.Add("4։ Մասնագիտական Անգլերեն լեզու /գ/");
            List<string> ChildDetials10 = new List<string>();
            ChildDetials10.Add("1։ ");
            ChildDetials10.Add("2։ Հանրահաշիվ /դ/");
            ChildDetials10.Add("3։ ԷՀՄ ճարտ․ և ասեմբլեր լեզու /գ/");
            List<string> ChildDetials11 = new List<string>();
            ChildDetials11.Add("1։ Մաթ․ անալիզ-3 /գ/");
            ChildDetials11.Add("2։ Հանրահաշիվ /գ/");
            ChildDetials11.Add("3։ Մաթ․ անալիզ-3 /դ/");
            ChildDetials11.Add("4։ Մաթ․ անալիզ-3 /գ/");
            List<string> ChildDetials12 = new List<string>();
            ChildDetials12.Add("Դաս չկա");
            List<string> ChildDetials13 = new List<string>();
            ChildDetials13.Add("Դաս չկա");
            List<string> ChildDetials14 = new List<string>();
            ChildDetials14.Add("Դաս չկա");
            // hamarichi haytarar
            List<string> ChildDetials15 = new List<string>();
            ChildDetials15.Add("Դաս չկա");
            List<string> ChildDetials16 = new List<string>();
            ChildDetials16.Add("1։ ԷՀՄ ճարտ․ և ասեմբլեր լեզու /գ/");
            ChildDetials16.Add("2։ Ֆիզիկա /դ/");
            ChildDetials16.Add("3։ Իրավունքի հիմունքներ /դ/");
            List<string> ChildDetials17 = new List<string>();
            ChildDetials17.Add("1։ Հանրահաշիվ /դ/");
            ChildDetials17.Add("2։ Մասնագիտական Անգլերեն լեզու /գ/");
            ChildDetials17.Add("3։ Ֆիզիկա /գ/");
            List<string> ChildDetials18 = new List<string>();
            ChildDetials18.Add("1։ Ֆիզդաստիարակություն /գ/");
            ChildDetials18.Add("2։ Հանրահաշիվ /դ/");
            ChildDetials18.Add("3։ Մաթ․ անալիզ-3 /դ/");
            ChildDetials18.Add("4։ Մաթ․ անալիզ-3 /գ/");
            List<string> ChildDetials19 = new List<string>();
            ChildDetials19.Add("1։ Մաթ․ անալիզ-3 /դ/");
            ChildDetials19.Add("2: Տվյալների կառուցոածքներ /դ/");
            ChildDetials19.Add("3: Տվյալների կառուցոածքներ /գ/");
            List<string> ChildDetials20 = new List<string>();
            ChildDetials20.Add("1: Տվյալների կառուցոածքներ /դ/");
            ChildDetials20.Add("2։ ԷՀՄ ճարտ․ և ասեմբլեր լեզու /դ/");
            ChildDetials20.Add("1: Տվյալների կառուցոածքներ /գ/");
            ChildDetials20.Add("2։ ԷՀՄ ճարտ․ և ասեմբլեր լեզու /դ/");
            List<string> ChildDetials21 = new List<string>();
            ChildDetials21.Add("Դաս չկա");
            // haytarari haytarar

            List<string> ChildDetials22 = new List<string>();
            ChildDetials22.Add("1։ Ֆիզդաստիարակություն /գ/");
            ChildDetials22.Add("2։ Ֆիզիկա /դ/");
            List<string> ChildDetials23 = new List<string>();
            ChildDetials23.Add("1։ Ֆիզիկա /գ/");
            ChildDetials23.Add("2։ Մասնագիտական Անգլերեն լեզու /գ/");
            ChildDetials23.Add("3։ Իրավունքի հիմունքներ /դ/");
            ChildDetials23.Add("4։ Մասնագիտական Անգլերեն լեզու /գ/");
            List<string> ChildDetials24 = new List<string>();
            ChildDetials24.Add("1։ ");
            ChildDetials24.Add("2։ Հանրահաշիվ /դ/");
            ChildDetials24.Add("3։ ԷՀՄ ճարտ․ և ասեմբլեր լեզու /գ/");
            List<string> ChildDetials25 = new List<string>();
            ChildDetials25.Add("1։ Մաթ․ անալիզ-3 /գ/");
            ChildDetials25.Add("2։ Հանրահաշիվ /գ/");
            ChildDetials25.Add("3։ Մաթ․ անալիզ-3 /դ/");
            ChildDetials25.Add("4։ Մաթ․ անալիզ-3 /գ/");
            List<string> ChildDetials26 = new List<string>();
            ChildDetials26.Add("1։ Կրոնագիտության հիմունքներ /դ/");
            ChildDetials26.Add("2։ Կրոնագիտության հիմունքներ /դ/");
            ChildDetials26.Add("3։ Կրոնագիտության հիմունքներ /դ/");
            ChildDetials26.Add("4։ Կրոնագիտության հիմունքներ /դ/");
            List<string> ChildDetials27 = new List<string>();
            ChildDetials27.Add("1։ Տնտեսագիտության հիմունքներ /դ/");
            ChildDetials27.Add("2։ Տնտեսագիտության հիմունքներ /դ/");
            ChildDetials27.Add("3։ Տնտեսագիտության հիմունքներ /դ/");
            ChildDetials27.Add("4։ Տնտեսագիտության հիմունքներ /դ/");
            List<string> ChildDetials0 = new List<string>();
            ChildDetials0.Add("Դաս չկա");


            HeaderDetials["Երկուշաբթի հմ/հմ"] = ChildDetials1;
            HeaderDetials["Երեքշաբթի հմ/հմ"] = ChildDetials2;
            HeaderDetials["Չորեքշաբթի հմ/հմ"] = ChildDetials3;
            HeaderDetials["Հինգշաբթի հմ/հմ"] = ChildDetials4;
            HeaderDetials["Ուրբաթ հմ/հմ"] = ChildDetials5;
            HeaderDetials["Շաբաթ հմ/հմ"] = ChildDetials6;
            HeaderDetials["Կիրակի հմ/հմ"] = ChildDetials7;

            HeaderDetials["Երկուշաբթի հյ/հմ"] = ChildDetials8;
            HeaderDetials["Երեքշաբթի հյ/հմ"] = ChildDetials9;
            HeaderDetials["Չորեքշաբթի հյ/հմ"] = ChildDetials10;
            HeaderDetials["Հինգշաբթի հյ/հմ"] = ChildDetials11;
            HeaderDetials["Ուրբաթ հյ/հմ"] = ChildDetials12;
            HeaderDetials["Շաբաթ հյ/հմ"] = ChildDetials13;
            HeaderDetials["Կիրակի հյ/հմ"] = ChildDetials14;

            HeaderDetials["Երկուշաբթի հմ/հյ"] = ChildDetials15;
            HeaderDetials["Երեքշաբթի հմ/հյ"] = ChildDetials16;
            HeaderDetials["Չորեքշաբթի հմ/հյ"] = ChildDetials17;
            HeaderDetials["Հինգշաբթի հմ/հյ"] = ChildDetials18;
            HeaderDetials["Ուրբաթ հմ/հյ"] = ChildDetials19;
            HeaderDetials["Շաբաթ հմ/հյ"] = ChildDetials20;
            HeaderDetials["Կիրակի հմ/հյ"] = ChildDetials21;

            HeaderDetials["Երկուշաբթի հյ/հյ"] = ChildDetials22;
            HeaderDetials["Երեքշաբթի հյ/հյ"] = ChildDetials23;
            HeaderDetials["Չորեքշաբթի հյ/հյ"] = ChildDetials24;
            HeaderDetials["Հինգշաբթի հյ/հյ"] = ChildDetials25;
            HeaderDetials["Ուրբաթ հյ/հյ"] = ChildDetials26;
            HeaderDetials["Շաբաթ հյ/հյ"] = ChildDetials27;
            HeaderDetials["Կիրակի հյ/հյ"] = ChildDetials0;

            HeaderDetials["Դաս չկա"] = ChildDetials0;
            return HeaderDetials;

        }

        // ԻԿՄ 3
        public static List<string> getIKM3ChildInfo(string Class)
        {
            List<string> result = new List<string>();
            switch (Class.Substring(3))
            {
                case "Հավանականությունների տես․ և մաթ․ վիճ /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 3");
                        result.Add("Հովսեփյան Կ․ ֆ․մ․գ․թ․, դոցենտ");
                        break;
                    }
                case "Մաթ․ մոդելավորում և թվային մեթոդներ /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Համակարգչային սրահ 2");
                        result.Add("Օթարյան Ք․ դասախոս");
                        break;
                    }
                case "Մաթ․ մոդելավորում և թվային մեթոդներ /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 3");
                        result.Add("Մակարյան Ա․ ֆ․մ․գ․թ․ դոցենտ");
                        break;
                    }
                case "Կիսահաղորդչային սարքերի ֆիզիկա /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 3");
                        result.Add("Գուլակյան Գ․ դասախոս");
                        break;
                    }
                case "Կիսահաղորդչային սարքերի ֆիզիկա /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 3");
                        result.Add("Գուլակյան Գ․ դասախոս");
                        break;
                    }
                case "Ֆունկցիոնալ անալիզ /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 3");
                        result.Add("Գրիգորյան Գ․ ֆ․մ․գ․թ․, ասիստենտ");
                        break;
                    }
                case "Դիֆ․ հավասարումներ /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 3");
                        result.Add("Քամալյան Հ․ ֆ․մ․գ․թ․, ասիստենտ");
                        break;
                    }
                case "Դիֆ․ հավասարումներ /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 3");
                        result.Add("Քամալյան Հ․ ֆ․մ․գ․թ․, ասիստենտ");
                        break;
                    }

                default:
                    result = null;
                    break;
            }
            return result;
        }
        public static Dictionary<string, List<string>> getIKM3Info()
        {

            Dictionary<string, List<string>> HeaderDetials = new Dictionary<string, List<string>>();
            // hamarich/hamarich
            List<string> ChildDetials1 = new List<string>();
            ChildDetials1.Add("1: Հավանականությունների տես․ և մաթ․ վիճ /դ/");
            ChildDetials1.Add("2: Մաթ․ մոդելավորում և թվային մեթոդներ /գ/");
            ChildDetials1.Add("3: Հավանականությունների տես․ և մաթ․ վիճ /դ/");
            List<string> ChildDetials2 = new List<string>();
            ChildDetials2.Add("1։ Մաթ․ մոդելավորում և թվային մեթոդներ /գ/");
            ChildDetials2.Add("2։ Հավանականությունների տես․ և մաթ․ վիճ /գ/");
            List<string> ChildDetials3 = new List<string>();
            ChildDetials3.Add("1։ Մաթ․ մոդելավորում և թվային մեթոդներ /գ/");
            ChildDetials3.Add("2։ Մաթ․ մոդելավորում և թվային մեթոդներ /դ/");
            ChildDetials3.Add("3։ Կիսահաղորդչային սարքերի ֆիզիկա /գ/");
            List<string> ChildDetials4 = new List<string>();
            ChildDetials4.Add("1։ Ֆունկցիոնալ անալիզ /դ/");
            ChildDetials4.Add("2։ Ֆունկցիոնալ անալիզ /դ/");
            List<string> ChildDetials5 = new List<string>();
            ChildDetials5.Add("1։ ");
            ChildDetials5.Add("2։ Ֆունկցիոնալ անալիզ /դ/");
            ChildDetials5.Add("3: Դիֆ․ հավասարումներ /դ/");
            ChildDetials5.Add("4։ Դիֆ․ հավասարումներ /դ/");
            List<string> ChildDetials6 = new List<string>();
            ChildDetials6.Add("Դաս չկա");
            List<string> ChildDetials7 = new List<string>();
            ChildDetials7.Add("Դաս չկա");
            // haytarar
            List<string> ChildDetials8 = new List<string>();
            ChildDetials8.Add("1։ Հավանականությունների տես․ և մաթ․ վիճ /դ/");
            ChildDetials8.Add("2։ Մաթ․ մոդելավորում և թվային մեթոդներ /գ/");
            List<string> ChildDetials9 = new List<string>();
            ChildDetials9.Add("1։ Հավանականությունների տես․ և մաթ․ վիճ /դ/");
            ChildDetials9.Add("2։ Հավանականությունների տես․ և մաթ․ վիճ /դ/");
            List<string> ChildDetials10 = new List<string>();
            ChildDetials10.Add("1։ Մաթ․ մոդելավորում և թվային մեթոդներ /դ/");
            ChildDetials10.Add("2։ Կիսահաղորդիչ սարքերի ֆիզիկա /գ/");
            List<string> ChildDetials11 = new List<string>();
            ChildDetials11.Add("Դաս չկա");
            List<string> ChildDetials12 = new List<string>();
            ChildDetials12.Add("1։ Դիֆ․ հավասարումներ /դ/");
            ChildDetials12.Add("2։ Դիֆ․ հավասարումներ /գ/");
            ChildDetials12.Add("3։ Ֆունկցիոնալ անալիզ /դ/");
            ChildDetials12.Add("4: Ֆունկցիոնալ անալիզ /դ/");
            List<string> ChildDetials13 = new List<string>();
            ChildDetials13.Add("1: ");
            ChildDetials13.Add("2։ Դիֆ․ հավասարումներ /դ/");
            ChildDetials13.Add("3։ Դիֆ․ հավասարումներ /դ/");
            List<string> ChildDetials14 = new List<string>();
            ChildDetials14.Add("Դաս չկա");

            //hamarich/haytarar
            List<string> ChildDetials15 = new List<string>();
            ChildDetials15.Add("1: Հավանականությունների տես․ և մաթ․ վիճ /դ/");
            ChildDetials15.Add("2: Մաթ․ մոդելավորում և թվային մեթոդներ /գ/");
            ChildDetials15.Add("3: Հավանականությունների տես․ և մաթ․ վիճ /դ/");
            List<string> ChildDetials16 = new List<string>();
            ChildDetials16.Add("1։ Մաթ․ մոդելավորում և թվային մեթոդներ /գ/");
            ChildDetials16.Add("2։ Հավանականությունների տես․ և մաթ․ վիճ /գ/");
            List<string> ChildDetials17 = new List<string>();
            ChildDetials17.Add("1։ Մաթ․ մոդելավորում և թվային մեթոդներ /գ/");
            ChildDetials17.Add("2։ Մաթ․ մոդելավորում և թվային մեթոդներ /դ/");
            ChildDetials17.Add("3։ Կիսահաղորդչային սարքերի ֆիզիկա /գ/");
            List<string> ChildDetials18 = new List<string>();
            ChildDetials18.Add("1։ Ֆունկցիոնալ անալիզ /դ/");
            ChildDetials18.Add("2։ Ֆունկցիոնալ անալիզ /դ/");
            List<string> ChildDetials19 = new List<string>();
            ChildDetials19.Add("1։ ");
            ChildDetials19.Add("2։ Ֆունկցիոնալ անալիզ /դ/");
            ChildDetials19.Add("3: Կիսահաղորդչային սարքերի ֆիզիկա /դ/");
            ChildDetials19.Add("4։ Կիսահաղորդչային սարքերի ֆիզիկա /դ/");
            List<string> ChildDetials20 = new List<string>();
            ChildDetials20.Add("1։ Կիսահաղորդչային սարքերի ֆիզիկա /դ/");
            ChildDetials20.Add("2։ Կիսահաղորդչային սարքերի ֆիզիկա /դ/");
            ChildDetials20.Add("3։ Կիսահաղորդչային սարքերի ֆիզիկա /դ/");
            ChildDetials20.Add("4։ Կիսահաղորդչային սարքերի ֆիզիկա /դ/");
            List<string> ChildDetials21 = new List<string>();
            ChildDetials21.Add("Դաս չկա");

            List<string> ChildDetials0 = new List<string>();
            ChildDetials0.Add("Դաս չկա");


            HeaderDetials["Երկուշաբթի հմ/հմ"] = ChildDetials1;
            HeaderDetials["Երեքշաբթի հմ/հմ"] = ChildDetials2;
            HeaderDetials["Չորեքշաբթի հմ/հմ"] = ChildDetials3;
            HeaderDetials["Հինգշաբթի հմ/հմ"] = ChildDetials4;
            HeaderDetials["Ուրբաթ հմ/հմ"] = ChildDetials5;
            HeaderDetials["Շաբաթ հմ/հմ"] = ChildDetials6;
            HeaderDetials["Կիրակի հմ/հմ"] = ChildDetials7;

            HeaderDetials["Երկուշաբթի հյ"] = ChildDetials8;
            HeaderDetials["Երեքշաբթի հյ"] = ChildDetials9;
            HeaderDetials["Չորեքշաբթի հյ"] = ChildDetials10;
            HeaderDetials["Հինգշաբթի հյ"] = ChildDetials11;
            HeaderDetials["Ուրբաթ հյ"] = ChildDetials12;
            HeaderDetials["Շաբաթ հյ"] = ChildDetials13;
            HeaderDetials["Կիրակի հյ"] = ChildDetials14;

            HeaderDetials["Երկուշաբթի հմ/հյ"] = ChildDetials1;
            HeaderDetials["Երեքշաբթի հմ/հյ"] = ChildDetials2;
            HeaderDetials["Չորեքշաբթի հմ/հյ"] = ChildDetials3;
            HeaderDetials["Հինգշաբթի հմ/հյ"] = ChildDetials4;
            HeaderDetials["Ուրբաթ հմ/հյ"] = ChildDetials5;
            HeaderDetials["Շաբաթ հմ/հյ"] = ChildDetials6;
            HeaderDetials["Կիրակի հմ/հյ"] = ChildDetials7;


            HeaderDetials["Դաս չկա"] = ChildDetials0;
            return HeaderDetials;

        }

        // ԻԿՄ 4
        public static List<string> getIKM4ChildInfo(string Class)
        {
            List<string> result = new List<string>();
            switch (Class.Substring(3))
            {
                case "Կոմբ․ ալգորիթմներ և վերլուծություն /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 4");
                        result.Add("Գևորգյան Ա․ դասախոս");
                        break;
                    }
                case "Կոմբ․ ալգորիթմներ և վերլուծություն /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 4");
                        result.Add("Գևորգյան Ա․ դասախոս");
                        break;
                    }
                case "Թարգմանությունների տեսություն /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 6");
                        result.Add("Ճաղարյան Մ․ ասիստենտ");
                        break;
                    }
                case "Թարգմանությունների տեսություն /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 6");
                        result.Add("Ճաղարյան Մ․ ասիստենտ");
                        break;
                    }
                case "Մաթ․ կիբեռնետիկայի տարրեր /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 4");
                        result.Add("Յոլչյան Ռ․ ֆ․մ․գ․թ․, դոցենտ");
                        break;
                    }
                case "Մաթ․ կիբեռնետիկայի տարրեր /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 4");
                        result.Add("Յոլչյան Ռ․ ֆ․մ․գ․թ․, դոցենտ");
                        break;
                    }
                case "Կրիպտոգրաֆիա /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 4");
                        result.Add("Յոլչյան Ռ․ ֆ․մ․գ․թ․, դոցենտ");
                        break;
                    }
                case "Կրիպտոգրաֆիա /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 4");
                        result.Add("Յոլչյան Ռ․ ֆ․մ․գ․թ․, դոցենտ");
                        break;
                    }
                case "Web ծրագրավորում /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Համակարգչային սրահ 2");
                        result.Add("Ծատուրյան Լ․ դասախոս");
                        break;
                    }
                case "Web ծրագրավորում /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Համակարգչային սրահ 2");
                        result.Add("Ծատուրյան Լ․ դասախոս");
                        break;
                    }
                case "Մաթ․ Տրամաբանություն /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 4");
                        result.Add("Հովակիմյան Ա․ տեխ․գ․թ․,դոցենտ");
                        break;
                    }
                default:
                    result = null;
                    break;
            }
            return result;
        }
        public static Dictionary<string, List<string>> getIKM4Info()
        {

            Dictionary<string, List<string>> HeaderDetials = new Dictionary<string, List<string>>();
            // hamarich
            List<string> ChildDetials1 = new List<string>();
            ChildDetials1.Add("Դաս չկա");
            List<string> ChildDetials2 = new List<string>();
            ChildDetials2.Add("Դաս չկա");
            List<string> ChildDetials3 = new List<string>();
            ChildDetials3.Add("1։ Կոմբ․ ալգորիթմներ և վերլուծություն /դ/");
            ChildDetials3.Add("2։ Կոմբ․ ալգորիթմներ և վերլուծություն /գ/");
            List<string> ChildDetials4 = new List<string>();
            ChildDetials4.Add("1։ Թարգմանությունների տեսություն /դ/");
            ChildDetials4.Add("2։ Թարգմանությունների տեսություն /դ/");
            List<string> ChildDetials5 = new List<string>();
            ChildDetials5.Add("1։ Մաթ․ կիբեռնետիկայի տարրեր /դ/");
            ChildDetials5.Add("2։ Մաթ․ կիբեռնետիկայի տարրեր /գ/");
            ChildDetials5.Add("3: Մաթ․ կիբեռնետիկայի տարրեր /գ/");
            List<string> ChildDetials6 = new List<string>();
            ChildDetials6.Add("1։ Կրիպտոգրաֆիա /դ/");
            ChildDetials6.Add("2։ Web ծրագրավորում /դ/");
            ChildDetials6.Add("3։ Կրիպտոգրաֆիա /գ/");
            List<string> ChildDetials7 = new List<string>();
            ChildDetials7.Add("Դաս չկա");
            // haytarar
            List<string> ChildDetials8 = new List<string>();
            ChildDetials8.Add("1։ Թարգմանությունների տեսություն /դ/");
            ChildDetials8.Add("2։ Web ծրագրավորում /գ/");
            List<string> ChildDetials9 = new List<string>();
            ChildDetials9.Add("1։ Թարգմանությունների տեսություն /գ/");
            ChildDetials9.Add("2։ Թարգմանությունների տեսություն /գ/");
            List<string> ChildDetials10 = new List<string>();
            ChildDetials10.Add("1։ Կոմբ․ ալգորիթմներ և վերլուծություն /դ/");
            ChildDetials10.Add("2։ Կոմբ․ ալգորիթմներ և վերլուծություն /գ/");
            List<string> ChildDetials11 = new List<string>();
            ChildDetials11.Add("Դաս չկա");
            List<string> ChildDetials12 = new List<string>();
            ChildDetials12.Add("1։ Մաթ․ կիբեռնետիկայի տարրեր /դ/");
            ChildDetials12.Add("2։ Մաթ․ կիբեռնետիկայի տարրեր /գ/");
            ChildDetials12.Add("3։ Կրիպտոգրաֆիա /դ/");
            ChildDetials12.Add("4։ Կրիպտոգրաֆիա /գ/");
            List<string> ChildDetials13 = new List<string>();
            ChildDetials13.Add("1։ Մաթ․ Տրամաբանություն /դ/");
            ChildDetials13.Add("2։ Web ծրագրավորում /դ/");
            ChildDetials13.Add("3։ Մաթ․ Տրամաբանություն /դ/");
            ChildDetials13.Add("4։ Մաթ․ Տրամաբանություն /դ/");
            List<string> ChildDetials14 = new List<string>();
            ChildDetials14.Add("Դաս չկա");

            List<string> ChildDetials0 = new List<string>();
            ChildDetials0.Add("Դաս չկա");


            HeaderDetials["Երկուշաբթի հմ"] = ChildDetials1;
            HeaderDetials["Երեքշաբթի հմ"] = ChildDetials2;
            HeaderDetials["Չորեքշաբթի հմ"] = ChildDetials3;
            HeaderDetials["Հինգշաբթի հմ"] = ChildDetials4;
            HeaderDetials["Ուրբաթ հմ"] = ChildDetials5;
            HeaderDetials["Շաբաթ հմ"] = ChildDetials6;
            HeaderDetials["Կիրակի հմ"] = ChildDetials7;

            HeaderDetials["Երկուշաբթի հյ"] = ChildDetials8;
            HeaderDetials["Երեքշաբթի հյ"] = ChildDetials9;
            HeaderDetials["Չորեքշաբթի հյ"] = ChildDetials10;
            HeaderDetials["Հինգշաբթի հյ"] = ChildDetials11;
            HeaderDetials["Ուրբաթ հյ"] = ChildDetials12;
            HeaderDetials["Շաբաթ հյ"] = ChildDetials13;
            HeaderDetials["Կիրակի հյ"] = ChildDetials14;


            HeaderDetials["Դաս չկա"] = ChildDetials0;
            return HeaderDetials;

        }

        // ՔԿԳ 3
        public static List<string> getQKG3ChildInfo(string Class, string day)
        {
            List<string> result = new List<string>();
            switch (Class.Substring(3))
            {
                case "Անշարժ գույքի գնահատում /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        if (day == "Երկուշաբթի հմ" || day == "Երեքշաբթի հյ")
                            result.Add("Լսարան 2");
                        if (day == "Ուրբաթ հմ")
                            result.Add("Լսարան 3");
                        result.Add("Հայրապետյան Հ․ դասախոս");
                        break;
                    }
                case "Անշարժ գույքի գնահատում /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 2");
                        result.Add("Հայրապետյան Հ․ դասախոս");
                        break;
                    }
                case "Անշարժ գույքի էկոնոմ․ և պլանավորում /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        if (day == "Երկուշաբթի հմ") 
                            result.Add("Լսարան 2");
                        if( day == "Ուրբաթ հմ")
                            result.Add("Լսարան 3");
                        if (day == "Ուրբաթ հյ")
                            result.Add("Լսարան 5");
                        result.Add("Հայրապետյան Հ․ դասախոս");
                        break;
                    }
                case "Լանդշաֆտագիտ․ և լանդ․ պլանավորում /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        if (day == "Ուրբաթ հյ")
                            result.Add("Լսարան 5");
                        else
                            result.Add("Լսարան 4");
                        result.Add("Ասիլբեկյան Պ․ ասիստենտ");
                        break;
                    }
                case "Լանդշաֆտագիտ․ և լանդ․ պլանավորում /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 4");
                        result.Add("Ասիլբեկյան Պ․ ասիստենտ");
                        break;
                    }
                case "ՀՀ աշխարհագրություն /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        if (day == "Երեքշաբթի հյ")
                            result.Add("Լսարան 2");
                        else
                            result.Add("Լսարան 4");
                        result.Add("Ասիլբեկյան Պ․ ասիստենտ");
                        break;
                    }
                case "ՀՀ աշխարհագրություն /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 4");
                        result.Add("Ասիլբեկյան Պ․ ասիստենտ");
                        break;
                    }
                case "Քաղաքաշին․ և բն․ պլանավորում /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        if (day == "Հինգշաբթի հմ")
                            result.Add("Լսարան 3");
                        else
                            result.Add("Լսարան 5");
                        result.Add("Հակոբյան Ա․ դասախոս");
                        break;
                    }
                case "Կառուցապատված տարածքների կադաստր /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 3");
                        result.Add("Դավթյան Ս․ Տեխ․ գ․թ․ ասիստենտ");
                        break;
                    }
                case "Կառուցապատված տարածքների կադաստր /գ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 3");
                        result.Add("Դավթյան Ս․ Տեխ․ գ․թ․ ասիստենտ");
                        break;
                    }
                case "Քարտեզների նախագծում և կազմում /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("կ․ համակարգչային սրահ");
                        result.Add("Մուրադյան Վ․ աշխ․ գ․թ․ դոցենտ");
                        break;
                    }
                case "Քարտեզների նախագծում և կազմում /լ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("կ․ համակարգչային սրահ");
                        result.Add("Մուրադյան Վ․ աշխ․ գ․թ․ դոցենտ");
                        break;
                    }

                default:
                    result = null;
                    break;
            }
            return result;
        }
        public static Dictionary<string, List<string>> getQKG3Info()
        {

            Dictionary<string, List<string>> HeaderDetials = new Dictionary<string, List<string>>();
            // hamarich
            List<string> ChildDetials1 = new List<string>();
            ChildDetials1.Add("1։ Անշարժ գույքի գնահատում /դ/");
            ChildDetials1.Add("2։ Անշարժ գույքի գնահատում /գ/");
            ChildDetials1.Add("3։ Անշարժ գույքի էկոնոմ․ և պլանավորում /դ/");
            List<string> ChildDetials2 = new List<string>();
            ChildDetials2.Add("1։ Լանդշաֆտագիտ․ և լանդ․ պլանավորում /դ/");
            ChildDetials2.Add("2։ Լանդշաֆտագիտ․ և լանդ․ պլանավորում /գ/");
            ChildDetials2.Add("3։ ՀՀ աշխարհագրություն /դ/");
            ChildDetials2.Add("4։ ՀՀ աշխարհագրություն /գ/");
            List<string> ChildDetials3 = new List<string>();
            ChildDetials3.Add("Դաս չկա");
            List<string> ChildDetials4 = new List<string>();
            ChildDetials4.Add("1։ Քաղաքաշին․ և բն․ պլանավորում /դ/");
            ChildDetials4.Add("2։ Քաղաքաշին․ և բն․ պլանավորում /դ/");
            ChildDetials4.Add("3։ ՀՀ աշխարհագրություն /դ/");
            List<string> ChildDetials5 = new List<string>();
            ChildDetials5.Add("1։ Անշարժ գույքի գնահատում /դ/");
            ChildDetials5.Add("2։ Անշարժ գույքի էկոնոմ․ և պլանավորում /դ/");
            List<string> ChildDetials6 = new List<string>();
            ChildDetials6.Add("Դաս չկա");
            List<string> ChildDetials7 = new List<string>();
            ChildDetials7.Add("Դաս չկա");
            // haytarar
            List<string> ChildDetials8 = new List<string>();
            ChildDetials8.Add("Դաս չկա");
            List<string> ChildDetials9 = new List<string>();
            ChildDetials9.Add("1։ Անշարժ գույքի գնահատում /դ/");
            ChildDetials9.Add("2։ Անշարժ գույքի գնահատում /գ/");
            ChildDetials9.Add("3։ ՀՀ աշխարհագրություն /դ/");
            List<string> ChildDetials10 = new List<string>();
            ChildDetials10.Add("1։ Քաղաքաշին․ և բն․ պլանավորում /դ/");
            ChildDetials10.Add("2։ ՀՀ աշխարհագրություն /դ/");
            List<string> ChildDetials11 = new List<string>();
            ChildDetials11.Add("1։ Կառուցապատված տարածքների կադաստր /դ/");
            ChildDetials11.Add("2։ Կառուցապատված տարածքների կադաստր /դ/");
            ChildDetials11.Add("3։ Կառուցապատված տարածքների կադաստր /գ/");
            ChildDetials11.Add("4։ Կառուցապատված տարածքների կադաստր /գ/");
            List<string> ChildDetials12 = new List<string>();
            ChildDetials12.Add("1։ Լանդշաֆտագիտ․ և լանդ․ պլանավորում /դ/");
            ChildDetials12.Add("2։ Անշարժ գույքի էկոնոմ․ և պլանավորում /դ/");
            ChildDetials12.Add("3։ Անշարժ գույքի էկոնոմ․ և պլանավորում /գ/");
            List<string> ChildDetials13 = new List<string>();
            ChildDetials13.Add("1։ Քարտեզների նախագծում և կազմում /դ/");
            ChildDetials13.Add("2։ Քարտեզների նախագծում և կազմում /դ/");
            ChildDetials13.Add("3։ Քարտեզների նախագծում և կազմում /լ/");
            ChildDetials13.Add("4։ Քարտեզների նախագծում և կազմում /լ/");
            List<string> ChildDetials14 = new List<string>();
            ChildDetials14.Add("Դաս չկա");

            List<string> ChildDetials0 = new List<string>();
            ChildDetials0.Add("Դաս չկա");


            HeaderDetials["Երկուշաբթի հմ"] = ChildDetials1;
            HeaderDetials["Երեքշաբթի հմ"] = ChildDetials2;
            HeaderDetials["Չորեքշաբթի հմ"] = ChildDetials3;
            HeaderDetials["Հինգշաբթի հմ"] = ChildDetials4;
            HeaderDetials["Ուրբաթ հմ"] = ChildDetials5;
            HeaderDetials["Շաբաթ հմ"] = ChildDetials6;
            HeaderDetials["Կիրակի հմ"] = ChildDetials7;

            HeaderDetials["Երկուշաբթի հյ"] = ChildDetials8;
            HeaderDetials["Երեքշաբթի հյ"] = ChildDetials9;
            HeaderDetials["Չորեքշաբթի հյ"] = ChildDetials10;
            HeaderDetials["Հինգշաբթի հյ"] = ChildDetials11;
            HeaderDetials["Ուրբաթ հյ"] = ChildDetials12;
            HeaderDetials["Շաբաթ հյ"] = ChildDetials13;
            HeaderDetials["Կիրակի հյ"] = ChildDetials14;


            HeaderDetials["Դաս չկա"] = ChildDetials0;
            return HeaderDetials;

        }

        // ՔԿԳ 4
        public static List<string> getQKG4ChildInfo(string Class, string day)
        {
            List<string> result = new List<string>();
            switch (Class.Substring(3))
            {
                case "Քարտեզների ձև․ և համ․ դիզայն /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Համակարգչային սրահ 1");

                        result.Add("Բեկնազարյան Օ․ դասախոս");
                        break;
                    }
                case "Քարտեզների ձև․ և համ․ դիզայն /լ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Համակարգչային սրահ 1");

                        result.Add("Բեկնազարյան Օ․ դասախոս");
                        break;
                    }
                case "Հողային ռեսուրսների կառավարում /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 5");

                        result.Add("Հակոբյան Ա․ դասախոս");
                        break;
                    }
                case "Հողային ռեսուրսների կառավարում /լ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        if (day == "Հինգշաբթի հմ/հմ" || day == "Հինգշաբթի հմ/հյ")
                            result.Add("Լսարան 2");
                        else
                            result.Add("Լսարան 5");
                        result.Add("Հակոբյան Ա․ դասախոս");
                        break;
                    }
                case "Հողային և քաղաքային կադաստր /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        if (day == "Հինգշաբթի հմ/հմ" || day == "Հինգշաբթի հմ/հյ")
                            result.Add("Լսարան 3");
                        else
                            result.Add("Լսարան 5");
                        result.Add("Հակոբյան Ա․ դասախոս");
                        break;
                    }
                case "Հողային և անտ․ ռես․ կադ և մոտ /լ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 7");
                        result.Add("Ալավերդյան Ա․ կ․գ․թ․ դոցենտ");
                        break;
                    }
                case "Հողային և անտ․ ռես․ կադ և մոտ /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Լսարան 7");
                        result.Add("Ալավերդյան Ա․ կ․գ․թ․ դոցենտ");
                        break;
                    }
                case "Թվային քարտեզագրություն /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Համակարգչային սրահ 1");
                        result.Add("Սարգսյան է․ դասախոս");
                        break;
                    }
                case "Թվային քարտեզագրություն /լ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Համակարգչային սրահ 1");
                        result.Add("Սարգսյան է․ դասախոս");
                        break;
                    }
                case "ԱՏՀ տեխն․ Կիրառ․ և GPS /լ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Համակարգչային սրահ 1");
                        result.Add("Մովսիսյան Հ․ երկ․գ․թ․ դոցենտ");
                        break;
                    }
                case "ԱՏՀ տեխն․ Կիրառ․ և GPS /դ/":
                    {
                        if (Class.Substring(0, 1) == "1")
                            result.Add(T[0]);
                        if (Class.Substring(0, 1) == "2")
                            result.Add(T[1]);
                        if (Class.Substring(0, 1) == "3")
                            result.Add(T[2]);
                        if (Class.Substring(0, 1) == "4")
                            result.Add(T[3]);
                        result.Add("Համակարգչային սրահ 1");
                        result.Add("Մովսիսյան Հ․ երկ․գ․թ․ դոցենտ");
                        break;
                    }

                default:
                    result = null;
                    break;
            }
            return result;
        }
        public static Dictionary<string, List<string>> getQKG4Info()
        {

            Dictionary<string, List<string>> HeaderDetials = new Dictionary<string, List<string>>();
            // hamarich hamarich
            List<string> ChildDetials1 = new List<string>();
            ChildDetials1.Add("Դաս չկա");
            List<string> ChildDetials2 = new List<string>();
            ChildDetials2.Add("1։ Քարտեզների ձև․ և համ․ դիզայն /դ/");
            ChildDetials2.Add("2։ Քարտեզների ձև․ և համ․ դիզայն /դ/");
            List<string> ChildDetials3 = new List<string>();
            ChildDetials3.Add("1։ Հողային ռեսուրսների կառավարում /դ/");
            ChildDetials3.Add("2։ Հողային ռեսուրսների կառավարում /լ/");
            List<string> ChildDetials4 = new List<string>();
            ChildDetials4.Add("1։ Հողային ռեսուրսների կառավարում /լ/");
            ChildDetials4.Add("2։ Քարտեզների ձև․ և համ․ դիզայն /դ/" );
            ChildDetials4.Add("3։ Հողային և քաղաքային կադաստր /դ/");
            List<string> ChildDetials5 = new List<string>();
            ChildDetials5.Add("1։ Հողային և անտ․ ռես․ կադ և մոտ /լ/");
            ChildDetials5.Add("2։ Հողային և անտ․ ռես․ կադ և մոտ /լ/");
            ChildDetials5.Add("3։ Հողային և անտ․ ռես․ կադ և մոտ /լ/");
            ChildDetials5.Add("4։ Հողային և անտ․ ռես․ կադ և մոտ /լ/");
            List<string> ChildDetials6 = new List<string>();
            ChildDetials6.Add("1։ Թվային քարտեզագրություն /դ/");
            ChildDetials6.Add("2։ Թվային քարտեզագրություն /դ/");
            ChildDetials6.Add("3։ Թվային քարտեզագրություն /դ/");
            ChildDetials6.Add("4։ Թվային քարտեզագրություն /լ/");
            List<string> ChildDetials7 = new List<string>();
            ChildDetials7.Add("Դաս չկա");
            // haytarar hamarich
            List<string> ChildDetials8 = new List<string>();
            ChildDetials8.Add("Դաս չկա");
            List<string> ChildDetials9 = new List<string>();
            ChildDetials9.Add("1։ Հողային և քաղաքային կադաստր /դ/");
            ChildDetials9.Add("2։ Հողային ռեսուրսների կառավարում /դ/");
            List<string> ChildDetials10 = new List<string>();
            ChildDetials10.Add("1։ Քարտեզների ձև․ և համ․ դիզայն /դ/");
            ChildDetials10.Add("2։ Քարտեզների ձև․ և համ․ դիզայն /լ/");
            ChildDetials10.Add("3։ Հողային ռեսուրսների կառավարում /լ/");
            List<string> ChildDetials11 = new List<string>();
            ChildDetials11.Add("1։ ԱՏՀ տեխն․ Կիրառ․ և GPS /դ/");
            ChildDetials11.Add("2։ ԱՏՀ տեխն․ Կիրառ․ և GPS /դ/");
            ChildDetials11.Add("3։ ԱՏՀ տեխն․ Կիրառ․ և GPS /դ/");
            ChildDetials11.Add("4։ ԱՏՀ տեխն․ Կիրառ․ և GPS /դ/");
            List<string> ChildDetials12 = new List<string>();
            ChildDetials12.Add("1։ ԱՏՀ տեխն․ Կիրառ․ և GPS /լ/");
            ChildDetials12.Add("2։ ԱՏՀ տեխն․ Կիրառ․ և GPS /լ/");
            ChildDetials12.Add("3։ ԱՏՀ տեխն․ Կիրառ․ և GPS /լ/");
            ChildDetials12.Add("4։ ԱՏՀ տեխն․ Կիրառ․ և GPS /լ/");
            List<string> ChildDetials13 = new List<string>();
            ChildDetials13.Add("1։ ԱՏՀ տեխն․ Կիրառ․ և GPS /լ/");
            ChildDetials13.Add("2։ ԱՏՀ տեխն․ Կիրառ․ և GPS /լ/");
            ChildDetials13.Add("3։ ԱՏՀ տեխն․ Կիրառ․ և GPS /լ/");
            ChildDetials13.Add("4։ ԱՏՀ տեխն․ Կիրառ․ և GPS /լ/");
            List<string> ChildDetials14 = new List<string>();
            ChildDetials14.Add("Դաս չկա");

            //hamarich haytarar
            List<string> ChildDetials15 = new List<string>();
            ChildDetials15.Add("Դաս չկա");
            List<string> ChildDetials16 = new List<string>();
            ChildDetials16.Add("1։ Քարտեզների ձև․ և համ․ դիզայն /դ/");
            ChildDetials16.Add("2։ Քարտեզների ձև․ և համ․ դիզայն /դ/");
            List<string> ChildDetials17 = new List<string>();
            ChildDetials17.Add("1։ Հողային ռեսուրսների կառավարում /դ/");
            ChildDetials17.Add("2։ Հողային ռեսուրսների կառավարում /լ/");
            List<string> ChildDetials18 = new List<string>();
            ChildDetials18.Add("1։ Հողային ռեսուրսների կառավարում /լ/");
            ChildDetials18.Add("2։ Քարտեզների ձև․ և համ․ դիզայն /դ/");
            ChildDetials18.Add("3։ Հողային և քաղաքային կադաստր /դ/");
            List<string> ChildDetials19 = new List<string>();
            ChildDetials19.Add("1։ Հողային և անտ․ ռես․ կադ և մոտ /դ/");
            ChildDetials19.Add("2։ Հողային և անտ․ ռես․ կադ և մոտ /դ/");
            ChildDetials19.Add("3։ Հողային և անտ․ ռես․ կադ և մոտ /դ/");
            ChildDetials19.Add("4։ Հողային և անտ․ ռես․ կադ և մոտ /դ/");
            List<string> ChildDetials20 = new List<string>();
            ChildDetials20.Add("1։ Թվային քարտեզագրություն /դ/");
            ChildDetials20.Add("2։ Թվային քարտեզագրություն /դ/");
            ChildDetials20.Add("3։ Թվային քարտեզագրություն /դ/");
            ChildDetials20.Add("4։ Թվային քարտեզագրություն /լ/");
            List<string> ChildDetials21 = new List<string>();
            ChildDetials21.Add("Դաս չկա");

            // haytarar haytarar
            List<string> ChildDetials22 = new List<string>();
            ChildDetials22.Add("Դաս չկա");
            List<string> ChildDetials23 = new List<string>();
            ChildDetials23.Add("1։ Հողային և քաղաքային կադաստր /դ/");
            ChildDetials23.Add("2։ Հողային ռեսուրսների կառավարում /դ/");
            List<string> ChildDetials24 = new List<string>();
            ChildDetials24.Add("1։ Քարտեզների ձև․ և համ․ դիզայն /դ/");
            ChildDetials24.Add("2։ Քարտեզների ձև․ և համ․ դիզայն /լ/");
            ChildDetials24.Add("3։ Հողային ռեսուրսների կառավարում /լ/");
            List<string> ChildDetials25 = new List<string>();
            ChildDetials25.Add("1։ ԱՏՀ տեխն․ Կիրառ․ և GPS /լ/");
            ChildDetials25.Add("2։ ԱՏՀ տեխն․ Կիրառ․ և GPS /լ/");
            ChildDetials25.Add("3։ ԱՏՀ տեխն․ Կիրառ․ և GPS /լ/");
            ChildDetials25.Add("4։ ԱՏՀ տեխն․ Կիրառ․ և GPS /լ/");
            List<string> ChildDetials26 = new List<string>();
            ChildDetials26.Add("1։ ԱՏՀ տեխն․ Կիրառ․ և GPS /լ/");
            ChildDetials26.Add("2։ ԱՏՀ տեխն․ Կիրառ․ և GPS /լ/");
            ChildDetials26.Add("3։ ԱՏՀ տեխն․ Կիրառ․ և GPS /լ/");
            ChildDetials26.Add("4։ ԱՏՀ տեխն․ Կիրառ․ և GPS /լ/");
            List<string> ChildDetials27 = new List<string>();
            ChildDetials27.Add("1։ Թվային քարտեզագրություն /լ/");
            ChildDetials27.Add("2։ Թվային քարտեզագրություն /լ/");
            ChildDetials27.Add("3։ Թվային քարտեզագրություն /լ/");
            ChildDetials27.Add("4։ Թվային քարտեզագրություն /լ/");
            List<string> ChildDetials28 = new List<string>();
            ChildDetials28.Add("Դաս չկա");

            List<string> ChildDetials0 = new List<string>();
            ChildDetials0.Add("Դաս չկա");


            HeaderDetials["Երկուշաբթի հմ/հմ"] = ChildDetials1;
            HeaderDetials["Երեքշաբթի հմ/հմ"] = ChildDetials2;
            HeaderDetials["Չորեքշաբթի հմ/հմ"] = ChildDetials3;
            HeaderDetials["Հինգշաբթի հմ/հմ"] = ChildDetials4;
            HeaderDetials["Ուրբաթ հմ/հմ"] = ChildDetials5;
            HeaderDetials["Շաբաթ հմ/հմ"] = ChildDetials6;
            HeaderDetials["Կիրակի հմ/հմ"] = ChildDetials7;

            HeaderDetials["Երկուշաբթի հյ/հմ"] = ChildDetials8;
            HeaderDetials["Երեքշաբթի հյ/հմ"] = ChildDetials9;
            HeaderDetials["Չորեքշաբթի հյ/հմ"] = ChildDetials10;
            HeaderDetials["Հինգշաբթի հյ/հմ"] = ChildDetials11;
            HeaderDetials["Ուրբաթ հյ/հմ"] = ChildDetials12;
            HeaderDetials["Շաբաթ հյ/հմ"] = ChildDetials13;
            HeaderDetials["Կիրակի հյ/հմ"] = ChildDetials14;

            HeaderDetials["Երկուշաբթի հմ/հյ"] = ChildDetials15;
            HeaderDetials["Երեքշաբթի հմ/հյ"] = ChildDetials16;
            HeaderDetials["Չորեքշաբթի հմ/հյ"] = ChildDetials17;
            HeaderDetials["Հինգշաբթի հմ/հյ"] = ChildDetials18;
            HeaderDetials["Ուրբաթ հմ/հյ"] = ChildDetials19;
            HeaderDetials["Շաբաթ հմ/հյ"] = ChildDetials20;
            HeaderDetials["Կիրակի հմ/հյ"] = ChildDetials21;

            HeaderDetials["Երկուշաբթի հյ/հյ"] = ChildDetials22;
            HeaderDetials["Երեքշաբթի հյ/հյ"] = ChildDetials23;
            HeaderDetials["Չորեքշաբթի հյ/հյ"] = ChildDetials24;
            HeaderDetials["Հինգշաբթի հյ/հյ"] = ChildDetials25;
            HeaderDetials["Ուրբաթ հյ/հյ"] = ChildDetials26;
            HeaderDetials["Շաբաթ հյ/հյ"] = ChildDetials27;
            HeaderDetials["Կիրակի հյ/հյ"] = ChildDetials28;


            HeaderDetials["Դաս չկա"] = ChildDetials0;
            return HeaderDetials;

        }
    }
}