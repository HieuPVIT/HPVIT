using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using LocalJson1.Models;
using Newtonsoft.Json;



namespace LocalJson1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<RootObject> _rootobj;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("LocalJson1.herosima.json");


            using (var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();

                List<RootObject> mylist = JsonConvert.DeserializeObject<List<RootObject>>(json);
                _rootobj = new ObservableCollection<RootObject>(mylist);
                MyListView.ItemsSource = _rootobj;
            }
        }
    }
}
