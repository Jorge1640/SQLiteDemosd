using SQLiteDemo.ViewModels;

namespace SQLiteDemo.Views;

public partial class GradoListPage : ContentPage
{
    private GradoListPageViewModel _viewMode;
    public GradoListPage(GradoListPageViewModel viewModel)
	{
		InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetGradoListCommand.Execute(null);
    }
}