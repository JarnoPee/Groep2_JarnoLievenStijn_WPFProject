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
using Artmin_DAL;

namespace Artmin
{
    /// <summary>
    /// Interaction logic for NotitieOverzicht.xaml
    /// </summary>
    public partial class NotitieOverzicht : Window
    {
        public NotitieOverzicht()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblNaamEvenement.Content = $"Naam Evenement NOG INVULLEN";
            List<Notitie> notities = DatabaseOperations.OphalenNotitiesViaEventId(1); // NOG AANPASSEN NAAR INGELADEN EVENT
            datagridNotitieEvenement.ItemsSource = notities;
        }
    }
}
