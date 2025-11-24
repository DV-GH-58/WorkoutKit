using System;
using System.Diagnostics;
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

public partial class WOEngineViewModel : ObservableObject, INavigationAwareEx
{
    private double _pR_Value;
    public double PR_Value
    {
        get => _pR_Value;
        set => SetProperty(ref _pR_Value, value);
    }

    private double _pR_Max;
    public double PR_Max
    {
        get => _pR_Max;
        set => SetProperty(ref _pR_Max, value);
    }

    private string _pR_Text = "";
    public string PR_Text
    {
        get => _pR_Text;
        set => SetProperty(ref _pR_Text, value);
    }

    private double _CurrentRound;
    public double CurrentRound
    {
        get => _CurrentRound;
        set => SetProperty(ref _CurrentRound, value);
    }

    public WorkoutSettingsOptions Options
    {
        get
        {
            return App.GetService<IWorkoutService>().Options();
        }
    }

    public WorkoutSettingsOptions LocalOptions { get; set; } = new Models.WorkoutSettingsOptions();
    
    private string _statusInfoA = "A";
    public string StatusInfoA
    {
        get => _statusInfoA;
        set => SetProperty(ref _statusInfoA, value);
    }

    private string _statusInfoB = "B";
    public string StatusInfoB
    {
        get => _statusInfoB;
        set => SetProperty(ref _statusInfoB, value);
    }

    private string _statusInfoC = "C";
    public string StatusInfoC
    {
        get => _statusInfoC;
        set => SetProperty(ref _statusInfoC, value);
    }

    public WOEngineViewModel()
    {
    }

    public void OnNavigatedFrom()
    {
    }

    public void OnNavigatedTo(object parameter)
    {
        PerformStartup();
    }

    private async void PerformStartup()
    {
        LocalOptions.Progress = 0;
        StatusInfoA = $"{Options.Max_Rounds} Rounds.\n{Options.Max_Workout} Seconds Workout\n{Options.Max_Pause} Seconds Rest\nGet ready...";

        while (LocalOptions.Max_Rounds < Options.Max_Rounds)
        {
            if (LocalOptions.Progress == 0)
            {
                // Startup
                await ProcessRest((int)Options.Startup_Counter, "Startup");
                LocalOptions.Progress++;
            }

            if (LocalOptions.Progress % 2 == 0)
            {
                StatusInfoB = "Rest";
                await ProcessRest(Options.Max_Pause, "Rest");
                LocalOptions.Progress++;
            }

            if (LocalOptions.Progress % 2 == 1)
            {
                await ProcessExercise(Options.Max_Workout, "Work");
                LocalOptions.Progress++;
                StatusInfoB = $"Work {CurrentRound}";
            }

            if (LocalOptions.Progress > Options.Max_Rounds * 2)
            {
                StatusInfoB = $"End";
                break;
            }

            StatusInfoA = $"{LocalOptions.Max_Rounds}";
        }

        StatusInfoA = $"Done\n{Options.Max_Rounds} Rounds\n{Options.Max_Workout} seconds workout\n{Options.Max_Pause} seconds pause";
        await ProcessRest((int)Options.Shutdown_Counter, "End");

        StatusInfoA = $"End";
    }
    private async Task ProcessExercise(int max_Workout, string text)
    {
        max_Workout *= 100;
        PR_Max = max_Workout;

        for (var i = 0; i <= max_Workout; i++)
        {
            DispatcherQueue.GetForCurrentThread()?.TryEnqueue(() =>
            {
                double perc = (i * 100) / max_Workout;

                CurrentRound = LocalOptions.Max_Rounds + perc/100;

                StatusInfoA = $"Round {LocalOptions.Max_Rounds + 1}\n{perc} %\n";
                LocalOptions.Max_Workout = i/10;

                PR_Text = $"{i / 100}";
                PR_Value = i;
            });
            await Task.Run(() => Thread.Sleep(10));
        }

        LocalOptions.Max_Rounds++;
        CurrentRound = LocalOptions.Max_Rounds;
    }

    private async Task ProcessRest(int max, string text)
    {
        max *= 100;
        PR_Max = max;
        for (var i = 0; i <= max; i++)
        {
            DispatcherQueue.GetForCurrentThread()?.TryEnqueue(() =>
            {
                PR_Text = $"{text}";
                PR_Value = max - i;
            });
            await Task.Run(() => Thread.Sleep(10));
        }
    }
}

