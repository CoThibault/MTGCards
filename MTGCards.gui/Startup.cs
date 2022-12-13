using System;
using System.Windows;
using MTGCards.gui.Services.Injection;
using MTGCards.gui.Views;

namespace MTGCards.gui;

internal static class Startup
{
    [STAThread]
    internal static void Main()
    {
        try
        {
            var mainBoot = new MtgBoot();
            var app = new App
            {
                //close the app when the main window is closed (default value is lastWindow)
                ShutdownMode = ShutdownMode.OnMainWindowClose
            };
                
            app.Exit += mainBoot.OnExit;
            app.InitializeComponent();

            app.Run(mainBoot.Run<MainWindowView>());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Unhandled Exception (will exit after close): {ex} ");
        }
    }
}
