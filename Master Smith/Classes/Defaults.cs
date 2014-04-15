using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MasterSmith.Classes {
	class Defaults {
		public const int MAX_CARRY_CAPACITY = 500;
		public const int MAX_HP = 100;
		public const int PLAYER_SPEED = 8;
		public const int JUMP_VELOCITY = 20;

		public const int GROUND = 100;
		public const int GRAVITY = -1;

		public static int ScreenWidth;
		public static int ScreenHeight;

		public static Vector2 GetKeyboardInputDirection(KeyboardState state) {
			Vector2 direction = Vector2.Zero;
			if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left))
				direction.X += -1;
			if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right))
				direction.X += 1;
			return direction;
		}
	}
}
