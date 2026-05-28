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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Proprietà per il Binding
        public Brano NuovoBrano { get; set; }
        public CD MioCD { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            NuovoBrano = new Brano();
            MioCD = new CD();

            // Impostiamo il DataContext per far funzionare i Binding ({Binding ...})
            this.DataContext = this;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NuovoBrano.Titolo)) return;

            // Creiamo una copia del brano per aggiungerlo alla lista
            Brano branoDaAggiungere = new Brano
            {
                Titolo = NuovoBrano.Titolo,
                Durata = NuovoBrano.Durata,
                Artista = new Autore
                {
                    NomeArte = NuovoBrano.Artista.NomeArte,
                    NomeReale = NuovoBrano.Artista.NomeReale,
                    Cognome = NuovoBrano.Artista.Cognome
                }
            };

            MioCD.ListaBrani.Add(branoDaAggiungere);
            lblStatus.Text = $"Brano '{branoDaAggiungere.Titolo}' aggiunto con successo.";

            // Reset campi input
            NuovoBrano.Titolo = "";
            NuovoBrano.Durata = "";
            NuovoBrano.Artista.NomeArte = "";
            NuovoBrano.Artista.NomeReale = "";
            NuovoBrano.Artista.Cognome = "";
        }

        private void BtnCreaCD_Click(object sender, RoutedEventArgs e)
        {
            MioCD.Titolo = txtTitoloCD.Text;
            lblStatus.Text = $"CD '{MioCD.Titolo}' aggiornato.";
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            string report = $"TEST CD: {MioCD.Titolo}\n" +
                           $"Numero Brani: {MioCD.ListaBrani.Count}\n" +
                           "--------------------------\n";

            foreach (var b in MioCD.ListaBrani)
                report += $"- {b.ToString()}\n";

            MessageBox.Show(report, "Risultato Test Funzionalità");
        }
    }
}