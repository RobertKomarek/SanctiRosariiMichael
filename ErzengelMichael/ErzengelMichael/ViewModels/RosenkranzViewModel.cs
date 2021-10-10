using System;
using Xamarin.Forms;
using ErzengelMichael.Models;
using System.Collections.ObjectModel;
using System.Timers;

namespace ErzengelMichael.ViewModels
{
    public class RosenkranzViewModel : BaseViewModel
    {
        public ObservableCollection<Rosenkranz> Rosenkranz { get; set; }
        public ObservableCollection<Languages> Languages { get; set; }

        public Command BackToPageOneCommand { get; set; }
        public Command BackOnePositionCommand { get; set; }
        public Command ForwardOnePositionCommand { get; set; }
        public Command ChangeLanguageCommand { get; set; }
        public Command GoToIcons8Command { get; set; }

        private int _carouselViewPosition;
        public int CarouselViewPosition
        {
            get { return _carouselViewPosition; }
            set
            {
                _carouselViewPosition = value;
                OnPropertyChanged();
            }
        }


        public RosenkranzViewModel()
        {
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            BackToPageOneCommand = new Command(RosaryBackToPageOne);
            BackOnePositionCommand = new Command(BackOnePosition);
            ForwardOnePositionCommand = new Command(ForwardOnePosition);
            ChangeLanguageCommand = new Command<string>(ChangeLanguage);
            
            
            #region LANGUAGE SPRACHE AUSWÄHLEN
            Languages = new ObservableCollection<Languages>();

            Languages.Add(new Languages
            {
                CommandParameter = "French",
                Source = "france.jpg",
                Language = "Français"
            });

            Languages.Add(new Languages
            {
                CommandParameter = "German",
                Source = "germany.jpg",
                Language = "Deutsch"
            });

            Languages.Add(new Languages
            {
                CommandParameter = "English",
                Source = "usa.jpg",
                Language = "English"
            });

            Languages.Add(new Languages
            {
                CommandParameter = "Spanish",
                Source = "spain.jpg",
                Language = "Español"
            });

            Languages.Add(new Languages
            {
                CommandParameter = "Italian",
                Source = "italy.jpg",
                Language = "Italiano"
            });

            Languages.Add(new Languages
            {
                CommandParameter = "Portugese",
                Source = "portugal.jpg",
                Language = "Português"
            });
            #endregion

            Rosenkranz = new ObservableCollection<Rosenkranz>();

            if (App.Current.Properties.ContainsKey("Spracheinstellungen"))
            {
                var sprachEinstellungen = Application.Current.Properties["Spracheinstellungen"].ToString();

                switch (sprachEinstellungen)
                {
                    case "English":
                        Rosenkranz = GetEnglish();
                        break;

                    case "German":
                        Rosenkranz = GetGerman();
                        break;

                    case "Spanish":
                        Rosenkranz = GetSpanish();
                        break;

                    case "French":
                        Rosenkranz = GetFrench();
                        break;

                    case "Portugese":
                        Rosenkranz = GetPortugese();
                        break;

                    case "Italian":
                        Rosenkranz = GetItalian();
                        break;

                    default:
                        Rosenkranz = GetGerman();
                        break;
                }
            }
            else
            {
                //DEFAULT LANGUAGE
                Rosenkranz = GetEnglish();
            }
        }
               

        #region Seiten vor und zurück bzw. zurück zu Seite 1
        private void ForwardOnePosition()
        {

            if (CarouselViewPosition < Rosenkranz.Count - 1)
            {
                CarouselViewPosition += 1;
            }
        }

        private void BackOnePosition()
        {
            if (CarouselViewPosition >= 1)
            {
                CarouselViewPosition -= 1;
            }
        }

        void RosaryBackToPageOne()
        {
            CarouselViewPosition = 0;
        }
        #endregion


        public void ChangeLanguage(string language)
        {
            Rosenkranz.Clear();

            switch (language)
            {
                case "German":
                    Rosenkranz = GetGerman();
                    App.Current.MainPage.DisplayAlert("Einstellungen", "Sprache geändert auf Deutsch!", "OK");
                    break;

                case "English":
                    Rosenkranz = GetEnglish();
                    App.Current.MainPage.DisplayAlert("Settings", "Language changed to English!", "OK");
                    break;

                case "French":
                    Rosenkranz = GetFrench();
                    App.Current.MainPage.DisplayAlert("Paramètres", "Langue changée en français!", "D'ACCORD");
                    break;

                case "Spanish":
                    Rosenkranz = GetSpanish();
                    App.Current.MainPage.DisplayAlert("Configuración", "El idioma cambió en español!", "DE ACUERDO");
                    break;

                case "Italian":
                    Rosenkranz = GetItalian();
                    App.Current.MainPage.DisplayAlert("Impostazioni", "Lingua cambiata in italiano!", "OK");
                    break;

                case "Portugese":
                    Rosenkranz = GetPortugese();
                    App.Current.MainPage.DisplayAlert("Configurações", "Língua mudada para português!", "OK");
                    break;
            }

            //Status vom Rosenkranz speichern, damit beim Aufruf einer anderen Page die geänderten Spracheinstellungen
            //übernommen werden
            SetProperties("Spracheinstellungen", language);
            //Startseite neu laden, damit die Collection geladen und die Sprache umgestellt wird
            (App.Current).MainPage = new AppShell();

            CarouselViewPosition = 0;

        }

        public async static void SetProperties(string property, object value)
        {
            var app = (App)Application.Current;
            app.Properties[property] = value;

            await app.SavePropertiesAsync();
        }

        //private async void GoToIcons8()
        //{
        //await Launcher.OpenAsync(new Uri("https://icons8.de"));
        //}

