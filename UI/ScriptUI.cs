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
		ScriptRenderHelper srh;

		public ScriptUI(ContentManager content, Vector2 windowDimensions)
		{
			lineOffset = 0;
			position = new Vector2(0, 0);
			scriptBG = content.Load<Texture2D>("script-bg");
			scriptFont = content.Load<SpriteFont>("script-font");
			playerScript = "";
			characterSize = scriptFont.MeasureString("a"); // make sure font is monospaced
			lineWidth = 300 - characterSize.X * 4;
			charactersInLine = (int) (lineWidth/characterSize.X);
			cursor = new Cursor(content, charactersInLine, characterSize);
			cursor.position = playerScript.Length;

			srh = new ScriptRenderHelper(charactersInLine);

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
			cursor.HandleInput(playerScript);
			srh.Update(playerScript, cursor.position);
			cursor.Update(playerScript, srh.CursorDrawPosition);
		}

		//public void UpdateDrawableString()
		//{
		//	drawableString = playerScript;


		//	int charactersInThisLine = 0;

		//	int i = 0;
		
		//	while (i < drawableString.Length)
		//	{
		//		if (drawableString[i] == '\n')
		//		{
		//			charactersInThisLine = -1;
		//		}

		//		else if (i > 0 && charactersInThisLine % charactersInLine == 0)
		//		{
		//			drawableString = drawableString.Insert(i, "\n");
		//			charactersInThisLine = 0;
		//			i++;
		//		}
		//		charactersInThisLine++;
		//		i++;
		//	}
		//}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(scriptBG, position, null, Color.White, 0f, new Vector2(0, 0), new Vector2(.75f, .75f), SpriteEffects.None, 0f);
			spriteBatch.DrawString(scriptFont, srh.DrawableString, new Vector2(position.X + (characterSize.X * 2) , position.Y + (characterSize.Y*2) + (lineOffset*characterSize.Y)), Color.White);
			cursor.Draw(spriteBatch);
		}
	}
}
