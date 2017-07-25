using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;



namespace OneWeek2017
{
	public class ScriptUI
	{
        public string PlayerScript { get; private set; }

        Texture2D scriptBG;
		Vector2 position;
		Vector2 characterSize;
		SpriteFont scriptFont;
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
			PlayerScript = "";
			characterSize = scriptFont.MeasureString("a"); // make sure font is monospaced
			lineWidth = 300 - characterSize.X * 6;
			charactersInLine = (int) (lineWidth/characterSize.X);
			cursor = new Cursor(content, charactersInLine, characterSize);
			cursor.position = PlayerScript.Length;

			srh = new ScriptRenderHelper(charactersInLine);

			InputHandler.Instance.RegisterEveryKeyEvent(HandleInput);
		}

		public void HandleInput(char c)
		{
			if (GameStateManager.Instance.CurrentState == GameStateManager.GameState.EditingScript)
			{
				// if backspace is pressed...
				if (c == '\b' && cursor.position > 0)
				{
					PlayerScript = PlayerScript.Remove(cursor.position - 1, 1);
					cursor.position--;
				}

				// if enter is pressed...
				if (c == '\r' || c == '\n')
				{
					PlayerScript = PlayerScript.Insert(cursor.position, "\n");

					cursor.position += 1;
				}

				if (char.IsControl(c))
				{
					return;
				}
				PlayerScript = PlayerScript.Insert(cursor.position, c.ToString());
				cursor.position++;
			}
		}

		public void Update(float elapsedTime)
		{
			srh.Update(PlayerScript, cursor.position);
			cursor.Update(PlayerScript, srh.CursorDrawPosition);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(scriptBG, position, null, Color.White, 0f, new Vector2(0, 0), new Vector2(.75f, .75f), SpriteEffects.None, 0f);
			spriteBatch.DrawString(scriptFont, srh.DrawableString, new Vector2(position.X + (characterSize.X * 3) , position.Y + (characterSize.Y*2) + (lineOffset*characterSize.Y)), Color.White);
			cursor.Draw(spriteBatch);
		}
	}
}
