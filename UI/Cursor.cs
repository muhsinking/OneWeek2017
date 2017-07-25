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

		public void Update(string playerScript, int cursorDrawPosition)
		{
        	//HandleInput(playerScript);

			Vector2 startingPos = new Vector2(characterSize.X * 2, characterSize.Y * 2);
			positionOnScreen = startingPos;

			positionOnScreen.X = startingPos.X + cursorDrawPosition % charactersInLine * characterSize.X;
			positionOnScreen.Y = startingPos.Y + cursorDrawPosition / charactersInLine * characterSize.Y;
		}

		// TODO: handle this with InputHandler events, rather than monogame kb input
		public void HandleInput(string playerScript)
		{
			KeyboardState kb = Keyboard.GetState();

			if (kb.IsKeyDown(Keys.Down))
			{
				if (!isArrowKeyDown)
				{
					int i;

					for (i = 0; i < charactersInLine; i++)
					{
						if (position + i < playerScript.Length)
						{
							if (playerScript[position + i] == '\n')
							{
								i++;
								break;
							}
						}
						else break;
					}

					position += i;

					isArrowKeyDown = true;
				}
			}

			else if (kb.IsKeyDown(Keys.Up))
			{
				if (!isArrowKeyDown)
				{
					int i;

					for (i = 0; i < charactersInLine; i++)
					{
						if (position - i - 1 >= 0)
						{
							if (playerScript[position - i - 1] == '\n')
							{
								i++;
								break;
							}
						}
						else break;
					}

					position -= i;

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
