# MAUI Controls Showcase

A single-project **.NET 8 MAUI** app whose only job is to demonstrate the breadth of what
.NET MAUI can do, with Ukrainian language user interface.

## What's inside

| Page | Controls demonstrated |
|---|---|
| Home | `CollectionView` (grid layout), `Border`, navigation via `Shell.Current.GoToAsync` |
| Buttons & Inputs | `Button` (+ styles/VisualStateManager), `ImageButton`, `Entry`, `Editor`, `SearchBar`, `BindableLayout` |
| Selection Controls | `Switch`, `CheckBox`, `RadioButton` (+ `RadioButtonGroup`), `Picker`, `DatePicker`, `TimePicker`, `Stepper`, `Slider` |
| Layouts | `Grid` (row/col span), `VerticalStackLayout`/`HorizontalStackLayout`, `FlexLayout`, `AbsoluteLayout`, `ScrollView` |
| Collections | `CollectionView`, `SwipeView`, `RefreshView`, `CarouselView` + `IndicatorView`, `Image` (remote `Uri`) |
| Indicators & Progress | `ActivityIndicator`, `ProgressBar`, `BoxView`, `Border` + `Shadow`, legacy `Frame` |
| Graphics & Drawing | `GraphicsView` + custom `IDrawable` (bar chart, live analog clock), `Image` |
| Gestures & Animation | `TapGestureRecognizer`, `PinchGestureRecognizer`, `PanGestureRecognizer`, `SwipeGestureRecognizer`, `ViewExtensions` (`FadeTo`, `RotateTo`, `ScaleTo`, `TranslateTo`) |
| Styling & Theming | `ResourceDictionary`, implicit/explicit `Style`, `AppThemeBinding`, `DynamicResource` vs `StaticResource`, `VisualStateManager` |
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
├── Models/                    Plain data types used by the demos (TodoItem, GalleryPhoto, ...)
├── ViewModels/                One view-model per page (CommunityToolkit.Mvvm)
├── Views/                     One ContentPage (XAML + code-behind) per page
├── Converters/                Small IValueConverters used across pages
├── Graphics/                  IDrawable implementations for the GraphicsView demos
├── Resources/Styles/          Colors.xaml + Styles.xaml (the whole app's look & feel)
├── Resources/AppIcon|Splash/  Vector app icon & splash screen
└── Platforms/                 Android / iOS / Mac Catalyst / Windows entry points
```

## Building it

This was authored in a cloud sandbox **without the .NET MAUI SDK or mobile workloads
installed**, so the code has been written and hand-reviewed carefully but not compiled
here - you'll want to do a first build yourself. To run it you need a machine with:

1. **.NET 8 SDK** - <https://dotnet.microsoft.com/download>
2. The **MAUI workload**:
   ```bash
   dotnet workload install maui
   ```
3. Then, from the project folder:
   ```bash
   dotnet build -t:Run -f net8.0-windows10.0.19041.0   # Windows
   dotnet build -t:Run -f net8.0-maccatalyst            # Mac
   ```
   ...or just open `MauiControlsShowcase.csproj` in **Visual Studio 2022** (Windows) or
   **Visual Studio Code with the .NET MAUI extension** / **JetBrains Rider**, pick a target
   (Android emulator, Windows Machine, Mac Catalyst, or an iOS simulator on a Mac), and hit Run.

### Notes / things you may want to add

- **No bundled images or custom fonts.** The app intentionally ships without binary
  assets so it stays a small, easy-to-review source sample. `ImageButton` and `Image`
  gracefully degrade without `Resources/Images/dotnet_bot.png` (see the READMEs left in
  `Resources/Images` and `Resources/Fonts` for exactly what to drop in and how to wire it up).
- **CommunityToolkit.Maui** is pinned with a floating `9.*` version in the `.csproj` so
  restore always grabs the newest compatible release - if you want a fully reproducible
  build, pin it to a specific version after your first successful restore.
- If anything doesn't compile first try, it's most likely a small API/version drift
  between when this was written and whatever MAUI/toolkit version you restore - the
  fixes are almost always one-line (e.g. a renamed property), the app's overall
  structure will still be correct.

## Why Shell + MVVM + CommunityToolkit.Mvvm

You asked for a demo that shows off the *power* of MAUI, not just a control gallery -
Shell's flyout gives free platform-idiomatic navigation (a proper hamburger menu on
phones, a permanent side rail on desktop/tablet), while CommunityToolkit.Mvvm's source
generators keep the view-model code short enough that each page's XAML and C# both fit
on one screen, so the controls stay the star of the show.
