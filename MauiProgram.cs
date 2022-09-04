using SQLiteDemo.Services;
using SQLiteDemo.ViewModels;
using SQLiteDemo.Views;

namespace SQLiteDemo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

 // Services
        //Estudiantes
        builder.Services.AddSingleton<IStudentService, StudentService>();
        //Materia
        builder.Services.AddSingleton<IMateriaService, MateriaService>();
        //Sede
        builder.Services.AddSingleton<ISedeService, SedeService>();
        //Grado
        builder.Services.AddSingleton<IGradoService, GradoService>();

        //Views Registration
        //Estudiantes
        builder.Services.AddSingleton<StudentListPage>();
        builder.Services.AddTransient<AddUpdateStudentDetail>();
        //Materias
        builder.Services.AddSingleton<MateriaListPage>();
        builder.Services.AddTransient<AddUpdateMateriaDetail>();
        //Sede
        builder.Services.AddSingleton<SedeListPage>();
        builder.Services.AddTransient<AddUpdateSedeDetail>();
        //Grado
        builder.Services.AddSingleton<GradoListPage>();
        builder.Services.AddTransient<AddUpdateGradoDetail>();



        //View Modles 
        //Estudiantes
        builder.Services.AddSingleton<StudentListPageViewModel>();
        builder.Services.AddTransient<AddUpdateStudentDetailViewModel>();
        //Materias
        builder.Services.AddSingleton<MateriaListPageViewModel>();
        builder.Services.AddTransient<AddUpdateMateriaDetailViewModel>();
        //Sede
        builder.Services.AddSingleton<SedeListPageViewModel>();
        builder.Services.AddTransient<AddUpdateSedeDetailViewModel>();
        //Grado
        builder.Services.AddSingleton<GradoListPageViewModel>();
        builder.Services.AddTransient<AddUpdateGradoDetailViewModel>();

        return builder.Build();
    }
}
