using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MasterSmith.Classes {
	class Creature : GameObject {
		public int maxHealth { get; private set; }
		public int health { get; private set; }

		public Creature(Vector2 position, int maxHealth) : base (position) {
			this.health = maxHealth;
			this.maxHealth = maxHealth;
		}
	}
}
