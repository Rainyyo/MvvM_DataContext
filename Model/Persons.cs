using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Model
{
    public class Persons:ViewModelBase
    {
		private int id;

		public int ID
		{
			get { return id; }
			set 
			{ 
				id = value;
				RaisePropertyChanged(nameof(id));
			}
		}

		private string name;

		public string Name
		{
			get { return name; }
			set
			{
                name = value;
				RaisePropertyChanged("name");
			}
		}


	}
}
