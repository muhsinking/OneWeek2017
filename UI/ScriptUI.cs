using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace OneWeek2017
{
	public class ScriptUI
	{
		Texture2D scriptBG;
		Vector2 position;
		SpriteFont scriptFont;

		public ScriptUI(ContentManager content, Vector2 windowDimensions)
		{
			scriptBG = content.Load<Texture2D>("script-bg");
			scriptFont = content.Load<SpriteFont>("script-font");
		}

		public void Update(float elapsedTime)
		{

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(scriptBG, position, null, Color.White, 0f, new Vector2(0, 0), new Vector2(.75f, .75f), SpriteEffects.None, 0f);
			spriteBatch.DrawString(scriptFont, "whatever", new Vector2(position.X + 30, position.Y + 30), Color.White);
		}
	}
}
