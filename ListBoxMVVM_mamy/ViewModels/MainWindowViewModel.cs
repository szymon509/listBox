using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using ListBoxMVVM_mamy.Models;
using ReactiveUI;

namespace ListBoxMVVM_mamy.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<BoardGameModel> BoardGames { get; } = new()
    {
        new BoardGameModel
        {
            Title = "Eurobiznes", Genre = "Ekonomiczne", MinPlayers = 2, MaxPlayers = 3, Rating = 7.0
        },
        new BoardGameModel
        {
            Title = "Senet", Genre = "Historyczna", MinPlayers = 2, MaxPlayers = 2, Rating = 1.0
        },
        new BoardGameModel
        {
            Title = "Tryktrak", Genre = "Strategiczna", MinPlayers = 2, MaxPlayers = 2, Rating = 4.0
        },
        new BoardGameModel
        {
            Title = "Grzybobranie", Genre = "Rodzinna", MinPlayers = 2, MaxPlayers = 4, Rating = 9.0
        },
    };

    private BoardGameModel _selectedBoardGame;

    public BoardGameModel SelectedBoardGame
    {
        get => _selectedBoardGame;
        set => this.RaiseAndSetIfChanged(ref _selectedBoardGame, value);
    }

    public ReactiveCommand<Unit, Unit> ShowDetailsCommand { get; }
    public ReactiveCommand<BoardGameModel, Unit> ShowTitleCommand { get; }

    private void ShowDetails()
    {

        if (SelectedBoardGame != null)
        {
            {
                Console.WriteLine(
                    $"Gra: {SelectedBoardGame.Title}, {SelectedBoardGame.Genre}, {SelectedBoardGame.MinPlayers}, {SelectedBoardGame.MaxPlayers}, {SelectedBoardGame.Rating}");
            }
        }
    }

    public MainWindowViewModel()
    {
        var canShow = this
            .WhenAnyValue(x => x.SelectedBoardGame)
            .Select(game => game != null);
        
        ShowDetailsCommand = ReactiveCommand.Create(ShowDetails, canShow);
        ShowTitleCommand = ReactiveCommand.Create(ShowDetails, canShow);
    }
}
