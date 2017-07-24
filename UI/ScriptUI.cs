using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace OneWeek2017
{
	public class ScriptUI
	{
		Texture2D scriptBG;
		Vector2 position = new Vector2(0, 400);

		public ScriptUI(ContentManager content)
		{
			scriptBG = content.Load<Texture2D>("script-bg");
		}

		public void Update(float elapsedTime)
		{

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(scriptBG, position, Color.White);
		}
	}
}
