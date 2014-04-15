using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MasterSmith.Classes {
	class GameObject {
		public Vector2 position { get; set; }
		public Vector2 velocity { get; set; }

		public bool onGround { get; set; }
		public Texture2D texture { get; set; }

		public GameObject(Vector2 position) {
			this.position = position;
			this.texture = null;
		}

		public GameObject(Vector2 position, Texture2D texture) {
			this.position = position;
			this.texture = texture;
		}

		public void Draw(SpriteBatch spriteBatch) {
			spriteBatch.Draw(texture, position, Color.White);
		}

		public virtual void Update(GameTime gameTime) {
			// Gravity
			if (!onGround)
				velocity += new Vector2(0, -Defaults.GRAVITY);

			Move(velocity);
		}

		public virtual void Move(Vector2 amount) {
			position += amount;

			// Prevent objects from falling through the ground.
			Vector2 newPos = position;
			if (position.Y >= Defaults.ScreenHeight - (Defaults.GROUND + texture.Width)) {
				newPos.Y = Defaults.ScreenHeight - (Defaults.GROUND + texture.Width);
				onGround = true;
			} else {
				onGround = false;
			}

			position = newPos;
		}
	}

	class ItemObject : GameObject {
		public Item item { get; private set; }

		public ItemObject(Vector2 position, Item item) : base(position, item.texture) {
			this.item = item;
		}
	}
}
