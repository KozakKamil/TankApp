
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TankApp.Model;
using TankApp.Services;

namespace TankApp.ViewModel;

public partial class TankViewModel : ObservableObject
{
    private readonly TankService _tankService;
    public ObservableCollection<TankModel> Tanks { get; set; } = new();

    [ObservableProperty]
    private bool isLoading;

    public TankViewModel(TankService tankService)
    {
        _tankService = tankService;
        LoadTanksCommand = new AsyncRelayCommand(LoadTanksAsync);
    }

    public IAsyncRelayCommand LoadTanksCommand { get; }

    private async Task LoadTanksAsync()
    {
        if (IsLoading) return;
        IsLoading = true;

        var tanks = await _tankService.GetTanksAsync();
        Tanks.Clear();
        foreach (var tank in tanks)
        {
            Tanks.Add(tank);
        }

        IsLoading = false;
    }
}
