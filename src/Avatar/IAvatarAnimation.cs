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
	public interface IAvatarAnimation
	{
		#region Public Properties

		ReadOnlyCollection<Matrix> BoneTransforms
		{
			get;
		}

		TimeSpan CurrentPosition
		{
			get;
			set;
		}

		TimeSpan Length
		{
			get;
		}

		AvatarExpression Expression
		{
			get;
		}

		#endregion

		#region Public Methods

		void Update(
			TimeSpan elapsedAnimationTime,
			bool loop
		);

		#endregion
	}
}
