using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using Xamarin.Essentials;

namespace ListOfContacts
{
    class MainVM
    {
        public ObservableCollection<Contact> CollectionOfContacts { get; set; }

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
