using Abbigliamento_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbigliamento_Task.DAL
{
    internal class UtenteDal : IDal<Utente>
    {
        private static UtenteDal? istanza;

        public static UtenteDal getIstanza()
        {
            if (istanza == null)
                istanza = new UtenteDal();

            return istanza;
        }

        private UtenteDal() { }
        public bool Delete(Utente t)
        {
            bool risultato = false;
            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {

                    ctx.Utentes.Remove(t);
                    ctx.SaveChanges();
                    risultato = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return risultato;
        }

        public List<Utente> GetAll()
        {
            List<Utente> risultato = new List<Utente>();

            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    risultato = ctx.Utentes.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return risultato;
        }

        public Utente GetbyId(int id)
        {
            Utente u = new Utente();
            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    u = ctx.Utentes.Single(u => u.UtenteId == id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return u;
        }

        public bool Insert(Utente t)
        {
            bool risultato = false;
            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    ctx.Utentes.Add(t);
                    ctx.SaveChanges();
                    risultato = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return risultato;
        }

        public bool Update(Utente t)
        {
            bool risultato = false;
            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    
                    ctx.Entry(t).State = EntityState.Modified;
                    ctx.SaveChanges();
                    risultato = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return risultato;
        }
    }
}
