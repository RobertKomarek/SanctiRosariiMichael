using ErzengelMichael.Models;
using ErzengelMichael.ViewModels;
using ErzengelMichael.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ErzengelMichael.Views
{
    public partial class VersprechungenPage : TabbedPage
    {
        public VersprechungenPage()
        {
            InitializeComponent();
        }
        //VersprechungenViewModel _viewModel;

        //public VersprechungenPage()
        //{
        //    InitializeComponent();
        //    BindingContext = _viewModel = new VersprechungenViewModel();
        //}

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    _viewModel.OnAppearing();
        //}
    }
}