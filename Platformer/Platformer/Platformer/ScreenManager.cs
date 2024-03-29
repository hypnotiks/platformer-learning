﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class ScreenManager
    {
        #region Variables

        /// <summary>
        /// Creating custom contentManager
        /// </summary>

        ContentManager content;

        /// <summary>
        /// Current Screen that's being displayed
        /// </summary>

        GameScreen currentScreen;

        /// <summary>
        /// The new screen that will be taking effect
        /// </summary>

        GameScreen newScreen;

        /// <summary>
        /// ScreenManager Instance
        /// </summary>

        private static ScreenManager instance;

        /// <summary>
        /// Screen Stack
        /// </summary>

        Stack<GameScreen> screenStack = new Stack<GameScreen>();

        /// <summary>
        /// Screens width and height
        /// </summary>

        Vector2 dimensions;

        #endregion

        #region Properties

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }

        public Vector2 Dimensions
        {
            get { return dimensions; }
            set { dimensions = value; }
        }

        #endregion

        #region Main Methods

        public void AddScreen(GameScreen screen)
        {
            newScreen = screen;
            screenStack.Push(screen);
            currentScreen.UnloadContent();
            currentScreen = newScreen;
            currentScreen.LoadContent(content);
        }

        public void Initialize() 
        {
            currentScreen = new SplashScreen();
        }
        public void LoadContent(ContentManager Content) 
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(Content);
        }
        public void Update(GameTime gameTime) 
        {
            currentScreen.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch) 
        {
            currentScreen.Draw(spriteBatch);
        }

        #endregion
    }
}
