using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacMan.GameGL;
using EZInput;
using PacManGUI.GameGL;
using Game.GameGL;

namespace PacManGUI
{
    public partial class Form1 : Form
    {
        List<Enemy> robot = new List<Enemy>();
        GameTerminatorPlayer player;
        HorizontalEnemy horizontal;
        VerticalEnemy vertical1;
        VerticalEnemy vertical2;
        VerticalEnemy vertical3;
        VerticalEnemy vertical4;
        VerticalEnemy vertical5;
        VerticalEnemy vertical6;
        VerticalEnemy vertical7;
        VerticalEnemy vertical8;
        RandomEnemy random;
        SmartEnemy smart;
        GameGrid grid;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            grid = new GameGrid("maze.txt", 17, 24);
            Image pacManImage = RobotGame.getGameObjectImage('p');
            GameCell startCell = grid.getCell(5, 8);
            GameCell v_Cell1 = grid.getCell(3, 22);
            GameCell v_Cell2 = grid.getCell(10, 1);
            GameCell v_Cell3 = grid.getCell(4, 4);
            GameCell v_Cell4 = grid.getCell(4, 18);
            GameCell v_Cell5 = grid.getCell(12, 4);
            GameCell v_Cell6 = grid.getCell(12, 18);
            GameCell v_Cell7 = grid.getCell(10, 7);
            GameCell v_Cell8 = grid.getCell(1, 1);
            GameCell s_cell = grid.getCell(15, 5);

            player = new GameTerminatorPlayer(pacManImage, startCell);
            vertical1 = new VerticalEnemy(Properties.Resources.V_Enemy_Robot, v_Cell1, GameObjectType.ENEMY, GameDirection.Up);
            vertical2 = new VerticalEnemy(Properties.Resources.V_Enemy1, v_Cell2, GameObjectType.ENEMY, GameDirection.Up);
            vertical3 = new VerticalEnemy(Properties.Resources.V_Enemy1, v_Cell3, GameObjectType.ENEMY, GameDirection.Up);
            vertical4 = new VerticalEnemy(Properties.Resources.V_Enemy_Robot, v_Cell4, GameObjectType.ENEMY, GameDirection.Up);
            vertical5 = new VerticalEnemy(Properties.Resources.V_Enemy1, v_Cell5, GameObjectType.ENEMY, GameDirection.Up);
            vertical6 = new VerticalEnemy(Properties.Resources.V_Enemy_Robot, v_Cell6, GameObjectType.ENEMY, GameDirection.Up);
            //  vertical7 = new VerticalEnemy(Properties.Resources.ee, v_Cell7, GameObjectType.ENEMY, GameDirection.Up);
            //  vertical8 = new VerticalEnemy(Properties.Resources.dd, v_Cell8, GameObjectType.ENEMY, GameDirection.Up);
            // smart = new SmartEnemy(Properties.Resources.s_Enemy, s_cell, GameObjectType.ENEMY, GameDirection.Up, player);

            robot.Add(vertical1);
            robot.Add(vertical2);
            robot.Add(vertical3);
            robot.Add(vertical4);
            robot.Add(vertical5);
            robot.Add(vertical6);

