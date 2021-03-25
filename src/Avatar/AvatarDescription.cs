#region License
/* FNA.NetStub - XNA4 Xbox Live Stub DLL
 * Copyright 2019 Ethan "flibitijibibo" Lee
 *
 * Released under the Microsoft Public License.
 * See LICENSE for details.
 */
#endregion

#region Using Statements
using System;
using System.Collections.ObjectModel;
using System.Threading;
#endregion

namespace Microsoft.Xna.Framework.GamerServices
{
	public class AvatarDescription
	{
		#region Public Properties

		public byte[] Description
		{
			get
			{
				byte[] copy = new byte[descriptionSize];
				Array.Copy(description, copy, descriptionSize);
				return copy;
			}
		}

		public bool IsValid
		{
			get
			{
				return description[0] != 0;
			}
		}

		public float Height
		{
			get;
			private set;
		}

		public AvatarBodyType BodyType
		{
			get;
			private set;
		}

		#endregion

		#region Private Variables

		// Tested anything between 0 and 100000 and this was the only valid size.
		private const int descriptionSize = 1021;
		private byte[] description;

		#endregion

		#region Public Events

#pragma warning disable 0067
		public static event EventHandler<EventArgs> Changed;
#pragma warning restore 0067

		#endregion

		#region Async Object Type

		internal class AvatarDescriptionAction : IAsyncResult
		{
			public object AsyncState
			{
				get;
				private set;
			}

			public bool CompletedSynchronously
			{
				get
				{
					return false;
				}
			}

			public bool IsCompleted
			{
				get;
				internal set;
			}

			public WaitHandle AsyncWaitHandle
			{
				get;
				private set;
			}

			public readonly AsyncCallback Callback;

			public AvatarDescriptionAction(object state, AsyncCallback callback)
			{
				AsyncState = state;
				Callback = callback;
				IsCompleted = false;
				AsyncWaitHandle = new ManualResetEvent(true);
			}
		}

		#endregion

		#region Public Constructors

		public AvatarDescription(
			byte[] data
		) {
			// Some trial and error went into this, although only with the mostly stubbed PC version.
			if (data == null)
			{
				throw new ArgumentNullException("availableSession");
			}
			if (data.Length != descriptionSize)
			{
				throw new ArgumentException("The array is not the correct size for the amount of data requested.");
			}

			description = new byte[descriptionSize];
			Array.Copy(data, description, descriptionSize);
		}

		#endregion

		#region Internal Constructors

		internal AvatarDescription(
			bool isValid
		) {
			description = new byte[descriptionSize];
			if (isValid)
			{
				description[0] = 1;
			}
		}

		#endregion

		#region Public Static Methods

		public static AvatarDescription CreateRandom()
		{
			// On PC, it's following the same randomness principle as Sony with PS3 security.
			return new AvatarDescription(true);
		}

		public static AvatarDescription CreateRandom(
			AvatarBodyType bodyType
		) {
			if (!Enum.IsDefined(typeof(AvatarBodyType), bodyType))
			{
				throw new ArgumentOutOfRangeException("bodyType");
			}

			// It "checks" but doesn't respect bodyType on PC. -ade
			return new AvatarDescription(true);
		}

		public static System.IAsyncResult BeginGetFromGamer(
			Gamer gamer,
			AsyncCallback callback,
			object state
		) {
			return new AvatarDescriptionAction(state, callback)
			{
				IsCompleted = true
			};
		}

		public static AvatarDescription EndGetFromGamer(
			IAsyncResult result
		)
		{
			return new AvatarDescription(false);
		}

		#endregion
	}
}
