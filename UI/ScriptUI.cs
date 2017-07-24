using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;



namespace OneWeek2017
{
	public class ScriptUI
	{
		Texture2D scriptBG;
		Vector2 position;
		SpriteFont scriptFont;
		String playerScript;
		int lineOffset;
		float lineHeight;
		float lineWidth;
		int charactersInLine;
		Vector2 characterSize;
		int cursorPosition;
		Vector2 cursor;


		public ScriptUI(ContentManager content, Vector2 windowDimensions)
		{
			lineOffset = 0;
			scriptBG = content.Load<Texture2D>("script-bg");
			scriptFont = content.Load<SpriteFont>("script-font");
			playerScript = "whatever";
			characterSize = scriptFont.MeasureString("a");
			lineWidth = 300 - characterSize.X * 4;
			charactersInLine = (int) (lineWidth/characterSize.X);
			cursor = new Vector2(0, 0);
			cursorPosition = playerScript.Length;
		}

		public void Update(float elapsedTime)
		{




			//KeyboardState kb = Keyboard.GetState();

			//if (kb.IsKeyDown(Keys.W))
			//{
			//	Vector2 scriptSize = scriptFont.MeasureString(playerScript+"w\n");

			//	if (scriptSize.X > lineWidth)
			//	{
			//		playerScript = playerScript.Insert(cursorPosition,"\n  ");
			//		cursorPosition += 3;
			//	}

			//	playerScript = playerScript.Insert(cursorPosition,"w");

			//	cursorPosition++;

			//}
			//if (kb.IsKeyDown(Keys.Enter))
			//{
			//	playerScript = playerScript.Insert(cursorPosition,"\n  ");
			//}

			//if (kb.IsKeyDown(Keys.Down))
			//{
			//	cursorPosition += charactersInLine;
			//	if (cursorPosition >= playerScript.Length)
			//	{
			//		cursorPosition = playerScript.Length - 1;
			//	}
			//	//lineOffset++;
			//}

			//if (kb.IsKeyDown(Keys.Up))
			//{
			//	cursorPosition -= charactersInLine;
			//	if (cursorPosition < 0) cursorPosition = 0;
			//	//lineOffset--;
			//}



		}

		public string CreateDrawableString()
		{
			return "";
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(scriptBG, position, null, Color.White, 0f, new Vector2(0, 0), new Vector2(.75f, .75f), SpriteEffects.None, 0f);
			spriteBatch.DrawString(scriptFont, playerScript, new Vector2(position.X + (characterSize.X * 2) , position.Y + (characterSize.Y*2) + (lineOffset*characterSize.Y)), Color.White);
		}
	}
}
