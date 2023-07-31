using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGUI.GameGL
{
    class SmartEnemy : Enemy
    {
        GameTerminatorPlayer pacman;
        public SmartEnemy(Image img, GameCell cell, GameObjectType type, GameDirection direction , GameTerminatorPlayer pacman) : base(img, type)
        {
            this.Image = img;
            this.CurrentCell = cell;
            this.direction = direction;
            this.GameObjectType = type;
            this.pacman = pacman;
        }
        public SmartEnemy(char DisplayCharacter, GameCell cell, GameObjectType type, GameDirection direction , GameTerminatorPlayer pacman) : base(DisplayCharacter, type)
        {
            this.DisplayCharacter = DisplayCharacter;
            this.CurrentCell = cell;
            this.direction = direction;
            this.GameObjectType = type;
            this.pacman = pacman;
        }


        public double CalculateDistance(int x , int y , int px ,int py)
        {
            return Math.Sqrt(Math.Pow((px - x), 2) + Math.Pow((py -y), 2));
        }
        public override GameCell MoveGhost(GameGrid gameGrid)
        {
            double[] distance = new double[4] { 1000000, 1000000, 1000000, 1000000 };
            if (GameObjectType != GameObjectType.WALL)
            {
                distance[0] = (CalculateDistance(CurrentCell.X , CurrentCell.Y - 1, pacman.CurrentCell.X, pacman.CurrentCell.Y));
            }
            if (GameObjectType != GameObjectType.WALL)
            {
                distance[1] = (CalculateDistance(CurrentCell.X, CurrentCell.Y + 1, pacman.CurrentCell.X, pacman.CurrentCell.Y));
            }
            if (GameObjectType != GameObjectType.WALL)
            {
                distance[2] = (CalculateDistance(CurrentCell.X+1, CurrentCell.Y, pacman.CurrentCell.X, pacman.CurrentCell.Y));
            }
            if (GameObjectType != GameObjectType.WALL)
            {
                distance[3] = (CalculateDistance(CurrentCell.X - 1, CurrentCell.Y, pacman.CurrentCell.X, pacman.CurrentCell.Y));
            }

            GameCell currentCell = this.CurrentCell;
            if (distance[0] <= distance[1] && distance[0] <= distance[2] && distance[0] <= distance[3])
            {
                direction = GameDirection.Left;
                
                GameCell next = gameGrid.getCell(CurrentCell.X , CurrentCell.Y-1);

                if (next.CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
                {
                    RobotGame.SetFlag( false);
                }
                if (next.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                {

                    if (next != null)
                    {
                        currentCell.setGameObject(RobotGame.getCurrentObject(next));
                        CurrentCell = next;
                        return next;
                    }
                }
            }
            if (distance[1] <= distance[0] && distance[1] <= distance[2] && distance[1] <= distance[3])
            {
                direction = GameDirection.Right;
                
                GameCell next = gameGrid.getCell(CurrentCell.X, CurrentCell.Y+1);

                if (next.CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
                {
                    RobotGame.SetFlag( false);
                }

                if (next.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                {

                    if (next != null)
                    {
                        currentCell.setGameObject(RobotGame.getCurrentObject(next));
                        CurrentCell = next;
                        return next;
                    }
                }

            }
            if (distance[2] <= distance[0] && distance[2] <= distance[1] && distance[2] <= distance[3])
            {
                direction = GameDirection.Down;
                
                GameCell next = gameGrid.getCell(CurrentCell.X + 1, CurrentCell.Y);

                if (next.CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
                {
                    RobotGame.SetFlag(false);
                }
                if (next.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                {

                    if (next != null)
                    {
                        currentCell.setGameObject(RobotGame.getCurrentObject(next));
                        CurrentCell = next;
                        return next;
                    }
                }
            }
            else
            {
                direction = GameDirection.Up;               
                GameCell next = gameGrid.getCell(CurrentCell.X - 1, CurrentCell.Y);
                if (next.CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
                {
                    RobotGame.SetFlag(false);
                }
                if (next.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                {
                    if (next != null)
                    {
                        currentCell.setGameObject(RobotGame.getCurrentObject(next));
                        CurrentCell = next;
                        return next;
                    }
                }

            }
            return null;
        }
    }
}
