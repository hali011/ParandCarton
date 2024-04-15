using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;

namespace ParandCartonUpdate.ClassHelper
{
    public static class DateTimeExtensions
    {
        private const string PersianCulture = "fa-IR";

        private static string currentUICultureName;

        public static string CurrentUICultureName
        {
            get
            {
                currentUICultureName = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
                return (currentUICultureName);
            }
        }

        private static PersianCalendar Jalali
        {
            get
            {
                PersianCalendar jalali = new PersianCalendar();
                return jalali;
            }
        }

        private static GregorianCalendar Gregorian
        {
            get
            {
                GregorianCalendar gregorian = new GregorianCalendar();
                return gregorian;

            }
        }

        public static int GetUIYear(DateTime date)
        {
            int intResult = 1000;

            if (!string.IsNullOrEmpty(currentUICultureName))
            {
                if (currentUICultureName == PersianCulture)
                {
                    intResult = Jalali.GetYear(date);
                }
                else
                {
                    System.Globalization.GregorianCalendar gregorian = new System.Globalization.GregorianCalendar();
                    intResult = gregorian.GetYear(date);
                }
            }
            #region Added By h.khoddami
            else
            {
                intResult = Jalali.GetYear(date);
            }
            #endregion
            return (intResult);
        }

        public static int GetUIMonth(DateTime date)
        {
            int intResult = 0;

            if (!string.IsNullOrEmpty(currentUICultureName))
            {
                if (currentUICultureName == PersianCulture)
                {
                    intResult = Jalali.GetMonth(date);
                }
                else
                {
                    intResult = Gregorian.GetMonth(date);
                }
            }
            #region Added By h.khoddami
            else
            {
                intResult = Jalali.GetMonth(date);
            }
            #endregion
            return (intResult);
        }

        public static int GetUIDayOfMonth(DateTime date)
        {
            int intResult = 0;

            if (!string.IsNullOrEmpty(currentUICultureName))
            {
                if (currentUICultureName == PersianCulture)
                {
                    intResult = Jalali.GetDayOfMonth(date);
                }
                else
                {
                    intResult = Gregorian.GetDayOfMonth(date);
                }
            }
            #region Added By h.khoddami
            else
            {
                intResult = Jalali.GetDayOfMonth(date);
            }
            #endregion
            return (intResult);
        }

        public static int GetUIDayOfYear(DateTime date)
        {
            int intResult = 0;

            if (!string.IsNullOrEmpty(currentUICultureName))
            {
                if (currentUICultureName == PersianCulture)
                {
                    intResult = Jalali.GetDayOfYear(date);

                }
                else
                {
                    intResult = Gregorian.GetDayOfYear(date);
                }
            }
            #region Added By h.khoddami
            else
            {
                intResult = Jalali.GetDayOfYear(date);
            }
            #endregion
            return (intResult);
        }

        public static DayOfWeek GetUIDayOfWeek(DateTime date)
        {
            DayOfWeek result = DayOfWeek.Friday;

            if (!string.IsNullOrEmpty(currentUICultureName))
            {
                if (currentUICultureName == PersianCulture)
                {
                    result = Jalali.GetDayOfWeek(date);
                }
                else
                {
                    result = Gregorian.GetDayOfWeek(date);
                }
            }
            #region Added By h.khoddami
            else
            {
                result = Jalali.GetDayOfWeek(date);
            }
            #endregion
            return (result);
        }

        public static string ConvertToDbDate(string strDate)
        {
            DateTime date;
            date = Convert.ToDateTime(strDate);

            string strResult = string.Empty;

            string strYear, strMonth, strDay;
            strYear = Jalali.GetYear(date).ToString();
            strMonth = Jalali.GetMonth(date).ToString();
            strDay = Jalali.GetDayOfMonth(date).ToString();

            if (strMonth.Length < 2)
            {
                strMonth = "0" + strMonth;
            }
            if (strDay.Length < 2)
            {
                strDay = "0" + strDay;
            }

            strResult = strYear + "/" + strMonth + "/" + strDay;

            return (strResult);
        }

        public static DateTime JalaliToGregorian(this string date)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            DateTime objResult;

