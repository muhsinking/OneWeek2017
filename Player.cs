using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace OneWeek2017
{
	public class Player : SpriteClass
	{
		const string TEXTURENAME = "halberd-badger-nobg";
		const float speed = 30;

		public Player(ContentManager content, float scale) : base(content, TEXTURENAME, scale)
		{
			
		}

		public void HandleInput()
		{
		}
	}
}
