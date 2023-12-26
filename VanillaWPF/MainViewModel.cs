using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Media.Imaging;

namespace VanillaWPF;

partial class MainViewModel : ObservableObject
{
    public IEnumerable<MenuItemViewModel?> MenuItems { get; }

    public MainViewModel()
    {
        MenuItems = new[]
        {
            new MenuItemViewModel(
                "_File",
                "file.png",
                null,
                new MenuItemViewModel(
                    "New",
                    "add.png",
                    null,
                    new MenuItemViewModel("Project", null, null),
                    new MenuItemViewModel("Solution", null, null),
                    new MenuItemViewModel("Directory", "folder.png", null),
                    new MenuItemViewModel("File", "file.png", null)
                ),
                new MenuItemViewModel("Open", null, null),
                new MenuItemViewModel("Save", null, null),
                new MenuItemViewModel("Save As", null, null),
                null,
                new MenuItemViewModel("Exit", null, new RelayCommand(() => App.Current.Shutdown()))
            ),
            new MenuItemViewModel(
                "_Edit",
                "edit.png",
                null,
                new MenuItemViewModel("Undo", "undo.png", null),
                new MenuItemViewModel("Redo", "redo.png", null),
                new MenuItemViewModel("Cut", "cut.png", null),
                new MenuItemViewModel("Copy", null, null),
                new MenuItemViewModel("Paste", null, null)
            ),
            new MenuItemViewModel("Help", "info.png", null, new MenuItemViewModel("About", null, null))
        };
    }
}

class MenuItemViewModel : ObservableObject
{
    public string Header { get; init; }
    public BitmapImage? Icon { get; init; }
    public RelayCommand? Command { get; init; }
    public IEnumerable<MenuItemViewModel?> Children { get; init; }

    public MenuItemViewModel(
        string header,
        string? icon,
        RelayCommand? command,
        params MenuItemViewModel?[] children
    )
    {
        Header = header;
        Command = command;
        Children = children;
        if (!string.IsNullOrEmpty(icon))
        {
            Icon = new BitmapImage(new Uri($"pack://application:,,,/Resources/Images/{icon}"));
        }
    }
}
