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
        public TileMarker selectedTile;
        private List<TileHighlight> highlightTiles;
        public bool ShowingMovement;
        public bool ValidMovement;

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
            selectedTile = new TileMarker();
            highlightTiles = new List<TileHighlight>();
            ShowingMovement = false;
            ValidMovement = false;
        }

        public void Update(Creature creatureTurn)
        {
            screenOrigin = Vector2.Transform(Vector2.Zero, Matrix.Invert(Camera.Instance.Transform));
            //healthBar.Update(creatureTurn.Health.Value, creatureTurn.Health.ValueMax, screenOrigin, barHeight);
            //manaBar.Update(creatureTurn.Mana.Value, creatureTurn.Mana.ValueMax, screenOrigin, 0);

            turnMarker.Update(creatureTurn.MapPosition);

            healthBar.Update(creatureTurn.Health.Value, creatureTurn.Health.ValueMax, new Vector2(creatureTurn.Position.X, creatureTurn.Position.Y-2*barHeight));
            manaBar.Update(creatureTurn.Mana.Value, creatureTurn.Mana.ValueMax, new Vector2(creatureTurn.Position.X, creatureTurn.Position.Y-barHeight));
        }

        public void HighlightMovement(List<Destructible> destructibles, Creature creatureTurn, int radius)
        {
            ClearHighlight();
            ClearSelectedTile();
            if (!ShowingMovement)
            {
                for (int i = radius; i >= -radius; i--)
                {
                    for (int j = radius; j >= -radius; j--)
                    {
                        Vector2 temp = new Vector2(creatureTurn.MapPosition.X + i, creatureTurn.MapPosition.Y + j);
                        if ( (temp.X >= 0) && (temp.Y >= 0))
                        {
                            highlightTiles.Add(new TileHighlight(temp, Color.CornflowerBlue));
                        }
                    }
                }
                ShowingMovement = true;
            }
            else
            {
                ShowingMovement = false;
            }
        }

        public void MoveCreature()
        {
            ClearHighlight();
            ClearSelectedTile();
            ShowingMovement = false;
            ValidMovement = false;
        }

        public void ClearHighlight()
        {
            highlightTiles.Clear();
        }

        public void SelectTile(Vector2 mapPos, bool objectSelected)
        {
            ClearSelectedTile();
            Color selectColor = Color.Orange;
            ValidMovement = false;

            if (objectSelected)
            {
                selectColor = Color.Purple;
            }
            if (ShowingMovement && objectSelected)
            {
                selectColor = Color.Red;
            }
            else if (ShowingMovement)
            {
                selectColor = Color.Red;
                foreach (TileHighlight tile in highlightTiles)
                {
                    if (tile.MapPosition.Equals(mapPos))
                    {
                        ValidMovement = true;
                        selectColor = Color.DarkBlue;
                    }
                }
            }
            selectedTile = new TileMarker(selectColor, mapPos);
        }

        public void ClearSelectedTile()
        {
            selectedTile = new TileMarker();
        }

        public void EndTurn()
        {
            ClearHighlight();
            ClearSelectedTile();
            ShowingMovement = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Vector2 stringDimensions = font.MeasureString(killCountString + world.NumKilled);
            //spriteBatch.DrawString(font, killCountString + world.NumKilled, new Vector2(10, 10) + screenOrigin, Color.Black);

            turnMarker.Draw(spriteBatch);

            selectedTile.Draw(spriteBatch);

            foreach (TileHighlight tile in highlightTiles)
            {
                tile.Draw(spriteBatch);
            }

            healthBar.Draw(spriteBatch);
            manaBar.Draw(spriteBatch);
        }
    }
}