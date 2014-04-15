using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MasterSmith.Classes {
	class Player : Creature {
		private List<Item> inventory = new List<Item>();

		public int inventoryWeight {
			get {
				int weight = 0;
				foreach (Item item in inventory) weight += item.weight;
				return weight;
			}
		}

		public Player(Vector2 position)	: base(position, Defaults.MAX_HP) {

		}

		public override void Update(GameTime gameTime) {
			base.Update(gameTime);

			KeyboardState state = Keyboard.GetState();
			if (onGround)
				velocity = Defaults.GetKeyboardInputDirection(state) * Defaults.PLAYER_SPEED;

			if (state.IsKeyDown(Keys.Space) && onGround) {
				velocity += new Vector2(0, -Defaults.JUMP_VELOCITY);
			}
		}

		public override void Move(Vector2 amount) {
			base.Move(amount);

			// Clamp player to screen
			Vector2 newPos = position;
			if (position.X < 0)
				newPos.X = 0;
			if (position.X >= Defaults.ScreenWidth - texture.Width)
				newPos.X = Defaults.ScreenWidth - texture.Width;

			position = newPos;
		}

		/// <summary>
		/// Add an item to the player's inventory if the player can carry it.
		/// </summary>
		/// <param name="item">Item to pickup.</param>
		/// <returns>True if picked up, false otherwise.</returns>
		public bool Pickup(Item item) {
			if (inventoryWeight + item.weight <= Defaults.MAX_CARRY_CAPACITY) {
				// pickup the item
				inventory.Add(item);
				return true;
			} else {
				// too heavy
				return false;
			}
		}
	}
}
