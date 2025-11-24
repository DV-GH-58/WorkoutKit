using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WorkoutKit.Models;
using DevWinUI;
using WorkoutKit.Contracts;

namespace WorkoutKit.ViewModels;

public partial class MainViewModel : ObservableObject
{
    // Replace field with a partial property for AOT compatibility
    public WorkoutSettingsOptions MainOptions
    {
        get => mainOptions;
        set => SetProperty(ref mainOptions, value);
    }   
    private WorkoutSettingsOptions mainOptions = new();

    private RelayCommand<object>? setting;
    public ICommand Setting => setting ??= new RelayCommand<object>(PerformSetting);
    private void PerformSetting(object? parameter)
    {
        if (parameter is string)
        {
            switch (parameter.ToString())
            {
                case "0":
                    App.GetService<IWorkoutService>().Options().Progress = 0;
                    App.Current.NavService.NavigateTo(typeof(Views.WOEnginePage));
                    break;
                case "1":
                    MainOptions.Shutdown_Counter = 5;
                    MainOptions.Startup_Counter = 5;
                    MainOptions.Max_Pause = 10;
                    MainOptions.Max_Rounds = 7;
                    MainOptions.Max_Workout = 50;
                    break;
                case "2":
                    MainOptions.Shutdown_Counter = 5;
                    MainOptions.Startup_Counter = 0;
                    MainOptions.Max_Pause = 10;
                    MainOptions.Max_Rounds = 10;
                    MainOptions.Max_Workout = 20;
                    break;
            }
        }
    }

    public MainViewModel()
    {
        App.GetService<IWorkoutService>().Options(MainOptions);
        App.GetService<IWorkoutService>().Options().Progress = 0;
        PerformSetting("1");
    }
}
