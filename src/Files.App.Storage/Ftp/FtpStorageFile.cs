// Copyright (c) Files Community
// Licensed under the MIT License.

using System.IO;

namespace Files.App.Storage
{
	public sealed class FtpStorageFile : FtpStorable, IChildFile
	{
		public FtpStorageFile(string path, string name, IFolder? parent)
			: base(path, name, parent)
		{
		}

		/// <inheritdoc/>
		public async Task<Stream> OpenStreamAsync(FileAccess access, CancellationToken cancellationToken = default)
		{
			using var ftpClient = GetFtpClient();
			await ftpClient.EnsureConnectedAsync(cancellationToken);

			if (access.HasFlag(FileAccess.Write))
				return await ftpClient.OpenWrite(Id, token: cancellationToken);
			else if (access.HasFlag(FileAccess.Read))
				return await ftpClient.OpenRead(Id, token: cancellationToken);
			else
				throw new ArgumentException($"Invalid {nameof(access)} flag.");
		}
	}
}
