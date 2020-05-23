using System;
using System.Collections.Generic;
<<<<<<< Updated upstream
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
>>>>>>> Stashed changes
using Xamarin.Forms;
using Microsoft.Azure.Cosmos;

namespace SOFT262_FlashCards
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
<<<<<<< Updated upstream
        public MainPage()
        {
            InitializeComponent();
        }
    }
=======
        public static ObservableCollection<string> items { get; set; }


        public static ObservableCollection<QnA> qnalist { get; set; }
        public static ObservableCollection<string> qstrings { get; set; }
        public static ObservableCollection<string> astrings { get; set; }

        public MainPage()
        {
            QnAaccessors.getQnAlist();
            QnAaccessors.getAs();
            QnAaccessors.getQs();

            qstrings = QnAaccessors.qlist;
            astrings = QnAaccessors.qlist;

            ListView lstView = new ListView();
            lstView.IsPullToRefreshEnabled = true;
            lstView.Refreshing += OnRefresh;
            lstView.ItemSelected += OnSelection;

            lstView.ItemsSource = qstrings;
            //lstView.SelectionMode = ListViewSelectionMode.None;
          

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children =
                {
                    new Label { Text = "Flashcards", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
                    lstView
                }
            };
        }



        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            DisplayAlert("Item Selected", e.SelectedItemIndex.ToString(), "Ok");
        }

        void OnRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            //put your refreshing logic here
            var itemList = qstrings.Reverse().ToList();
            qstrings.Clear();
            foreach (var s in itemList)
            {
                qstrings.Add(s);
            }
            //make sure to end the refresh state
            list.IsRefreshing = false;
        }

        void OnMore(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            //Do something here... e.g. Navigation.pushAsync(new specialPage(item.commandParameter));
            //page.DisplayAlert("More Context Action", item.CommandParameter + " more context action", 	"OK");
        }

        void OnDelete(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            MainPage.items.Remove(item.CommandParameter.ToString());
        }

    }



  

    
>>>>>>> Stashed changes
}
