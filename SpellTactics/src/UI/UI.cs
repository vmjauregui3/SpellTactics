using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SpellTactics;

namespace SpellTactics
{
    public class UI
    {
        private SpriteFont font;
        private Vector2 screenOrigin;

        private TileMarker turnMarker;
        private TileMarker selectedObjectMarker;
        private List<TileHighlight> highlightTiles;
        public bool ShowingMovement;

        //private string killCountString;
        private DisplayBar healthBar;
        private DisplayBar manaBar;

        private int barWidth;
        private int barHeight;
        private int barBorder;
        public UI()
        {
            //font = SpellTactics.STContent.Load<SpriteFont>("Fonts/ComicSansMS16");
            //killCountString = "Enemies Killed: ";
            barWidth = 64;
            barHeight = 12;
            barBorder = 2;
            healthBar = new DisplayBar(new Vector2(barWidth, barHeight), barBorder, Color.Red);
            manaBar = new DisplayBar(new Vector2(barWidth, barHeight), barBorder, Color.Blue);
            turnMarker = new TileMarker(Color.Green);
            highlightTiles = new List<TileHighlight>();
            ShowingMovement = false;
        }

        public void Update(Creature creatureTurn)
        {
            screenOrigin = Vector2.Transform(Vector2.Zero, Matrix.Invert(Camera.Instance.Transform));
            //healthBar.Update(creatureTurn.Health.Value, creatureTurn.Health.ValueMax, screenOrigin, barHeight);
            //manaBar.Update(creatureTurn.Mana.Value, creatureTurn.Mana.ValueMax, screenOrigin, 0);

            turnMarker.Update(creatureTurn.Position);

            healthBar.Update(creatureTurn.Health.Value, creatureTurn.Health.ValueMax, new Vector2(creatureTurn.Position.X, creatureTurn.Position.Y-2*barHeight));
            manaBar.Update(creatureTurn.Mana.Value, creatureTurn.Mana.ValueMax, new Vector2(creatureTurn.Position.X, creatureTurn.Position.Y-barHeight));
        }

        public void HighlightMovement(Dictionary<Vector2, Destructible> destructibles, Creature creatureTurn, int radius)
        {
            ClearHighlight();
            if (!ShowingMovement)
            {
                for (int i = radius; i >= -radius; i--)
                {
                    for (int j = radius; j >= -radius; j--)
                    {
                        highlightTiles.Add(new TileHighlight(GameFunctions.MapPosToPos(new Vector2(creatureTurn.MapPosition.X + i, creatureTurn.MapPosition.Y + j)), Color.CornflowerBlue));
                    }
                }
                ShowingMovement = true;
            }
            else
            {
                ShowingMovement = false;
            }
        }

        public void ClearHighlight()
        {
            highlightTiles.Clear();
        }

        public void EndTurn()
        {
            ClearHighlight();
            ShowingMovement = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Vector2 stringDimensions = font.MeasureString(killCountString + world.NumKilled);
            //spriteBatch.DrawString(font, killCountString + world.NumKilled, new Vector2(10, 10) + screenOrigin, Color.Black);

            turnMarker.Draw(spriteBatch);

            foreach (TileHighlight tile in highlightTiles)
            {
                tile.Draw(spriteBatch);
            }

            healthBar.Draw(spriteBatch);
            manaBar.Draw(spriteBatch);
        }
    }
}