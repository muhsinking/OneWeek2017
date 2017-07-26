using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneWeek2017
{
    class Tile : SpriteBase
    {

        private List<IScriptableObject> _objectsInTile;

        public Tile(Texture2D texture, float x = 0f, float y = 0f, float scale = 1f, float angle = 0f) 
            : base(texture)
        {
            _objectsInTile = new List<IScriptableObject>();
        }

        public void AddObject(IScriptableObject obj)
        {
            _objectsInTile.Add(obj);
        }
    }
}
