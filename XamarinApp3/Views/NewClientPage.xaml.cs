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
    public partial class NewClientPage : ContentPage
    {
        public NewClientPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Client client = new Client() //Creating a new post object with the values from the XAML
            {
                Name = clientName.Text,
                Email = clientEmail.Text,
                Phone = clientPhone.Text,
                Address = clientAddress.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Client>();
                int rows = conn.Insert(client);


                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience successfully inserted", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
                }
            }
 
        }
    }
}