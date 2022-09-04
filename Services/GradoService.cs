
using SQLite;
using SQLiteDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Services
{
    public class GradoService : IGradoService
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<GradoModel>();
            }
        }

        public async Task<int> AddGrado(GradoModel gradoModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(gradoModel);
        }

        public async Task<int> DeleteGrado(GradoModel gradoModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(gradoModel);
        }

        public async Task<List<GradoModel>> GetGradoList()
        {
            await SetUpDb();
            var gradoList = await _dbConnection.Table<GradoModel>().ToListAsync();
            return gradoList;
        }

        public async Task<int> UpdateGrado(GradoModel gradoModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(gradoModel);
        }
    }
}