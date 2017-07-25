using System;
namespace OneWeek2017
{
	public class GameStateManager
	{
		private static GameStateManager instance;

		public enum GameState { MovingPlayer = 0, EditingScript = 1}

		public GameState CurrentState { get; set; }

		private GameStateManager()
		{
			CurrentState = GameState.EditingScript;
		}

		public static GameStateManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new GameStateManager();
				}
				return instance;
			}
		}

		//public int GetState()
		//{
		//	return GameState;
		//}


	}
}
