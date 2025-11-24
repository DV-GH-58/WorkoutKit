using Microsoft.UI.Xaml.Controls;
using WorkoutKit.ViewModels;

namespace WorkoutKit.Views;

public sealed partial class WOEnginePage : Page
{
    public WOEngineViewModel ViewModel
    {
        get;
    }

    public WOEnginePage()
    {
        ViewModel = App.GetService<WOEngineViewModel>();
        DataContext = ViewModel;
        InitializeComponent();
    }
}
