using ExamSQLite_UWP.Entity;
using ExamSQLite_UWP.Models;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ExamSQLite_UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchContact : Page
    {
        private ContactModel contactModel;
        public SearchContact()
        {
            this.InitializeComponent();
            this.contactModel = new ContactModel();
        }

        private void ButtonLogin_OnClick(object sender, RoutedEventArgs e)
        {
            var contact = new Contact
            {
                Name = this.Name.Text,
                PhoneNumber = this.Phone.Text,

            };
            contactModel.Insert(contact);
        }
    }
}
