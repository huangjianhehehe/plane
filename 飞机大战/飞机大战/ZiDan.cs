using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace 飞机大战
{
    class ZiDan : GameObject   //子弹类
    {
        private Image imgZiDan;  //子弹图片
        //记录一个子弹的威力
      public int Power
        { get; set; }
        public ZiDan(PlaneFather pf,Image img,int speed,int power) :
            base(pf.X+pf.Width/2-20, pf.Y+pf.Height/2-45, img.Width, img.Height, speed,0, pf.Dir)
        {
            this.imgZiDan = img;
            this.Power = power;
        }

       
        public override void Move()
        {
            switch (this.Dir)
            {
                case Direction.Up:
                    this.Y -= this.Speed;
                    break;
                case Direction.Down:
                    this.Y += this.Speed;
                    break;
            }
            //子弹发出后,控制一下子弹的坐标
            if (this.Y<=0)
            {
                this.Y = -100;  //在游戏中移除子弹对象
            }
            if (this.Y>=780)
            {
                this.Y = 1000;
                //在游戏中移除子弹对象
            }
        }

        public override void Draw(Graphics g)
        {
            this.Move();
            g.DrawImage(imgZiDan, this.X, this.Y,this.Width/2,this.Height/2);
        }
    }
}
