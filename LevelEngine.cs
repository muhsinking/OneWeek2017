using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace OneWeek2017
{
	public class LevelEngine
	{
		DocumentationUI docUI;
		ScriptUI scriptUI;
		Door door1;
		public int GameState { get; set; }
		//const int 
		//const int EDITINGSCRIPT

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
