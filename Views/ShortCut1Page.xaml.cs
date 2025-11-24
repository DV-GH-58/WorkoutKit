using Microsoft.UI.Xaml.Controls;
using WorkoutKit.ViewModels;
using WorkoutKit.Models;

namespace WorkoutKit.Views;

public sealed partial class ShortCut1Page : Page
{

    public ShortCut1ViewModel ViewModel
    {
        get;
    }

    public ShortCut1Page()
    {
        ViewModel = App.GetService<ShortCut1ViewModel>();
        DataContext = ViewModel;
        InitializeComponent();
    }

}