            string[] objParts = date.Split('/');
            for (int i = 0; i < objParts.Length; i++)
            {
                var fa = CultureInfo.GetCultureInfoByIetfLanguageTag("fa");
                var en = CultureInfo.GetCultureInfoByIetfLanguageTag("en");
                objParts[i] = objParts[i].ConvertDigitChar(fa, en);
            }
            string strYear = objParts[0];
            if (strYear.Length == 2)
            {
                strYear = "13" + strYear;
            }

            string strDay = objParts[2];
            if (strDay.Length > 2)
            {
                strDay = strDay.Substring(0, 2);
            }

            objResult = Jalali.ToDateTime(Convert.ToInt16(strYear), Convert.ToInt16(objParts[1]), Convert.ToInt16(strDay), 0, 0, 0, 0);

            return (objResult);
        }

        public static bool IsValidDbDate(string date)
        {
            if (string.IsNullOrEmpty(date) == true)
            {
                return (false);
            }

            string[] objParts = date.Split('/');

            if (objParts == null)
            {
                return (false);
            }

            if (objParts.Length != 3)
            {
                return (false);
            }

            string strYear = objParts[0];
            string strMonth = objParts[1];
            string strDay = objParts[2];

            int nYear = 0;
            int nMonth = 0;
            int nDay = 0;

            bool bParseResult = true;

            bParseResult &= int.TryParse(strYear, out nYear);
            bParseResult &= int.TryParse(strMonth, out nMonth);
            bParseResult &= int.TryParse(strDay, out nDay);

            if (bParseResult == false)
            {
                return (false);
            }

            if (nYear < 1000 || nYear > 9000)
            {
                return (false);
            }

            if (nMonth < 1 || nMonth > 12)
            {
                return (false);
            }

            if (nDay < 1 || nDay > 31)
            {
                return (false);
            }

            if (nMonth > 6 && nDay > 30)
            {
                return (false);
            }

            if (nDay == 30 && nMonth == 12 && IsLeapYear(nYear) == false)
            {
                return (false);
            }

            return (true);
        }

        private static bool IsLeapYear(int year)
        {
            bool bResult = false;

            bResult = Jalali.IsLeapYear(year);

            return (bResult);
        }

        public static string GregorianToJalali(this DateTime date)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string intResult = "";

