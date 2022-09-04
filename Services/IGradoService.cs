using SQLiteDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SQLiteDemo.Services
{
    public interface IGradoService
    {
        Task<List<GradoModel>> GetGradoList();
        Task<int> AddGrado(GradoModel gradoModel);
        Task<int> DeleteGrado(GradoModel gradoModel);
        Task<int> UpdateGrado(GradoModel gradoModel);
    }
}
