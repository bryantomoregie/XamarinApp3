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
    public partial class ClientDetailPage : ContentPage
    {
        Client selectedClient;
        public ClientDetailPage(Client selectedClient)
        {
            InitializeComponent();
            this.selectedClient = selectedClient;
            nameLabel.Text = selectedClient.Name;
            emailLabel.Text = selectedClient.Email;
            phoneLabel.Text = selectedClient.Phone;
            addressLabel.Text = selectedClient.Address;

        }

        private void updateButton_Clicked(object sender, EventArgs e)
        {
            selectedClient.Name = nameLabel.Text;
            selectedClient.Email = emailLabel.Text;
            selectedClient.Phone = phoneLabel.Text;
            selectedClient.Address = addressLabel.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Client>();
                int rows = conn.Update(selectedClient);


                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience successfully updated", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to be updated", "Ok");
                }
            }


        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Client>();
                int rows = conn.Delete(selectedClient);


                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience successfully deleted", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to be deleted", "Ok");
                }
            }
        }
    }
}