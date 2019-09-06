using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using 飞机大战.Properties;

namespace 飞机大战
{
    class PlaneEnemy : PlaneFather
    {
        private static Image img1 = Resources.enemy1;
        private static Image img2 = Resources.enemyMiddle;
        private static Image img3 = Resources.enemyBig;

        //因为每一架飞机的大小,生命值,速度都不一样,所以我们需要声明一个标示来标
        //记当前到底属于哪架飞机
        //0---最小的飞机   1---中间的飞机   2---最大的飞机
        public int EnemyType
        {
            get; set;
        }
        //下面需要根据我们飞机的类型,分别的写三个函数,用于返回飞机的图片,飞机的速
        //度,飞机的生命值
        
            //根据飞机的类型,返回飞机的图片
        public static Image GetImage(int type)   //静态函数中只能访问静态成员
        {
            switch (type)
            {
                case 0:
                    return img1;
                case 1:
                    return img2;
                case 2:
                    return img3;
             
            }
            return null;
        }

        //根据飞机的类型,返回对应的生命值 
        public static int GetLife(int type)
        {
            switch (type)
            {
                case 0:
                    return 1;
                case 1:
                    return 2;
                case 2:
                    return 3;
            }
            return 0;
        }

        //根据飞机的类型,返回对应的速度
        public static int GetSpeed(int type)
        {
            switch (type)
            {
                case 0:
                    return 5;
                case 1:
                    return 6;
                case 2:
                    return 7;
            }
            return 0;
        }

        //根据需要构造函数
        public PlaneEnemy(int x, int y, int type) :
            base(x, y,GetImage(type),GetSpeed(type),GetLife(type),Direction.Down)
        {
            this.EnemyType = type;
        }

        //我们需要重写父类中Draw函数,将自己绘制Form窗体上
        public override void Draw(Graphics g)
        {
            this.Move();
            //也需要根据不同的飞机类型,来绘制飞机
            switch (EnemyType)
            {
                case 0:
                    g.DrawImage(img1, this.X, this.Y);
                    break;
                case 1:
                    g.DrawImage(img2, this.X, this.Y );
                    break;
                case 2:
                    g.DrawImage(img3, this.X, this.Y);
                    break;
            }
        }
        public override void Move()
        {
       
            //根据游戏对象的方向进行移动
            switch (Dir)
            {
                case Direction.Up:
                    this.Y -= this.Speed;
                    break;
                case Direction.Down:
                    this.Y += this.Speed;
                    break;
                case Direction.Left:
                    this.X -= this.Speed;
                    break;
                case Direction.Right:
                    this.X += this.Speed;
                    break;
                default:
                    break;
            }
            //移动完成后,判断一下游戏对象是否超过窗体
            if (this.X <= 0)
            {
                this.X = 0;
            }
            if (this.X >= 400)
            {
                this.X = 400;
            }
            if (this.Y <= 0)
            {
                this.Y = 0;
            }
            if (this.Y >= 780)
            {
                this.Y = 1400;  //敌人飞机到底部时,让敌人飞机离开窗体
                //同时当敌机离开窗体时,我们应该销毁敌机
                SingleObject.GetSingle().RemoveGame(this);
            }
            //当敌人的飞机类型是0 ,并且纵坐标>=某个值之后,我们不停的更换他的横坐标
            if (this.EnemyType==0&&this.Y>=200)
            {
                if (this.X>=0&&this.X<=240)
                {
                    //表示当前的小飞机在左边的范围内
                    //增加当前飞机的X值
                    this.X += r.Next(0, 50);
                }
                else
                {
                    this.X -= r.Next(0, 50);
                }
            }
            else    //如果飞机是1,2大飞机
            {
                //大飞机不更改坐标,改速度
                this.Speed += 1;

            }
            //百分之三十概率发射子弹
            if (r.Next(0,100)>90)
            {
                Fire();
            }
        }   //Move()
        public void Fire()
        {
            SingleObject.GetSingle().AddGameObject(new EnemyZiDan(this, 20, 1));

        }   //Fire()

        public override void IsOver()
        {
            //实现敌机死亡的方法
            if (this.Life<=0)
            {
                //敌人飞机坠毁,应该把敌机从游戏中移除
                SingleObject.GetSingle().RemoveGame(this);
                //播放敌机爆炸的图片
                SingleObject.GetSingle().AddGameObject(new EnemyBoom(this.X, this.Y, this.EnemyType));

                //敌人发生爆炸,给玩家加分,根据不同的敌机,给玩家不同的分数
                switch (this.EnemyType)
                {
                    case 0:
                        SingleObject.GetSingle().Score += 100;
                        break;
                    case 1:
                        SingleObject.GetSingle().Score += 200;
                        break;
                    case 2:
                        SingleObject.GetSingle().Score += 300;
                        break;
                }
            }
        }

        static Random r = new Random();
    }
}

