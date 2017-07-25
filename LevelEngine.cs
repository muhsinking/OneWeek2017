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
        Door door;

		public LevelEngine(ContentManager content, Vector2 windowDimensions)
		{
			docUI = new DocumentationUI(content, windowDimensions);
			scriptUI = new ScriptUI(content, windowDimensions);

            door = new Door("door1");
            List<IScriptableObject> objects = new List<IScriptableObject>();
            objects.Add(door);
            InputHandler.Instance.RegisterKeyEvent('\u000D', x => CompileHelper.ExecuteRoom(objects, "door1.Open();"));
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

		public void HandleInput()
		{
			
		}

		public void HandleCollision()
		{
			
		}

	}
}
