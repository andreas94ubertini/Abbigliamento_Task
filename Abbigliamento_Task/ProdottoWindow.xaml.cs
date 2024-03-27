using Abbigliamento_Task.DAL;
using Abbigliamento_Task.Models;
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

namespace Abbigliamento_Task
{
    /// <summary>
    /// Logica di interazione per ProdottoWindow.xaml
    /// </summary>
    public partial class ProdottoWindow : Window
    {
        public ProdottoWindow()
        {
            InitializeComponent();
            Lista.ItemsSource = categoriaDAL.getIstanza().GetAll();
        }
        private void btnSalvaProdotto_Click(object sender, RoutedEventArgs e)
        {
            Button? b = sender as Button;
            var cat = Lista.SelectedValue;
            Categorium c = cat as Categorium;
            Prodotto p = new Prodotto
            {
                Marca = this.tbMarca.Text,
                Modello = this.tbModello.Text,
                ImgUno = this.tbImgUno.Text,
                ImgDue = this.tbImgDue.Text,
                CategoriaRif = c.CategoriaId
            };
            ProdottoDal.getIstanza().Insert(p);
        }
    }
}