        #region Get Languages
        public ObservableCollection<Rosenkranz> GetGerman()
        {
            var getLanguage = new ObservableCollection<Rosenkranz>();

            getLanguage.Add(new Rosenkranz
            {
                ContentPageTitle = "Sancti Rosarii Michael",
                TabBarTitleRosary = "Rosenkranz",
                TabBarTitleManual = "Anleitung",
                TabBarTitlePromises = "Versprechungen",
                TabBarTitlePrayers = "Gebete",
                TabBarTitleSettings = "Sprachen",
                SettingsText = "Zum Ändern der Sprache auf eine Flagge tippen!",
                
                ContentPageTitlePromisesMichael = "...von Erzengel Michael",
                Promises = "Wer diesen Rosenkranz vor der hl.Kommunion andächtig betet, wird von neun heiligen Engeln, aus jedem Chore " +
                "einen, zur heiligen Kommunion begleitet; auch seine Seele soll mit dem kostbaren Blute Jesu abgewaschen und geziert werden," +
                " um würdig zu kommunizieren. Wer diesen Rosenkranz täglich betet, wird in seiner Sterbestunde von genannter Anzahl heiliger " +
                "Engel besucht, getröstet und gestärkt und von den höllischen Feinden und Peinen befreit und beschützt werden. Auch werden " +
                "dessen Verwandte, wenn sich deren noch einige im Fegfeuer befinden, neun Mal des Tages besucht und getröstet.",


                ContentPageTitleIndulgences = "Ablässe durch Pius IX.",
                Indulgences =

                "Antónia d'Astónaco war eine portugiesische karmelitische Nonne, die über eine private Offenbarung des Erzengels" +
                " Michael berichtete." + Environment.NewLine +

                "D'Astónaco sagte, der Erzengel Michael habe in einer Erscheinung angedeutet, dass er durch das Beten von neun" +
                " besonderen Anrufungen geehrt und Gott verherrlicht werden möchte. Diese neun Anrufungen entsprechen Anrufungen" +
                " an die neun Engelschöre und sind der Ursprung des Rosenkranzes des Heiligen Michael. Diese private Offenbarung und " +
                "Gebete wurden 1851 von Papst Pius IX. bestätigt." + Environment.NewLine + Environment.NewLine +

                "Pius IX. verlieh am 8. August 1851 folgende Ablässe:" + Environment.NewLine +
                "1. Einen Ablass von 7 Jahren und 7 Quaragenen jedes Mal, sooft man diesen Rosenkranz betet." + Environment.NewLine +
                "2. Einen Ablass von 100 Tagen an jedem Tag, an welchem man diesen Rosenkranz bei sich trägt oder die ihm angehängte Medaille der heiligen Engel küsst." + Environment.NewLine +
                "3. Bei täglicher Verrichtung desselben einmal im Monat einen vollkommenen Ablass, wenn man an einem beliebigen Tage die heiligen Sakramente empfängt und nach der Meinung des Heiligen Vaters betet." + Environment.NewLine +
                "4. Einen vollkommenen Ablass unter den soeben angeführten Bedingungen:" + Environment.NewLine +
                "a) Am Feste des Hl. Erzengel Michael, Erscheinung, 8. Mai." + Environment.NewLine +
                "b) Am Feste des Hl. Erzengel Michael, 29. September." + Environment.NewLine +
                "c) Am Feste des Hl. Erzengel Gabriel, 18. März." + Environment.NewLine +
                "d) Am Feste des Hl. Erzengel Raphael, 24. Oktober." + Environment.NewLine +
                "e) Am Feste der Hl. Schutzengel, 2. Oktober.",

                ContentPageTitleLitany = "LITANEI",
                Litany =
                "Herr, erbarme Dich unser." + Environment.NewLine +
                "Christus, erbarme Dich unser." + Environment.NewLine +
                "Herr, erbarme Dich unser." + Environment.NewLine +
                "Christus, höre uns." + Environment.NewLine +
                "Christus, erhöre uns." + Environment.NewLine +
                "Gott Vater vom Himmel, erbarme Dich unser." + Environment.NewLine +
                "Gott Sohn, Erlöser der Welt, erbarme Dich unser." + Environment.NewLine +
                "Gott Heiliger Geist, erbarme Dich unser." + Environment.NewLine +
                "Heiligste Dreifaltigkeit, ein einiger Gott, erbarme Dich unser." + Environment.NewLine + Environment.NewLine +
                "Heilige Maria, Königin der Engel, bitte für uns." + Environment.NewLine +
                "Heiliger Erzengel Michael, bitte für uns (mit jeder Anrufung wiederholen)." + Environment.NewLine +
                "Heiliger Michael, voll der Weisheit Gottes, ..." + Environment.NewLine +
                "Heiliger Michael, du vollkommener Anbeter des Wortes Gottes, ...etc." + Environment.NewLine +
                "Heiliger Michael, mit Ruhm und Ehre gekrönt, " + Environment.NewLine +
                "Heiliger Michael, du mächtiger Fürst der himmlischen Heere, " + Environment.NewLine +
                "Heiliger Michael, du Fahnenträger der Heiligsten Dreifaltigkeit, " + Environment.NewLine +
                "Heiliger Michael, du Wächter des Paradieses, " + Environment.NewLine +
                "Heiliger Michael, du Führer und Tröster des Volkes Israel, " + Environment.NewLine +
                "Heiliger Michael, du Glanz und Stütze der streitenden Kirche, " + Environment.NewLine +
                "Heiliger Michael, du Ehre und Freude der triumphierenden Kirche, " + Environment.NewLine +
                "Heiliger Michael, du Licht der Engel, " + Environment.NewLine +
                "Heiliger Michael, du Bollwerk der Rechtgläubigen, " + Environment.NewLine +
                "Heiliger Michael, du Kraft derer, die unter dem Kreuzesbanner kämpfen, " + Environment.NewLine +
                "Heiliger Michael, du Licht und Vertrauen der Seelen in der Sterbestunde, " + Environment.NewLine +
                "Heiliger Michael, du unsere sichere Hilfe, " + Environment.NewLine +
                "Heiliger Michael, unser Helfer in allen Widerwärtigkeiten, " + Environment.NewLine +
                "Heiliger Michael, du Herold des ewigen Urteilspruches, " + Environment.NewLine +
                "Heiliger Michael, du Tröster der Armen Seelen, " + Environment.NewLine +
                "Heiliger Michael, von Gott beauftragt, die Seelen nach dem Tode zu empfangen, " + Environment.NewLine +
                "Heiliger Michael, du unser Fürst, " + Environment.NewLine +
                "Heiliger Michael, du unser Fürsprecher, " + Environment.NewLine + Environment.NewLine +
                "Lamm Gottes, Du nimmst hinweg die Sünden der Welt – verschone uns, o Herr." + Environment.NewLine +
                "Lamm Gottes, Du nimmst hinweg die Sünden der Welt – erhöre uns, o Herr." + Environment.NewLine +
                "Lamm Gottes, Du nimmst hinweg die Sünden der Welt – erbarme Dich unser, o Herr." + Environment.NewLine +
                "V.: ..., heiliger Erzengel Michael, du Fürst der Kirche Christi." + Environment.NewLine +
                "A.: Auf dass wir würdig werden Seiner Verheißungen." + Environment.NewLine + Environment.NewLine +
                "Herr Jesus Christus, gib uns Deinen Segen und verleihe uns auf die Fürbitte des heiligen Erzengels Michael jene Weisheit, die uns " +
                "lehrt, für den Himmel Schätze zu sammeln und die ewigen Güter den zeitlichen vorzuziehen. Der Du lebst und regierst von Ewigkeit " +
                "zu Ewigkeit." + Environment.NewLine +
                " Amen",

                ContentPageTitleLeoXIII = "...von Papst LEO XIII.",
                NativeLanguage = "DEUTSCH",
                PrayerLeoXIII =
                "Heiliger Erzengel Michael! Verteidige uns im Kampfe gegen die Bosheiten und die Nachstellungen des Teufels, sei Du " +
                "unser Schutz! Gott gebiete ihm, so bitten wir flehentlich," + Environment.NewLine +
                "Du aber, Fürst der himmlischen Heerscharen,stürze den Satan und die anderen bösen Geister," + Environment.NewLine +
                "die zum Verderben der Seelen in der Welt umherschweifen, in der Kraft Gottes hinab in die Hölle! Amen.",
                #region LEOXIII LANGES MICHAEL GEBET
                //"O ruhmreichster Führer der Himmlischen Heerscharen, Heiliger Erzengel Michael, verteidige uns in diesem schrecklichen Krieg wider die Fürstentümer und Mächte, wider die Beherrscher dieser finsteren Welt, wider die bösen Geister. Komme den Menschen zu Hilfe, die Gott nach Seinem Abbild unsterblich erschaffen und um einen sehr teuren Preis aus der Tyrannei des Teufels zurückgekauft hat." + Environment.NewLine +
                //"Mit dem Heere der Heiligen Engel schlage heute aufs neue die Schlacht des Herrn, so wie Du einst gegen Luzifer, den Führer der stolzen Rebellen, und gegen seinen Anhang, die abtrünnigen Engel, gestritten hast! Sie hatten weder Kraft, Dir zu widerstehen, noch gab es länger Platz für sie im Himmel. Jene grausame Urschlange, die auch Teufel oder Satan genannt wird, und die ganze Welt verführt, wurde samt Anhang in den Abgrund gestürzt." + Environment.NewLine +
                //"Siehe, dieser Urfeind und Menschenmörder von Anbeginn hat wieder Mut gefasst. Verwandelt in einen Lichtengel überfällt er die Erde und wandert mit einer Vielzahl von bösen Geistern herum, um den Namen Gottes und seines Christus auszumerzen und von den, für die Krone des ewigen Ruhmes bestimmten Seelen, Besitz zu ergreifen, sie zu morden und in die ewige Verdammnis zu stoßen. Wie das schmutzigste Abwasser gießt dieser böse Drache das Gift seiner Bosheit, nämlich den Geist der Lüge, der Gottlosigkeit und Lästerung, den Pesthauch der Unreinheit und jegliche Art von Laster und Gemeinheit, auf Menschen verdorbenen Geistes und Herzens aus." + Environment.NewLine +
                //"Diese gerissensten Feinde haben die Kirche, die unbefleckte Braut des Lammes, mit Galle und Bitterkeit erfüllt und getränkt, und haben ihre frevlerischen Hände an Ihre Heiligsten Schätze gelegt. Selbst am Heiligen Orte, wo der Sitz des Heiligsten Petrus und der Thron d er Wahrheit zur Erleuchtung der Welt, errichtet wurde, haben sie ihren Thron des grauenvollen Frevels aufgestellt, mit der heimtückischen Absicht, den Hirten zu schlagen, damit sich dann die Schafe in alle Richtungen zerstreuen." + Environment.NewLine +
                //"Darum erhebe Dich, o unbesiegbarer Heerführer, komm dem Volk Gottes wider die Anstürme der gefallenen Geister zu Hilfe, und gib ihm den Sieg. Es verehrt Dich als seinen Beschützer und Schutzpatron; Du bringst der Heiligen Kirche den Ruhm, in dem Du sie gegen die bösen Mächte der Hölle verteidigst; Dir hat Gott die Seelen der Menschen anvertraut, die in die ewige Freude eingehen werden. O, bete zum Gott des Friedens, Er möge Satan unter unsere Füße legen, damit er derart besiegt sein möge, dass er nicht mehr länger Menschen in seiner Gefangenschaft halte und der Kirche schade." + Environment.NewLine +
                //"Bringe unsere Gebete im Angesicht des Allerhöchsten dar, damit schnell die reiche Barmherzigkeit unseres Herrn auf uns herabsteige und Dir gewähre, den Drachen, die Urschlange, die nichts weiter ist als der Teufel und Satan, zu erschlagen und mit Ketten gefesselt in die Hölle zu werfen, damit er nicht länger die Völker verführe. Amen." + Environment.NewLine +
                //"V. Seht das Kreuz des Herrn, seid zerschmettert, ihr feindlichen Mächte." + Environment.NewLine +
                //"A. Der Löwe aus dem Stamme Juda hat erobert die Wurzel Davids." + Environment.NewLine +
                //"V. Lasse deine Gnaden uns zufließen, o Herr," + Environment.NewLine +
                //"A. uns, die wir auf Dich hoffen." + Environment.NewLine +
                //"V. O Herr, höre mein Gebet," + Environment.NewLine +
                //"A. und laß meinen Ruf zu Dir kommen." + Environment.NewLine +
                //"V. Lasset uns beten" + Environment.NewLine +
                //"O Gott, der Vater Unseres Herrn Jesus Christus, wir rufen Deinen Heiligsten Namen an, und bettelnd erflehen wir deine Sanftmut, daß durch die Fürbitte Mariens, der immerwährenden Jungfrau und unserer Mutter, und des ruhmreichen Erzengels Michael, Du uns deine Hilfe gegen Satan und alle anderen unreinen Geister, die zum Schaden der menschlichen Rasse und zum Ruin der Seelen herumwandern, gewährest." + Environment.NewLine +
                //"Amen.", 
                #endregion

                Latin = "LATEIN",
                PrayerLeoXIIILatin =
                "Sancte Míchael Archángele! Defénde nos in próelio;" + Environment.NewLine +
                "contra nequítiam et insídias diáboli esto praesídium." + Environment.NewLine +
                "Imperet illi Deus, súpplices deprecámur, tuque, Prínceps milítiae caeléstis, Sátanam aliósque spíritus malígnos," + Environment.NewLine +
                "qui ad perditiónem animárum pervagántur in mundo, divína virtúte, in inférnum detrúde." + Environment.NewLine +
                "Amen.",

                ManualHeader = "Herzlichen willkommen zum Rosenkranz von Erzengel Michael!",

                Prayer = "So wird der Rosenkranz gebetet:" + Environment.NewLine + Environment.NewLine +
                "1. Anrufung der Engel (Serpahim, Cherubim, etc.)" + Environment.NewLine + Environment.NewLine +
                "2. Vater unser 1x" + Environment.NewLine + Environment.NewLine +
                "3. Ave Maria 3x" + Environment.NewLine + Environment.NewLine +
                "4. Je 1 Vater unser zu Ehren der Erzengel Michael, Raphael, Gabriel und des Schutzengels",

                ImageofAngel = "rosenkranz.jpg"

            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Heiliger Erzengel Michael! Ich empfehle Dir die Stunde meines Todes; halte in derselben den bösen Feind gefangen, dass er mich nicht anfechten und meiner Seele nicht schaden kann."
                + Environment.NewLine + Environment.NewLine + "Vater unser…",

                ImageofAngel = "michael.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                "Heiliger Erzengel Gabriel! Erlange mir von Gott einen lebendigen Glauben, eine starke Hoffnung, inbrünstige Liebe und große Andacht zum Heiligsten Altarsakrament."
                + Environment.NewLine + Environment.NewLine + "Vater unser...",

                ImageofAngel = "gabrielpd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                "Heiliger Erzengel Raphael! Führe mich allezeit den Weg der Tugend und Vollkommenheit." +
               Environment.NewLine + Environment.NewLine + "Vater unser...",

                ImageofAngel = "raphaelpd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                "Heiliger Schutzengel! Erlange mir göttliche Einsprechungen und die besondere Gnade dieselbe treu zu befolgen." +
               Environment.NewLine + Environment.NewLine + "Vater unser...",

                ImageofAngel = "michael1pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                "O Ihr flammenden Seraphim! Erlanget mir eine brennende Liebe zu Gott." +
               Environment.NewLine + Environment.NewLine + "1 Vater unser..., 3 Ave Maria",

                ImageofAngel = "michael2pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                "O Ihr hocherleuchteten Cherubim! Erlanget mir die wahre Erkenntnis Gottes und die Wissenschaft der Heiligen."
                + Environment.NewLine + Environment.NewLine + "1 Vater unser..., 3 Ave Maria",

                ImageofAngel = "michael3pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                "O vortreffliche Throne! Erlanget mir den Frieden und die Ruhe des Herzens."
                + Environment.NewLine + Environment.NewLine + "1 Vater unser..., 3 Ave Maria",

                ImageofAngel = "michael4pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                "O hohe Herrschaften! Erlanget mir den Sieg über alle bösen Neigungen und Begierden." + Environment.NewLine +
                Environment.NewLine + "1 Vater unser..., 3 Ave Maria",

                ImageofAngel = "michael5pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                "O unüberwindliche Gewalten! Erlanget mir Stärke wider alle bösen Geister." + Environment.NewLine +
                Environment.NewLine + "1 Vater unser..., 3 Ave Maria",

                ImageofAngel = "michael6pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                "O durchlauchte Fürsten! Erlanget mir vollkommenen Gehorsam und Gerechtigkeit." + Environment.NewLine +
                Environment.NewLine + "1 Vater unser..., 3 Ave Maria",

                ImageofAngel = "michael7pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                "O wundertägige Mächte! Erlanget mir die Fülle aller Tugenden und Vollkommenheit." + Environment.NewLine +
                Environment.NewLine + "1 Vater unser..., 3 Ave Maria",

                ImageofAngel = "michael8pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                "O heilige Erzengel! Erlanget mir Gleichförmigkeit mit dem Willen Gottes." + Environment.NewLine +
                Environment.NewLine + "1 Vater unser..., 3 Ave Maria",

                ImageofAngel = "michael9pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                "O heilige Engel! Erlanget mir wahre Demut und großes Vertrauen auf Gottes Barmherzigkeit" + Environment.NewLine +
                Environment.NewLine + "1 Vater unser..., 3 Ave Maria",

                ImageofAngel = "michael10pd.jpg"
            });


            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                "Lieber JESUS! Diesen Rosenkranz übergebe ich Deinem göttlichen Herzen, vervollkommne Du ihn zur größeren " +
                "Freude Deiner heiligen Engel. Sie mögen mich in ihrem Schutz erhalten, besonders in meiner Sterbestunde, " +
                "wozu ich sie jetzt schon von Herzen einlade, damit ich, durch ihre Gegenwart gestärkt, den Tod mit " +
                "Freuden erwarte und vor den höllischen Nachstellungen beschützt werde. Ich bitte euch auch inständig," +
                "ihr lieben heiligen Engel, besucht die Armen Seelen, vor allem meine Eltern, Freunde und Wohltäter. " +
                "Helft ihnen zur baldigen Erlösung und bittet um Erbarmen auch für mich nach meinem Tode." +
                "Dies bitte ich euch herzinniglich durch die heiligsten Herzen Jesu und Mariä. Amen",

                ImageofAngel = "michael11pd.jpg"
            });

