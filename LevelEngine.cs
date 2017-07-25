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
        

		public LevelEngine(ContentManager content, Vector2 windowDimensions)
		{
			docUI = new DocumentationUI(content, windowDimensions);
			scriptUI = new ScriptUI(content, windowDimensions);
            
            // TODO: Hardcoded to listen on ESC key. Should be on a button or something
            //
            InputHandler.Instance.RegisterKeyEvent('\u001b', x => ExecuteCode());

        }

		public void Update(float elapsedTime)
		{
			docUI.Update(elapsedTime);
			scriptUI.Update(elapsedTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			scriptUI.Draw(spriteBatch);
			docUI.Draw(spriteBatch);
		}

		public void ExecuteCode()
		{
            // TODO: Need to do level setup elsewhere
            //
            Door door = new Door("door1");
            List<IScriptableObject> objects = new List<IScriptableObject>();
            objects.Add(door);
            CompileHelper.ExecuteRoom(objects, scriptUI.PlayerScript);
        }

		public void HandleCollision()
		{
			
		}

	}
}
