namespace ShootHouse
{
    public abstract class Object : IDisposable
    {
        /// <summary>
        /// オブジェクトの X 座標（中心の座標）
        /// </summary>
        protected float _x;

        /// <summary>
        /// オブジェクトの Y 座標（中心の座標）
        /// </summary>
        protected float _y;

        /// <summary>
        /// オブジェクトの角度（上方向が 0度）
        /// </summary>
        protected double _angle;

        /// <summary>
        /// オブジェクトの移動速度
        /// </summary>
        protected float _speed;

        /// <summary>
        /// オブジェクト画像
        /// </summary>
        protected Bitmap? _bitmap;

        /// <summary>
        /// 描画
        /// </summary>
        public virtual void Draw(Graphics g)
        {
            if (_bitmap == null) return;

            var halfW = _bitmap.Width / 2f;
            var halfH = _bitmap.Height / 2f;

            PointF Rotate(float lx, float ly)
            {
                float rx = lx * (float)Math.Cos(_angle) - ly * (float)Math.Sin(_angle);
                float ry = lx * (float)Math.Sin(_angle) + ly * (float)Math.Cos(_angle);
                return new PointF(_x + rx, _y + ry);
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
        /// オブジェクト画像リソースの解放
        /// </summary>
        public void Dispose()
        {
            _bitmap?.Dispose();
            _bitmap = null;

            GC.SuppressFinalize(this);
        }
    }
}