            return getLanguage;
        }

        public ObservableCollection<Rosenkranz> GetEnglish()
        {
            var getLanguage = new ObservableCollection<Rosenkranz>();

            getLanguage.Add(new Rosenkranz
            {
                ContentPageTitle = "Sancti Rosarii Michael",
                TabBarTitleRosary = "Rosary",
                TabBarTitleManual = "Manual",
                TabBarTitlePromises = "Promises",
                TabBarTitlePrayers = "Prayers",
                TabBarTitleSettings = "Languages",
                SettingsText = "Press flag to choose language!",

                ContentPageTitlePromisesMichael = "...From Archangel Michael",
                Promises = "The Archangel Michael promised to whoever would pray this Chaplet:" + Environment.NewLine +
                "That he would send a chosen angel from each angelic choir to accompany the devotees at the time of Communion." + Environment.NewLine +
                "To those who recite these nine salutations, every day:" + Environment.NewLine +
                "That they will enjoy his continued assistance during this life and also after death, in purgatory." + Environment.NewLine +
                "They will be accompanied by all the angels and will be, with all their loved ones and relatives freed from Purgatory.",

                ContentPageTitleIndulgences = "Indulgences by Pius IX.",
                Indulgences =

                "Antónia d'Astónaco was a Portuguese Carmelite nun who reported a private revelation by Saint Michael the " +
                "Archangel." + Environment.NewLine +
                "d'Astónaco said that the Archangel Michael had indicated in an apparition that he would like to be honored, " +
                "and God glorified, by the praying of nine special invocations. These nine invocations correspond to invocations" +
                " to the nine choirs of angels and origins the Chaplet of Saint Michael. This private revelation and prayers " +
                "were approved by Pope Pius IX in 1851" + Environment.NewLine + Environment.NewLine +

                "Pope Pius IX granted the following Indulgences to those who pray the chaplet:" + Environment.NewLine +
                "Partial indulgence, to those who pray this Chaplet with a contrite heart." + Environment.NewLine +
                "Partial indulgence, each day to those who carry the Chaplet with them and / or kiss the medal of the Holy Angels that " +
                "hangs from it." + Environment.NewLine +
                "Full indulgence, to those who pray it once a month, the day they choose, truly contrite and confessed," +
                "praying for the intentions of their Holiness." + Environment.NewLine +
                "Full indulgence, with the same conditions, in the feasts of the Apparition of St Michael the Archangel(May 8); the " +
                "feast of the Archangels Michael, Gabriel and Rafael(September 29); and on the day of the Holy Guardian Angels(October 2).",


                ContentPageTitleLitany = "LITANY",
                Litany =
                "Lord, have mercy." + Environment.NewLine +
                "Christ, have mercy." + Environment.NewLine +
                "Lord, have mercy." + Environment.NewLine +
                "Christ, hear us." + Environment.NewLine +
                "Christ, graciously hear us." + Environment.NewLine +
                "God, the Father of heaven, have mercy on us. (repeat after each line)" + Environment.NewLine +
                "God, the Son, the Redeemer of the world," + Environment.NewLine +
                "God, the Holy Spirit," + Environment.NewLine +
                "Holy Trinity, one God," + Environment.NewLine + Environment.NewLine +
                "Holy Mary, Queen of Angels, pray for us." + Environment.NewLine +
                "Saint Michael, pray for us (repeat after each line)." + Environment.NewLine +
                "Saint Michael, abundant font of divine wisdom,..." + Environment.NewLine +
                "Saint Michael, most perfect adorer of the Divine Word,...etc." + Environment.NewLine +
                "Saint Michael, whom God crowned with honor and glory," + Environment.NewLine +
                "Saint Michael, most powerful Prince of the heavenly host," + Environment.NewLine +
                "Saint Michael, standard-bearer of the Most Holy Trinity," + Environment.NewLine +
                "Saint Michael, guardian of Paradise," + Environment.NewLine +
                "Saint Michael, guide and consoler of the People of God," + Environment.NewLine +
                "Saint Michael, splendor and fortitude of the Church Militant," + Environment.NewLine +
                "Saint Michael, honor and joy of the Church Triumphant," + Environment.NewLine +
                "Saint Michael, light of the Angels, " + Environment.NewLine +
                "Saint Michael, protection of orthodox people," + Environment.NewLine +
                "Saint Michael, strength of those who fight under the standard of the Cross," + Environment.NewLine +
                "Saint Michael, light and hope of souls near death," + Environment.NewLine +
                "Saint Michael, our most sure aid," + Environment.NewLine +
                "Saint Michael, help in our adversities," + Environment.NewLine +
                "Saint Michael, herald of the everlasting judgment," + Environment.NewLine +
                "Saint Michael, consoler of souls languishing in purgatory," + Environment.NewLine +
                "Saint Michael, receiver of the souls of the elect after death," + Environment.NewLine +
                "Saint Michael, our prince, " + Environment.NewLine +
                "Saint Michael, our defender," + Environment.NewLine + Environment.NewLine +
                "Lamb of God, who takest away the sins of the world," + Environment.NewLine +
                "Spare us O Lord." + Environment.NewLine +
                "Lamb of God, who takest away the sins of the world," + Environment.NewLine +
                "Graciously hear us O Lord." + Environment.NewLine +
                "Lamb of God, who takest away the sins of the world," + Environment.NewLine +
                "Have mercy on us." + Environment.NewLine +
                "Pray for us Saint Michael the Archangel" + Environment.NewLine +
                "That we may be made worthy of the promises of Christ." + Environment.NewLine +
                "Let us pray." + Environment.NewLine + Environment.NewLine +
                "O Lord Jesus Christ, may your continual blessing sanctify us, and grant us through the intercession of Saint Michael the wisdom that teaches us to lay up our treasure in Heaven and choose eternal goods over those of this world. Thou, who lives and reigns forever." +
                Environment.NewLine + "Amen",

                ContentPageTitleLeoXIII = "...from Pope LEO XIII.",
                NativeLanguage = "ENGLISH",
                PrayerLeoXIII =
                "Blessed Michael, archangel, defend us in the hour of conflict. Be our safeguard against the wickedness and " +
                "snares of the devil (may God restrain him, we humbly pray):" + Environment.NewLine +
                "and do thou, O Prince of the heavenly host, " +
                "by the power of God thrust Satan down to hell" +
                "and with him those other wicked spirits" +
                "who wander through the world for the ruin of souls." + Environment.NewLine +
                "Amen.",

                Latin = "LATIN",
                PrayerLeoXIIILatin =
                "Sancte Míchael Archángele! Defénde nos in próelio;" + Environment.NewLine +
                "contra nequítiam et insídias diáboli esto praesídium." + Environment.NewLine +
                "Imperet illi Deus, súpplices deprecámur, tuque, Prínceps milítiae caeléstis, Sátanam aliósque spíritus malígnos," + Environment.NewLine +
                "qui ad perditiónem animárum pervagántur in mundo, divína virtúte, in inférnum detrúde." + Environment.NewLine +
                "Amen.",

                ManualHeader = "Welcome to the Rosary of Saint Archangel Michael!",

                Prayer = "This is how the rosary is prayed:" + Environment.NewLine + Environment.NewLine +
                "1. Invocation of the Angels (Serpahim, Cherubim, etc.)" + Environment.NewLine + Environment.NewLine +
                "2. Our Father 1x" + Environment.NewLine + Environment.NewLine +
                "3. Hail Mary 3x" + Environment.NewLine + Environment.NewLine +
                "4. One Our Father each in honor of the Archangels Michael, Raphael, Gabriel and the Guardian Angel",

                ImageofAngel = "rosenkranz.jpg"
            });

            getLanguage.Add(new Models.Rosenkranz
            {
                Prayer = "In the name of the Father, and of the Son, and of the Holy Spirit. Amen." + Environment.NewLine +
                    "O God, come to my assistance. O Lord, make haste to help me. Glory be to the Father, to the Son," +
                    " and to the Holy Spirit, as it was in the beginning, is now and will be forever, time without end. Amen.",

                ImageofAngel = "michael.jpg"

            });


            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                    "By the intercession of St. Michael and the celestial Choir of Seraphim may the Lord make us " +
                    "worthy to burn with the fire of perfect charity. Amen." + Environment.NewLine +
                    Environment.NewLine + "(Our Father, Three Hail Marys)",

                ImageofAngel = "gabrielpd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                    "By the intercession of St.Michael and the celestial Choir of Cherubim may the Lord grant us " +
                    "the grace to leave the ways of sin and run in the paths of Christian perfection.Amen." +
                    Environment.NewLine + Environment.NewLine + "(Our Father, Three Hail Marys)",

                ImageofAngel = "raphaelpd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                    "By the intercession of St.Michael and the celestial Choir of Thrones may the Lord infuse into" +
                    "our hearts a true and sincere spirit of humility. Amen." +
                    Environment.NewLine + Environment.NewLine + "(Our Father, Three Hail Marys)",

                ImageofAngel = "michael1pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                    "By the intercession of St.Michael and the celestial Choir of Dominions may the Lord give us " +
                    "grace to govern our senses and overcome any unruly passions. Amen." + Environment.NewLine +
                    Environment.NewLine + "(Our Father, Three Hail Marys)",

                ImageofAngel = "michael2pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                    "By the intercession of St.Michael and the celestial Choir of Powers may the Lord protect our " +
                    "souls against the snares and temptations of the devil. Amen." + Environment.NewLine +
                    Environment.NewLine + "(Our Father, Three Hail Marys)",

                ImageofAngel = "michael4pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                    "By the intercession of St.Michael and the celestial Choir of Virtues may the Lord preserve " +
                    "us from evil and falling into temptation. Amen." + Environment.NewLine +
                    Environment.NewLine + "(Our Father, Three Hail Marys)",

                ImageofAngel = "michael5pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                    "By the intercession of St. Michael and the celestial Choir of Principalities may God fill our" +
                    " souls with a true spirit of obedience. Amen." + Environment.NewLine +
                    Environment.NewLine + "(Our Father, Three Hail Marys)",

                ImageofAngel = "michael6pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                    "By the intercession of St. Michael and the celestial Choir of Archangels may the Lord give " +
                    "us perseverance in faith and in all good works in order that we may attain the glory of Heaven. Amen."
                    + Environment.NewLine + Environment.NewLine + "(Our Father, Three Hail Marys)",

                ImageofAngel = "michael8pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                   "By the intercession of St. Michael and the celestial Choir of Angels may the Lord grant us to " +
                   "be protected by them in this mortal life and conducted in the life to come to Heaven. Amen." +
                   Environment.NewLine + Environment.NewLine + " (Our Father, Three Hail Marys)",

                ImageofAngel = "michael9pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                   "(Four Our Fathers. One in honor of each of the following leading Angels: St.Michael, St.Gabriel," +
                   "St.Raphael and our Guardian Angel.)",

                ImageofAngel = "michael10pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer =
                    "O glorious prince St. Michael, chief and commander of the heavenly hosts, guardian of souls, " +
                    "vanquisher of rebel spirits, servant in the house of the Divine King and our admirable conductor, " +
                    "you who shine with excellence and superhuman virtue deliver us from all evil, who turn to you with" +
                    " confidence and enable us by your gracious protection to serve God more and more faithfully every " +
                    "day." + Environment.NewLine +
                    "Pray for us, O glorious St.Michael, Prince of the Church of Jesus Christ, that we may be made " +
                    "worthy of His promises." + Environment.NewLine +
                    "Almighty and Everlasting God, Who, by a prodigy of goodness and a merciful desire for the " +
                    "salvation of all men, has appointed the most glorious Archangel St.Michael Prince of Your" +
                    " Church, make us worthy, we ask You, to be delivered from all our enemies, that none of them" +
                    " may harass us at the hour of death, but that we may be conducted by him into Your Presence." +
                    "This we ask through the merits of Jesus Christ Our Lord. Amen.",

                ImageofAngel = "michael11pd.jpg"
            });

            return getLanguage;
        }

        public ObservableCollection<Rosenkranz> GetFrench()
        {
            var getLanguage = new ObservableCollection<Rosenkranz>();

            getLanguage.Add(new Rosenkranz
            {
                ContentPageTitle = "Sancti Rosarii Michael",
                TabBarTitleRosary = "Rosaire",
                TabBarTitleManual = "L'Instruction",
                TabBarTitlePromises = "Promesses",
                TabBarTitlePrayers = "Prières",
                TabBarTitleSettings = "Langue",
                SettingsText = "Appuyez sur le drapeau pour choisir la langue!",

                ContentPageTitlePromisesMichael = "...De L'Archange Michel",
                Promises = "(Traduction avec un programme informatique)" +
                "«Le pape Pie IX a accordé les indulgences suivantes à ceux qui prient le chapelet:" + Environment.NewLine +
                "Indulgence partielle, à ceux qui prient ce chapelet avec un cœur contrit." + Environment.NewLine +
                "Indulgence partielle, chaque jour à ceux qui portent le Chapelet avec eux et / ou baisent la médaille des Saints" +
                "Anges qui y pend." + Environment.NewLine +
                "Indulgence totale, à ceux qui la prient une fois par mois, le jour de leur choix, vraiment contrit et confessés," +
                "priant pour les intentions de leur Sainteté." + Environment.NewLine +
                "Indulgence totale, dans les mêmes conditions, aux fêtes de l'Apparition de Saint Michel Archange (8 mai); la fête des" +
                " Archanges Michel, Gabriel et Rafael (29 septembre); et le jour des saints anges gardiens (2 octobre).",

                ContentPageTitleIndulgences = "L'Indulgence de Pius IX.",
                Indulgences = 
                
                "(Traduction avec un programme informatique)" + Environment.NewLine +

                "Cette prière trouve sa source dans une révélation à une moniale carmélite portugaise, Antónia de Astónaco," +
                "en 1750.La prière reçut ensuite l'approbation du pape Pie IX le 8 août 1851, qui lui attribua des indulgences." + Environment.NewLine + Environment.NewLine +

                "L'Archange Michel a promis à quiconque prierait ce chapelet:" + Environment.NewLine +
                "Qu'il enverrait un ange choisi de chaque chœur angélique pour accompagner les fidèles au moment de la communion." + Environment.NewLine +
                "A ceux qui récitent ces neuf salutations, chaque jour:" + Environment.NewLine +
                "Qu'ils bénéficieront de son assistance continue pendant cette vie et aussi après la mort, au purgatoire." + Environment.NewLine +
                "Ils seront accompagnés de tous les anges et seront, avec tous leurs proches et parents libérés du purgatoire.",

                ContentPageTitleLitany = "LITANIE",
                Litany =
                "Seigneur, ayez pitié de nous" + Environment.NewLine +
                "Jésus-Christ, ayez pitié de nous" + Environment.NewLine +
                "Seigneur, ayez pitié de nous" + Environment.NewLine +
                "Jésus-Christ, écoutez-nous" + Environment.NewLine +
                "Jésus-Christ exaucez-nous" + Environment.NewLine +
                "Père céleste, qui êtes Dieu, ayez pitié de nous" + Environment.NewLine +
                "Fils, Rédempteur du monde, qui êtes Dieu, ayez pitié de nous" + Environment.NewLine +
                "Esprit Saint, qui êtes Dieu, ayez pitié de nous." + Environment.NewLine +
                "Trinité Sainte, qui êtes un seul Dieu, ayez pitié de nous" + Environment.NewLine + Environment.NewLine +
                "Sainte Marie, Reine des Anges, priez pour nous." + Environment.NewLine +
                "Saint Michel, rempli de la sagesse de Dieu," + Environment.NewLine +
                "Saint Michel, parfait adorateur du Verbe divin," + Environment.NewLine +
                "Saint Michel, couronné d’honneur et de gloire." + Environment.NewLine +
                "Saint Michel, très puissant prince des armées du Seigneur," + Environment.NewLine +
                "Saint Michel, porte-étendard de la Très Saint Trinité," + Environment.NewLine +
                "Saint Michel, guide et consolateur du peuple d’Israël," + Environment.NewLine +
                "Saint Michel, splendeur et forteresse de l’Eglise militante," + Environment.NewLine +
                "Saint Michel, lumière des Anges," + Environment.NewLine +
                "Saint Michel, rempart des orthodoxes," + Environment.NewLine +
                "Saint Michel, force de ceux qui combattent sous l’Etendard de la Croix," + Environment.NewLine +
                "Saint Michel, lumière et confiance des âmes au dernier terme de la vie," + Environment.NewLine +
                "Saint Michel, secours très assuré," + Environment.NewLine +
                "Saint Michel, notre aide dans toutes nos adversités," + Environment.NewLine +
                "Saint Michel, héraut de la sentence éternelle," + Environment.NewLine +
                "Saint Michel, consolateur des âmes retenues dans les flammes du Purgatoire," + Environment.NewLine +
                "Saint Michel, que le Seigneur a chargé de recevoir les âmes après la mort," + Environment.NewLine +
                "Saint Michel, notre prince," + Environment.NewLine +
                "Saint Michel, notre avocat," + Environment.NewLine + Environment.NewLine +
                "Agneau de Dieu, qui enlevez les péchés du monde, pardonnez-nous Seigneur," + Environment.NewLine +
                "Agneau de Dieu, qui enlevez les péchés du monde, exaucez-nous Seigneur," + Environment.NewLine +
                "Agneau de Dieu, qui enlevez les péchés du monde, ayez pitié de nous Seigneur," + Environment.NewLine +
                "Jésus-Christ, écoutez nous," + Environment.NewLine +
                "Jésus-Christ, exaucez nous." + Environment.NewLine + Environment.NewLine +
                "Priez pour nous, ô glorieux saint Michel, Prince de l’Eglise de Jésus-Christ." + Environment.NewLine +
                "Afin que nous puissions être dignes de ses promesses." + Environment.NewLine +
                "PRIONS" + Environment.NewLine +
                "Seigneur Jésus, sanctifiez-nous par une bénédiction toujours nouvelle, et accordez-nous, par l’intercession de Saint Michel, cette sagesse qui nous enseigne à amasser des trésors dans le ciel, et à échanger les biens du temps contre ceux de l’éternité, Vous qui vivez et régnez dans les siècles des siècles." +
                Environment.NewLine + " Amen.",


                ContentPageTitleLeoXIII = "...par Pape LEO XIII .",
                NativeLanguage = "FRANÇAIS",
                PrayerLeoXIII =
                 "Saint Michel archange," + Environment.NewLine +
                "défendez - nous dans le combat ; soyez notre secours contre la malice et les embûches du démon. " +
                "Que Dieu lui fasse sentir son empire, nous vous en supplions. Et vous, prince de la milice céleste, " +
                "repoussez en enfer, par la force divine, Satan et les autres esprits mauvais qui rôdent dans le monde en " +
                "vue de perdre les âmes. Amen.",

                Latin = "LATIN",
                PrayerLeoXIIILatin =
                "Sancte Míchael Archángele! Defénde nos in próelio;" + Environment.NewLine +
                "contra nequítiam et insídias diáboli esto praesídium." + Environment.NewLine +
                "Imperet illi Deus, súpplices deprecámur, tuque, Prínceps milítiae caeléstis, Sátanam aliósque spíritus malígnos," + Environment.NewLine +
                "qui ad perditiónem animárum pervagántur in mundo, divína virtúte, in inférnum detrúde." + Environment.NewLine +
                "Amen.",

                ManualHeader = "Bienvenue au Rosaire de Saint Archange Michel!",

                Prayer = "Voici comment le chapelet est prié:" + Environment.NewLine + Environment.NewLine +
                "1. Invocation des anges (Serpahim, chérubins, etc." + Environment.NewLine + Environment.NewLine +
                "2. Notre Père 1x" + Environment.NewLine + Environment.NewLine +
                "3. Salue Marie 3x" + Environment.NewLine + Environment.NewLine +
                "4. Un Notre Père chacun en l'honneur des Archanges Michel, Raphaël, Gabriel et l'Ange Gardien",

                ImageofAngel = "rosenkranz.jpg"

            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Saint Michel Archange, défendez-nous dans le combat pour que nous ne périssions pas au jour du Jugement. O Dieu, venez à mon " +
                    "aide, Seigneur, hâtez vous de me secourir.",

                ImageofAngel = "michael.jpg"

            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Par l’intercession de Saint Michel et du Chœur céleste des Séraphins, que le Seigneur daigne nous rendre dignes de la " +
                "flamme du parfait amour.Ainsi soit - il." + Environment.NewLine +
                Environment.NewLine + "(1x Notre Père, 3x Je Vous Salue Marie)",

                ImageofAngel = "gabrielpd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Par l’intercession de Saint Michel et du Chœur céleste des Chérubins, que le Seigneur veuille nous faire la grâce" +
                "d’abandonner la voie du péché et d’avancer dans celle de la perfection chrétienne.Ainsi soit - il." + Environment.NewLine +
                Environment.NewLine + "(1x Notre Père, 3x Je Vous Salue Marie)",

                ImageofAngel = "raphaelpd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Par l’intercession de Saint Michel et du Chœur très Saint des Trônes, que le Seigneur infuse dans nos cœurs l’esprit " +
                "de vraie et sincère humilité. Ainsi soit-il." + Environment.NewLine +
                Environment.NewLine + "(1x Notre Père, 3x Je Vous Salue Marie)",

                ImageofAngel = "michael1pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Par l’intercession de Saint Michel et du Chœur céleste des Dominations, que le Seigneur nous fasse la grâce de dominer nos" +
                " sens et de nous libérer de l’esclavage des passions. Ainsi soit-il." + Environment.NewLine +
                Environment.NewLine + "(1x Notre Père, 3x Je Vous Salue Marie)",

                ImageofAngel = "michael2pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Par l’intercession de Saint Michel et du Chœur céleste des Puissances, que le Seigneur daigne préserver nos âmes des" +
                " embûches et des tentations du démon. Ainsi soit-il." + Environment.NewLine +
                Environment.NewLine + "(1x Notre Père, 3x Je Vous Salue Marie)",

                ImageofAngel = "michael4pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Par l’intercession de Saint Michel et du Chœur admirable des Vertus Célestes, que le Seigneur ne nous laisse pas succomber" +
                " à la tentation mais qu’il nous délivre du mal. Ainsi soit-il." + Environment.NewLine +
                Environment.NewLine + "(1x Notre Père, 3x Je Vous Salue Marie)",

                ImageofAngel = "michael5pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Par l’intercession de Saint Michel et du Chœur céleste des Principautés, que le Seigneur emplisse nos âmes de l’esprit " +
                "de vraie et sincère obéissance. Ainsi soit-il." + Environment.NewLine +
                Environment.NewLine + "(1x Notre Père, 3x Je Vous Salue Marie)",

                ImageofAngel = "michael6pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Par l’intercession de Saint Michel et du Chœur céleste des Archanges, que le Seigneur nous accorde le don de la persévérance" +
                " dans la foi et dans les bonnes œuvres pour pouvoir gagner la gloire du paradis. Ainsi soit-il." + Environment.NewLine +
                Environment.NewLine + "(1x Notre Père, 3x Je Vous Salue Marie)",

                ImageofAngel = "michael8pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Par l’intercession de Saint Michel et du Chœur céleste de tous les Anges, que le Seigneur daigne nous faire la grâce d’être" +
                " gardés par eux en cette vie mortelle pour être conduits ensuite à la gloire éternelle du ciel. Ainsi soit-il." + Environment.NewLine +
                Environment.NewLine + "(1x Notre Père, 3x Je Vous Salue Marie)",

                ImageofAngel = "michael9pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Quatre Notre Père : le premier en l’honneur de Saint Michel Archange, le deuxième en l’honneur de Saint Gabriel Archange, " +
                "le troisième en l’honneur de Saint Raphaël Archange et le quatrième en l’honneur de notre ange gardien ainsi que des cinq autres " +
                "archanges.",

                ImageofAngel = "michael11pd.jpg"
            });

            return getLanguage;
        }

        public ObservableCollection<Rosenkranz> GetPortugese()
        {
            var getLanguage = new ObservableCollection<Rosenkranz>();

            getLanguage.Add(new Rosenkranz
            {
                ContentPageTitle = "Sancti Rosarii Michael",
                TabBarTitleRosary = "Terço",
                TabBarTitleManual = "Instrução",
                TabBarTitlePromises = "Promessas",
                TabBarTitlePrayers = "Orações",
                TabBarTitleSettings = "Idiomas",
                SettingsText = "Pressione a bandeira para escolher o idioma!",

                ContentPageTitlePromisesMichael = "...do São Miguel Arcanjo",
                Promises =
                "O glorioso São Miguel Arcanjo prometeu:" + Environment.NewLine +
                "A quem o honrasse desta maneira antes da Sagrada Comunhão seria acompanhado à Sagrada Mesa por um Anjo de cada um dos " +
                "nove Coros;" + Environment.NewLine +
                "A quem rezasse todos os dias essas nove saudações teria a sua assistência e a dos Santos Anjos durante a sua vida e que" +
                " depois da morte livraria do Purgatório a essa pessoa e aos seus parentes." + Environment.NewLine +
                "Através da recitação desta Coroa Angélica(ou Terço) obter - se - ão ainda muitas graças nas calamidades públicas, sobretudo" +
                " nas da Igreja Católica(de que São Miguel Arcanjo é o padroeiro perpétuo), e as indulgências que lhe foram atribuídas" +
                " pelo Papa Pio IX.",

                ContentPageTitleIndulgences = "indulgências pelo pius ix",
                Indulgences = "(tradução com um programa de computador)" + Environment.NewLine +

                "De acordo com a tradição da Igreja Católica, a origem desta devoção está relacionada com uma aparição e " +
                "revelação privada do próprio Arcanjo São Miguel a uma freira carmelita portuguesa, Antónia de Astónaco, " +
                "no ano de 1750, sendo posteriormente reconhecida e aprovada pelo Papa Pio IX, a 8 de agosto de 1851, quem " +
                "a enriqueceu de indulgências." + Environment.NewLine + Environment.NewLine + 
                "O Papa Pio IX concedeu as seguintes indulgências para aqueles que rezam o chapelim:"  + Environment.NewLine +
                "Indulgência parcial, para aqueles que rezam este Chaplet com o coração contrito." + Environment.NewLine +
                "Indulgência parcial, a cada dia, a quem carrega consigo o diadema e / ou beija a medalha dos Santos Anjos que dela pende." + Environment.NewLine +
                "Plena indulgência, a quantos o rezam uma vez por mês, o dia que escolherem, verdadeiramente arrependidos e confessados," +
                "rezando pelas intenções de sua Santidade." + Environment.NewLine +
                "Indulgência plena, nas mesmas condições, nas festas da Aparição de São Miguel Arcanjo(8 de maio); a festa dos" +
                " Arcanjos Miguel, Gabriel e Rafael(29 de setembro); e no dia dos Santos Anjos da Guarda(2 de outubro).",

                ContentPageTitleLeoXIII = "..do Papa Leão XIII",
                NativeLanguage = "PORTUGUÊS",
                PrayerLeoXIII = 
                "São Miguel Arcanjo, defendei - nos neste combate, sede o nosso auxílio contra os embustes e as ciladas do demónio. " +
                "Que Deus sobre ele impere, instante e humildemente o suplicamos. E vós, Príncipe da Milícia Celeste, com esse poder divino," +
                " precipitai no inferno a Satanás e a todos os espíritos malignos que vagueiam pelo mundo para perdição das almas. " +
                "Assim seja!",

                Latin = "LATIN",
                PrayerLeoXIIILatin = "Sancte Míchael Archángele! Defénde nos in próelio;" + Environment.NewLine +
                "contra nequítiam et insídias diáboli esto praesídium." + Environment.NewLine +
                "Imperet illi Deus, súpplices deprecámur, tuque, Prínceps milítiae caeléstis, Sátanam aliósque spíritus malígnos," + Environment.NewLine +
                "qui ad perditiónem animárum pervagántur in mundo, divína virtúte, in inférnum detrúde." + Environment.NewLine +
                "Amen.",

                ContentPageTitleLitany = "Ladainha",
                Litany =
                "Ladainha de São Miguel Arcanjo" + Environment.NewLine + Environment.NewLine +
                "Senhor, tende piedade de nós." + Environment.NewLine +
                "Jesus Cristo, tende piedade de nós." + Environment.NewLine + 
                "Senhor, tende piedade de nós." + Environment.NewLine + Environment.NewLine +

                "Jesus Cristo, ouvi - nos." + Environment.NewLine +
                "Jesus Cristo, atendei - nos." + Environment.NewLine + Environment.NewLine +

                "Pai Celeste, que sois Deus, tende piedade de nós." + Environment.NewLine +
                "Filho, Redentor do Mundo, que sois Deus, tende piedade de nós." + Environment.NewLine +
                "Espírito Santo, que sois Deus, tende piedade de nós." + Environment.NewLine +
                "Trindade Santa, que sois um único Deus, tende piedade de nós." + Environment.NewLine + Environment.NewLine +

                "Santa Maria, Rainha dos Anjos, rogai por nós." + Environment.NewLine +  Environment.NewLine +

                "São Miguel, rogai por nós." + Environment.NewLine +
                "São Miguel, cheio da graça de Deus, rogai por nós." + Environment.NewLine +
                "São Miguel, perfeito adorador do Verbo Divino, rogai por nós." + Environment.NewLine +
                "São Miguel, coroado de honra e de glória, rogai por nós." + Environment.NewLine +
                "São Miguel, poderosíssimo Príncipe dos exércitos do Senhor, rogai por nós." + Environment.NewLine +
                "São Miguel, porta-estandarte da Santíssima Trindade, rogai por nós." + Environment.NewLine +
                "São Miguel, guardião do Paraíso, rogai por nós." + Environment.NewLine +
                "São Miguel, guia e consolador do povo israelita, rogai por nós." + Environment.NewLine +
                "São Miguel, esplendor e fortaleza da Igreja militante, rogai por nós." + Environment.NewLine +
                "São Miguel, honra e alegria da Igreja triunfante, rogai por nós." + Environment.NewLine +
                "São Miguel, Luz dos Anjos, rogai por nós." + Environment.NewLine +
                "São Miguel, baluarte dos Cristãos, rogai por nós." + Environment.NewLine +
                "São Miguel, força daqueles que combatem pelo estandarte da Cruz, rogai por nós." + Environment.NewLine +
                "São Miguel, luz e confiança das almas no último momento da vida, rogai por nós." + Environment.NewLine +
                "São Miguel, socorro muito certo, rogai por nós." + Environment.NewLine +
                "São Miguel, nosso auxílio em todas as adversidades, rogai por nós." + Environment.NewLine +
                "São Miguel, arauto da sentença eterna, rogai por nós." + Environment.NewLine +
                "São Miguel, consolador das almas que estão no Purgatório, rogai por nós." + Environment.NewLine +
                "São Miguel, a quem o Senhor incumbiu de receber as almas que estão no Purgatório, rogai por nós." + Environment.NewLine +
                "São Miguel, nosso Príncipe, rogai por nós." + Environment.NewLine +
                "São Miguel, nosso Advogado, rogai por nós." + Environment.NewLine + Environment.NewLine +

                "Cordeiro de Deus, que tirais o pecado do mundo, perdoai - nos, Senhor." + Environment.NewLine +
                "Cordeiro de Deus, que tirais o pecado do mundo, atendei - nos, Senhor." + Environment.NewLine +
                "Cordeiro de Deus, que tirais o pecado do mundo, tende piedade de nós." + Environment.NewLine + Environment.NewLine +

                "Rogai por nós, ó glorioso São Miguel Arcanjo, Príncipe da Igreja de Cristo,para que sejamos dignos de " +
                "Suas promessas." + Environment.NewLine + "Amém.",

                ManualHeader = "Bem-vindo ao Rosário de São Arcanjo Miguel!",

                Prayer = "É assim que se reza o rosário:" + Environment.NewLine + Environment.NewLine +
                "1. Invocação dos Anjos (Serpahim, Querubins, etc.)" + Environment.NewLine + Environment.NewLine +
                "2. Pai Nosso 1x" + Environment.NewLine + Environment.NewLine +
                "3. Ave Maria 3x" + Environment.NewLine + Environment.NewLine +
                "4. Um Pai Nosso em homenagem aos Arcanjos Miguel, Rafael, Gabriel e o Anjo da Guarda",

                ImageofAngel = "rosenkranz.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Deus, vinde em meu auxílio. Senhor, socorrei-me e salvai-me. Glória ao Pai, ao Filho e ao Espírito Santo, assim como" +
                    " era no princípio, agora e sempre.",

                ImageofAngel = "michael.jpg"

            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "1ª invocação: Pela intercessão de São Miguel Arcanjo e do Coro Celeste dos Serafins, o Senhor nos faça dignos" +
                "do fogo da perfeita caridade." + Environment.NewLine + Environment.NewLine +
                "(Um Pai Nosso e de três Ave Marias)",

                ImageofAngel = "gabrielpd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "2ª invocação: Pela intercessão de São Miguel Arcanjo e do Coro Celeste dos Querubins, o Senhor nos conceda a " +
                "graça de trilharmos a estrada da perfeição cristã." + Environment.NewLine +
                Environment.NewLine + "(Um Pai Nosso e de três Ave Marias)",

                ImageofAngel = "raphaelpd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "3ª invocação: Pela intercessão de São Miguel Arcanjo e do Coro Celeste dos Tronos, o Senhor nos conceda o " +
                "espírito da verdadeira humildade." + Environment.NewLine +
                Environment.NewLine + "(Um Pai Nosso e de três Ave Marias)",

                ImageofAngel = "michael1pd.jpg"

            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "4ª invocação: Pela intercessão de São Miguel Arcanjo e do Coro Celeste das Dominações, o Senhor nos dê a " +
                "graça de podermos dominar os nossos sentidos." + Environment.NewLine +
                Environment.NewLine + "(Um Pai Nosso e de três Ave Marias)",

                ImageofAngel = "michael2pd.jpg"

            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "5ª invocação: Pela intercessão de São Miguel Arcanjo e do Coro Celeste das Potestades, o Senhor nos guarde" +
                " das traições e tentações do demónio." + Environment.NewLine +
                Environment.NewLine + "(Um Pai Nosso e de três Ave Marias)",

                ImageofAngel = "michael4pd.jpg"

            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "6ª invocação: Pela intercessão de São Miguel Arcanjo e do Coro Celeste das Virtudes, o Senhor nos conceda" +
                " a graça de não sermos vencidos no combate perigoso das tentações." + Environment.NewLine +
                Environment.NewLine + "(Um Pai Nosso e de três Ave Marias)",

                ImageofAngel = "michael5pd.jpg"

            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "7ª invocação: Pela intercessão de São Miguel Arcanjo e do Coro Celeste dos Principados, o Senhor nos dê o" +
                " espírito da verdadeira e sincera obediência." + Environment.NewLine +
                Environment.NewLine + "(Um Pai Nosso e de três Ave Marias)",

                ImageofAngel = "michael6pd.jpg"

            });

            getLanguage.Add(new Rosenkranz
            { 
                Prayer = "8ª invocação: Pela intercessão de São Miguel Arcanjo e do Coro Celeste dos Arcanjos, o Senhor nos conceda" +
                " o dom da perseverança na fé e boas obras." + Environment.NewLine +
                Environment.NewLine + "(Um Pai Nosso e de três Ave Marias)",

                ImageofAngel = "michael8pd.jpg"

            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "9ª invocação: Pela intercessão de São Miguel Arcanjo e do Coro Celeste dos Anjos, o Senhor nos conceda que" +
                " estes espíritos bem-aventurados nos guardem sempre, e principalmente na hora da nossa morte." + Environment.NewLine +
                Environment.NewLine + "(Um Pai Nosso e de três Ave Marias)",

                ImageofAngel = "michael9pd.jpg"

            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Um Pai Nosso a São Miguel Arcanjo." + Environment.NewLine +
                "Um Pai Nosso a São Gabriel Arcanjo." + Environment.NewLine +
                "Um Pai Nosso a São Rafael Arcanjo." + Environment.NewLine +
                "Um Pai Nosso ao nosso Anjo da Guarda.",

                ImageofAngel = "michael10pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Glorioso São Miguel Arcanjo, o primeiro entre todos os Anjos, defensor das almas, vencedor do Demónio, vós que" +
                " estais junto da glória de Deus e, depois de Nosso Senhor Jesus Cristo, sois admirável protector nosso, dotado de " +
                "sobre-humana excelência e fortaleza, dignai-vos alcançar de Deus que sejamos livres de toda a espécie de mal e " +
                "ajudai-nos a ser fiéis em cada dia ao serviço do nosso Deus. Rogai por nós, ó Bem-aventurado São Miguel Arcanjo, " +
                "príncipe da Igreja de Jesus Cristo, para que sejamos dignos das promessas do mesmo Senhor. Amén." + Environment.NewLine +
                "Omnipotente e sempiterno Deus que, por prodígio da Vossa bondade e misericórdia, elegestes para príncipe da Vossa Igreja" +
                " o gloriosíssimo Arcanjo São Miguel, com o fim da comum salvação das almas, nós Vos rogamos que nos façais dignos de" +
                " sermos, por sua benéfica protecção, libertos de todos os nossos inimigos, de sorte que nenhum deles possa molestar - nos" +
                " na hora da nossa morte, mas antes nos seja dado que o mesmo Arcanjo nos conduza à presença da Vossa excelsa e divina" +
                " Majestade.Pelos merecimentos de Jesus Cristo, nosso Senhor. Amén.",

                ImageofAngel = "michael11pd.jpg"
            });

            return getLanguage;
        }

        public ObservableCollection<Rosenkranz> GetItalian()
        {
            var getLanguage = new ObservableCollection<Rosenkranz>();

            getLanguage.Add(new Rosenkranz
            {
                ContentPageTitle = "Sancti Rosarii Michael",
                TabBarTitleRosary = "Rosario",
                TabBarTitleManual = "L'Istruzione",
                TabBarTitlePromises = "Promesse",
                TabBarTitlePrayers = "Preghiere",
                TabBarTitleSettings = "Lingue",
                SettingsText = "Premere bandiera per scegliere la lingua!",

                ContentPageTitlePromisesMichael = "...Dall'Arcangelo Michele",
                Promises = "(tradotto con programma per computer) L'Arcangelo Michele ha promesso a chiunque avrebbe recitato questa " +
                "Coroncina:" + Environment.NewLine +
                "Che avrebbe mandato un angelo scelto da ogni coro angelico per accompagnare i devoti al momento della comunione." +
                "A coloro che recitano questi nove saluti, ogni giorno:" + Environment.NewLine +
                "Che godranno della sua continua assistenza durante questa vita e anche dopo la morte, in purgatorio." +
                "Saranno accompagnati da tutti gli angeli e saranno, con tutti i loro cari e parenti liberati dal Purgatorio.",

                ContentPageTitleIndulgences = "L'Indulgenza da Pius IX.",
                Indulgences = "(tradotto con programma per computer)" + Environment.NewLine +

                "Nel 1751 la serva di Dio Antonia de Astonac, religiosa carmelitana portoghese di cui è in corso il processo " +
                "di beatificazione, avrebbe ricevuto una rivelazione da san Michele arcangelo, contenente la richiesta di una" +
                " preghiera particolare che, recitata quotidianamente, è legata alla promessa di continua assistenza in vita," +
                "e in purgatorio dopo la morte, da parte dell'arcangelo stesso." + Environment.NewLine + Environment.NewLine +

                "Papa Pio IX concesse a coloro che recitano la coroncina le seguenti " +
                "indulgenze:" + Environment.NewLine +
                "Indulgenza parziale, a coloro che recitano questa Coroncina con cuore contrito." + Environment.NewLine +
                "Indulgenza parziale, ogni giorno, a chi porta con sé la Coroncina e / o bacia la medaglia dei Santi Angeli che pende da essa." + Environment.NewLine +
                "Piena indulgenza, a coloro che la pregano una volta al mese, il giorno che scelgono, veramente contriti e confessati," +
                "pregando per le intenzioni della loro Santità." + Environment.NewLine +
                "Piena indulgenza, a medesime condizioni, nelle feste dell'Apparizione di San Michele Arcangelo (8 maggio); la festa " +
                "degli Arcangeli Michele, Gabriele e Raffaele (29 settembre); e nel giorno dei Santi Angeli Custodi (2 ottobre).",


                ContentPageTitleLeoXIII = "..di Papa Leone XIII ",
                NativeLanguage = "ITALIANO",
                PrayerLeoXIII =
                "Nel nome del Padre, del Figlio e dello Spirito Santo." + Environment.NewLine +
                "San Michele Arcangelo, difendici nella lotta; sii nostro aiuto contro la cattiveria e le insidie del demonio." +
                "Che Dio eserciti il suo dominio su di lui, supplichevoli ti preghiamo: tu, che sei il Principe della milizia" +
                "celeste, con la forza divina rinchiudi nell'inferno Satana e gli altri spiriti maligni che girano il mondo" +
                "per portare le anime alla dannazione." + Environment.NewLine +
                "Amen.",

                Latin = "LATINO",
                PrayerLeoXIIILatin = "Sancte Míchael Archángele! Defénde nos in próelio;" + Environment.NewLine +
                "contra nequítiam et insídias diáboli esto praesídium." + Environment.NewLine +
                "Imperet illi Deus, súpplices deprecámur, tuque, Prínceps milítiae caeléstis, Sátanam aliósque spíritus malígnos," + Environment.NewLine +
                "qui ad perditiónem animárum pervagántur in mundo, divína virtúte, in inférnum detrúde." + Environment.NewLine +
                "Amen.",

                ContentPageTitleLitany = "LITANIA",
                Litany =
               "Signore, pietà" + Environment.NewLine +
                "Cristo, pietà" + Environment.NewLine +
                "Signore, pietà" + Environment.NewLine +
                "Cristo, ascoltaci" + Environment.NewLine +
                "Cristo, esaudiscici" + Environment.NewLine +
                "Padre celeste, Dio, Abbi pietà di noi" + Environment.NewLine +
                "Figlio redentore del mondo, Dio, Abbi pietà di noi" + Environment.NewLine +
                "Spirito Santo, Dio, Santa Trinità, unico Dio, Abbi pietà di noi" + Environment.NewLine + Environment.NewLine +
                "Santa Maria, Prega per noi" + Environment.NewLine +
                "San Michele Arcangelo, Prega per noi" + Environment.NewLine +
                "San Michele, Principe dei Serafini, Prega per noi" + Environment.NewLine +
                "San Michele, ambasciatore del Signore Dio d'Israele, Prega per noi" + Environment.NewLine +
                "San Michele, assessore della Santissima Trinità, Prega per noi" + Environment.NewLine +
                "San Michele, preposto del Paradiso, Prega per noi" + Environment.NewLine +
                "San Michele, chiarissima stella dell'ordine Angelico, Prega per noi" + Environment.NewLine +
                "San Michele, mediatore delle divine Grazie, Prega per noi" + Environment.NewLine +
                "San Michele, sole splendissimo di carità, Prega per noi" + Environment.NewLine +
                "San Michele, primo modello di umiltà, Prega per noi" + Environment.NewLine +
                "San Michele, esempio di mansuetudine, Prega per noi" + Environment.NewLine +
                "San Michele, prima fiamma di ardentissimo zelo, Prega per noi" + Environment.NewLine +
                "San Michele, degno di ammirazione, Prega per noi" + Environment.NewLine +
                "San Michele, degno di venerazione, Prega per noi" + Environment.NewLine +
                "San Michele, degno di lode, Prega per noi" + Environment.NewLine +
                "San Michele, ministro della divina clemenza, Prega per noi" + Environment.NewLine +
                "San Michele, duce fortissimo, Prega per noi" + Environment.NewLine +
                "San Michele, dispensatore di gloria, Prega per noi" + Environment.NewLine +
                "San Michele, consolatore degli sfiduciati, Prega per noi" + Environment.NewLine +
                "San Michele, Angelo di pace, Prega per noi" + Environment.NewLine +
                "San Michele, consolatore degli animi, Prega per noi" + Environment.NewLine +
                "San Michele, guida degli erranti, Prega per noi" + Environment.NewLine +
                "San Michele, sostegno di coloro che sperano, Prega per noi" + Environment.NewLine +
                "San Michele, custode di chi ha Fede, Prega per noi" + Environment.NewLine +
                "San Michele, protettore della Chiesa, Prega per noi" + Environment.NewLine +
                "San Michele, dispensatore generoso, Prega per noi" + Environment.NewLine +
                "San Michele, rifugio dei poveri, Prega per noi" + Environment.NewLine +
                "San Michele, sollievo degli oppressi, Prega per noi" + Environment.NewLine +
                "San Michele, vincitore dei demoni, Prega per noi" + Environment.NewLine +
                "San Michele, nostra fortezza, Prega per noi" + Environment.NewLine +
                "San Michele, nostro rifugio, Prega per noi" + Environment.NewLine +
                "San Michele, duce degli Angeli, Prega per noi" + Environment.NewLine +
                "San Michele, conforto dei Patriarchi, Prega per noi" + Environment.NewLine +
                "San Michele, luce dei Profeti, Prega per noi" + Environment.NewLine +
                "San Michele, guida degli Apostoli, Prega per noi" + Environment.NewLine +
                "San Michele, sollievo dei Martiri, Prega per noi" + Environment.NewLine +
                "San Michele, letizia dei Confessori, Prega per noi" + Environment.NewLine +
                "San Michele, custode delle Vergini, Prega per noi" + Environment.NewLine +
                "San Michele, onore di tutti i Santi, Prega per noi" + Environment.NewLine + Environment.NewLine +
                "Agnello di Dio, che togli i peccati del mondo, perdonaci, Signore." + Environment.NewLine +
                "Agnello di Dio, che togli i peccati del mondo, esaudiscici, Signore." + Environment.NewLine +
                "Agnello di Dio, che togli i peccati del mondo, abbi pietà di noi." + Environment.NewLine + Environment.NewLine +
                "PREGHIAMO O Signore, la potente intercessione del tuo Arcangelo Michele, ci protegga sempre e in ogni luogo; ci liberi da ogni male e ci conduca alla vita eterna." + Environment.NewLine +
                "Per Cristo nostro Signore. Amen." + Environment.NewLine +
                "Santi Angeli e Arcangeli, difendeteci. Amen.",

                ManualHeader = "Benvenuti al Rosario di San Michele Arcangelo!",

                Prayer = "Così si recita il rosario:" + Environment.NewLine + Environment.NewLine +
                "1. Invocazione degli angeli (Serpahim, Cherubim, ecc.)" + Environment.NewLine + Environment.NewLine +
                "2. Padre Nostro 1x" + Environment.NewLine + Environment.NewLine +
                "3. Ave Maria 3x" + Environment.NewLine + Environment.NewLine +
                "4. Un Padre Nostro ciascuno in onore degli Arcangeli Michele, Raffaele, Gabriele e l'Angelo Custode",

                ImageofAngel = "rosenkranz.jpg"
            });

            getLanguage.Add(new Rosenkranz {

                Prayer = "O Dio, vieni a salvarmi." + Environment.NewLine +
                "Signore, vieni presto in mio aiuto." + Environment.NewLine +
                "Gloria al Padre" + Environment.NewLine +
                "e al Figlio" + Environment.NewLine +
                "e allo Spirito Santo." + Environment.NewLine +
                "Come era nel principio" + Environment.NewLine +
                "e ora e sempre," + Environment.NewLine +
                "nei secoli dei secoli.Amen." + Environment.NewLine +
                "San Michele Arcangelo, difendici nella lotta, per essere salvati nell'estremo giudizio.",

                ImageofAngel = "michael.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Per intercessione di san Michele e del celeste coro dei Serafini, ci renda il Signore degni della fiamma di" +
                " perfetta carità." + Environment.NewLine + Environment.NewLine +
                "(Padre nostro e tre Ave Maria al 1° Coro Angelico).",


                ImageofAngel = "gabrielpd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Per intercessione di san Michele Arcangelo e del Coro celeste dei Cherubini, voglia il Signore darci la grazia" +
                " di abbandonare la vita del peccato e correre in quella della cristiana perfezione." + Environment.NewLine +
                Environment.NewLine + "(Padre nostro e tre Ave Maria al 2° Coro Angelico).",

                ImageofAngel = "raphaelpd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Per intercessione di san Michele Arcangelo e del sacro Coro dei Troni, infonda il Signore nei nostri cuori " +
                "lo spirito di vera e sincera umiltà." + Environment.NewLine + Environment.NewLine +
                "(Padre nostro e tre Ave Maria al 3° Coro Angelico).",

                ImageofAngel = "michael1pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Per intercessione di san Michele Arcangelo e del coro celeste delle Dominazioni, ci dia grazia il Signore" +
                " di dominare i nostri sensi e correggere le corrotte passioni." + Environment.NewLine +
                Environment.NewLine + "(Padre nostro e tre Ave Maria al 4° Coro Angelico).",

                ImageofAngel = "michael2pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Per intercessione di san Michele e del celeste Coro delle Potestà, il Signore si degni di proteggere le anime " +
                "nostre dalle insidie e tentazioni del demonio." + Environment.NewLine +
                Environment.NewLine + "(Padre nostro e tre Ave Maria al 5° Coro Angelico).",

                ImageofAngel = "michael4pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Per intercessione di san Michele e del Coro delle ammirabili Virtù celesti, non permetta il Signore che " +
                "cadiamo nelle tentazioni, ma ci liberi dal male." + Environment.NewLine +
                Environment.NewLine + "(Padre nostro e tre Ave Maria al 6° Coro Angelico).",

                ImageofAngel = "michael5pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Per intercessione di san Michele e del Coro celeste dei Principati, riempia Dio le anime nostre dello " +
                "spirito di vera e sincera obbedienza." + Environment.NewLine +
                Environment.NewLine + "(Padre nostro e tre Ave Maria al 7° Coro Angelico).",

                ImageofAngel = "michael6pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Per intercessione di san Michele e del Coro celeste degli Arcangeli, ci conceda il Signore il dono della" +
                " perseveranza nella fede e nelle opere buone." + Environment.NewLine +
                Environment.NewLine + "(Padre nostro e tre Ave Maria all'8° Coro Angelico).",

                ImageofAngel = "michael8pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Per intercessione di san Michele e del Coro celeste di tutti gli Angeli, si degni il Signore di concederci" +
                " di essere da essi custoditi nella vita presente e poi introdotti nella gloria dei cieli." + Environment.NewLine +
                Environment.NewLine + "(Padre nostro e tre Ave Maria al 9° Coro Angelico).",

                ImageofAngel = "michael9pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Un Padre nostro in onore di San Michele." + Environment.NewLine +
                "Un Padre nostro in onore di San Gabriele." + Environment.NewLine +
                "Un Padre nostro in onore di San Raffaele." + Environment.NewLine +
                "Un Padre nostro in onore dell'Angelo custode.",

                ImageofAngel = "michael10pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Prega per noi, arcangelo san Michele, Gesù Cristo Signore nostro." + Environment.NewLine +
                "E saremo resi degni delle Sue promesse. Dio onnipotente ed eterno, che con prodigio di bontà e misericordia," +
                "per la salvezza degli uomini hai eletto a Principe della tua Chiesa il glorioso san Michele, concedici, mediante la sua " +
                "benefica protezione, di essere liberati da tutti i nostri spirituali nemici.Nell'ora della nostra morte non ci molesti" +
                " l'antico avversario, ma sia il tuo arcangelo Michele a condurci alla presenza della tua divina Maestà. Amen.",

                ImageofAngel = "michael11pd.jpg"
            });

            return getLanguage;
        }

        public ObservableCollection<Rosenkranz> GetSpanish()
        {
            var getLanguage = new ObservableCollection<Rosenkranz>();

            getLanguage.Add(new Rosenkranz
            {
                ContentPageTitle = "Sancti Rosarii Michael",
                TabBarTitleRosary = "Rosario",
                TabBarTitleManual = "La Instrucción",
                TabBarTitlePromises = "Promesas",
                TabBarTitlePrayers = "Oraciones",
                TabBarTitleSettings = "Idiomas",
                SettingsText = "Presione la bandera para elegir el idioma!",

                ContentPageTitlePromisesMichael = "...por el Arcángel Miguel",
                Promises = "El arcángel Miguel prometió a quien rece la coronilla:" + Environment.NewLine +
                "Enviar un ángel escogido de cada coro angelical para acompañar a los devotos a la hora de la comunión." + Environment.NewLine +
                "A los que reciten estas nueve salutaciones todos los días les asegura que:" + Environment.NewLine +
                "Disfrutarán de su asistencia continua durante esta vida y también después de la muerte." + Environment.NewLine +
                "Serán acompañados de todos los ángeles y serán, con todos sus seres queridos, parientes y familiares, librados del Purgatorio.",

                ContentPageTitleIndulgences = "Indulgencias por Pius IX.",
                Indulgences =

                "La coronilla fue revelada en Portugal a la sierva de Dios Antónia de Astónaco, una monja de la Orden de Nuestra" +
                " Señora del Monte Carmelo, aproximadamente en el año 1750.El arcángel Miguel le dijo a la religiosa carmelita" +
                " que deseaba ser invocado mediante la recitación de nueve salutaciones a través de las cuales se pide la " +
                "intercesión de San Miguel y del coro celestial correspondiente, rezando un padrenuestro y tres avemarías en " +
                "cada salutación." + Environment.NewLine + Environment.NewLine +

                "El papa Pío IX concedió las siguientes indulgencias a quienes recen la coronilla:" + Environment.NewLine +
                "Indulgencia parcial, a los que recen esta Corona con el corazón contrito." + Environment.NewLine +
                "Indulgencia parcial, cada día que lleven consigo la Corona o besaren la medalla de los Santos Ángeles que cuelga de ella." + Environment.NewLine +
                "Indulgencia plenaria, a aquellos que la rezaren una vez al mes, el día que escogieren, verdaderamente contritos, " +
                "confesados y comulgados, rogando por las intenciones de su Santidad." + Environment.NewLine +
                "Indulgencia plenaria, con las mismas condiciones, en las fiestas de la Aparición de San Miguel Arcángel(8 de mayo); " +
                "la fiesta de los santos Arcángeles Miguel, Gabriel y Rafael(29 de setiembre); y la de los Santos Ángeles Custodios" +
                "(2 de octubre).",

                ContentPageTitleLitany = "LETANÍA ",
                Litany =
                "Señor, ten piedad de nosotros. Señor, ten piedad de nosotros." + Environment.NewLine +
                "Cristo, ten piedad de nosotros. Cristo, ten piedad de nosotros." + Environment.NewLine +
                "Señor, ten piedad de nosotros. Señor, ten piedad de nosotros." + Environment.NewLine +
                "Cristo, óyenos. Cristo, óyenos." + Environment.NewLine +
                "Cristo, escúchanos. Cristo, escúchanos." + Environment.NewLine + Environment.NewLine +

                "Dios Padre celestial, ten misericordia de nosotros." + Environment.NewLine +
                "Dios Hijo, redentor del mundo, ten misericordia de nosotros." + Environment.NewLine +
                "Dios, Espíritu Santo, ten misericordia de nosotros." + Environment.NewLine +
                "Trinidad Santa, un solo Dios, ten misericordia de nosotros." + Environment.NewLine +
                "Santa María, reina de los Ángeles, ruega por nosotros." + Environment.NewLine + Environment.NewLine +

                "San Miguel, ruega por nosotros." + Environment.NewLine +
                "San Miguel, lleno de la gracia de Dios, ruega por nosotros." + Environment.NewLine +
                "San Miguel, perfecto adorador del verbo divino, ruega por nosotros." + Environment.NewLine +
                "San Miguel, coronado de honor y gloria, ruega por nosotros." + Environment.NewLine +
                "San Miguel, poderoso príncipe de los ejércitos del Señor, ruega por nosotros." + Environment.NewLine +
                "San Miguel, portaestandarte de la Santísima Trinidad, ruega por nosotros." + Environment.NewLine +
                "San Miguel, guardián del paraíso, ruega por nosotros." + Environment.NewLine +
                "San Miguel, guía y consolador del pueblo israelita, ruega por nosotros." + Environment.NewLine +
                "San Miguel, esplendor y vigor de la Iglesia militante, ruega por nosotros." + Environment.NewLine +
                "San Miguel, honor y alegría de Iglesia triunfante, ruega por nosotros." + Environment.NewLine +
                "San Miguel, luz de los ángeles, ruega por nosotros." + Environment.NewLine +
                "San Miguel, baluarte de los ortodoxos, ruega por nosotros." + Environment.NewLine +
                "San Miguel, fuerza de los que combaten bajo el estandarte de la cruz, ruega por nosotros." + Environment.NewLine +
                "San Miguel, luz y confianza de las almas en el último momento de la vida, ruega por nosotros." + Environment.NewLine +
                "San Miguel, socorro certero, ruega por nosotros." + Environment.NewLine +
                "San Miguel, nuestro auxilio en todas las adversidades, ruega por nosotros." + Environment.NewLine +
                "San Miguel, heraldo de la sentencia eterna, ruega por nosotros." + Environment.NewLine +
                "San Miguel, consolador de las almas que están en el purgatorio, ruega por nosotros." + Environment.NewLine +
                "San Miguel, a quien el señor encomendó recibir las almas después de la muerte, ruega por nosotros." + Environment.NewLine +
                "San Miguel, nuestro príncipe, ruega por nosotros." + Environment.NewLine +
                "San Miguel, nuestro abogado, ruega por nosotros." + Environment.NewLine + Environment.NewLine +

                "Cordero de Dios, que quitas el pecado del mundo. Perdónanos Señor." + Environment.NewLine +
                "Cordero de Dios, que quitas el pecado del mundo. Escúchanos Señor." + Environment.NewLine +
                "Cordero de Dios, que quitas el pecado del mundo. Ten misericordia de nosotros." + Environment.NewLine + Environment.NewLine +

                "Ruega por nosotros, glorioso San Miguel, príncipe de la Iglesia de Jesucristo, para que seamos dignos de sus promesas." + Environment.NewLine +
                "Amén" ,


                ContentPageTitleLeoXIII = "...del Papa LEO XIII",
                NativeLanguage = "ESPAÑOL",
                PrayerLeoXIII =
                "San Miguel arcángel, defiéndenos en la lucha." + Environment.NewLine +
                "Sé nuestro amparo contra la perversidad y asechanzas del demonio." + Environment.NewLine +
                "Que Dios manifieste sobre él su poder, es nuestra humilde súplica." + Environment.NewLine +
                "Y tú, oh príncipe de la milicia celestial, con el poder que Dios te ha conferido," + Environment.NewLine +
                "arroja al infierno a satanás, y a los demás espíritus malignos que vagan por el mundo para la perdición de " +
                "las almas." + Environment.NewLine + "Amén.",

                Latin = "LATÍN",
                PrayerLeoXIIILatin =
                "Sancte Míchael Archángele! Defénde nos in próelio;" + Environment.NewLine +
                "contra nequítiam et insídias diáboli esto praesídium." + Environment.NewLine +
                "Imperet illi Deus, súpplices deprecámur, tuque, Prínceps milítiae caeléstis, Sátanam aliósque spíritus malígnos," + Environment.NewLine +
                "qui ad perditiónem animárum pervagántur in mundo, divína virtúte, in inférnum detrúde." + Environment.NewLine +
                "Amen.",

                ManualHeader = "Bienvenidos al Rosario de San Arcángel Miguel!",

                Prayer = "Así se reza el rosario:" + Environment.NewLine + Environment.NewLine +
                "1. Invocación de los Ángeles (Serpahim, Querubines, etc.)" + Environment.NewLine + Environment.NewLine +
                "2. Padre Nuestro 1x" + Environment.NewLine + Environment.NewLine +
                "3. Avemaría 3x" + Environment.NewLine + Environment.NewLine +
                "4. Un Padre Nuestro, cada uno en honor de los Arcángeles Miguel, Rafael, Gabriel y el Ángel de la Guarda",

                ImageofAngel = "rosenkranz.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "En el nombre del Padre, del Hijo y del Espíritu Santo." + Environment.NewLine +
                "Dios mío, ven en mi auxilio.Señor, date prisa en socorrerme." + Environment.NewLine +
                "Gloria al Padre, al Hijo y al Espíritu santo. Amén",

                ImageofAngel = "michael.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Por la intercesión de San Miguel y el Coro Celestial de los Serafines, que Dios Nuestro Señor prepare nuestras" +
                " almas para así recibir dignamente en nuestros corazones, el fuego de la Caridad Perfecta. Amén." + Environment.NewLine +
                Environment.NewLine + "(Un Padre Nuestro y tres Avemaría)",

                ImageofAngel = "gabrielpd.jpg"

            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Por la intercesión de San Miguel y el Coro Celestial de los Querubines, que Dios Nuestro Señor nos conceda" +
                " la gracia de abandonar los caminos del pecado y seguir el camino de la Perfección Cristiana. Amén." + Environment.NewLine +
                Environment.NewLine + "(Un Padre Nuestro y tres Avemaría)",

                ImageofAngel = "raphaelpd.jpg"

            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Por la intercesión de San Miguel y el Coro Celestial de los Tronos, que Dios Nuestro Señor derrame en nuestros" +
                " corazones, el verdadero y sincero espíritu de humildad. Amén." + Environment.NewLine +
                Environment.NewLine + "(Un Padre Nuestro y tres Avemaría)",

                ImageofAngel = "michael1pd.jpg"

            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = " Por la intercesión de San Miguel y el Coro Celestial de Potestades, que Dios Nuestro señor nos conceda " +
                "la gracia de controlar nuestros sentidos y así dominar nuestras pasiones. Amén." + Environment.NewLine +
                Environment.NewLine + "(Un Padre Nuestro y tres Avemaría)",

                ImageofAngel = "michael2pd.jpg"

            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = " Por la intercesión de San Miguel y el Coro Celestial de Dominaciones, que Dios Nuestro Señor proteja " +
                "nuestras almas contra las asechanzas del demonio. Amén." + Environment.NewLine +
                Environment.NewLine + "(Un Padre Nuestro y tres Avemaría)",

                ImageofAngel = "michael4pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Por la intercesión de San Miguel y el Coro Celestial de las Virtudes, que Dios nuestro señor nos conserve " +
                "de todo mal y no nos deje caer en la tentación. Amén." + Environment.NewLine +
                Environment.NewLine + "(Un Padre Nuestro y tres Avemaría)",

                ImageofAngel = "michael5pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = " Por la intercesión de San Miguel y el Coro Celestial de los Principados, que Dios nuestro señor se digne " +
                "llenar nuestras almas con el verdadero espíritu de obediencia. Amén." + Environment.NewLine +
                Environment.NewLine + "(Un Padre Nuestro y tres Avemaría)",

                ImageofAngel = "michael6pd.jpg"

            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Por la intercesión de San Miguel y el Coro Celestial de los Arcángeles, que Dios nuestro señor nos conceda" +
                " la gracia de la perseverancia final en la fe, y en las buenas obras, y así nos lleve a la Gloria del Paraíso. Amén." + Environment.NewLine +
                Environment.NewLine + "(Un Padre Nuestro y tres Avemaría)",

                ImageofAngel = "michael8pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Por la intercesión de San Miguel y el Coro Celestial de los Ángeles, que Dios Nuestro Señor nos conceda" +
                " la gracia de ser protegidos por ellos durante esta vida mortal, y nos guíen a la Gloria Eterna. Amén." + Environment.NewLine +
                Environment.NewLine + "(Un Padre Nuestro y tres Avemaría)",

                ImageofAngel = "michael9pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Un Padre Nuestro a San Miguel." + Environment.NewLine +
                "Un Padre Nuestro a San Gabriel." + Environment.NewLine +
                "Un Padre Nuestro a San Rafael." + Environment.NewLine +
                "Un Padre Nuestro al Ángel de la Guarda.",

                ImageofAngel = "michael10pd.jpg"
            });

            getLanguage.Add(new Rosenkranz
            {
                Prayer = "Glorioso Príncipe San Miguel, Jefe Principal de la Milicia Celestial, Guardián fidelísimo de las almas, Vencedor" +
                " eficaz de los espíritus rebeldes, fiel Servidor en el Palacio del Rey Divino." + Environment.NewLine +
                "Eres nuestro admirable guía y conductor." + Environment.NewLine +
                "Tú brillas con excelente resplandor y con virtud sobrehumana, libradnos de todo mal. Con plena confianza recurrimos a ti." + Environment.NewLine +
                "Asístenos con tu afable protección para que seamos más y más fieles al servicio de Dios todos los días de nuestra vida." + Environment.NewLine +
                "Ruega por nosotros, Glorioso San Miguel, Príncipe de la Iglesia de Jesucristo." + Environment.NewLine +
                "Para que seamos dignos de alcanzar las promesas de Nuestro Señor." + Environment.NewLine +
                "Omnipotente y Eterno Dios, los adoramos y bendecimos." + Environment.NewLine +
                "En vuestra maravillosa bondad, y con el misericordioso deseo de salvar las almas del género humano, habéis escogido al" +
                " Glorioso Arcángel, San Miguel, como Príncipe de Vuestra Iglesia." + Environment.NewLine +
                "Humildemente les suplicamos, Padre Celestial, que nos libres de nuestros enemigos.En la hora de la muerte, no permitas que " +
                "ningún espíritu maligno se nos acerque, para perjudicar nuestras almas." + Environment.NewLine +
                "Oh Dios y Señor Nuestro, guiadnos por medio de este mismo Arcángel." + Environment.NewLine +
                "Envíale a que nos conduzca a la Presencia de tu Excelsa y divina Majestad." + Environment.NewLine +
                "Te lo pedimos por los méritos de Jesucristo, Nuestro Señor. Amén.",

                ImageofAngel = "michael11pd.jpg"
            });

            return getLanguage;
        }
        #endregion

        

        
    }
}