using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABI.Microsoft.UI.Xaml.Markup;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WorkoutKit.Models;

public partial class WorkoutSettingsOptions : ObservableObject
{
    public string Name
    {
        get; set;
    } = "Workout Kit #1";

    // Replace [ObservableProperty] field with a partial property for AOT compatibility
    private int _max_Workout;
    public int Max_Workout
    {
        get => _max_Workout;
        set => SetProperty(ref _max_Workout, value);
    }

    // FIX for MVVMTK0045: Replace [ObservableProperty] with a partial property
    private int _max_Pause;
    public int Max_Pause
    {
        get => _max_Pause;
        set => SetProperty(ref _max_Pause, value);
    }

    // Replace [ObservableProperty] field with a partial property for AOT compatibility
    private double _max_Rounds;
    public double Max_Rounds
    {
        get => _max_Rounds;
        set => SetProperty(ref _max_Rounds, value);
    }

    /// <summary>
    /// session startup count
    /// </summary>
    // Replace [ObservableProperty] field with a partial property for AOT compatibility
    private double _startup_Counter;
    public double Startup_Counter
    {
        get => _startup_Counter;
        set => SetProperty(ref _startup_Counter, value);
    }

    /// <summary>
    /// session end count
    /// </summary>
    // Replace [ObservableProperty] field with a partial property for AOT compatibility
    private double _shutdown_Counter;
    public double Shutdown_Counter
    {
        get => _shutdown_Counter;
        set => SetProperty(ref _shutdown_Counter, value);
    }

    /// <summary>
    /// Gets or sets the progress value 
    /// Updated when page is opened.
    /// Should be O on start
    /// </summary>
    // Replace [ObservableProperty] field with a partial property for AOT compatibility
    private double _progress;
    public double Progress
    {
        get => _progress;
        set => SetProperty(ref _progress, value);
    }

    private double _max_Progress;
    public double Max_Progress
    {
        get => _max_Progress;
        set => SetProperty(ref _max_Progress, value);
    }
}
