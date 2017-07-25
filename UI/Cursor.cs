using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace OneWeek2017
{
	public class Cursor
	{
		public int position { get; set; }
		int charactersInLine;
		Vector2 positionOnScreen;
		Vector2 characterSize;
		SpriteFont scriptFont;
		Boolean isArrowKeyDown;


		public Cursor(ContentManager content, int charactersInLine, Vector2 characterSize)
		{
			scriptFont = content.Load<SpriteFont>("script-font");
			isArrowKeyDown = false;
			this.charactersInLine = charactersInLine;
			this.characterSize = characterSize;
			positionOnScreen = new Vector2(0, 0);
		}

		public void Update(string playerScript)
		{
        	HandleInput(playerScript);

			Vector2 startingPos = new Vector2(characterSize.X * 2, characterSize.Y * 2);
			positionOnScreen = startingPos;
			int charactersInThisLine = 0;
			int drawablePosition = 0;

			for (int i = 0; i < position; i++)
			{
				if (playerScript[i] == '\n')
				{
					drawablePosition += charactersInLine - charactersInThisLine;
					positionOnScreen.Y += characterSize.Y;
					charactersInThisLine = 0;
				}
				else if (charactersInThisLine >= charactersInLine)
				{
					charactersInThisLine = 0;
					drawablePosition++;
				}
				else
				{
					charactersInThisLine++;
					drawablePosition++;
				}
			}

			//positionOnScreen.X += characterSize.X* charactersInThisLine;
			positionOnScreen.X = startingPos.X + drawablePosition % charactersInLine * characterSize.X;
			positionOnScreen.Y = startingPos.Y + drawablePosition / charactersInLine * characterSize.Y;
		}

		public void HandleInput(string playerScript)
		{
			KeyboardState kb = Keyboard.GetState();

			if (kb.IsKeyDown(Keys.Down))
			{
				if (!isArrowKeyDown)
				{
					position += charactersInLine;
					if (position >= playerScript.Length)
					{
						position = playerScript.Length;
					}

					isArrowKeyDown = true;
				}
			}

			else if (kb.IsKeyDown(Keys.Up))
			{
				if (!isArrowKeyDown)
				{
					position -= charactersInLine;
					if (position< 0)
					{
						position = 0;
					}

					isArrowKeyDown = true;
				}
			}

			else if (kb.IsKeyDown(Keys.Left))
			{
				if (!isArrowKeyDown)
				{
					if (position > 0)
					{
						position--;
					}
					isArrowKeyDown = true;
				}
			}

			else if (kb.IsKeyDown(Keys.Right))
			{
				if (!isArrowKeyDown)
				{
					if (position<playerScript.Length)
					{
						position++;
					}
					isArrowKeyDown = true;
				}
			}

			else isArrowKeyDown = false;


		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString(scriptFont, "_", positionOnScreen, Color.White);
		}
	}
}
