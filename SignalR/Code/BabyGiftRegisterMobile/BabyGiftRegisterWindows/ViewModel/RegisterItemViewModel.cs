using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BabyGiftRegisterLibrary.Model;

namespace BabyGiftRegisterWindows.ViewModel
{
    public class RegisterItemViewModel : INotifyPropertyChanged
    {
        private readonly RegisterItem _registerItem;

        public RegisterItemViewModel(RegisterItem registerItem)
        {
            _registerItem = registerItem;
        }

        public int Id
        {
            get { return _registerItem.Id; }
        }

        public string Name
        {
            get { return _registerItem.Name; }
            set
            {
                if (value != _registerItem.Name)
                {
                    _registerItem.Name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool ItemSold
        {
            get { return _registerItem.Sold; }
            set
            {
                if (value != _registerItem.Sold)
                {
                    _registerItem.Sold = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Price
        {
            get { return _registerItem.Price; }
        }

        public bool Sold
        {
            get { return _registerItem.Sold; }
        }

        public string ButtonBackground
        {
            get { return _registerItem.Sold ? "#E68F8D" : "#FF428BCA"; }
        }

        public string ButtonContent
        {
            get { return _registerItem.Sold ? "SOLD!" : "Buy"; }
        }

        public string Image
        {
            get { return "Images/" + _registerItem.ImageName + ".png"; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}