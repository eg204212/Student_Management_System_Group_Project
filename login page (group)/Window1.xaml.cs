using SQL_Group_4115_4212.NewFolder;
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
using System.Windows.Shapes;

namespace SQL_Group_4115_4212
{
    public partial class Window1 : Window
    {
        public List<crudop> Databasecrudops { get; private set; }

        public Window1()
        {
            InitializeComponent();
            DataContext = this; // Set the data context of the window to itself
            Read(); // Populate the ListView when the window is loaded
        }

        public void Create()
        {
            using (Window1DataContext context = new Window1DataContext())
            {
                var selectedcrudop = ItemList.SelectedItem as crudop;
                var StuId = selectedcrudop?.StuId;
                var firstname = selectedcrudop?.FirstName;
                var lastname = selectedcrudop?.LastName;
                var address = selectedcrudop?.Address;

                if (!string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(address))
                {
                    context.crudops.Add(new crudop() { StuId = StuId, FirstName = firstname, LastName = lastname, Address = address });
                    context.SaveChanges();
                }
            }
        }

        public void Read()
        {
            using (Window1DataContext context = new Window1DataContext())
            {
                Databasecrudops = context.crudops.ToList();
                ItemList.ItemsSource = Databasecrudops;
            }
        }

        public void Update()
        {
            using (Window1DataContext context = new Window1DataContext())
            {
                crudop selectedcrudop = ItemList.SelectedItem as crudop;

                var name = selectedcrudop?.FirstName;
                var address = selectedcrudop?.Address;

                if (selectedcrudop != null && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(address))
                {
                    crudop crudop = context.crudops.Find(selectedcrudop.StuId);
                    crudop.FirstName = name;
                    crudop.LastName = selectedcrudop?.LastName;
                    crudop.Address = address;

                    context.SaveChanges();
                }
            }
        }

        public void Delete()
        {
            using (Window1DataContext context = new Window1DataContext())
            {
                crudop selectedcrudop = ItemList.SelectedItem as crudop;

                if (selectedcrudop != null)
                {
                    crudop crudop = context.crudops.Single(x => x.StuId == selectedcrudop.StuId);

                    context.Remove(crudop);
                    context.SaveChanges();
                }
            }
        }

        private void crtbtn_Click(object sender, RoutedEventArgs e)
        {
            Create();
            Read(); // Refresh the ListView after creating a new record
        }

        private void RdBtn_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void DltBtn_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            Read(); // Refresh the ListView after deleting a record
        }

        private void UpdatBtn_Click(object sender, RoutedEventArgs e)
        {
            Update();
            Read(); // Refresh the ListView after updating a record
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ItemList.ItemsSource = null; // Clear the ListView items source
        }
    }
}
