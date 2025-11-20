namespace ShootHouse
{
    public class Bullet : Object
    {
        /// <summary>
        /// 弾丸の飛距離
        /// </summary>
        public float Distance = 0f;

        public Bullet(float x, float y, double a)
        {
            // 弾丸の初期位置をプレイヤーの少し前に設定
            const float offset = 25f;
            _x = x + (float)Math.Sin(a) * offset;
            _y = y - (float)Math.Cos(a) * offset;

            _angle = a;
            _speed = 10f;
            _bitmap = Properties.Resources.bullut;
        }

        /// <summary>
        /// 弾丸の更新
        /// </summary>
        public void Update()
        {
            _x += _speed * (float)Math.Sin(_angle);
            _y -= _speed * (float)Math.Cos(_angle);

            Distance += _speed;
        }
    }
}
