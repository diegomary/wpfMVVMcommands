using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ControllsMVVM.ViewModel;
using ControllsMVVM.Model;

namespace ControllsMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        private PersonListViewModel pv;
        private CollectionViewSource cv;


        public MainWindow()
        { 
            InitializeComponent();
            pv = new PersonListViewModel(new DataAccess.PersonRespository());
            cv = new CollectionViewSource();
            cv.Source = pv.AllPersons;            
            cv.SortDescriptions.Add(new System.ComponentModel.SortDescription("LastName", System.ComponentModel.ListSortDirection.Ascending));                  
            ListPersons.ItemsSource = cv.View;     
            btnremove.DataContext = pv;
            btnadd.DataContext = pv;                   

        }
      

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            btnadd.CommandParameter = new Person(txtfirstname.Text,txtlastname.Text);
        }

       



    }
}
