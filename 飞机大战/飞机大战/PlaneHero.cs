using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using 飞机大战.Properties;

namespace 飞机大战
{
    class PlaneHero : PlaneFather
    {
        //导入玩家的飞机的图片,存储到字段中
        private static Image imgPlane = Resources.hero1;
        public PlaneHero(int x, int y,  int speed, int life, Direction dir) : base(x, y, imgPlane, speed, life, dir)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(imgPlane, this.X, this.Y,this.Width/2,this.Height/2);
        }

        //让玩家飞机跟 着鼠标走
        public void MouseMove(MouseEventArgs e)
        {
            this.X = e.X;
            this.Y = e.Y;
        }
        //玩家飞机发射子弹的方法
        public void Fire()
        {
            //初始化我们玩家子弹到游戏中
            SingleObject.GetSingle().AddGameObject(new HeroZiDan(this, 10, 1));
        }

        public override void IsOver()
        {
            //实现英雄飞机死亡
            SingleObject.GetSingle().AddGameObject(new HeroBoom(this.X, this.Y));
        }
    }
}
