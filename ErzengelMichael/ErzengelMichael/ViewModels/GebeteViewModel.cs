using ErzengelMichael.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ErzengelMichael.ViewModels
{
    //[QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class GebeteViewModel : BaseViewModel
    {
        public List<string> GebetLeoXIII { get; set; }
        public List<string> LitaneiMichael { get; set; }
        //public List<string> Besessenheiten { get; set; }
        private string _gebetMichaelLatein;
        public string _gebetMichaelDeutsch;

        public string GebetMichaelLatein
        {
            get { return _gebetMichaelLatein; }
            set { _gebetMichaelLatein = value; OnPropertyChanged(); }
        }
        public string GebetMichaelDeutsch
        {
            get { return _gebetMichaelDeutsch; }
            set { _gebetMichaelDeutsch = value; OnPropertyChanged(); }
        }
        

        public GebeteViewModel()
        {
            GebetMichaelDeutsch = 
            "Heiliger Erzengel Michael! Verteidige uns im Kampfe gegen die Bosheiten und die Nachstellungen des Teufels, sei Du unser Schutz!" + Environment.NewLine +
            "Gott gebiete ihm, so bitten wir flehentlich," + Environment.NewLine +
            "Du aber, Fürst der himmlischen Heerscharen, stürze den Satan und die anderen bösen Geister," +
            "die zum Verderben der Seelen in der Welt umherschweifen, in der Kraft Gottes hinab in die Hölle !" + Environment.NewLine +
            "Amen.";

            GebetMichaelLatein = "Sancte Míchael Archángele! Defénde nos in próelio;" + Environment.NewLine +
            "contra nequítiam et insídias diáboli esto praesídium." + Environment.NewLine +
            "Imperet illi Deus, súpplices deprecámur, tuque, Prínceps milítiae caeléstis, Sátanam aliósque spíritus malígnos," + Environment.NewLine +
            "qui ad perditiónem animárum pervagántur in mundo, divína virtúte, in inférnum detrúde." + Environment.NewLine +
            "Amen.";

            GebetLeoXIII = new List<string>()
            {
               "O ruhmreichster Führer der Himmlischen Heerscharen, Heiliger Erzengel Michael, verteidige uns in diesem schrecklichen Krieg wider die Fürstentümer und Mächte, wider die Beherrscher dieser finsteren Welt, wider die bösen Geister. Komme den Menschen zu Hilfe, die Gott nach Seinem Abbild unsterblich erschaffen und um einen sehr teuren Preis aus der Tyrannei des Teufels zurückgekauft hat."
                , "Mit dem Heere der Heiligen Engel schlage heute aufs neue die Schlacht des Herrn, so wie Du einst gegen Luzifer, den Führer der stolzen Rebellen, und gegen seinen Anhang, die abtrünnigen Engel, gestritten hast! Sie hatten weder Kraft, Dir zu widerstehen, noch gab es länger Platz für sie im Himmel. Jene grausame Urschlange, die auch Teufel oder Satan genannt wird, und die ganze Welt verführt, wurde samt Anhang in den Abgrund gestürzt."
                , "Siehe, dieser Urfeind und Menschenmörder von Anbeginn hat wieder Mut gefasst. Verwandelt in einen Lichtengel überfällt er die Erde und wandert mit einer Vielzahl von bösen Geistern herum, um den Namen Gottes und seines Christus auszumerzen und von den, für die Krone des ewigen Ruhmes bestimmten Seelen, Besitz zu ergreifen, sie zu morden und in die ewige Verdammnis zu stoßen. Wie das schmutzigste Abwasser gießt dieser böse Drache das Gift seiner Bosheit, nämlich den Geist der Lüge, der Gottlosigkeit und Lästerung, den Pesthauch der Unreinheit und jegliche Art von Laster und Gemeinheit, auf Menschen verdorbenen Geistes und Herzens aus."
                , "Diese gerissensten Feinde haben die Kirche, die unbefleckte Braut des Lammes, mit Galle und Bitterkeit erfüllt und getränkt, und haben ihre frevlerischen Hände an Ihre Heiligsten Schätze gelegt. Selbst am Heiligen Orte, wo der Sitz des Heiligsten Petrus und der Thron d er Wahrheit zur Erleuchtung der Welt, errichtet wurde, haben sie ihren Thron des grauenvollen Frevels aufgestellt, mit der heimtückischen Absicht, den Hirten zu schlagen, damit sich dann die Schafe in alle Richtungen zerstreuen."
                , "Darum erhebe Dich, o unbesiegbarer Heerführer, komm dem Volk Gottes wider die Anstürme der gefallenen Geister zu Hilfe, und gib ihm den Sieg. Es verehrt Dich als seinen Beschützer und Schutzpatron; Du bringst der Heiligen Kirche den Ruhm, in dem Du sie gegen die bösen Mächte der Hölle verteidigst; Dir hat Gott die Seelen der Menschen anvertraut, die in die ewige Freude eingehen werden. O, bete zum Gott des Friedens, Er möge Satan unter unsere Füße legen, damit er derart besiegt sein möge, dass er nicht mehr länger Menschen in seiner Gefangenschaft halte und der Kirche schade."
                , "Bringe unsere Gebete im Angesicht des Allerhöchsten dar, damit schnell die reiche Barmherzigkeit unseres Herrn auf uns herabsteige und Dir gewähre, den Drachen, die Urschlange, die nichts weiter ist als der Teufel und Satan, zu erschlagen und mit Ketten gefesselt in die Hölle zu werfen, damit er nicht länger die Völker verführe. Amen."
                , "V. Seht das Kreuz des Herrn, seid zerschmettert, ihr feindlichen Mächte." + Environment.NewLine +
                "A. Der Löwe aus dem Stamme Juda hat erobert die Wurzel Davids." + Environment.NewLine +
                "V. Lasse deine Gnaden uns zufließen, o Herr," + Environment.NewLine +
                "A. uns, die wir auf Dich hoffen." + Environment.NewLine +
                "V. O Herr, höre mein Gebet," + Environment.NewLine +
                "A. und laß meinen Ruf zu Dir kommen." + Environment.NewLine +
                "V. Lasset uns beten"
                , "O Gott, der Vater Unseres Herrn Jesus Christus, wir rufen Deinen Heiligsten Namen an, und bettelnd erflehen wir deine Sanftmut, daß durch die Fürbitte Mariens, der immerwährenden Jungfrau und unserer Mutter, und des ruhmreichen Erzengels Michael, Du uns deine Hilfe gegen Satan und alle anderen unreinen Geister, die zum Schaden der menschlichen Rasse und zum Ruin der Seelen herumwandern, gewährest." +
                Environment.NewLine + "Amen."

            };

            LitaneiMichael = new List<string>()
            {
                "Herr, erbarme Dich unser.",
                "Christus, erbarme Dich unser.",
                "Herr, erbarme Dich unser.",
                "Christus, höre uns.",
                "Christus, erhöre uns.",
                "Gott Vater vom Himmel, erbarme Dich unser.",
                "Gott Sohn, Erlöser der Welt, erbarme Dich unser.",
                "Gott Heiliger Geist, erbarme Dich unser.",
                "Heiligste Dreifaltigkeit, ein einiger Gott, erbarme Dich unser.",
                "Heilige Maria, Königin der Engel, bitte für uns.",
                "Heiliger Erzengel Michael, bitte für uns.",
                "Heiliger Michael, voll der Weisheit Gottes, bitte für uns.",
                "Heiliger Michael, du vollkommener Anbeter des Wortes Gottes, bitte für uns.",
                "Heiliger Michael, mit Ruhm und Ehre gekrönt, bitte für uns.",
                "Heiliger Michael, du mächtiger Fürst der himmlischen Heere, bitte für uns.",
                "Heiliger Michael, du Fahnenträger der Heiligsten Dreifaltigkeit, bitte für uns.",
                "Heiliger Michael, du Wächter des Paradieses, bitte für uns.",
                "Heiliger Michael, du Führer und Tröster des Volkes Israel, bitte für uns.",
                "Heiliger Michael, du Glanz und Stütze der streitenden Kirche, bitte für uns.",
                "Heiliger Michael, du Ehre und Freude der triumphierenden Kirche, bitte für uns.",
                "Heiliger Michael, du Licht der Engel, bitte für uns.",
                "Heiliger Michael, du Bollwerk der Rechtgläubigen, bitte für uns.",
                "Heiliger Michael, du Kraft derer, die unter dem Kreuzesbanner kämpfen, bitte für uns.",
                "Heiliger Michael, du Licht und Vertrauen der Seelen in der Sterbestunde, bitte für uns.",
                "Heiliger Michael, du unsere sichere Hilfe, bitte für uns.",
                "Heiliger Michael, unser Helfer in allen Widerwärtigkeiten, bitte für uns.",
                "Heiliger Michael, du Herold des ewigen Urteilspruches, bitte für uns.",
                "Heiliger Michael, du Tröster der Armen Seelen, bitte für uns.",
                "Heiliger Michael, von Gott beauftragt, die Seelen nach dem Tode zu empfangen, bitte für uns.",
                "Heiliger Michael, du unser Fürst, bitte für uns.",
                "Heiliger Michael, du unser Fürsprecher, bitte für uns.",
                "Lamm Gottes, Du nimmst hinweg die Sünden der Welt – verschone uns, o Herr.",
                "Lamm Gottes, Du nimmst hinweg die Sünden der Welt – erhöre uns, o Herr.",
                "Lamm Gottes, Du nimmst hinweg die Sünden der Welt – erbarme Dich unser, o Herr.",
                "V.: Bitte für uns, heiliger Erzengel Michael, du Fürst der Kirche Christi.",
                "A.: Auf dass wir würdig werden Seiner Verheißungen.",
                "Herr Jesus Christus, gib uns Deinen Segen und verleihe uns auf die Fürbitte des heiligen Erzengels Michael jene Weisheit, die uns lehrt, für den Himmel Schätze zu sammeln und die ewigen Güter den zeitlichen vorzuziehen. Der Du lebst und regierst von Ewigkeit zu Ewigkeit. Amen."

            };

            //Besessenheiten = new List<string>()
            //{
            //    "Es ist ganz klar, daß Jesus allen jenen die Macht, Teufel auszutreiben, gegeben hat, die an ihn glauben und in der Kraft seines Namens wirken. In solchen Fällen handelt es sich um private Gebete, die wir als \"Gebete der Befreiung\" bezeichnen."
            //    ,"Demgegenüber ist den Exorzisten eine besondere Fähigkeit gegeben, also jenen Priestern, die von ihrem Bischof ausdrücklich beauftragt sind. Indem sie die entsprechenden Formeln des Rituale verwenden, spenden sie ein Sakramentale, das, im Unterschied zum privaten Gebet, die Vermittlung der Kirche einschließt."
            //    ,"Quelle: Ein Exorzist erzählt, Gabriele Amorth"
            //    ,"Man spricht von teuflischer Besessenheit, wenn eine Person vom Teufel besessen, das heißt von ihm völlig in Besitz genommen ist. "
            //    ,"Andererseits gibt es Geplagtwerden vom Teufel, wenn man den Quälereien und Schikanen des Teufels ausgesetzt ist, wie zum Beispiel im Fall von Pater Pio, der - wie viele Zeugnisse berichten - vom Teufel verprügelt und bis aufs Blut geschlagen wurde, jedoch nie vom Teufel besessen war."
            //    ,""
            //};


        }
        //    private string itemId;
        //    private string text;
        //    private string description;
        //    public string Id { get; set; }

        //    public string Text
        //    {
        //        get => text;
        //        set => SetProperty(ref text, value);
        //    }

        //    public string Description
        //    {
        //        get => description;
        //        set => SetProperty(ref description, value);
        //    }

        //    public string ItemId
        //    {
        //        get
        //        {
        //            return itemId;
        //        }
        //        set
        //        {
        //            itemId = value;
        //            LoadItemId(value);
        //        }
        //    }

        //    public async void LoadItemId(string itemId)
        //    {
        //        try
        //        {
        //            var item = await DataStore.GetItemAsync(itemId);
        //            Id = item.Id;
        //            Text = item.Text;
        //            Description = item.Description;
        //        }
        //        catch (Exception)
        //        {
        //            Debug.WriteLine("Failed to Load Item");
        //        }
        //    }
    }
}
