using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace homework4
{
    public partial class WardrobePage : ContentPage
    {
        private Wardrobe wardrobe;//Our Selected Wardrobe
        double total = 0;

        public WardrobePage()
        {
            InitializeComponent();
        }

        
        public WardrobePage(Wardrobe wardrobe)
        {
            this.wardrobe = wardrobe;
            InitializeComponent();
            BindingContext = this;
            WardrobeList.ItemsSource = this.wardrobe.myWardrobe;//Set ItemSource
        }

        public void WardrobeList_ItemTapped(object sender, EventArgs e)
        {
            MenuItem w = (MenuItem)sender;
            string price = w.CommandParameter.ToString();
            total += Convert.ToDouble(price);

            wardrobe.UpdateTotal(total);

            DisplayAlert("Item Added to Cart","Price: "+ price +" ","OK");
            

        }

        
    }
}
