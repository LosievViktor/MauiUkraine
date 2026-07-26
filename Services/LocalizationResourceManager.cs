using System.ComponentModel;
using System.Globalization;
using MauiControlsShowcase.Resources.Strings;

namespace MauiControlsShowcase.Services;

/// <summary>
/// App-wide culture switcher. Bind XAML to <see cref="Instance"/> with an indexer
/// path (e.g. <c>[Home_HeroTitle]</c>) so texts refresh when the language changes.
/// </summary>
public sealed class LocalizationResourceManager : INotifyPropertyChanged
{
	public const string PreferenceKey = "AppLanguage";
	public const string DefaultLanguage = "en";

	public static LocalizationResourceManager Instance { get; } = new();

	private LocalizationResourceManager()
	{
		var saved = Preferences.Default.Get(PreferenceKey, DefaultLanguage);
		ApplyCulture(saved, persist: false);
	}

	public event PropertyChangedEventHandler? PropertyChanged;
	public event EventHandler? CultureChanged;

	/// <summary>Increments on every culture change so MultiBindings can refresh.</summary>
	public int CultureVersion { get; private set; }

	public string CurrentLanguage { get; private set; } = DefaultLanguage;

	public string this[string key] => AppResources.Get(key);

	public void SetCulture(string languageCode)
	{
		if (string.Equals(CurrentLanguage, languageCode, StringComparison.OrdinalIgnoreCase))
		{
			return;
		}

		ApplyCulture(languageCode, persist: true);
	}

	private void ApplyCulture(string languageCode, bool persist)
	{
		var culture = languageCode.StartsWith("uk", StringComparison.OrdinalIgnoreCase)
			? new CultureInfo("uk")
			: new CultureInfo("en");

		CurrentLanguage = culture.TwoLetterISOLanguageName;
		CultureInfo.CurrentCulture = culture;
		CultureInfo.CurrentUICulture = culture;
		CultureInfo.DefaultThreadCurrentCulture = culture;
		CultureInfo.DefaultThreadCurrentUICulture = culture;
		AppResources.Culture = culture;
		CultureVersion++;

		if (persist)
		{
			Preferences.Default.Set(PreferenceKey, CurrentLanguage);
		}

		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CultureVersion)));
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentLanguage)));
		CultureChanged?.Invoke(this, EventArgs.Empty);
	}
}
