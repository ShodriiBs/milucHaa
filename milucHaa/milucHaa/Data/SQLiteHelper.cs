using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using milucHaa.Models;
using System.Threading.Tasks;

namespace milucHaa.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Emociones>().Wait();
        }

        public Task<int> SaveEmocionAsync(Emociones emocion)
        {
            if(emocion.IdEmocion!=0)
            {
                return db.UpdateAsync(emocion);
            }
            else
            {
                return db.InsertAsync(emocion);
            }
        }

        public Task<int> DeleteEmocionesAsync(Emociones emocion)
        {
            return db.DeleteAsync(emocion);
        }

        public Task<List<Emociones>> GetEmocionAsync()
        { 
            return db.Table<Emociones>().ToListAsync();
        }

        public Task<Emociones> GetEmocionesByIdAsync(int IdEmocion)
        {
            return db.Table<Emociones>().Where(a => a.IdEmocion == IdEmocion).FirstOrDefaultAsync();
        }
    }
}
