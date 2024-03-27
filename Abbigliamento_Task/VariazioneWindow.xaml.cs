using Abbigliamento_Task.DAL;
using Abbigliamento_Task.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Abbigliamento_Task
{
    /// <summary>
    /// Logica di interazione per VariazioneWindow.xaml
    /// </summary>
    public partial class VariazioneWindow : Window
    {
        public int IdProd {  get; set; }
        public VariazioneWindow(int id)
        {
            InitializeComponent();
            this.IdProd = id;
            ListaVar.ItemsSource = ProdottoDal.getIstanza().GetbyId(IdProd).Variaziones.ToList();
        }

        private void btnSalvaVar_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button? b = sender as System.Windows.Controls.Button;
            Variazione v = new Variazione()
            {
                Colore = this.tbColore.Text,
                Taglia = this.tbtaglia.Text,
                Qt = Convert.ToInt32(this.tbQt.Text),
                ProdottoRif = this.IdProd
                
            };
            VariazioneDal.getIstanza().Insert(v);
            ListaVar.ItemsSource = ProdottoDal.getIstanza().GetbyId(IdProd).Variaziones.ToList();
        }
    }
}
