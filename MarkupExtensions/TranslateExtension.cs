using MauiControlsShowcase.Services;

namespace MauiControlsShowcase.MarkupExtensions;

[ContentProperty(nameof(Name))]
public sealed class TranslateExtension : IMarkupExtension<BindingBase>
{
	public string Name { get; set; } = string.Empty;

	public BindingBase ProvideValue(IServiceProvider serviceProvider)
		=> new Binding($"[{Name}]", BindingMode.OneWay, source: LocalizationResourceManager.Instance);

	object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
		=> ProvideValue(serviceProvider);
}
