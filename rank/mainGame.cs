using rank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace rank
{

    public partial class mainGame : Form
    {
        private Timer timer;
        private readonly int scrollSpeed = 1;
        private int position = 0;
        private readonly System.Windows.Forms.PictureBox backgroundPictureBox;  //배경 설정

        private readonly PictureBox ch;
        private int jumpHeight = 0;
        private bool isJumping = false;    //캐릭터 설정

        private int obstacleType;
        private List<Obstacle> obstacles;
        int score = 0;
        int x = 50;
        private DateTime startTime;
        private int scoreUpdateInterval = 7000; //7초마다 5점 증가, 플레이 시간에 따른 점수 부가
        private Timer obstacleTimer;
        private bool gameStopped = false;   //점수랑 장애물 설정

        public mainGame()
        {
            InitializeComponent();
            InitializeTimer();

            label1.BackColor = Color.Transparent;  //점수판 디자인 고민
            label2.BackColor = Color.Transparent;
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label1.Location = new Point(500, 30);
            label2.Location = new Point(450, 30);

            this.DoubleBuffered = true;
            backgroundPictureBox = new System.Windows.Forms.PictureBox();
            backgroundPictureBox.Size = new Size(pictureBox1.Width, pictureBox1.Height);

            this.Size = new Size(1000, 650);   //나중에 배경 사이즈 & 속도 조절 해야함
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            ch = new PictureBox();
            ch.Size = new Size(Properties.Resources.ch.Width, Properties.Resources.ch.Height);
            ch.Image = Properties.Resources.ch;
            jumpHeight = 0; // 초기 시작 높이, 0이 아니라면 처음에 캐릭터가 바닥에 있지 않고 추락하면서 시작함


            Timer jumpTimer = new Timer();
            jumpTimer.Interval = 40;
            jumpTimer.Tick += new EventHandler(JumpTimer_Tick);
            jumpTimer.Start();

            obstacles = new List<Obstacle>();
            this.obstacleTimer = new Timer();
            this.obstacleTimer.Interval = 1000; // 장애물 생성 간격
            this.obstacleTimer.Tick += new EventHandler(ObstacleTimer_Tick);
            this.obstacleTimer.Start();
            startTime = DateTime.Now;

            this.MouseClick += Fm_Click;
            pictureBox1.MouseClick += Fm_Click;

        }

        string nickname = string.Empty;
        public string NickName(string nickName)
        {
            // nickname 값을 설정에 저장
            Properties.Settings.Default.nickname = nickName;
            Properties.Settings.Default.Save();

            // nickname 변수에도 할당
            return nickname = nickName;
        }
        private void mainGame_Load(object sender, EventArgs e)
        {
            // 설정에서 nickname 값을 가져와서 레이블에 표시
            this.Text = Properties.Settings.Default.nickname;
        }

        private void InitializeTimer()
        {
            timer = new Timer { Interval = 30, Enabled = true };
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            position -= scrollSpeed;

            // 배경 이미지 크기에 맞게 조절
            /*  if (position <= -backgroundPictureBox.Width)
              {
                  position =0;
              }*/

            // 화면 갱신
            Invalidate();
        }
        public class Obstacle
        {
            public float StartX { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public Image Image { get; set; }
            public int ObstacleType { get; private set; }

            public Obstacle(float startX, int y, Image image, int obstacleType)
            {
                StartX = startX;
                Y = y;
                Width = image.Width;
                Height = image.Height;
                Image = image;
                ObstacleType = obstacleType;

            }
        }

        private void ObstacleTimer_Tick(object sender, EventArgs e)
        {
            if (!gameStopped)
            {
                Obstacle newObstacle = CreateRandomObstacle();
                obstacles.Add(newObstacle);
            }
        }

        private Obstacle CreateRandomObstacle()
        {
            Image obstacleImage;

            obstacleType = new Random().Next(2); //0과 1 랜덤하게 생성
            if (obstacleType == 0)
            {
                obstacleImage = Properties.Resources.장애물1; // 장애물1
            }
            else
            {
                obstacleImage = Properties.Resources.장애물2; // 장애물2, 장애물 크기 더 높여서 점프 되는지 확인해야함
            }



            int characterGroundHeight = pictureBox1.Height - 70;

            // 현재 생성된 장애물의 오른쪽에 위치시킴
            float lastObstacleX = obstacles.Count > 0 ? obstacles[obstacles.Count - 1].StartX + obstacles[obstacles.Count - 1].Width : this.Width - obstacleImage.Width;

            // 장애물 생성, 숫자는 장애물 간격 설정하는 것
            return new Obstacle(lastObstacleX + obstacleImage.Width + 180, characterGroundHeight - obstacleImage.Height, obstacleImage, obstacleType);

        }

        private void CheckObstacleCollision()
        {
            if (gameStopped)
                return;

            bool jumped = false;

            // 장애물을 넘었는지 확인
            for (int i = 0; i < obstacles.Count; i++)
            {
                Obstacle obstacle = obstacles[i];


                if (ch.Right > obstacle.StartX + obstacle.Width)
                {
                    jumped = true;


                    if (obstacle.ObstacleType == 0) //작은 장애물 10점
                    {
                        score += 10;
                    }
                    else if (obstacle.ObstacleType == 1) //큰 장애물 20점
                    {
                        score += 20;
                    }

                    obstacles.RemoveAt(i);
                    i--;
                }


            }

            if (jumped)
            {
                Invoke(new Action(delegate () {
                    label1.Text = score.ToString();
                }));
            }

            if (IsCharacterCollided())
            {
                ShowGameOverMessage();

            }
        }

        private void MoveObstacles()
        {
            for (int i = obstacles.Count - 1; i >= 0; i--)
            {
                Obstacle obstacle = obstacles[i];
                obstacle.StartX -= 5; // 이동 속도 조절

                // 장애물이 왼쪽 끝으로 이동하면 리스트에서 제거
                if (obstacle.StartX + obstacle.Width <= 0)
                {
                    obstacles.RemoveAt(i);
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a bitmap to draw on
            Bitmap bitmap = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {

                int imageWidth = backgroundPictureBox.Width;
                int imageHeight = backgroundPictureBox.Height;

                // 현재 위치부터 배경 이미지를 계속해서 이어서 그리기
                int currentPosition = position;
                while (currentPosition <= Width)
                {
                    g.DrawImage(Properties.Resources.background, currentPosition, 0, imageWidth, imageHeight);
                    currentPosition += imageWidth;
                }

                foreach (Obstacle obstacle in obstacles)
                {
                    g.DrawImage(obstacle.Image, obstacle.StartX, obstacle.Y, obstacle.Width, obstacle.Height);
                }

                int y = pictureBox1.Height - 130 - jumpHeight;

                g.DrawImage(Properties.Resources.ch, x, y, ch.Width, ch.Height);
            }

            // Draw the bitmap onto the PictureBox
            pictureBox1.Image = bitmap;
        }




        private bool IsCharacterCollided()
        {
            if (gameStopped)
                return false;

            // 캐릭터와 장애물의 충돌 여부 확인,살짝 스치는게 인식이 안될수도 있음 확인해봐야함
            foreach (Obstacle obstacle in obstacles)
            {
                // 캐릭터의 위치 정보
                int characterLeft = x; // 캐릭터의 왼쪽 X 좌표
                int characterRight = x + ch.Width; // 캐릭터의 오른쪽 X 좌표
                int characterTop = pictureBox1.Height - 130 - jumpHeight; // 캐릭터의 상단 Y 좌표
                int characterBottom = characterTop + ch.Height; // 캐릭터의 하단 Y 좌표

                // 장애물의 위치 정보
                int obstacleLeft = (int)obstacle.StartX; // 장애물의 왼쪽 X 좌표
                int obstacleRight = obstacleLeft + obstacle.Width; // 장애물의 오른쪽 X 좌표
                int obstacleTop = obstacle.Y; // 장애물의 상단 Y 좌표
                int obstacleBottom = obstacleTop + obstacle.Height; // 장애물의 하단 Y 좌표

                // 두 사각형이 교차하면 충돌이 발생한 것
                if (characterLeft < obstacleRight &&
                    characterRight > obstacleLeft &&
                    characterTop < obstacleBottom &&
                    characterBottom > obstacleTop)
                {
                    // 부딪혔을 때 true 반환
                    gameStopped = true;
                    return true;
                }
            }

            // 부딪히지 않았을 때 false 반환
            return false;
        }



        private void ShowGameOverMessage()
        {
            gameStopped = true;
            MessageBox.Show("게임 종료! 최종 점수: " + score.ToString());

            Rank rank = new Rank();
            rank.InsertData(Properties.Settings.Default.nickname, score);
            rank.Show();
            Dispose();
        }
        private void JumpTimer_Tick(object sender, EventArgs e)
        {
            if (gameStopped)
                return;

            if (isJumping) // 1단점프와 2단점프 높이를 다르게 설정하고, 두번 점프하면 바닥에 닿아야 다시 점프가능하게 구현하고 싶음
            {
                jumpHeight += 6; //위로 올라가는 속도

                if (jumpHeight >= 130) //점프 높이 
                {
                    isJumping = false;
                }
            }
            else
            {
                jumpHeight -= 5; //내려갈때 속도 

                // 캐릭터 바닥에 닿는지 확인
                if (jumpHeight <= 0)
                {
                    // 다시 점프 가능하게 
                    isJumping = false;
                    jumpHeight = 0;
                }
            }

            MoveObstacles();
            CheckObstacleCollision();
            UpdateScore();
            Invalidate();
        }

        private void UpdateScore()
        {
            // 현재 시간과 시작 시간의 차이를 계산하여 7초마다 점수를 추가
            TimeSpan elapsedTime = DateTime.Now - startTime;
            if (elapsedTime.TotalMilliseconds >= scoreUpdateInterval)
            {
                score += 5;
                label1.Text = score.ToString();
                startTime = DateTime.Now; // 시작 시간 갱신
            }
        }
        public void Fm_Click(object sender, MouseEventArgs e)
        {
            Point relativeClickPoint = pictureBox1.PointToClient(Cursor.Position);
            if (pictureBox1.ClientRectangle.Contains(relativeClickPoint) && e.Button == MouseButtons.Left)
            {
                isJumping = true;


                return;  // 여기서 함수를 종료합니다.
            }

            else if (e.Button == MouseButtons.Left && !isJumping)
                isJumping = true;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }




}
