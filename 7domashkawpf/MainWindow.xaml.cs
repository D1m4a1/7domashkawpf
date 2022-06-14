using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;
using _7domashkawpf.serviceinfo;

namespace _7domashkawpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string Path = $"{Environment.CurrentDirectory}\\workerlist.json";
        private BindingList<AllINfoWorkers> _allINfoWorkers;
        private ServiceInfo _serviceInfo;
        public MainWindow()
        {
            InitializeComponent();
       
           
        }

        private void workerlist_Loaded(object sender, RoutedEventArgs e)
        {
            _serviceInfo = new ServiceInfo(Path);
            try
            {
                _allINfoWorkers = _serviceInfo.LoadList();
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message);
                this.Close();
            }
           

            workerlist.ItemsSource = _allINfoWorkers;
            _allINfoWorkers.ListChanged += _allINfoWorkers_ListChanged;
        }

        private void _allINfoWorkers_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemDeleted||e.ListChangedType==ListChangedType.ItemChanged||e.ListChangedType==ListChangedType.ItemAdded)
            {
                try
                {
                    _serviceInfo.SaveList(sender);
                }
                catch (Exception exeption)
                {
                    MessageBox.Show(exeption.Message);
                    this.Close();
                }
            }
           
        }

        private void workerlist_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}