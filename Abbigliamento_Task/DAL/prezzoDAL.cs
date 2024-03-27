using Abbigliamento_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbigliamento_Task.DAL
{
    internal class prezzoDAL : IDal <Prezzo>
    {
        private static prezzoDAL istanza;

        public static prezzoDAL getIstanza()
        {
            if(istanza == null)
                istanza = new prezzoDAL();

            return istanza;
        }

        private prezzoDAL()
        {

        }

        public List<Prezzo> GetAll()
        {
            List<Prezzo> prezzi = new List<Prezzo>();
            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    prezzi = ctx.Prezzos.ToList();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return prezzi;
        }

        public Prezzo GetbyId(int id)
        {
            Prezzo prezzi = new Prezzo();

            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    prezzi = ctx.Prezzos.Single(p => p.PrezzoId == id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return prezzi;
            }
        }

        public bool Insert(Prezzo t)
        {
            bool res = false;

            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    ctx.Prezzos.Add(t);
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

        public bool Delete(Prezzo t)
        {
            bool res = false;

            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    ctx.Prezzos.Remove(t);
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

        public bool Update(Prezzo t)
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