            System.Globalization.PersianCalendar jalali = new System.Globalization.PersianCalendar();
            intResult = jalali.GetYear(date) + "/" + ((jalali.GetMonth(date).ToString().Length == 1) ? "0" + jalali.GetMonth(date).ToString() : jalali.GetMonth(date).ToString()) + "/" + ((jalali.GetDayOfMonth(date).ToString().Length == 1) ? "0" + jalali.GetDayOfMonth(date).ToString() : jalali.GetDayOfMonth(date).ToString());
            return (intResult);
        }

        public static string GregorianToJalaliWithTime(this DateTime date)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string intResult = "";

            System.Globalization.PersianCalendar jalali = new System.Globalization.PersianCalendar();
            intResult = jalali.GetYear(date) + "/" + ((jalali.GetMonth(date).ToString().Length == 1) ? "0" + jalali.GetMonth(date).ToString() : jalali.GetMonth(date).ToString())
                        + "/" + ((jalali.GetDayOfMonth(date).ToString().Length == 1) ? "0" + jalali.GetDayOfMonth(date).ToString() : jalali.GetDayOfMonth(date).ToString())
                        + "-" + ((jalali.GetHour(date).ToString().Length == 1) ? "0" + jalali.GetHour(date).ToString() : jalali.GetHour(date).ToString())
                        + ":" + ((jalali.GetMinute(date).ToString().Length == 1) ? "0" + jalali.GetMinute(date).ToString() : jalali.GetMinute(date).ToString());
            return (intResult);
        }

        public static string GregorianToJalaliTime(this DateTime date)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string intResult = "";

            System.Globalization.PersianCalendar jalali = new System.Globalization.PersianCalendar();
            intResult = ((jalali.GetHour(date).ToString().Length == 1) ? "0" + jalali.GetHour(date).ToString() : jalali.GetHour(date).ToString())
                        + ":" + ((jalali.GetMinute(date).ToString().Length == 1) ? "0" + jalali.GetMinute(date).ToString() : jalali.GetMinute(date).ToString());
            return (intResult);
        }

        public static DateTime JalaliToGregorianWithTime(this string date, string hour, string minute)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            DateTime objResult;

            string[] objParts = date.Split('/');
            for (int i = 0; i < objParts.Length; i++)
            {
                var fa = CultureInfo.GetCultureInfoByIetfLanguageTag("fa");
                var en = CultureInfo.GetCultureInfoByIetfLanguageTag("en");
                objParts[i] = objParts[i].ConvertDigitChar(fa, en);
            }
            string strYear = objParts[0];
            if (strYear.Length == 2)
            {
                strYear = "13" + strYear;
            }

            string strDay = objParts[2];
            if (strDay.Length > 2)
            {
                strDay = strDay.Substring(0, 2);
            }

            int Hour = Convert.ToInt32(hour);
            int Minute = Convert.ToInt32(minute);

            objResult = Jalali.ToDateTime(Convert.ToInt16(strYear), Convert.ToInt16(objParts[1]), Convert.ToInt16(strDay), Hour, Minute, 0, 0);

            return (objResult);
        }

        public static string ConvertDigitChar(this string str, CultureInfo source, CultureInfo destination)
        {
            for (int i = 0; i <= 9; i++)
            {
                str = str.Replace(source.NumberFormat.NativeDigits[i], destination.NumberFormat.NativeDigits[i]);
            }
            return str;
        }

        public static string ConvertDigitChar(this int digit, CultureInfo destination)
        {
            string res = digit.ToString();
            for (int i = 0; i <= 9; i++)
            {
                res = res.Replace(i.ToString(), destination.NumberFormat.NativeDigits[i]);
            }
            return res;
        }
        public static string GetMonthJalali(DateTime Date = default(DateTime), int? month = null)
        {
            string stringmonthJalali = string.Empty;
            int? MonthJalali = new int();
            if (month == null)
            {
                MonthJalali = Jalali.GetMonth(Date);
            }
            else
            {
                MonthJalali = month;
            }
            switch (MonthJalali)
            {
                case 1:
                    stringmonthJalali = "فروردین"; break;
                case 2:
                    stringmonthJalali = "اردیبهشت"; break;
                case 3:
                    stringmonthJalali = "خرداد"; break;
                case 4:
                    stringmonthJalali = "تیر"; break;
                case 5:
                    stringmonthJalali = "مرداد"; break;
                case 6:
                    stringmonthJalali = "شهریور"; break;
                case 7:
                    stringmonthJalali = "مهر"; break;
                case 8:
                    stringmonthJalali = "آبان"; break;
                case 9:
                    stringmonthJalali = "آذر"; break;
                case 10:
                    stringmonthJalali = "دی"; break;
                case 11:
                    stringmonthJalali = "بهمن"; break;
                case 12:
                    stringmonthJalali = "اسفند"; break;
            }
            return stringmonthJalali;
        }

        #region تبدیل فرمت زمان از حالت 0:0 به حالت 00:00 به جهت نمایش بهتر
        public static string FormatTime(DateTime datetime)
        {
            string _StartHour = "";
            string _StartMin = "";
            string time = "";
            PersianCalendar pdate = new PersianCalendar();
            int StartHour = Convert.ToInt32(String.Format("{0}", pdate.GetHour(datetime)));
            int StartMin = Convert.ToInt32(String.Format("{0}", pdate.GetMinute(datetime)));
            if (StartHour < 10 || StartMin < 10)
            {
                if (StartHour < 10)
                    _StartHour = "0" + StartHour.ToString();

                if (StartMin < 10)
                    _StartMin = "0" + StartMin.ToString();
                if (_StartMin != "" & _StartHour != "")
                    time = _StartHour + ":" + _StartMin;
                else if (_StartMin == "" & _StartHour != "")
                    time = _StartHour + ":" + StartMin.ToString();
                else if (_StartMin != "" & _StartHour == "")
                    time = StartHour.ToString() + ":" + _StartMin;
            }
            else
                time = String.Format("{0}:{1}", pdate.GetHour(datetime), pdate.GetMinute(datetime));
            return time;
        }
        #endregion
    }
}
