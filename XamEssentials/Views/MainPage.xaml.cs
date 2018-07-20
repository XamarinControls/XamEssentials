using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamEssentials.ViewModels;

namespace XamEssentials.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
