using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace homework4
{
    public class Wardrobe
    {
        public int number { get; set; } //The number id of the wardrobe
        public string type { get; set; } //The type of wardrobe (e.g.Shirts, Shoes, Pants, Hats)
        public string description { get; set; } //description
        public string image { get; set; } //image of the type
        public double totalPrice { get; set; } //The total Price of all the items the user has added to their cart in this wardrobe
        public ObservableCollection<WardrobeItem> myWardrobe { get; set; } //The Collection of Wardrobe Items


        public Wardrobe(int n, string t, string d,string i,double p,ObservableCollection<WardrobeItem> w)
        {
            number = n;
            type = t;
            description = d;
            image = i;
            myWardrobe = w;
            totalPrice = p;

        }

        public void UpdateTotal(double n)
        {
            totalPrice += n;//Update the total price of all the items the user has added to their cart
        }

    }
}
