using Admin_Managing_Program.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Managing_Program.ViewModel
{
    class Order_ViewModel : INotifyPropertyChanged
    {
        static ObservableCollection<_Order> orders = new ObservableCollection<_Order>();

        public static ObservableCollection<_Order> Orders
        {
            get { return orders; }
            set { orders = value; new Order_ViewModel().OnPropertyChanged("Orders"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            if (Orders.Count != 0)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }
        }

    }
}
