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

namespace TestMat
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Enregistrement> enregistrements = new List<Enregistrement>();

        public MainWindow()
        {
            InitializeComponent();

            InitEnregistrements();
        }

        private void InitEnregistrements()
        {
            enregistrements.Add(new Enregistrement { libelle = "Libellé 01", isAnalytics = true, isGed = false });
            enregistrements.Add(new Enregistrement { libelle = "Libellé 02", isAnalytics = false, isGed = true });
            enregistrements.Add(new Enregistrement { libelle = "Libellé 03", isAnalytics = true, isGed = true });
            enregistrements.Add(new Enregistrement { libelle = "Libellé 04", isAnalytics = false, isGed = false });
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            StackPanel dtRowEntete = new StackPanel();
            dtRowEntete.Orientation = Orientation.Horizontal;

            // On crée la ligne d'entête :p
            TextBlock col1 = new TextBlock();
            col1.Text = "Libellé";
            col1.Width = 100;

            TextBlock col2 = new TextBlock();
            col2.Text = "GED";
            col2.Width = 100;

            TextBlock col3 = new TextBlock();
            col3.Text = "Analytics";
            col3.Width = 100;

            // On colle les 3 colonnes dans la ligne
            dtRowEntete.Children.Add(col1);
            dtRowEntete.Children.Add(col2);
            dtRowEntete.Children.Add(col3);

            // On colle la ligne dans le "faux" dt :p
            dt.Children.Add(dtRowEntete);

            // Ensuite on gère tous les enregistrements
            foreach (Enregistrement enregistrement in enregistrements)
            {
                StackPanel dtRow = new StackPanel();
                dtRow.Orientation = Orientation.Horizontal;

                // On crée les éléments d'une ligne ! (libelle, is analytics, isGed)
                TextBlock tb = new TextBlock();
                tb.Text = enregistrement.libelle;
                tb.Width = 100;

                CheckBox cbAnalytics = new CheckBox();
                cbAnalytics.Content = enregistrement.isAnalytics.ToString(); // Affiche le True/False en tant que texte, ça peut se transformer...
                cbAnalytics.IsChecked = enregistrement.isAnalytics;
                cbAnalytics.Width = 100;

                // Fonction liée à "je coche"
                cbAnalytics.Checked += (o, args) =>
                {
                    MessageBox.Show($"Vous avez coché 'Analytics' de la ligne {enregistrement.libelle}");
                    // On peut mettre la requête Update !!
                };

                // Fonction liée à "je décoche"
                cbAnalytics.Unchecked += (o, args) =>
                {
                    MessageBox.Show($"Vous avez décoché 'Analytics' de la ligne {enregistrement.libelle}");
                    // On peut mettre la requête Update !!
                };

                CheckBox cbGed = new CheckBox();
                cbGed.Content = enregistrement.isGed.ToString();
                cbGed.IsChecked = enregistrement.isGed;
                cbGed.Width = 100;

                cbGed.Checked += (o, args) =>
                {
                    MessageBox.Show($"Vous avez coché 'Ged' de la ligne {enregistrement.libelle}");
                    // On peut mettre la requête Update !!
                };

                cbGed.Unchecked += (o, args) =>
                {
                    MessageBox.Show($"Vous avez décoché 'Ged' de la ligne {enregistrement.libelle}");
                    // On peut mettre la requête Update !!
                };


                dtRow.Children.Add(tb);
                dtRow.Children.Add(cbGed);
                dtRow.Children.Add(cbAnalytics);

                dt.Children.Add(dtRow);
            }
        }
    }
}
