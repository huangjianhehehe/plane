﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using 飞机大战.Properties;

namespace 飞机大战
{
    class BackGround : GameObject  //继承父类游戏类
    {

        //首先应该把背景图片导入,因为我们需要将背景图片绘制到窗体上
        private static Image imgBG = Resources.background;

        //写构造函数去调用父类GameObject的构造函数
        public BackGround(int x,int y,int speed):base(x,y,imgBG.Width,imgBG.Height,speed,0,Direction.Down)
        { }
        public override void Draw(Graphics g)
        {
            this.Y += this.Speed;
            if (this.Y==0)
            {
                this.Y = -850;
            }
            //坐标改变完成后,将背景图像不停的绘制到我们的窗体中
            g.DrawImage(imgBG, this.X, this.Y);
        }
    }
}
