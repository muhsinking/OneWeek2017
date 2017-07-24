using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace OneWeek2017
{
	public class DocumentationUI
	{
		Texture2D documentationBG;
		Vector2 position;

		public DocumentationUI(ContentManager content, Vector2 windowDimensions)
		{
			position = new Vector2(0, windowDimensions.Y / 2);
			documentationBG = content.Load<Texture2D>("documentation-bg");
		}

		public void Update(float elapsedTime)
		{
			
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(documentationBG, position, null, Color.White, 0f, new Vector2(0, 0), new Vector2(.75f, .75f), SpriteEffects.None, 0f);
		}
	}
}
