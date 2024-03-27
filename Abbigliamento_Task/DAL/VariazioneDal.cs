using Abbigliamento_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbigliamento_Task.DAL
{
    internal class VariazioneDal : IDal<Variazione>
    {
        private static VariazioneDal? istanza;

        public static VariazioneDal getIstanza()
        {
            if (istanza == null)
                istanza = new VariazioneDal();

            return istanza;
        }

        private VariazioneDal() { }
        public List<Variazione> GetAll()
        {
            List<Variazione> risultato = new List<Variazione>();

            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    risultato = ctx.Variaziones.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return risultato;
        }

        public Variazione GetbyId(int id)
        {
            Variazione v = new Variazione();
            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    v = ctx.Variaziones.Single(v => v.VariazioneId == id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return v;
        }

        public bool Insert(Variazione t)
        {
            bool risultato = false;
            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    ctx.Variaziones.Add(t);
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

        public bool Delete(Variazione t)
        {
            bool risultato = false;
            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {

                    ctx.Variaziones.Remove(t);
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

        public bool Update(Variazione t)
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
