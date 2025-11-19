namespace ShootHouse
{
    internal class Player(float x, float y) : IDisposable
    {
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
        /// プレイヤー X 座標
        /// </summary>
        public float X { get; set; } = x;

        /// <summary>
        /// プレイヤー Y 座標
        /// </summary>
        public float Y { get; set; } = y;

        /// <summary>
        /// プレイヤー 向き角度
        /// </summary>
        public double R { get; set; } = 0;

        /// <summary>
        /// プレイヤー 移動速度
        /// </summary>
        public float Speed { get; set; } = 5f;

        /// <summary>
        /// プレイヤー画像
        /// </summary>
        private Bitmap? _bitmap = Properties.Resources.player;

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            // TODO: あたり判定
            // 移動処理
            if (MoveLeft) X -= Speed;
            if (MoveRight) X += Speed;
            if (MoveUp) Y -= Speed;
            if (MoveDown) Y += Speed;

            // TODO: 射撃
        }

        /// <summary>
        /// 描画
        /// </summary>
        public void Draw(Graphics g)
        {
            if (_bitmap == null) return;

            var halfW = _bitmap.Width / 2f;
            var halfH = _bitmap.Height / 2f;

            PointF Rotate(float lx, float ly)
            {
                float rx = lx * (float)Math.Cos(R) - ly * (float)Math.Sin(R);
                float ry = lx * (float)Math.Sin(R) + ly * (float)Math.Cos(R);
                return new PointF(X + rx, Y + ry);
            }

            PointF p0 = Rotate(-halfW, -halfH); // 左上
            PointF p1 = Rotate(halfW, -halfH);  // 右上
            PointF p2 = Rotate(-halfW, halfH);  // 左下
            PointF[] destPoints = [p0, p1, p2];

            g.DrawImage(
                _bitmap,
                destPoints,
                new Rectangle(0, 0, _bitmap.Width, _bitmap.Height),
                GraphicsUnit.Pixel
            );
        }

        /// <summary>
        /// リソース解放
        /// </summary>
        public void Dispose()
        {
            _bitmap?.Dispose();
            _bitmap = null;
        }
    }
}
