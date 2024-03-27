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

namespace Abbigliamento_Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Utente(object sender, RoutedEventArgs e)
        {
            creazioneUtente o = new creazioneUtente();
            o.Show();
            this.Close();
        }
        private void Button_Categoria(object sender, RoutedEventArgs e)
        {
            CreazioneCat o = new CreazioneCat();
            o.Show();
            this.Close();
        }
        private void Button_Prodotto(object sender, RoutedEventArgs e)
        {
            ProdottoWindow o = new ProdottoWindow();
            o.Show();
            this.Close();
        }
    }
}