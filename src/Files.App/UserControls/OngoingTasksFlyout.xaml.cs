// Copyright (c) 2023 Files Community
// Licensed under the MIT License. See the LICENSE.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Files.App.UserControls
{
	public sealed partial class OngoingTasksFlyout : UserControl
	{
		public OngoingTasksViewModel ViewModel { get; set; }

		public OngoingTasksFlyout()
		{
			InitializeComponent();
		}

		// Dismiss banner button event handler
		private void DismissBanner(object sender, RoutedEventArgs e)
		{
			StatusBanner itemToDismiss = (sender as Button).DataContext as StatusBanner;
			ViewModel.CloseBanner(itemToDismiss);
		}

		// Primary action button click
		private async void Button_Click_1(object sender, RoutedEventArgs e)
		{
			StatusBanner itemToDismiss = (sender as Button).DataContext as StatusBanner;
			await Task.Run(itemToDismiss.PrimaryButtonClick);
			ViewModel.CloseBanner(itemToDismiss);
		}

		private void DismissAllBannersButton_Click(object sender, RoutedEventArgs e)
		{
			ViewModel.CloseAllBanner();
		}
	}
}
