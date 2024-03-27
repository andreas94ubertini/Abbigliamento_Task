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
    /// Logica di interazione per CreazioneCat.xaml
    /// </summary>
    public partial class CreazioneCat : Window
    {
        public CreazioneCat()
        {
            InitializeComponent();
            catList.ItemsSource = categoriaDAL.getIstanza().GetAll();
        }
        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            string? nomeCat = this.nomeCat.Text;
            
            Categorium temp = new Categorium()
            {
                NomeCategoria = nomeCat
            };

            if (categoriaDAL.getIstanza().Insert(temp))
            {
                MessageBox.Show("Tutto ok!");
                catList.ItemsSource = categoriaDAL.getIstanza().GetAll();
            }
            else
                MessageBox.Show("Errore di inserimento");

            this.nomeCat.Text = "";
        }
        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var CategoriaId = button.Tag;
            int id = Convert.ToInt32(CategoriaId);
            categoriaDAL.getIstanza().DeleteByID(id);
            catList.ItemsSource = categoriaDAL.getIstanza().GetAll();
        }
        private void ModifyButtonClick(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            Categorium c = button.DataContext as Categorium;
            categoriaDAL.getIstanza().Update(c);
            catList.ItemsSource = categoriaDAL.getIstanza().GetAll();
        }
    }
}
