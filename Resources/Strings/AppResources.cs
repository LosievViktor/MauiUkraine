using System.Globalization;
using System.Resources;

namespace MauiControlsShowcase.Resources.Strings;

/// <summary>
/// Thin accessor over the AppResources.*.resx satellite files.
/// English lives in the invariant/default resx; Ukrainian in AppResources.uk.resx.
/// </summary>
public static class AppResources
{
	private static readonly ResourceManager ResourceManager =
		new("MauiControlsShowcase.Resources.Strings.AppResources", typeof(AppResources).Assembly);

	public static CultureInfo? Culture { get; set; }

	public static string Get(string name)
		=> ResourceManager.GetString(name, Culture) ?? name;

	public static string Format(string name, params object?[] args)
		=> string.Format(Culture ?? CultureInfo.CurrentUICulture, Get(name), args);
}
