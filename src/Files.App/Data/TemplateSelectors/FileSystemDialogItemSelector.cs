// Copyright (c) Files Community
// Licensed under the MIT License.

using Microsoft.UI.Xaml;

namespace Files.App.Data.TemplateSelectors
{
	internal sealed partial class FileSystemDialogItemSelector : BaseTemplateSelector<BaseFileSystemDialogItemViewModel>
	{
		public DataTemplate? ConflictItemDataTemplate { get; set; }

		public DataTemplate? DefaultItemDataTemplate { get; set; }

		protected override DataTemplate SelectTemplateCore(BaseFileSystemDialogItemViewModel? item, DependencyObject container)
		{
			if (item is FileSystemDialogConflictItemViewModel)
			{
				return ConflictItemDataTemplate!;
			}
			else if (item is FileSystemDialogDefaultItemViewModel)
			{
				return DefaultItemDataTemplate!;
			}
			else
			{
				return base.SelectTemplateCore(item, container);
			}
		}
	}
}
