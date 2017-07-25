using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OneWeek2017
{
	// Create superclass that handles multiple sprite states and animation sheets
	public class Door : IScriptableObject
    {
		string _openTextureName = "door-open";
		string _unlockedTextureName = "door-unlocked";
		string _lockedTextureName = "door-locked";

		Texture2D _openTexture;
		Texture2D _unlockedTexture;
		Texture2D _lockedTexture;
		Texture2D _currentTexture;

		public Boolean IsOpen { get; set; }
		public Boolean IsLocked { get; set; }

		Vector2 positionOnscreen;

        public Door(ContentManager content, string name)
        {
            VariableName = name;

			_openTexture = content.Load<Texture2D>(_openTextureName);
			_unlockedTexture = content.Load<Texture2D>(_unlockedTextureName);
			_lockedTexture = content.Load<Texture2D>(_lockedTextureName);
			_currentTexture = _lockedTexture;

			positionOnscreen = new Vector2(700,300); //TODO this shouldn't be hardcoded, should be retrieved from level data
        }

        public string VariableName { get; set; }

        public string GetParameterizedName()
        {
            return "Door " + VariableName;
        }

		// Visual response if you try to open a locked door
        public void Open()
        {

			if (!IsLocked)
			{
				IsOpen = true;
				Console.WriteLine("HOLY SHIT YOU OPENED " + VariableName);
			}
			else
			{
				Console.WriteLine(VariableName + " IS LOCKED, ASSHOLE");
			}
        }

		public void Close()
		{
			Console.WriteLine("HOLY SHIT YOU CLOSED " + VariableName);
			IsOpen = false;
		}

		public void Lock()
		{
			Console.WriteLine("HOLY SHIT YOU LOCKED " + VariableName);
			IsLocked = true;
		}

		public void Unlock()
		{
			Console.WriteLine("HOLY SHIT YOU UNLOCKED " + VariableName);
			IsLocked = false;;
		}

		public void Update()
		{
			if (IsOpen)
			{
				_currentTexture = _openTexture;
			}
			else if (IsLocked)
			{
				_currentTexture = _lockedTexture;
			}
			else _currentTexture = _unlockedTexture;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_currentTexture, positionOnscreen, null, Color.White, 0f, new Vector2(0, 0), new Vector2(2f, 2f), SpriteEffects.None, 0f);
		}
    }
}
