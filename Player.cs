namespace ShootHouse
{
    public class Player : Object
    {
        public Player(float x, float y)
        {
            _x = x;
            _y = y;
            _angle = 0;
            _speed = 5f;
            _bitmap = Properties.Resources.player;

            _shootTimer.Tick += (s, e) => { _shootTimer.Enabled = false; };
        }

        /// <summary>
        /// 移動フラグ（左）
        /// </summary>
        public bool MoveLeft { get; set; } = false;

        /// <summary>
        /// 移動フラグ（右）
        /// </summary>
        public bool MoveRight { get; set; } = false;

        /// <summary>
        /// 移動フラグ（上）
        /// </summary>
        public bool MoveUp { get; set; } = false;

        /// <summary>
        /// 移動フラグ（下）
        /// </summary>
        public bool MoveDown { get; set; } = false;

        /// <summary>
        /// 射撃フラグ
        /// </summary>
        public bool IsShooting { get; set; } = false;

        /// <summary>
        /// 射撃タイマー（連射防止用）
        /// </summary>
        private static readonly System.Windows.Forms.Timer _shootTimer = new();

        /// <summary>
        /// 発射した弾リスト
        /// </summary>
        private readonly List<Bullet> _bullets = [];

        /// <summary>
        /// プレイヤーの更新
        /// </summary>
        /// <param name="px">カーソルの X 座標</param>
        /// <param name="py">カーソルの Y 座標</param>
        public void Update(int px, int py)
        {
            // プレイヤーの向きをマウスカーソルに合わせる
            int dx = px - (int)_x;
            int dy = py - (int)_y;

            if (dx != 0 || dy != 0)
            {
                _angle = Math.Atan2(dy, dx) + Math.PI / 2;   // プレイヤー画像は上向きが 0 度なので補正
            }

            // 移動処理
            if (MoveLeft) _x -= _speed;
            if (MoveRight) _x += _speed;
            if (MoveUp) _y -= _speed;
            if (MoveDown) _y += _speed;

            // 射撃処理
            if (IsShooting) Shoot();

            // 弾丸の更新
            foreach (var b in _bullets)
            {
                b.Update();

                if (b.Distance > 500f)
                {
                    // 飛距離が 500 を超えた弾丸は削除
                    _bullets.Remove(b);
                    break;
                }
            }
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            // 弾丸の描画
            foreach (var b in _bullets)
            {
                b.Draw(g);
            }
        }

        private void Shoot()
        {
            IsShooting = false;

            // 連射防止
            if (_shootTimer.Enabled) return;

            _shootTimer.Start();
            _bullets.Add(new Bullet(_x, _y, _angle));
        }
    }
}
