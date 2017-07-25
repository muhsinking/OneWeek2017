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
		public int GameState { get; set; }


		public LevelEngine(ContentManager content, Vector2 windowDimensions)
		{
			docUI = new DocumentationUI(content, windowDimensions);
			scriptUI = new ScriptUI(content, windowDimensions);
            
            // TODO: Hardcoded to listen on ESC key. Should be on a button or something
            //
            InputHandler.Instance.RegisterKeyEvent('\u001b', x => ExecuteCode());

			door1 = new Door(content, "door1");

        }

		public void Update(float elapsedTime)
		{
			HandleMouseInput();
			docUI.Update(elapsedTime);

			scriptUI.Update(elapsedTime);

			door1.Update();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			scriptUI.Draw(spriteBatch);
			docUI.Draw(spriteBatch);
			door1.Draw(spriteBatch);
		}

		public void HandleMouseInput()
		{
			MouseState mouse = Mouse.GetState();

			// change gamestate based on mouse position
			if (mouse.LeftButton == ButtonState.Pressed)
			{
				if (mouse.X > 300) // TODO width of the script area should not be hard coded
				{
					GameStateManager.Instance.CurrentState = GameStateManager.GameState.MovingPlayer;
				}
				else GameStateManager.Instance.CurrentState = GameStateManager.GameState.EditingScript;
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