            // robot.Add(smart);
            printMaze(grid);
        }
        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {
                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    this.Controls.Add(cell.PictureBox);

                }

            }
        }
        static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.Y, cell.X);
            Console.Write(cell.CurrentGameObject.DisplayCharacter);
        }
        private List<GameFire> bulletsPlayerRight = new List<GameFire>();
        private List<GameFire> bulletsPlayerLeft = new List<GameFire>();// Initialize the list to store player bullets
        private int playerBulletsCounter = 0;
        private int player1BulletsCounter = 0;
        private const int maxPlayerBullets = 3; // Set the maximum number of player bullets
        private void GeneratePlayerBulletRight()
        {
            if (playerBulletsCounter >= maxPlayerBullets)
            {
                // Create a new GameCell for the player bullet at the player's current position
                GameCell playerBulletCell = new GameCell(player.CurrentCell.X, player.CurrentCell.Y, grid);
                // Create a new GameFire instance representing the player bullet
                GameFire playerBullet = new GameFire(Properties.Resources.bPB, GameObjectType.Fire, playerBulletCell);
                // Add the player bullet to the bulletsPlayer list
                bulletsPlayerRight.Add(playerBullet);
                // Reset the playerBulletsCounter
                playerBulletsCounter = 0;
            }
        }
        private void GeneratePlayerBulletLeft()
        {
            if (player1BulletsCounter >= maxPlayerBullets)
            {
                GameCell playerBulletCell = new GameCell(player.CurrentCell.X, player.CurrentCell.Y, grid);
                GameFire playerBullet = new GameFire(Properties.Resources.R, GameObjectType.Fire, playerBulletCell);
                bulletsPlayerLeft.Add(playerBullet);
                player1BulletsCounter = 0;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click_1(object sender, EventArgs e)
        {

        }
        private void gameLoop_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                player.move(GameDirection.Left);
                if (RobotGame.GetFireCheck() == true)
                {
                    progressBar1.Value -= 20;
                    player.Set_BulletCheckPlayer(false);
                }
            }

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                player.move(GameDirection.Right);
                if (RobotGame.GetFireCheck() == true)
                {
                    progressBar1.Value -= 20;
                    RobotGame.SetFireCheck(false);
                }
            }

            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                player.move(GameDirection.Up);
                if (RobotGame.GetFireCheck() == true)
                {
                    progressBar1.Value -= 20;
                    RobotGame.SetFireCheck(false);
                }
            }

            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                player.move(GameDirection.Down);
                if (RobotGame.GetFireCheck() == true)
                {
                    progressBar1.Value -= 20;
                    RobotGame.SetFireCheck(false);
                }

            }

            if (Keyboard.IsKeyPressed(Key.Space))
            {
                GeneratePlayerBulletRight();
                if (RobotGame.GetFireCheck() == true)
                {
                    progressBar1.Value -= 20;
                    RobotGame.SetFireCheck(false);
                }
            }
            if (RobotGame.GetFireCheck() == true)
            {
                progressBar1.Value -= 40;
                RobotGame.SetFireCheck(false);
            }

            if (Keyboard.IsKeyPressed(Key.Control))
            {
                GeneratePlayerBulletLeft();
                if (RobotGame.GetFireCheck() == true)
                {
                    progressBar1.Value -= 40;
                    RobotGame.SetFireCheck(false);
                }
            }

            foreach (Enemy i in robot)
            {
                i.MoveGhost(grid);

            }
            if (progressBar1.Value < 5)
            {
                gameLoop.Enabled = false;

                Form f = new LoseForm();
                f.Show();
                this.Hide();

            }
            if (vertical1.health == 0 && vertical2.health == 0 && vertical3.health == 0 && vertical4.health == 0 &&
               vertical5.health == 0 && vertical6.health == 0)
            {
                //&& smart.health == 0
                //  robot.Add(vertical7);
                // robot.Add(vertical8);
                Form f = new Win();
                f.Show();
                gameLoop.Enabled = false;

               
                this.Hide();

            }
            CheckGameState();
            if (vertical1.health == 0 && robot.Contains(vertical1))
            {
                robot.Remove(vertical1);
                pictureBox3.Hide();
                vertical1.CurrentCell.PictureBox.Image = Properties.Resources.Empty;

            }

            if (vertical2.health == 0 && robot.Contains(vertical2))
            {

                robot.Remove(vertical2);
                pictureBox7.Hide();

                vertical2.CurrentCell.PictureBox.Image = Properties.Resources.Empty;

            }

            if (vertical3.health == 0 && robot.Contains(vertical3))
            {


                robot.Remove(vertical3);
                vertical3.CurrentCell.PictureBox.Image = Properties.Resources.Empty;
                pictureBox6.Hide();

            }

            if (vertical4.health == 0 && robot.Contains(vertical4))
            {
                robot.Remove(vertical4);
                pictureBox5.Hide();
                vertical4.CurrentCell.PictureBox.Image = Properties.Resources.Empty;

            }
            if (vertical5.health == 0 && robot.Contains(vertical5))
            {
                pictureBox4.Hide();
                robot.Remove(vertical5);
                vertical5.CurrentCell.PictureBox.Image = Properties.Resources.Empty;
            }
            if (vertical6.health == 0 && robot.Contains(vertical6))
            {
                pictureBox8.Hide();
                robot.Remove(vertical6);
                vertical6.CurrentCell.PictureBox.Image = Properties.Resources.Empty;
            }
            //if (smart.health == 0 && robot.Contains(smart))
            //{
            //    pictureBox9.Hide();
            //    robot.Remove(smart);
            //    smart.CurrentCell.PictureBox.Image = Properties.Resources.Empty;
            //}

            if (score == 100)
            {
                gameLoop.Enabled = false;
                Form f = new Win();
                f.Show();
                this.Hide();
            }
            if (!RobotGame.GetFlag())
            {
                gameLoop.Enabled = false;
                Form f = new LoseForm();
                f.Show();
                this.Hide();
            }
            score = RobotGame.ReturnScore();
            lblScore.Text = score.ToString();



            foreach (GameFire fire in bulletsPlayerLeft)
            {
                fire.MovePlayerFireRight(grid);

                if (!fire.GetFlag())
                {

                    fire.CurrentCell.PictureBox.Image = Properties.Resources.Empty;
                    bulletsPlayerLeft.Remove(fire);
                    break;
                }

            }
            foreach (GameFire fire in bulletsPlayerRight)
            {
                fire.MovePlayerFireLeft(grid);

                if (!fire.GetFlag())
                {

                    fire.CurrentCell.PictureBox.Image = Properties.Resources.Empty;

                    bulletsPlayerRight.Remove(fire);
                    break;

                }

            }
            GenerateVerticalEnemyBulletLeft();
            GenerateVerticalEnemyBulletRight();
            foreach (GameFire i in V_FireLeft)
            {
                i.MoveEnemyFireLeft(grid);
                if (!i.GetFlag())
                {
                    V_FireLeft.Remove(i);
                    i.CurrentCell.PictureBox.Image = Properties.Resources.Empty;
                    break;
                }
            }
            foreach (GameFire i in V_FireRight)
            {
                i.MoveEnemyFireRight(grid);
                if (!i.GetFlag())
                {
                    V_FireRight.Remove(i);
                    i.CurrentCell.PictureBox.Image = Properties.Resources.Empty;
                    break;
                }
            }
            playerBulletsCounter++;
            player1BulletsCounter++;
            vertical_EnemyCounterLeft++;
            vertical_EnemyCounterRight++;
        }

        private int vertical_EnemyCounterLeft = 15;
        private int vertical_EnemyCounterRight = 15;
        GameCell V1_FireCell, V2_FireCell, V3_FireCell, V4_FireCell, V5_FireCell, V6_FireCell;
        GameFire V1_EnemyFire, V2_EnemyFire, V3_EnemyFire, V4_EnemyFire, V5_EnemyFire, V6_EnemyFire;

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        List<GameFire> V_FireLeft = new List<GameFire>();
        List<GameFire> V_FireRight = new List<GameFire>();
        private void GenerateVerticalEnemyBulletLeft()
        {
            if (vertical_EnemyCounterLeft >= 18)
            {
                if (vertical1 != null && robot.Contains(vertical1))
                {
                    V1_FireCell = new GameCell(vertical1.CurrentCell.X, vertical1.CurrentCell.Y, grid);
                    V1_EnemyFire = new GameFire(Properties.Resources.pB, GameObjectType.FireEnemy, V1_FireCell);
                    V_FireLeft.Add(V1_EnemyFire);
                }

                if (vertical4 != null && robot.Contains(vertical4))
                {
                    V4_FireCell = new GameCell(vertical4.CurrentCell.X, vertical4.CurrentCell.Y, grid);
                    V4_EnemyFire = new GameFire(Properties.Resources.pB, GameObjectType.FireEnemy, V4_FireCell);
                    V_FireLeft.Add(V4_EnemyFire);
                }
                if (vertical6 != null && robot.Contains(vertical6))
                {
                    V6_FireCell = new GameCell(vertical6.CurrentCell.X, vertical6.CurrentCell.Y, grid);
                    V6_EnemyFire = new GameFire(Properties.Resources.pB, GameObjectType.FireEnemy, V6_FireCell);
                    V_FireLeft.Add(V6_EnemyFire);
                }


                vertical_EnemyCounterLeft = 0;
            }

        }
        private void GenerateVerticalEnemyBulletRight()
        {
            if (vertical_EnemyCounterRight >= 18)
            {
                if (vertical2 != null && robot.Contains(vertical2))
                {
                    V2_FireCell = new GameCell(vertical2.CurrentCell.X, vertical2.CurrentCell.Y, grid);
                    V2_EnemyFire = new GameFire(Properties.Resources.v_R, GameObjectType.FireEnemy, V2_FireCell);
                    V_FireRight.Add(V2_EnemyFire);
                }

                if (vertical3 != null && robot.Contains(vertical3))
                {
                    V3_FireCell = new GameCell(vertical3.CurrentCell.X, vertical3.CurrentCell.Y, grid);
                    V3_EnemyFire = new GameFire(Properties.Resources.v_R, GameObjectType.FireEnemy, V3_FireCell);
                    V_FireRight.Add(V3_EnemyFire);
                }

                if (vertical5 != null && robot.Contains(vertical5))
                {
                    V5_FireCell = new GameCell(vertical5.CurrentCell.X, vertical5.CurrentCell.Y, grid);
                    V5_EnemyFire = new GameFire(Properties.Resources.v_R, GameObjectType.FireEnemy, V5_FireCell);
                    V_FireRight.Add(V5_EnemyFire);
                }
                vertical_EnemyCounterRight = 0;
            }
        }
        private void CheckGameState()
        {
            bool allEnemiesDead = true;

            foreach (Enemy enemy in robot)
            {
                if (enemy.health > 0)
                {
                    allEnemiesDead = false;
                    break;
                }
            }

            if (allEnemiesDead)
            {
                gameLoop.Enabled = false;
                Form f = new Win();
                f.Show();
                this.Close();
            }
        }

    }
}
