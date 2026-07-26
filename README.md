# MAUI Controls Showcase


A single-project **.NET 8 MAUI** app whose only job is to demonstrate the breadth of what
.NET MAUI can do, with Ukrainian language user interface.

## Languages

The UI supports **English** (default) and **Ukrainian**. Choose the language on the Home page;
the selection is saved and restored on the next launch.

## What's inside

| Page | Controls demonstrated |
|---|---|
| Home | `CollectionView` (grid layout), `Border`, language radio buttons, navigation via `Shell.Current.GoToAsync` |
| Buttons & Inputs | `Button` (+ styles/VisualStateManager), `Entry`, `SearchBar`, `BindableLayout` |
| Selection Controls | `Switch`, `CheckBox`, `RadioButton` (+ `RadioButtonGroup`), `Picker`, `DatePicker`, `TimePicker`, `Stepper`, `Slider` |
| Collections | `CollectionView`, `SwipeView`, `RefreshView` |
| Indicators & Progress | `ActivityIndicator`, `ProgressBar` |
| Alerts & Dialogs | `DisplayAlert`, `DisplayActionSheet`, `DisplayPromptAsync`, modal `Navigation`, CommunityToolkit.Maui `Toast` & `Snackbar` |

Every page follows the same MVVM shape: a `ViewModel` (in `ViewModels/`, using
`[ObservableProperty]` / `[RelayCommand]` source generators from CommunityToolkit.Mvvm) is
constructor-injected into its `ContentPage` (in `Views/`) via the built-in `MauiProgram`
service collection, and Shell resolves each page through DI when you tap a flyout item.

## Project layout

```
MauiControlsShowcase/
├── App.xaml(.cs)              Application entry point, global resources
├── AppShell.xaml(.cs)         Shell flyout navigation, one item per demo page
├── MauiProgram.cs             DI container wiring + CommunityToolkit registration
├── Models/                    Plain data types used by the demos (TodoItem, ...)
├── ViewModels/                One view-model per page (CommunityToolkit.Mvvm)
├── Views/                     One ContentPage (XAML + code-behind) per page
├── Converters/                Small IValueConverters used across pages
├── Services/                  LocalizationResourceManager (runtime language switch)
├── MarkupExtensions/          `{loc:Translate}` for XAML string bindings
├── Resources/Strings/         AppResources.resx (en) + AppResources.uk.resx
├── Resources/Styles/          Colors.xaml + Styles.xaml (the whole app's look & feel)
├── Resources/AppIcon|Splash/  Vector app icon & splash screen
└── Platforms/                 Android / iOS / Mac Catalyst / Windows entry points
```

## Building it

To run it you need a machine with:

1. **.NET 10 SDK** - <https://dotnet.microsoft.com/download>
2. The **MAUI workload**:
   ```bash
   dotnet workload install maui
   ```
3. Then, from the project folder:
   ```bash
   dotnet build -t:Run -f net10.0-windows10.0.19041.0   # Windows
   dotnet build -t:Run -f net10.0-maccatalyst            # Mac
   ```
   ...or just open `MauiControlsShowcase.csproj` in **Visual Studio 2022** (Windows) or
   **Visual Studio Code with the .NET MAUI extension** / **JetBrains Rider**, pick a target
   (Android emulator, Windows Machine, Mac Catalyst, or an iOS simulator on a Mac), and hit Run.
