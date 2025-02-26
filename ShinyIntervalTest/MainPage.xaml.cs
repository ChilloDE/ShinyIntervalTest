using Shiny.Notifications;

namespace ShinyIntervalTest
{
    public partial class MainPage : ContentPage
    {
        private readonly INotificationManager _manager;

        public MainPage(INotificationManager manager)
        {
            InitializeComponent();
            _manager = manager;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if ((await _manager.RequestAccess(AccessRequestFlags.TimeSensitivity)) is Shiny.AccessState.Available or Shiny.AccessState.Restricted)
            {
                await SendNotification();
            }
        }

        private async Task SendNotification()
        {
            await _manager.Cancel(1337);

            try
            {
                await _manager.Send(new Notification()
                {
                    RepeatInterval = new IntervalTrigger { Interval = TimeSpan.FromSeconds(30) },
                    Message = "This is a Test",
                    Thread = "AlarmMessages",
                    Id = 1337,
                });
            }
            catch (InvalidOperationException ex)
            {
                await Shell.Current.DisplayAlert("Unseccessful", ex.ToString(), "Ok");
            }
        }
    }
}
