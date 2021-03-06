﻿using System;
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

        public string VariableName { get; private set; }
		public string Documentation { get; private set; }
        public bool IsOpen { get; private set; }
		public bool IsLocked { get; private set; }

        bool DirtyTexture { get; set; }

        public Door(ContentManager content, string name, float x = 0f, float y = 0f, float scale = 2f, float Angle = 0f) : base(null)
        {
            VariableName = name;

			Documentation = 
				"Door " + name + "\n\n" +
				"Methods\n" +
				"  Open() - opens the door if unlocked\n" +
				"  Unlock() - unlocks the door\n" +
				"  Lock() - locks the door\n\n" +
				"Properties\n" +
				"  Boolean IsOpen\n" +
				"  Boolean IsLocked";

			_openTexture = content.Load<Texture2D>(_openTextureName);
			_unlockedTexture = content.Load<Texture2D>(_unlockedTextureName);
			_lockedTexture = content.Load<Texture2D>(_lockedTextureName);

            // TODO: this shouldn't be hardcoded, should be retrieved from level data
            //
            CurrentTexture = _lockedTexture;
            IsLocked = true;
            IsOpen = false;
            X = 700;
            Y = 300;
			Scale = 2f;
		}
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
                DirtyTexture = true;
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
            DirtyTexture = true;

        }

		public void Lock()
		{
			Console.WriteLine("HOLY SHIT YOU LOCKED " + VariableName);
			IsLocked = true;
            DirtyTexture = true;

        }

		public void Unlock()
		{
			Console.WriteLine("HOLY SHIT YOU UNLOCKED " + VariableName);
            DirtyTexture = true;
            IsLocked = false;
		}


        // TODO: Possibly move to open / close unlock methods (this is running every frame)
        //
		public void Update()
		{
            if (DirtyTexture)
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
}
