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
    /// Interaction logic for Aanpassen.xaml
    /// </summary>
    public partial class Aanpassen : UserControl
    {
        restaurantdbDataContext db = new restaurantdbDataContext();
        public Aanpassen()
        {
            InitializeComponent();
            dgDranken.ItemsSource = db.drankens.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dranken deDrank = (dranken)dgDranken.SelectedItem;
            var hetProduct = (from dranken in db.drankens
                              where dranken.ID == deDrank.ID
                              select dranken).Single();

            hetProduct.NAAM = txtName.Text;
            hetProduct.SOORT = txtCat.Text;
            hetProduct.PRIJS = Convert.ToDecimal(txtPrice.Text);

            db.SubmitChanges();
           
        }

        private void dgDranken_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dranken deDrank = (dranken)dgDranken.SelectedItem;

            txtID.Text = Convert.ToString(deDrank.ID);
            txtName.Text = deDrank.NAAM;
            txtCat.Text = deDrank.SOORT;
            txtPrice.Text = Convert.ToString(deDrank.PRIJS);
        }

        private void dgDranken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
