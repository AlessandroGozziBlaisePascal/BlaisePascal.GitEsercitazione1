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

namespace BlaisePascal.Esercitazione1.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public partial class MainWindow : Window
        {
            private CD mioCD;

            public MainWindow()
            {
                InitializeComponent();
                mioCD = new CD();
            }

            // Funzionalità Oggetto Brano
            private void BtnAggiungiBrano_Click(object sender, RoutedEventArgs e)
            {
                if (!string.IsNullOrWhiteSpace(txtTitoloBrano.Text))
                {
                    Brano nuovoBrano = new Brano
                    {
                        Titolo = txtTitoloBrano.Text,
                        Durata = txtDurataBrano.Text
                    };

                    mioCD.Brani.Add(nuovoBrano);
                    AggiornaInterfaccia();

                    txtTitoloBrano.Clear();
                    txtDurataBrano.Clear();
                    lblStatus.Text = $"Oggetto Brano '{nuovoBrano.Titolo}' creato e aggiunto.";
                }
            }

            // Funzionalità Oggetto CD
            private void BtnCreaCD_Click(object sender, RoutedEventArgs e)
            {
                mioCD.TitoloCD = txtTitoloCD.Text;
                lblStatus.Text = $"CD rinominato in: {mioCD.TitoloCD}";
            }

            private void BtnTest_Click(object sender, RoutedEventArgs e)
            {
                if (mioCD.Brani.Count > 0)
                {
                    MessageBox.Show(mioCD.InfoCD, "Test Funzionalità CD");
                }
                else
                {
                    MessageBox.Show("Il CD è vuoto! Aggiungi dei brani prima.", "Errore Test");
                }
            }

            private void AggiornaInterfaccia()
            {
                lstBraniCD.ItemsSource = null;
                lstBraniCD.ItemsSource = mioCD.Brani;
            }
        }
    }
}