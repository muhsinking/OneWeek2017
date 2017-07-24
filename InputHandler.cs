using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneWeek2017
{
    class InputHandler
    {

        EventHandler<TextInputEventArgs> onTextEntered;

        private static InputHandler _instance;
        private KeyboardState _prevKeyState;
        private Dictionary<char, List<Action<char>>> _keyEvents;
        private GameWindow _window;

        public static InputHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InputHandler();
                }
                return _instance;
            }
        }

        private InputHandler()
        {
            _keyEvents = new Dictionary<char, List<Action<char>>>();
        }

        public void Initialize(GameWindow window)
        {
            _window = window;
#if OpenGL
            _window.TextInput += TextEntered;
            onTextEntered += HandleInput;
#else
            _window.TextInput += HandleInput;
#endif
        }

        public void RegisterKeyEvent(char c, Action<char> keyEvent)
        {
            if(_keyEvents.ContainsKey(c))
            {
                _keyEvents[c].Add(keyEvent);
            }
            else
            {
                List<Action<char>> newEventList = new List<Action<char>>();
                newEventList.Add(keyEvent);

                _keyEvents[c] = newEventList;     
            }
        }

        private void TextEntered(object sender, TextInputEventArgs e)
        {
            if (onTextEntered != null)
            {
                onTextEntered.Invoke(sender, e);
            }              
        }

        private void HandleInput(object sender, TextInputEventArgs e)
        {
            char charEntered = e.Character;

            List<Action<char>> events = new List<Action<char>>() ;

            if (_keyEvents.TryGetValue(charEntered, out events))
            {
                foreach(Action<char> currentEvent in events)
                {
                    currentEvent.Invoke(charEntered);
                }

            }
        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();

            // Some special characters aren't handled well in OpenGL
#if OpenGL
            if (keyState.IsKeyDown(Keys.Back) && _prevKeyState.IsKeyUp(Keys.Back))
            {
                HandleInput(this, new TextInputEventArgs('\b'));
            }
            if (keyState.IsKeyDown(Keys.Enter) && _prevKeyState.IsKeyUp(Keys.Enter))
            {
                HandleInput(this, new TextInputEventArgs('\n'));
            }
            if (keyState.IsKeyDown(Keys.Tab) && _prevKeyState.IsKeyUp(Keys.Tab))
            {
                HandleInput(this, new TextInputEventArgs('\t'));
            }

            // Handle other special characters here
#endif
            _prevKeyState = keyState;
        }
    }
}
