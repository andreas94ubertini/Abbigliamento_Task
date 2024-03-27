using Abbigliamento_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbigliamento_Task.DAL
{
    internal class ProdottoDal : IDal<Prodotto>
    {
        private static ProdottoDal? istanza;

        public static ProdottoDal getIstanza()
        {
            if (istanza == null)
                istanza = new ProdottoDal();

            return istanza;
        }

        private ProdottoDal() { }
        public bool Delete(Prodotto t)
        {
            bool risultato = false;
            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {

                    ctx.Prodottos.Remove(t);
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

        public List<Prodotto> GetAll()
        {
            List<Prodotto> risultato = new List<Prodotto>();

            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    risultato = ctx.Prodottos.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return risultato;
        }

        public Prodotto GetbyId(int id)
        {
            Prodotto p = new Prodotto();
            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    p = ctx.Prodottos.Single(p => p.ProdottoId == id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return p;
        }

        public bool Insert(Prodotto t)
        {
            bool risultato = false;
            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    ctx.Prodottos.Add(t);
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

        public bool Update(Prodotto t)
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
