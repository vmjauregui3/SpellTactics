﻿using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpellTactics
{
    public class InputManager
    {
        KeyboardState currentKeyState, prevKeyState;

        private static InputManager instance;
        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                { instance = new InputManager(); }
                return instance;
            }
        }

        public void Update(GameTime gameTime)
        {
            prevKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
        }

        public bool KeyPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key))
                { return true; }
            }
            return false;
        }

        public bool KeyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyUp(key) && prevKeyState.IsKeyDown(key))
                { return true; }
            }
            return false;
        }

        public bool KeyDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyDown(key))
                { return true; }
            }
            return false;
        }
    }
}
