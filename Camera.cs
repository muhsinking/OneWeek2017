using System;
using Microsoft.Xna.Framework.Input;

namespace OneWeek2017
{
	public static class Camera
	{
		public static float X = 0;
		public static float Y = 0;
		public static float speed = 300f;
		public static float scale = 2f;

		// TODO make this non framerate dependent
		public static void HandleInput(float elapsedTime)
		{
			KeyboardState state = Keyboard.GetState();
			if (state.IsKeyDown(Keys.Up))
			{
				Y -= speed * elapsedTime;
			}
			if (state.IsKeyDown(Keys.Down))
			{
				Y += speed * elapsedTime;
			}
			if (state.IsKeyDown(Keys.Left))
			{
				X -= speed * elapsedTime;
			}
			if (state.IsKeyDown(Keys.Right))
			{
				X += speed * elapsedTime;
			}
		}
	}
}
