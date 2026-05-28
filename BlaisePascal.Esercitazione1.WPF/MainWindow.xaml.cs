using BlaisePascal.Esercitazione1.Domain;
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
    public partial class MainWindow : Window
    {
        private CD? mioCD;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAggiungi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Author autore = new(txtNomeArte.Text, txtNome.Text, txtCognome.Text);

                Brano brano = new Brano(txtTitoloBrano.Text, autore, int.Parse(txtDurata.Text));
               
                mioCD = new CD(txtTitoloCD.Text, autore.ArtisticName);
                mioCD.Brani.Add(brano);

                lstBrani.Items.Add(brano.ToString());

                PuliziaCampi();
            }
            catch (Exception)
            {
                MessageBox.Show("Errore: Inserisci dati validi (controlla la durata).");
            }
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            if (mioCD == null)
            {
                MessageBox.Show("Nessun CD creato! Aggiungi un brano per testare.");
                return;
            }
            if (mioCD.Brani.Count == 0)
            {
                MessageBox.Show("Il CD è vuoto! Aggiungi un brano per testare.");
                return;
            }

            string report = $"--- TEST CD ---\n" +
                            $"Titolo: {mioCD.GetTitolo()}\n" +
                            $"Numero tracce: {mioCD.Brani.Count}\n" +
                            $"Primo Brano: {mioCD.Brani[0].GetTitle()}\n" +
                            $"Autore: {mioCD.Brani[0].GetAuthor().ArtisticName}";

            MessageBox.Show(report, "Risultato Test Funzionalità");
        }

        private void PuliziaCampi()
        {
            txtTitoloBrano.Clear();
            txtDurata.Clear();
        }
    }
}