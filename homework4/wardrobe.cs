using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace homework4
{
    public class Wardrobe
    {
        public int number { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string image { get; set; }

        public ObservableCollection<WardrobeItem> myWardrobe { get; set; }


        public Wardrobe(int n, string t, string d,string i,ObservableCollection<WardrobeItem> w)
        {
            number = n;
            type = t;
            description = d;
            image = i;
            myWardrobe = w;


        }

    }
}
