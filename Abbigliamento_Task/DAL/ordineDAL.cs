using Abbigliamento_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbigliamento_Task.DAL
{
    internal class ordineDAL : IDal<Ordine>
    {
        private static ordineDAL istanza;

        public static ordineDAL getIstanza()
        {
            if (istanza == null)
                istanza = new ordineDAL();

            return istanza;
        }

        private ordineDAL()
        {

        }

        public List<Ordine> GetAll()
        {
            List<Ordine> ordini = new List<Ordine>();
            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    ordini = ctx.Ordines.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return ordini;
        }

        public Ordine GetbyId(int id)
        {
            Ordine ordini = new Ordine();

            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    ordini = ctx.Ordines.Single(o => o.OrdineId== id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return ordini;
            }
        }

        public bool Insert(Ordine t)
        {
            bool res = false;

            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    ctx.Ordines.Add(t);
                    ctx.SaveChanges();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            return res;
        }

        public bool Delete(Ordine t)
        {
            bool res = false;

            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    ctx.Ordines.Remove(t);
                    ctx.SaveChanges();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return res;
        }

        public bool Update(Ordine t)
        {
            bool res = false;

            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    ctx.Entry(t).State = EntityState.Modified;
                    ctx.SaveChanges();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return res;
        }        
    }
}
