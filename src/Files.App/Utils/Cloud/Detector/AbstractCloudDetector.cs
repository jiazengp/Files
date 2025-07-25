// Copyright (c) Files Community
// Licensed under the MIT License.

namespace Files.App.Utils.Cloud
{
	public abstract class AbstractCloudDetector : ICloudDetector
	{
		public async Task<IEnumerable<ICloudProvider>> DetectCloudProvidersAsync()
		{
			var providers = new List<ICloudProvider>();

			try
			{
				await foreach (var provider in GetProviders())
					providers.Add(provider);

				return providers;
			}
			catch
			{
				return providers;
			}
		}

		protected abstract IAsyncEnumerable<ICloudProvider> GetProviders();
	}
}