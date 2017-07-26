using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace OneWeek2017
{
	public class Player : SpriteBase, IScriptableObject
	{
		const string TEXTURENAME = "halberd-badger-nobg";
		float _speed = 300;
		public string VariableName { get; private set; }
		public string Documentation { get; private set; }

		public Player(ContentManager content, float X, float Y, float Scale) : base(content, TEXTURENAME, X, Y, Scale)
		{
			VariableName = "player1";
			Documentation = "It's you!";
		}

		public string GetParameterizedName()
		{
			return "Player " + VariableName;   
		}

		// TODO: should ultimately handle input with InputHandler
		public void HandleInput()
		{
			if (GameStateManager.Instance.CurrentState == GameStateManager.GameState.MovingPlayer)
			{
				KeyboardState kb = Keyboard.GetState();

				if (kb.IsKeyDown(Keys.W) || kb.IsKeyDown(Keys.Up))
				{
					dY = -_speed;
				}

				else if (kb.IsKeyDown(Keys.S) || kb.IsKeyDown(Keys.Down))
				{
					dY = _speed;
				}

				else
				{
					dY = 0;
				}

				if (kb.IsKeyDown(Keys.A) || kb.IsKeyDown(Keys.Left))
				{
					dX = -_speed;
				}

				else if (kb.IsKeyDown(Keys.D) || kb.IsKeyDown(Keys.Right))
				{
					dX = _speed;
				}

				else
				{
					dX = 0;
				}

			}
		}
	}
}
