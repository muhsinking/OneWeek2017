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
	public class Door : SpriteBase, IScriptableObject
    {
		string _openTextureName = "door-open";
		string _unlockedTextureName = "door-unlocked";
		string _lockedTextureName = "door-locked";

		Texture2D _openTexture;
		Texture2D _unlockedTexture;
		Texture2D _lockedTexture;

		public Boolean IsOpen { get; set; }
		public Boolean IsLocked { get; set; }

        public Door(ContentManager content, string name, float x = 0f, float y = 0f, float scale = 1f, float angle = 0f) : base(null)
        {
            VariableName = name;

			_openTexture = content.Load<Texture2D>(_openTextureName);
			_unlockedTexture = content.Load<Texture2D>(_unlockedTextureName);
			_lockedTexture = content.Load<Texture2D>(_lockedTextureName);

            CurrentTexture = _lockedTexture;

            // TODO: this shouldn't be hardcoded, should be retrieved from level data
            //
            X = 700;
            Y = 300; 
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


        // TODO: Possibly move to open / close unlock methods (this is running every frame)
        //
		public void Update()
		{

			if (IsOpen)
			{
				CurrentTexture = _openTexture;
			}
			else if (IsLocked)
			{
                CurrentTexture = _lockedTexture;
			}
			else CurrentTexture = _unlockedTexture;
		}

    }
}
