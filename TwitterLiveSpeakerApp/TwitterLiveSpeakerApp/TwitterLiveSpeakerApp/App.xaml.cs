using System.Configuration;
using System.Data;
using System.Windows;
using TwitterLiveSpeakerApiLib;
using TwitterLiveSpeakerApp.SignalR;
using TwitterLiveSpeakerApp.Views;

namespace TwitterLiveSpeakerApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ApiServer? _apiServer;
        private SignalRClient? _signalRClient;

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            var loadingWindow = new LoadingWindow();
            loadingWindow.Show();

            _apiServer = new ApiServer();
            await _apiServer.StartAsync(5000);

            _signalRClient = new SignalRClient();
            await _signalRClient.StartAsync("http://localhost:5000/speakerAppHub");

            loadingWindow.Close();

            var mainWindow = new MainWindow();
            mainWindow.Show();

            this.MainWindow = mainWindow;
            this.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            if (_signalRClient != null)
            {
                await _signalRClient.StopAsync();
            }

            if (_apiServer != null)
            {
                await _apiServer.StopAsync();
            }
            base.OnExit(e);
        }
    }
}