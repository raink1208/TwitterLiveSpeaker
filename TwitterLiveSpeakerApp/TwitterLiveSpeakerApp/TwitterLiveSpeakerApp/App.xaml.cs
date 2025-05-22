using System.Configuration;
using System.Data;
using System.Windows;
using TwitterLiveSpeakerApiLib;

namespace TwitterLiveSpeakerApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ApiServer? _apiServer;

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _apiServer = new ApiServer();
            await _apiServer.StartAsync(5000);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            if (_apiServer != null)
            {
                await _apiServer.StopAsync();
            }
            base.OnExit(e);
        }
    }
}
