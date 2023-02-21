using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ListOfContacts
{
    class MainVM
    {
        public ObservableCollection<Contact> CollectionOfContacts { get; set; }

        private ICommand _phoneCallCommand;

        public ICommand PhoneCallCommand
        {
            get 
            {
                if (_phoneCallCommand == null)
                    _phoneCallCommand = new Command<Contact>(
                        o =>
                        {

                        });
                return _phoneCallCommand; 
            }
        }


        public MainVM() 
        {
            try
            {
                Contacts.PickContactAsync();    
                CollectionOfContacts = new ObservableCollection<Contact>();
                var contacts = Contacts.GetAllAsync().Result;
                if (contacts == null)
                    return;
                foreach (var item in contacts)
                {
                    CollectionOfContacts.Add(item);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
