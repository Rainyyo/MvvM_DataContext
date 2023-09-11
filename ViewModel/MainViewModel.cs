using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using WpfApp1.Db;
using WpfApp1.Model;
using WpfApp1.View;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
            LocalDb = new LocalDb();
            QueryCommand = new RelayCommand(Query);
            ResetCommand = new RelayCommand(() =>
            {
                Search = string.Empty;
                this.Query();
            });
            EditCommand = new RelayCommand<int>(t => Edit(t));
            DelCommand = new RelayCommand<int>(t => Del(t));
            AddCommand = new RelayCommand(Add);
        }
        LocalDb LocalDb;
        private ObservableCollection<Persons> gridModelList;

        public ObservableCollection<Persons> GridModelList
        {
            get { return gridModelList; }
            set { gridModelList = value; RaisePropertyChanged(); }
        }
        private string search = string.Empty;

        public string Search
        {
            get { return search; }
            set { search = value; RaisePropertyChanged(); }
        }
        #region Command
        public RelayCommand QueryCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand<int> EditCommand { get; set; }
        public RelayCommand<int> DelCommand { get; set; }
        #endregion
        public void Query()
        {
            var model = LocalDb.GetPersonsByName(Search);
            GridModelList = new ObservableCollection<Persons>();
            if (model != null)
            {
                model.ForEach(arg =>
                {
                    gridModelList.Add(arg);
                });
            }
        }
        public void Edit(int id)
        {
            var model = LocalDb.GetPersonsByID(id);
            if (model != null)
            {
                UserView view = new UserView(model);
                var r = view.ShowDialog();
                if (r.Value)
                {
                    var newmodel = gridModelList.FirstOrDefault(t => t.ID == model.ID);
                    if (newmodel != null)
                    {
                        newmodel.Name = model.Name;
                    }
                }
            }
        }

        public void Add()
        {
            Persons persons = new Persons();

            UserView view = new UserView(persons);
            var r = view.ShowDialog();
            
            if (r.Value)
            {
                persons.ID=gridModelList.Max(t => t.ID)+1;
                LocalDb.AddPerson(persons);
                this.Query();               
            }
        }
        public void Del(int id)
        {
            var model = LocalDb.GetPersonsByID(id);
            if (model != null)
            {
                var r = MessageBox.Show($"确认删除当前用户：{model.Name}?", "操作提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (r == MessageBoxResult.OK)
                {
                    LocalDb.DelPerson(model.ID);
                }
                this.Query();
            }

        }
    }
}