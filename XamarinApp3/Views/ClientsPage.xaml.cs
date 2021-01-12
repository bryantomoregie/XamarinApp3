using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp3.Models;

namespace XamarinApp3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Clients : ContentPage
    {
        public Clients()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Client>();
                var clients = conn.Table<Client>().ToList();
                clientListView.ItemsSource = clients;
            
            }
               
        }

        private void clientListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedClient = clientListView.SelectedItem as Client;
            if (selectedClient != null)
            {
                Navigation.PushAsync(new ClientDetailPage(selectedClient));
            }
        }
    }
}