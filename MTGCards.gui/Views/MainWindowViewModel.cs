using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using MTGCards.Common.Async;
using MTGCards.gui.Adapters;
using MTGCards.gui.Services.Cards;
using MTGCards.gui.Services.Cards.Helpers;
using PRF.WPFCore;
using PRF.WPFCore.Commands;
using PRF.WPFCore.CustomCollections;

namespace MTGCards.gui.Views
{
    internal interface IMainWindowViewModel
    {
        string SearchFilter { get; }
        ICollectionView CardsToDisplay { get; }
    }

    internal sealed class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private readonly ICardAdapterProvider _cardAdapterProvider;
        private string _searchFilter = string.Empty;
        private ICardAdapter? _selectedCard;
        private readonly ObservableCollectionRanged<ICardAdapter> _cards;
        private bool _isLoadingCards;

        public MainWindowViewModel(ICardAdapterProvider cardAdapterProvider)
        {
            _cards = new ObservableCollectionRanged<ICardAdapter>();
            _cardAdapterProvider = cardAdapterProvider;
            CardsToDisplay = CollectionViewSource.GetDefaultView(_cards);
            UpdateSelectedCardCommand = new DelegateCommandLight<ICardAdapter>(ExecuteUpdateSelectedCard);
            ExecuteLoadCards();
        }

        private async void ExecuteLoadCards()
        {
            IsLoadingCards = true;
            
            var result = await AsyncWrapper.DispatchAndWrapAsync(
                () =>
                {
                    return _cardAdapterProvider.GetCardAdaptersFromSets();
                },
                () => IsLoadingCards = false).ConfigureAwait(true);
            if (result.Any())
            {
                _cards.Clear();
                _cards.AddRange(result);
                RaisePropertyChanged(nameof(HasCardsLoaded));
            }
        }

        public IDelegateCommandLight<ICardAdapter> UpdateSelectedCardCommand { get; }

        public bool HasCardsLoaded => !CardsToDisplay.IsEmpty;

        public bool IsLoadingCards
        {
            get => _isLoadingCards;
            private set => SetProperty(ref _isLoadingCards, value);
        }

        public ICollectionView CardsToDisplay { get; }

        public ICardAdapter? SelectedCard
        {
            get => _selectedCard;
            private set => SetProperty(ref _selectedCard, value);
        }

        /// <inheritdoc />
        public string SearchFilter
        {
            get => _searchFilter;
            set
            {
                if (SetProperty(ref _searchFilter, value))
                {
                    FilterCardsByName();
                }
            }
        }

        private void FilterCardsByName()
        {
            if (_cards.Count != 0)
            {
                if (string.IsNullOrEmpty(_searchFilter))
                {
                    CardsToDisplay.Filter = _ => true;
                }

                // var splitParts = CardSearchHelper.GetSplitParts(_searchFilter);
                CardsToDisplay.Filter = item => CardSearchHelper.FilterNames(item, _searchFilter);
            }
        }

        private void ExecuteUpdateSelectedCard(ICardAdapter? cardAdapter)
        {
            if (cardAdapter != null)
            {
                SelectedCard = cardAdapter;
            }
        }
    }   
}