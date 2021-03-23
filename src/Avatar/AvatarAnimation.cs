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
#endregion

namespace Microsoft.Xna.Framework.GamerServices
{
	public class AvatarAnimation : IAvatarAnimation, IDisposable
	{
		#region Public Properties

		public ReadOnlyCollection<Matrix> BoneTransforms
		{
			get;
			private set;
		}

		public TimeSpan CurrentPosition
		{
			get;
			set;
		}

		public TimeSpan Length
		{
			get;
			private set;
		}

		public AvatarExpression Expression
		{
			get;
			private set;
		}

		#endregion

		#region Public Constructors

		public AvatarAnimation(
			AvatarAnimationPreset animationPreset
		) {
			// The PC stub is surprising in that it returns a collection with default (not identity) matrices. -ade
			BoneTransforms = new ReadOnlyCollection<Matrix>(new Matrix[AvatarRenderer.BoneCount]);
		}

		#endregion

		#region Public Methods

		public void Update(
			TimeSpan elapsedAnimationTime,
			bool loop
		) {
		}

		public void Dispose()
		{
		}

		#endregion
	}
}
