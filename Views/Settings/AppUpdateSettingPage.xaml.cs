namespace WorkoutKit.Views;

public sealed partial class AppUpdateSettingPage : Page
{
    public AppUpdateSettingViewModel ViewModel { get; }

    public AppUpdateSettingPage()
    {
        this.ViewModel = App.GetService<AppUpdateSettingViewModel>();
        this.InitializeComponent();
    }
}


