using ErzengelMichael.ViewModels;
using ErzengelMichael.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ErzengelMichael
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GebetePage), typeof(GebetePage));
            Routing.RegisterRoute(nameof(EinstellungenPage), typeof(EinstellungenPage));
            Routing.RegisterRoute(nameof(RosenkranzPage), typeof(RosenkranzPage));
            Routing.RegisterRoute(nameof(VersprechungenPage), typeof(VersprechungenPage));
        }

    }
}
