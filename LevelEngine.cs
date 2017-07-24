using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

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
		}

		public void Update(float elapsedTime)
		{
			docUI.Update(elapsedTime);
			scriptUI.Update(elapsedTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			docUI.Draw(spriteBatch);
			scriptUI.Draw(spriteBatch);
		}

		public void HandleInput()
		{
			
		}

		public void HandleCollision()
		{
			
		}

	}
}
