using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
//------------------------------------------------------------------------------------------------
// Jerry Compton
// Homework 4
//
//This program will display the 4 shopping wardrobes, Hats, Shirts, Pants, and Shoes.
//The user will be able to navigate into each category sub page and view the WardrobeItems for sale in each.
//Then the user can swipe utilizing the context menu in order to add an item to their cart.
//Then, they can navigate back to the MainPage where they can Pull Down (Refresh) to update their
//total price of their shopping cart while shopping.

namespace homework4
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        //Load the Wardrobe Items for Shirt
        public WardrobeItem[] shirtItems = {
            new WardrobeItem{name="lvl.1 Shirt", image="shirt2.png", info="Capable of withstanding 5 dmg. Good luck!",price=20.99},
            new WardrobeItem{name="lvl.2 Shirt", image="shirt1.png", info="Capable of withstanding 50 dmg. Not too bad.",price=50.99 },
            new WardrobeItem{name="lvl.3 Shirt", image="shirt3.png", info="Capable of withstanding 100 dmg. The best.",price=100.99 }


        };
        //Load the Wardrobe Items for Pants
        public WardrobeItem[] pantItems = {
            new WardrobeItem{name="lvl.1 Pants", image="pants2.png", info="Capable of withstanding 5 dmg. Also, they do not fit well!",price=20.99 },
            new WardrobeItem{name="lvl.2 Pants", image="pants1.png", info="Capable of withstanding 50 dmg. Not too bad.",price=50.99 },
            new WardrobeItem{name="lvl.3 Pants", image="pants3.png", info="Capable of withstanding 100 dmg. One size fits all.",price=100.99 }


        };
        //Load the Wardrobe Items for Hats
        public WardrobeItem[] hatItems = {
            new WardrobeItem{name="lvl.1 Hat", image="hat2.png", info="Capable of withstanding a pebble to the head.",price=20.99 },
            new WardrobeItem{name="lvl.2 Hat", image="hat1.png", info="Capable of withstanding a good sized rock to the head.",price=50.99 },
            new WardrobeItem{name="lvl.3 Hat", image="hat3.png", info="Capable of withstanding 10 good sized rocks to the head.",price=100.99 }


        };
        //Load the Wardrobe Items for Shoes
        public WardrobeItem[] shoeItems = {
            new WardrobeItem{name="lvl.1 Shoes", image="shoe2.png", info="Shoelaces are not included.",price=20.99 },
            new WardrobeItem{name="lvl.2 Shoes", image="shoe1.png", info="You will run very fast with these.",price=50.99 },
            new WardrobeItem{name="lvl.3 Shoes", image="shoe3.png", info="Personally signed by Usain Bolt.",price=100.99 }


        };


        ObservableCollection<Wardrobe> listOfWardrobes1;

        public MainPage()
        {
            InitializeComponent();
            Wardrobe[] wardrobes = Setup(); //This will return our array of wardrobes ( Hat, Shirt, Pants, Shoes )
            BindingContext = this;
            ObservableCollection<Wardrobe> listOfWardrobes = new ObservableCollection<Wardrobe>(wardrobes); //Convert to Obs Coll
            listOfWardrobes1 = listOfWardrobes;

            WardrobeList.ItemsSource = listOfWardrobes1;// Set to our Item Source
            
            

        }

       
        //This function will initlialize everything
        public Wardrobe[] Setup()
        {
            ObservableCollection<WardrobeItem> sItems = new ObservableCollection<WardrobeItem>();
            for (int i = 0; i < 3; i++)
            {
                sItems.Add(shirtItems[i]);//Shirts
            }

            ObservableCollection<WardrobeItem> pItems = new ObservableCollection<WardrobeItem>();
            for (int i = 0; i < 3; i++)
            {
                pItems.Add(pantItems[i]);//Pants
            }

            ObservableCollection<WardrobeItem> hItems = new ObservableCollection<WardrobeItem>();
            for (int i = 0; i < 3; i++)
            {
                hItems.Add(hatItems[i]);//Hats
            }

            ObservableCollection<WardrobeItem> shItems = new ObservableCollection<WardrobeItem>();
            for (int i = 0; i < 3; i++)
            {
                shItems.Add(shoeItems[i]);//Shoes
            }

            Wardrobe[] wardrobes =
            {
                new Wardrobe(1,"Hats", "Browse Our Entire Hat Catalog...","hat.png",0,hItems),
                new Wardrobe(2,"Shirts","Browse Our Entire Shirt Catalog...","tshirt.png",0,sItems),
                new Wardrobe(3,"Pants", "Browse Our Entire Pants Catalog...","pants.png",0,pItems),
                new Wardrobe(4,"Shoes", "Browse Our Entire Shoes Catalog...","shoe.png",0,shItems)

            };

            return wardrobes; // Return our array of wardrobes with all the objects set

            
        }

        //Push our new page with the Wardrobe that was selected passed as a parameter
        async void WardrobeList_ItemTapped(object sender, ItemTappedEventArgs args)
        {
            Wardrobe w = args.Item as Wardrobe;
            
            await Navigation.PushAsync(new WardrobePage(w));
        }

        //Pulling the refresher will update the total price as you shop
        public void WardrobeList_Refreshing(object sender, EventArgs args)
        {
            double refreshedTotal = 0;

            for(int i = 0; i < 4; i++)
            {
                refreshedTotal += listOfWardrobes1[i].totalPrice;

            }

            this.totalBox.Text = refreshedTotal.ToString();

            WardrobeList.IsRefreshing = false;
        }







    }
}
