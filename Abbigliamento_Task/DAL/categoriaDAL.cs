using Abbigliamento_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbigliamento_Task.DAL
{
    internal class categoriaDAL : IDal<Categorium>
    {
        private static categoriaDAL istanza;

        public static categoriaDAL getIstanza()
        {
            if (istanza == null)
                istanza = new categoriaDAL();

            return istanza;
        }

        private categoriaDAL()
        {

        }

        public List<Categorium> GetAll()
        {
            List<Categorium> categorie = new List<Categorium>();
            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    categorie = ctx.Categoria.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return categorie;
        }

        public Categorium GetbyId(int id)
        {
            Categorium categorie = new Categorium();

            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    categorie = ctx.Categoria.Single(c => c.CategoriaId == id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return categorie;
            }
        }

        public bool Insert(Categorium t)
        {
                bool res = false;

                using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
                {
                    try
                    {
                        ctx.Categoria.Add(t);
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

        public bool Delete(Categorium t)
        {
            bool res = false;

            using (AbbigliamentoTaskContext ctx = new AbbigliamentoTaskContext())
            {
                try
                {
                    ctx.Categoria.Remove(t);
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

        public bool Update(Categorium t)
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
