#region License
/* FNA.NetStub - XNA4 Xbox Live Stub DLL
 * Copyright 2019 Ethan "flibitijibibo" Lee
 *
 * Released under the Microsoft Public License.
 * See LICENSE for details.
 */
#endregion

namespace Microsoft.Xna.Framework.Net
{
	public sealed class AvailableNetworkSession
	{
		#region Public Properties

		public int CurrentGamerCount
		{
			get;
			private set;
		}

		public string HostGamertag
		{
			get;
			private set;
		}

		public int OpenPrivateGamerSlots
		{
			get;
			private set;
		}

		public int OpenPublicGamerSlots
		{
			get;
			private set;
		}

		public QualityOfService QualityOfService
		{
			get;
			private set;
		}

		public NetworkSessionProperties SessionProperties
		{
			get;
			private set;
		}

		#endregion

		#region Internal Constructor

		internal AvailableNetworkSession(
			int numGamers,
			string host,
			int privateSlots,
			int publicSlots,
			NetworkSessionProperties properties,
			QualityOfService qos
		) {
			CurrentGamerCount = numGamers;
			HostGamertag = host;
			OpenPrivateGamerSlots = privateSlots;
			OpenPublicGamerSlots = publicSlots;
			SessionProperties = properties;
			QualityOfService = qos;
		}

		#endregion
	}
}
