using Abbigliamento_Task.DAL;
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
using Abbigliamento_Task.Models;

namespace Abbigliamento_Task
{
    /// <summary>
    /// Logica di interazione per creazioneUtente.xaml
    /// </summary>
    public partial class creazioneUtente : Window
    {
        public creazioneUtente()
        {
            InitializeComponent();

            dgUtente.ItemsSource = UtenteDal.getIstanza().GetAll();
        }

        private void btnSalvaUtente_Click(object sender, RoutedEventArgs e)
        {
            string? nome = this.tbNome.Text;
            string? cognome = this.tbCognome.Text;
            string? telefono = this.tbTelefono.Text;
            string? email = this.tbEmail.Text;
            string? nomeUtente = this.tbNomeUtente.Text;

            Utente utente = new Utente()
            {
                Nome = nome,
                Cognome = cognome,
                Telefono = telefono,
                Email = email,
                NomeUtente = nomeUtente
            };

            if (UtenteDal.getIstanza().Insert(utente))
            {
                MessageBox.Show("Utente inserito.");
                dgUtente.ItemsSource = UtenteDal.getIstanza().GetAll();
            }
            else
                MessageBox.Show("Errore di inserimento");

            this.tbNome.Text = "";
            this.tbCognome.Text = "";
            this.tbTelefono.Text = "";
            this.tbEmail.Text = "";
            this.tbNomeUtente.Text = "";
        }

        private void btnEliminaUtente_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var UtenteId = button.Tag;
            int id = Convert.ToInt32(UtenteId);
            if (UtenteDal.getIstanza().DeleteById(id))
                MessageBox.Show("Utente cancellato.");

            dgUtente.ItemsSource = UtenteDal.getIstanza().GetAll();
        }

        private void btnModifyUtente_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Utente u = button.DataContext as Utente;
            if (UtenteDal.getIstanza().Update(u))
                MessageBox.Show("Record Modificato");
            dgUtente.ItemsSource = UtenteDal.getIstanza().GetAll();


        }
    }
}
