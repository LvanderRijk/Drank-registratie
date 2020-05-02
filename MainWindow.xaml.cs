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
using System.Windows.Shapes;

namespace OverzichtDranken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        restaurantdbDataContext db = new restaurantdbDataContext();
        public MainWindow()
        {
            InitializeComponent();

            dgDranken.ItemsSource = db.drankens.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            dranken addItem = new dranken();
            addItem.NAAM = txtName.Text;
            addItem.SOORT = txtSoort.Text;
            addItem.PRIJS = Convert.ToDecimal(txtPrice.Text);

            db.drankens.InsertOnSubmit(addItem);
            db.SubmitChanges();

            dgDranken.ItemsSource = db.drankens.ToList();

        }

        private void btnZoek_Click(object sender, RoutedEventArgs e)
        {
            var lijst = (from dranken in db.drankens
                         where dranken.ID == Convert.ToInt16(txtZoek.Text)
                         select dranken).ToList();

            dgDranken.ItemsSource = lijst;
        }
    }
}
