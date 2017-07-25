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
		Vector2 characterSize;
		SpriteFont scriptFont;
		string playerScript;
		int lineOffset;
		int charactersInLine;
		float lineWidth;
		Cursor cursor;
		string drawableString;

		public ScriptUI(ContentManager content, Vector2 windowDimensions)
		{
			lineOffset = 0;
			position = new Vector2(0, 0);
			scriptBG = content.Load<Texture2D>("script-bg");
			scriptFont = content.Load<SpriteFont>("script-font");
			playerScript = "whatever";
			drawableString = playerScript;
			characterSize = scriptFont.MeasureString("a");
			lineWidth = 300 - characterSize.X * 4;
			charactersInLine = (int) (lineWidth/characterSize.X);
			cursor = new Cursor(content, charactersInLine, characterSize);
			cursor.position = playerScript.Length;

			InputHandler.Instance.RegisterEveryKeyEvent(HandleInput);
		}

		public void HandleInput(char c)
		{
			// if backspace is pressed...
			if (c == '\b' && cursor.position > 0)
			{
				playerScript = playerScript.Remove(cursor.position-1,1);
				cursor.position--;
			}

			// if enter is pressed...
			if (c == '\r' || c == '\n')
			{
				playerScript = playerScript.Insert(cursor.position, "\n");

				cursor.position += 1;
			}

			if (char.IsControl(c))
			{
				return;
			}
			playerScript = playerScript.Insert(cursor.position, c.ToString());
			cursor.position++;

		}

		public void Update(float elapsedTime)
		{
			UpdateDrawableString();
			cursor.Update(playerScript);
		}

		public void UpdateDrawableString()
		{
			//int newLinePos = charactersInLine;

			drawableString = playerScript;

			//while (newLinePos < drawableString.Length)
			//{
			//	drawableString = drawableString.Insert(newLinePos, "\n");
			//	newLinePos += charactersInLine+1;
			//}

			int charactersInThisLine = 0;
			int cursorDrawPosition = 0;

			int i = 0;
			int newLines = 0;

			while (i < drawableString.Length)
			{
				if (drawableString[i] == '\n')
				{
					cursorDrawPosition += charactersInLine - charactersInThisLine;
					charactersInThisLine = 0;
				}

				else if (i > 0 && charactersInThisLine % charactersInLine == 0)
				{
					drawableString = drawableString.Insert(i, "\n");
					charactersInThisLine = 0;
					newLines++;
				}
				charactersInThisLine++;
				i++;
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(scriptBG, position, null, Color.White, 0f, new Vector2(0, 0), new Vector2(.75f, .75f), SpriteEffects.None, 0f);
			spriteBatch.DrawString(scriptFont, drawableString, new Vector2(position.X + (characterSize.X * 2) , position.Y + (characterSize.Y*2) + (lineOffset*characterSize.Y)), Color.White);
			cursor.Draw(spriteBatch);
		}
	}
}
