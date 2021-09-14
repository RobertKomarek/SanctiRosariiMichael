using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ErzengelMichael.Models
{
    public class Rosenkranz
    {
        public string ContentPageTitle { get; set; }
        public string TabBarTitleRosary { get; set; }
        public string TabBarTitleManual { get; set; }
        public string TabBarTitlePrayers { get; set; }
        public string TabBarTitleSettings { get; set; }
        public string TabBarTitlePromises { get; set; }
        public string SettingsText { get; set; }

        //ROSARY PRAYERS AND IMAGES TO THE ANGELS
        public string Prayer { get; set; }
        public string ImageofAngel { get; set; }
        public string ManualHeader { get; set; }

        public string ContentPageTitleLitany { get; set; }
        //public string ContentPageTitlePrayerToMichael { get; set; }
        public string ContentPageTitleLeoXIII { get; set; }
        public string Litany { get; set; }
        //public string PrayerToMichael { get; set; }
        //public string PrayerToMichaelLatin { get; set; }
        public string PrayerLeoXIII { get; set; }
        public string PrayerLeoXIIILatin { get; set; }
        public string NativeLanguage { get; set; }
        public string Latin { get; set; }

        public string ContentPageTitlePromisesMichael { get; set; }
        public string ContentPageTitleIndulgences { get; set; }
        public string Promises { get; set; }
        public string Indulgences { get; set; }

    }
}
