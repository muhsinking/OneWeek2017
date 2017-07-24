using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace OneWeek2017
{
	public class DocumentationUI
	{
		Texture2D documentationBG;
		Vector2 position = new Vector2(0, 400);

		public DocumentationUI(ContentManager content)
		{
			documentationBG = content.Load<Texture2D>("documentation-bg");
		}

		public void Update(float elapsedTime)
		{
			
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(documentationBG, position, Color.White);
		}
	}
}
