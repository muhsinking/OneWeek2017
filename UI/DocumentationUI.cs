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
		SpriteFont scriptFont;
		Vector2 characterSize;

		// TODO: should retrieve this string from the object (door), and should parse through it for necessary word wrapping/etc.
		string docString = 
			"Door door1\n\n" +
			"Methods\n" +
			"  Open() - opens the door if unlocked\n" +
			"  Unlock() - unlocks the door\n" +
			"  Lock() - locks the door\n\n" +
			"Properties\n" +
			"  Boolean IsOpen\n" +
			"  Boolean IsLocked";

		public DocumentationUI(ContentManager content, Vector2 windowDimensions)
		{
			position = new Vector2(0, windowDimensions.Y / 2);
			documentationBG = content.Load<Texture2D>("documentation-bg");
			scriptFont = content.Load<SpriteFont>("script-font");
			characterSize = scriptFont.MeasureString("a"); // make sure font is monospaced
		}

		public void Update(float elapsedTime)
		{
			
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(documentationBG, position, null, Color.White, 0f, new Vector2(0, 0), new Vector2(.75f, .75f), SpriteEffects.None, 0f);
			spriteBatch.DrawString(scriptFont, docString, new Vector2(position.X + (characterSize.X* 3) , position.Y + (characterSize.Y) + (characterSize.Y)), Color.White);
		}
	}
}
