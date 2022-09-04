using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SQLiteDemo.Models;
using SQLiteDemo.Services;
using SQLiteDemo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.ViewModels
{
    public partial class GradoListPageViewModel : ObservableObject
    {
        public ObservableCollection<GradoModel> Grado { get; set; } = new ObservableCollection<GradoModel>();

        private readonly IGradoService _gradoService;
        public GradoListPageViewModel(IGradoService gradoService)
        {
            _gradoService = gradoService;
        }



        [ICommand]
        public async void GetGradoList()
        {
            Grado.Clear();
            var gradoList = await _gradoService.GetGradoList();
            if (gradoList?.Count > 0)
            {
                foreach (var grado in gradoList)
                {
                    Grado.Add(grado);
                }
            }
        }


        [ICommand]
        public async void AddUpdateGrado()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateSedeDetail));
        }


        [ICommand]
        public async void DisplayAction(GradoModel gradoModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Seleccione", "Aceptar", null, "Editar", "Eliminar","Cancelar");
            if (response == "Editar")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("GradoDetail", gradoModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateGradoDetail), navParam);
            }
            else if (response == "Eliminar")
            {
                var delResponse = await _gradoService.DeleteGrado(gradoModel);
                if (delResponse > 0)
                {
                    await Shell.Current.DisplayAlert("El registro fue eliminado", "Eliminado", "Aceptar");
                    GetGradoList();
                }
            }
        }
    }
}
