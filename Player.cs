using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace OneWeek2017
{
	public class Player : SpriteBase
	{
		const string TEXTURENAME = "halberd-badger-nobg";
		float _speed = 100;

		public Player(ContentManager content) : base(content, TEXTURENAME)
		{
			
		}

		public void HandleInput()
		{
			if (GameStateManager.Instance.CurrentState == GameStateManager.GameState.MovingPlayer)
			{
				KeyboardState kb = Keyboard.GetState();
			}
		}
	}
}
