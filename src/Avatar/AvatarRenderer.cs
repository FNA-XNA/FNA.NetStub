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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
#endregion

namespace Microsoft.Xna.Framework.GamerServices
{
	public class AvatarRenderer : IDisposable
	{
		#region Public Constants

		public const int BoneCount = 71;

		#endregion

		#region Public Properties

		public Matrix World
		{
			get;
			set;
		}

		public Matrix View
		{
			get;
			set;
		}

		public Matrix Projection
		{
			get;
			set;
		}

		public ReadOnlyCollection<int> ParentBones
		{
			get;
			private set;
		}

		public ReadOnlyCollection<Matrix> BindPose
		{
			get
			{
				// Haha, amazing joke right here. -ade
				throw new InvalidOperationException("BindPose is not accessible until AvatarRenderer.State value is AvatarRendererState.Ready.");
			}
		}

		public AvatarRendererState State
		{
			get;
			private set;
		}

		public Vector3 LightColor
		{
			get;
			set;
		}

		public Vector3 LightDirection
		{
			get;
			set;
		}

		public Vector3 AmbientLightColor
		{
			get;
			set;
		}

		public bool IsDisposed
		{
			get;
			private set;
		}

		#endregion

		#region Public Constructors

		public AvatarRenderer(
			AvatarDescription avatarDescription
		) : this(avatarDescription, false) {
		}

		public AvatarRenderer(
			AvatarDescription avatarDescription,
			bool useLoadingEffect
		) {
			// XNA on PC always returns the same dummy data, even according to MSDN.
			World = Matrix.Identity;
			View = Matrix.Identity;
			Projection = Matrix.Identity;
			ParentBones = new ReadOnlyCollection<int>(new int[]
			{
				-1, 0, 0, 0, 0, 1, 2, 2,
				3, 3, 1, 6, 5, 6, 5, 8,
				5, 8, 5, 14, 12, 11, 16, 15,
				14, 20, 20, 20, 22, 22, 22, 25,
				25, 25, 28, 28, 28, 33, 33, 33,
				33, 33, 33, 33, 36, 36, 36, 36,
				36, 36, 36, 37, 38, 39, 40, 43,
				44, 45, 46, 47, 50, 51, 52, 53,
				54, 55, 56, 57, 58, 59, 60
			});
			State = AvatarRendererState.Unavailable;
			LightColor = Vector3.Zero;
			LightDirection = Vector3.Zero;
			AmbientLightColor = Vector3.Zero;
		}

		#endregion

		#region Public Static Methods

		public void Draw(
			IAvatarAnimation animation
		) {
		}

		public void Draw(
			IList<Matrix> bones,
			AvatarExpression expression
		) {
		}

		public void Dispose()
		{
			IsDisposed = true;
		}

		#endregion
	}
}
