namespace pred.app.TagHelpers
{
	using System.Reflection;
	using Microsoft.AspNetCore.Razor.TagHelpers;
	// You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
	[HtmlTargetElement("version")]
	public class VersionTagHelper : TagHelper
	{
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "span";
			output.Content.SetContent($"(version {this.GetAppVersion()})");
			output.TagMode = TagMode.StartTagAndEndTag;
		}
		private string GetAppVersion()
		{
			string assemblyVersion = Assembly.GetEntryAssembly()
				.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
			return assemblyVersion;
		}
	}
}
