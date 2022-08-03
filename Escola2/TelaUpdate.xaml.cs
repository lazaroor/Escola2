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

namespace Escola2
{
    /// <summary>
    /// Lógica interna para TelaUpdate.xaml
    /// </summary>
    public partial class TelaUpdate : Window
    {
        public TelaUpdate()
        {
            InitializeComponent();
            ComboSerie.ItemsSource = Enum.GetValues(typeof(Ano)).Cast<Ano>();
        }
        public void btnSalvar(object sender, RoutedEventArgs e)
        {
            // criar validação para o texto e alterar valor do dialogresult com base nisso
            // alterar para combobox o textbox da serie
            // MessageBox.Show(serie.Text);
            DialogResult = true;
            // serie.Items.Add("1");
        }
    }
}
