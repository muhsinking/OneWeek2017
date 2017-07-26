using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace OneWeek2017
{
    public abstract class SpriteBase
    {
        public Texture2D CurrentTexture {get; set;}
		public float X { get; set; }
		public float Y { get; set; }
		public float dX { get; set; }
		public float dY { get; set; }
		public float dA { get; set; }
		public float Angle { get; set; }
		public float Scale { get; set; }
		public float HitboxScale { get; set; }

		public SpriteBase(ContentManager content, string textureName, float X = 0f, float Y = 0f, float scale = 1f, float angle = 0f)
		{
			this.X = X;
			this.Y = Y;
			this.dX = 0;
			this.dY = 0;
			this.Angle = angle;
			this.Scale = scale;
			HitboxScale = 1f;
            CurrentTexture = content.Load<Texture2D>(textureName);
		}

        public SpriteBase(Texture2D texture, float X = 0f, float Y = 0f, float scale = 1f, float angle = 0f)
        {
            this.X = X;
            this.Y = Y;
            this.dX = 0;
            this.dY = 0;
            this.Angle = angle;
            this.Scale = scale;
            HitboxScale = 1f;
            CurrentTexture = texture;
        }

        public virtual void Update(float elapsedTime)
		{
			X += dX * elapsedTime;
			Y += dY * elapsedTime;
			Angle += dA * elapsedTime;
			//scale = Camera.scale;
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			//Vector2 spritePosition = new Vector2(X + Camera.X, Y + Camera.Y);
			Vector2 spritePosition = new Vector2(X, Y);
			spriteBatch.Draw(CurrentTexture, spritePosition, null, Color.White, Angle, new Vector2(CurrentTexture.Width / 2, CurrentTexture.Height / 2), new Vector2(Scale, Scale), SpriteEffects.None, 0f);
		}

		public Boolean RectangularCollision(SpriteBase otherSprite)
		{
			if (this.X + this.CurrentTexture.Width * this.Scale * this.HitboxScale / 2 <
				otherSprite.X - otherSprite.CurrentTexture.Width * otherSprite.Scale * otherSprite.HitboxScale / 2) return false;
			if (this.Y + this.CurrentTexture.Height * this.Scale * this.HitboxScale / 2 <
				otherSprite.Y - otherSprite.CurrentTexture.Height * otherSprite.Scale * otherSprite.HitboxScale / 2) return false;
			if (this.X - this.CurrentTexture.Width * this.Scale * this.HitboxScale / 2 >
				otherSprite.X + otherSprite.CurrentTexture.Width * otherSprite.Scale * otherSprite.HitboxScale / 2) return false;
			if (this.Y - this.CurrentTexture.Height * this.Scale * this.HitboxScale / 2 >
				otherSprite.Y + otherSprite.CurrentTexture.Height * otherSprite.Scale * otherSprite.HitboxScale / 2) return false;
			return true;
		}


		public Boolean PointCollision(Vector2 point)
		{
			// if point < right edge
			if (this.X + this.CurrentTexture.Width* this.Scale * this.HitboxScale / 2 <
			    point.X) return false;

			// if point < bottom edge
			if (this.Y + this.CurrentTexture.Height * this.Scale * this.HitboxScale / 2 <
				point.Y) return false;
			
			// if point > left edge
			if (this.X - this.CurrentTexture.Width * this.Scale * this.HitboxScale / 2 >
				point.X) return false;

			// if point > top edge
			if (this.Y - this.CurrentTexture.Height * this.Scale * this.HitboxScale / 2 >
			    point.Y) return false;
			
			return true;
		}
	}
}
