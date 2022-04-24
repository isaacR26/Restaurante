using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Restaurante.Models;
using Xamarin.Forms;

namespace Restaurante.Data
{
    public class SQLiteH
    {
        private SQLiteAsyncConnection db;

        public SQLiteH(string dbPath)
        {
            db=new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Products>().Wait();

        }

        public Task <int> SaveProductAsync(Products products)
        {
            if (products == null)
            {
                return null;
            }
            return db.InsertAsync(products);
            //return products == null ? null : db.InsertAsync(products);
        }
        
        public async Task<List<Products>> GetProductsAsync()
        {
            return await db.Table<Products>().ToListAsync();
        }

        /// <summary>
        /// Recuperar productos por name
        /// </summary>
        /// <param name="nameProduct">Nombre del alumno</param>
        /// <returns></returns>

        public Task<Products> SearchOne(Products products)
        {
            return db.Table<Products>().Where(x => x.IdProduct == products.IdProduct).FirstOrDefaultAsync();
        }

        public Task<int> UpdateProductAsync(Products products)
        {
            return db.UpdateAsync(products);
        }
        public Task<int> DeleteProductAsync(Products products)
        {
            return db.DeleteAsync(products);
        }
    }
}
