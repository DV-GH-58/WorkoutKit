using System;
using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using DevWinUI;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WorkoutKit;
using WorkoutKit.Contracts;
using WorkoutKit.Models;
using WorkoutKit.Services;
using WorkoutKit.ViewModels;

namespace WorkoutKit.ViewModels;

public partial class ShortCut1ViewModel : ObservableObject
{
    [ObservableProperty]
    private bool shortCut;

    private RelayCommand<object>? setting;
    public ICommand Setting => setting ??= new RelayCommand<object>(PerformSetting);
    private void PerformSetting(object? parameter)
    {
        string? s1;

        if (parameter != null)
        {

            s1 = parameter as string;

            int[]? ints = s1?.Split(';').Select(int.Parse).ToArray();

            if (ints?.Length == 5)
            {
                var o = App.GetService<IWorkoutService>().Options();
                o.Max_Rounds = ints[0];
                o.Max_Workout = ints[1];
                o.Max_Pause = ints[2];
                o.Startup_Counter = ints[3];
                o.Shutdown_Counter = ints[4];
                App.Current.NavService.NavigateTo(typeof(WOEnginePage));
            }
        }
    }

    public ShortCut1ViewModel()
    {


    }
}
