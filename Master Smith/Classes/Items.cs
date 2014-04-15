using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace MasterSmith.Classes {
	class Item {
		public Texture2D texture { get; set; }
		public int weight { get; private set; }

		public Item(int weight) {
			this.weight = weight;
		}
	}
}
