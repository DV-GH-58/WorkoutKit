using WorkoutKit.Models;
using WorkoutKit.Services;

namespace WorkoutKit.Contracts;

public interface IWorkoutService
{
    WorkoutSettingsOptions Options();
    void Options(WorkoutSettingsOptions options);
    double WorkoutDuration { get; }
    double TotalDuration { get; }


}
