using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using 飞机大战.Properties;
namespace 飞机大战
{
    class EnemyBoom : Boom
    {
        //需要导入每种飞机爆炸时候的图片
        private Image[] img1 =
         {
                    Resources.enemy0_down1,
                    Resources.enemy0_down2,
                    Resources.enemy0_down3,
                    Resources.enemy0_down4
         };
        private Image[] img2 =
         {
                    Resources.enemy1_hit,
                    Resources.enemy1_down2,
                    Resources.enemy1_down3,
                    Resources.enemy1_down4
        };
      
        private Image[] img3 =
        {
                    Resources.enemy2_hit,
                    Resources.enemy2_down2,
                    Resources.enemy2_down3,
                    Resources.enemy2_down4,
                    Resources.enemy2_down5,
                    Resources.enemy2_down6

        };

        //爆炸的時候,我們需要知道是哪架飞机
        //根据敌人飞机的类型来播放对应的爆炸图片
        public int  Type
        { get; set; }
        public EnemyBoom(int x, int y,int type) : base(x, y)
        {
            this.Type = type;
        }
        public override void Draw(Graphics g)
        {
            //当爆炸图片绘制到窗体的时候,需要根据当前飞机的类型来绘制
            switch (this.Type)
            {
                case 0:
                    for (int i = 0; i <img1.Length; i++)
                    {
                        g.DrawImage(img1[i],this.X,this.Y);
                    }
                    break;
                case 1:
                    for (int i = 0; i < img2.Length; i++)
                    {
                        g.DrawImage(img2[i], this.X, this.Y);
                    }
                    break;
                case 2:
                    for (int i = 0; i < img3.Length; i++)
                    {
                        g.DrawImage(img3[i], this.X, this.Y);
                    }
                    break;
            }
            //播放完爆炸图片后,应该被销毁
            SingleObject.GetSingle().RemoveGame(this);

        }
    }
}
