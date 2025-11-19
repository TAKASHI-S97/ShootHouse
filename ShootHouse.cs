namespace ShootHouse
{
    public partial class ShootHouse : Form
    {
        /// <summary>
        /// タイマー（FPS 制御用）
        /// </summary>
        private readonly System.Windows.Forms.Timer _timer = new();

        /// <summary>
        /// プレイヤー
        /// </summary>
        private readonly Player _player;

        public ShootHouse()
        {
            InitializeComponent();

            // カーソルを十字に変更して中央に移動
            Cursor = new Cursor(new MemoryStream(Properties.Resources.crosshair_cursor));
            Cursor.Position = PointToScreen(new Point(Size.Width / 2, Size.Height / 2));

            // プレイヤー初期化
            _player = new Player(Size.Width / 2, Size.Height / 2);

            // タイマー初期化
            _timer.Interval = 16;
            _timer.Tick += (s, e) =>
            {
                UpdateGame();
                Invalidate();
            };
            _timer.Start();
        }

        private void UpdateGame()
        {
            // プレイヤーの向きをマウスカーソルに合わせる
            int dx = PointToClient(Cursor.Position).X - (int)_player.X;
            int dy = PointToClient(Cursor.Position).Y - (int)_player.Y;

            if (dx != 0 || dy != 0)
            {
                _player.R = Math.Atan2(dy, dx) + Math.PI / 2;   // プレイヤー画像は上向きが 0 度なので補正
            }

            // プレイヤー更新
            _player.Update();
        }

        private void ShootHouse_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            _player.Draw(g);
        }

        private void ShootHouse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                _player.MoveLeft = true;
            }
            else if (e.KeyCode == Keys.D)
            {
                _player.MoveRight = true;
            }
            else if (e.KeyCode == Keys.W)
            {
                _player.MoveUp = true;
            }
            else if (e.KeyCode == Keys.S)
            {
                _player.MoveDown = true;
            }
        }

        private void ShootHouse_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                _player.MoveLeft = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                _player.MoveRight = false;
            }
            else if (e.KeyCode == Keys.W)
            {
                _player.MoveUp = false;
            }
            else if (e.KeyCode == Keys.S)
            {
                _player.MoveDown = false;
            }
        }

        private void ShootHouse_FormClosed(object sender, FormClosedEventArgs e)
        {
            _player.Dispose();
        }
    }
}
