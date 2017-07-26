using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace OneWeek2017
{
	public class LevelEngine
	{
		DocumentationUI docUI;
		ScriptUI scriptUI;
		Door door1;
		Player player;
		string _docUIString;

		public int GameState { get; set; }


		public LevelEngine(ContentManager content, Vector2 windowDimensions)
		{
			docUI = new DocumentationUI(content, windowDimensions);
			scriptUI = new ScriptUI(content, windowDimensions);

			_docUIString = "";

            // TODO: Hardcoded to listen on ESC key. Should be on a button or something
            //
            InputHandler.Instance.RegisterKeyEvent('\u001b', x => ExecuteCode());

			door1 = new Door(content, "door1");
			player = new Player(content, 500, 300, 2);
        }

		public void Update(float elapsedTime)
		{
			HandleMouseInput();
			scriptUI.Update(elapsedTime);
			door1.Update();
			docUI.Update(_docUIString);
			player.HandleInput();
			player.Update(elapsedTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			scriptUI.Draw(spriteBatch);
			docUI.Draw(spriteBatch);
			door1.Draw(spriteBatch);
			player.Draw(spriteBatch);
		}

		public void HandleMouseInput()
		{
			MouseState mouse = Mouse.GetState();

			if (mouse.LeftButton == ButtonState.Pressed)
			{
				// change gamestate based on mouse position
				if (mouse.X > 300) // TODO width of the script area should not be hard coded
				{
					GameStateManager.Instance.CurrentState = GameStateManager.GameState.MovingPlayer;
				}
				else GameStateManager.Instance.CurrentState = GameStateManager.GameState.EditingScript;

				if (door1.PointCollision(new Vector2(mouse.X, mouse.Y)))
				{
					_docUIString = door1.Documentation;
				}
				else if(player.PointCollision(new Vector2(mouse.X, mouse.Y)))
				{
					_docUIString = player.Documentation;
				}
			}
		}

		public void ExecuteCode()
		{
            // TODO: Need to do level setup elsewhere
            //
            List<IScriptableObject> objects = new List<IScriptableObject>();
            objects.Add(door1);
            CompileHelper.ExecuteRoom(objects, scriptUI.PlayerScript);
        }

		public void HandleCollision()
		{
			
		}

	}
}
