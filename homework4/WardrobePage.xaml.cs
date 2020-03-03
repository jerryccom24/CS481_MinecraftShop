using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace homework4
{
    public partial class WardrobePage : ContentPage
    {
        private Wardrobe wardrobe;

        public WardrobePage()
        {
            InitializeComponent();
        }

        public WardrobePage(Wardrobe wardrobe)
        {
            this.wardrobe = wardrobe;
            InitializeComponent();
            BindingContext = this;
            WardrobeList.ItemsSource = this.wardrobe.myWardrobe;
        }
    }
}
