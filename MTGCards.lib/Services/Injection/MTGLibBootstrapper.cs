using MTGCards.lib.Services.Cards;
using MTGCards.lib.Services.Factories;
using PRF.Utils.Injection.BootStrappers;
using PRF.Utils.Injection.Containers;
using PRF.Utils.Injection.Utils;

namespace MTGCards.lib.Services.Injection;

internal sealed class MtgLibBootstrapper : BootStrapperCore
{
    public override void Register(IInjectionContainerRegister container)
    {
        container.Register<ICardsProvider, CardsProvider>(LifeTime.Singleton);
        container.Register<ICardsHolder, CardsHolder>(LifeTime.Singleton);
        container.Register<ICardsDeserializer, CardsDeserializer>(LifeTime.Singleton);
        container.Register<ICardsFactory, CardsFactory>(LifeTime.Singleton);
    }
}