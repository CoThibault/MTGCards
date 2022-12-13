using System.Collections.Generic;
using System.Windows;
using MTGCards.gui.Factories;
using MTGCards.gui.Services.Cards;
using MTGCards.gui.Views;
using MTGCards.lib.Services.Injection;
using PRF.Utils.Injection.BootStrappers;
using PRF.Utils.Injection.Containers;
using PRF.Utils.Injection.Utils;

namespace MTGCards.gui.Services.Injection
{
    internal sealed class MtgBoot
    {
        private readonly InjectionContainerSimpleInjector _internalContainer;

        private readonly List<IBootstrapperCore> _bootstrappers = new List<IBootstrapperCore>
        {
            new MtgLibBootstrapper(),
        };

        public MtgBoot()
        {
            _internalContainer = new InjectionContainerSimpleInjector();
        }
        
        public TMainWindow Run<TMainWindow>() where TMainWindow : class
        {
            Register();
            Initialize();
            return _internalContainer.Resolve<TMainWindow>();
        }
        
        private void Register()
        {
            foreach (var bootstrapper in _bootstrappers)
            {
                bootstrapper.Register(_internalContainer);
            }
            
            _internalContainer.RegisterType<MainWindowView>(LifeTime.Singleton);

            _internalContainer.Register<IMainWindowViewModel, MainWindowViewModel>(LifeTime.Singleton);
            _internalContainer.Register<ICardAdapterFactory, CardAdapterFactory>(LifeTime.Singleton);
            _internalContainer.Register<ICardAdapterProvider, CardAdapterProvider>(LifeTime.Singleton);
        }

        private void Initialize()
        {
            foreach (var bootstrapper in _bootstrappers)
            {
                bootstrapper.InitializeAsync(_internalContainer).Wait();
            }
        }

        public void OnExit(object sender, ExitEventArgs e)
        {
            _internalContainer.Dispose();
        }
    }   
}