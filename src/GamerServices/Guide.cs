#region License
/* FNA.NetStub - XNA4 Xbox Live Stub DLL
 * Copyright 2019 Ethan "flibitijibibo" Lee
 *
 * Released under the Microsoft Public License.
 * See LICENSE for details.
 */
#endregion

#region Using Statements
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Threading;
#endregion

namespace Microsoft.Xna.Framework.GamerServices
{
	public static class Guide
	{
		#region Public Static Properties

		public static bool IsScreenSaverEnabled
		{
			// FIXME: Should we use SDL here? -flibit
			get
			{
				return SDL2.SDL.SDL_IsScreenSaverEnabled() == SDL2.SDL.SDL_bool.SDL_TRUE;
			}
			set
			{
				if (value)
				{
					SDL2.SDL.SDL_EnableScreenSaver();
				}
				else
				{
					SDL2.SDL.SDL_DisableScreenSaver();
				}
			}
		}

		public static bool IsTrialMode
		{
			get;
			set;
		}

		public static bool IsVisible
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static NotificationPosition NotificationPosition
		{
			get
			{
				return position;
			}
			set
			{
				if (value != position)
				{
					position = value;
				}
			}
		}

		public static bool SimulateTrialMode
		{
			get;
			set;
		}

		#endregion

		#region Private Static Variables

		private static NotificationPosition position = NotificationPosition.BottomRight;

		#endregion

		#region Async Object Type

		internal class GuideAction : IAsyncResult
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

			public GuideAction(object state, AsyncCallback callback)
			{
				AsyncState = state;
				Callback = callback;
				IsCompleted = false;
				AsyncWaitHandle = new ManualResetEvent(true);
			}
		}

		#endregion

		#region Static Constructor

		static Guide()
		{
			IsTrialMode = false;
			SimulateTrialMode = false;
		}

		#endregion

		#region Public Static Methods

		public static IAsyncResult BeginShowKeyboardInput(
			PlayerIndex player,
			string title,
			string description,
			string defaultText,
			AsyncCallback callback,
			object state
		) {
			return BeginShowKeyboardInput(
				player,
				title,
				description,
				defaultText,
				callback,
				state,
				false
			);
		}

		public static IAsyncResult BeginShowKeyboardInput(
			PlayerIndex player,
			string title,
			string description,
			string defaultText,
			AsyncCallback callback,
			object state,
			bool usePasswordMode
		) {
			// FIXME: Register text input handler and obtain text? -ade
			TextInputEXT.StartTextInput();
			return new GuideAction(state, callback) {
				IsCompleted = true
			};
		}

		public static string EndShowKeyboardInput(IAsyncResult result)
		{
			// FIXME: Unregister text input handler and return obtained text? -ade
			TextInputEXT.StopTextInput();
			return "";
		}

		public static IAsyncResult BeginShowMessageBox(
			string title,
			string text,
			IEnumerable<string> buttons,
			int focusButton,
			MessageBoxIcon icon,
			AsyncCallback callback,
			object state
		) {
			// FIXME: Surely they don't want us doing this... -flibit
			throw new NotSupportedException();
		}

		public static IAsyncResult BeginShowMessageBox(
			PlayerIndex player,
			string title,
			string text,
			IEnumerable<string> buttons,
			int focusButton,
			MessageBoxIcon icon,
			AsyncCallback callback,
			object state
		) {
			// FIXME: Surely they don't want us doing this... -flibit
			throw new NotSupportedException();
		}

		public static int? EndShowMessageBox(IAsyncResult result)
		{
			// FIXME: Surely they don't want us doing this... -flibit
			throw new NotSupportedException();
		}

		public static void DelayNotifications(TimeSpan delay)
		{
		}

		public static void ShowComposeMessage(
			PlayerIndex player,
			string text,
			IEnumerable<Gamer> recipients
		) {
		}

		public static void ShowFriendRequest(PlayerIndex player, Gamer gamer)
		{
		}

		public static void ShowFriends(PlayerIndex player)
		{
		}

		public static void ShowGameInvite(
			PlayerIndex player,
			IEnumerable<Gamer> recipients
		) {
		}

		public static void ShowGameInvite(string sessionId)
		{
		}

		public static void ShowGamerCard(PlayerIndex player, Gamer gamer)
		{
		}

		public static void ShowMarketplace(PlayerIndex player)
		{
		}

		public static void ShowMessages(PlayerIndex player)
		{
		}

		public static void ShowParty(PlayerIndex player)
		{
		}

		public static void ShowPartySessions(PlayerIndex player)
		{
		}

		public static void ShowPlayerReview(PlayerIndex player, Gamer gamer)
		{
		}

		public static void ShowPlayers(PlayerIndex player)
		{
		}

		public static void ShowSignIn(int paneCount, bool onlineOnly)
		{
		}

		public static void ShowAchievementsEXT(PlayerIndex player)
		{
		}

		#endregion
	}
}
