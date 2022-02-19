using Exam.Data;
using Exam.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Exam
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = txtName.Text,
                Phone = txtPhone.Text
            };
            ContentDialog contentDialog = new ContentDialog();
            if (Data.DatabaseInitialize.SaveTables(contact)){
                contentDialog.Title = "Action success !!";
                contentDialog.Content = "Save success !!";
            }
            else
            {
                contentDialog.Title = "Action Failed !!";
                contentDialog.Content = "Save Failed !!";
            }
            contentDialog.CloseButtonText = "Okie";
            await contentDialog.ShowAsync();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            DatabaseInitialize data = new DatabaseInitialize();
            Contact contact = data.GetContact(txtSearch.Text);
            if(contact == null)
            {
                result.Text = "Contact not found";
            }
            else
            {
                result.Text = contact.ToString();
            }
        }
    }
}
