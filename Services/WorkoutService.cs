using CommunityToolkit.Mvvm.ComponentModel;
using WorkoutKit.Models;
using WorkoutKit.ViewModels;
using WorkoutKit.Contracts;

namespace WorkoutKit.Services;

public partial class WorkoutService : IWorkoutService
{

    private WorkoutSettingsOptions _Options;
    public WorkoutService()
    {
        _Options = new WorkoutSettingsOptions();
    }
    public WorkoutSettingsOptions Options()
    {
        return _Options;
    }
    public void Options(WorkoutSettingsOptions options)
    {
        _Options = options;
    }
    public double WorkoutDuration => _Options.Max_Rounds * (_Options.Max_Workout);
    public double TotalDuration => _Options.Max_Rounds * (_Options.Max_Workout + _Options.Max_Pause);

}
