using System;
using Microsoft.Xna.Framework;

namespace OneWeek2017
{
	public class ScriptRenderHelper
	{
		public int CursorDrawPosition { get; set; }
		public string DrawableString { get; set; }
		private int _maxCharsPerLine;

		public ScriptRenderHelper(int maxCharsPerLine)
		{
			_maxCharsPerLine = maxCharsPerLine;
		}


		// TODO: review and make more better
		// updates cursor draw position and drawable string based on current script and cursor position
		public void Update(string playerScript, int cursorPosition)
		{
			DrawableString = playerScript;

			int charactersInThisLine = 0;

			int offset = 0;
			//int tempCursorDraw = 0
			CursorDrawPosition = 0;

			for (int i = 0; i < playerScript.Length; i++)
			{
				if (DrawableString[i + offset] == '\n')
				{
					if(i < cursorPosition) CursorDrawPosition += _maxCharsPerLine - charactersInThisLine;

					charactersInThisLine = 0;
					DrawableString = DrawableString.Insert(i + offset, "\n");
					offset++;

					if(i < cursorPosition) CursorDrawPosition += _maxCharsPerLine;
 
				}

				else if (i > 0 && charactersInThisLine % _maxCharsPerLine == 0 && DrawableString[i + offset - 1] != '\n')
				{
					if(i < cursorPosition) CursorDrawPosition++;
					DrawableString = DrawableString.Insert(i + offset, "\n");
					offset++;
					charactersInThisLine = 1;
				}
				else
				{
					charactersInThisLine++;
					if(i < cursorPosition) CursorDrawPosition++;
				}

			}
		}


	}
}
