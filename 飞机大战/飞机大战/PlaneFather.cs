using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace 飞机大战
{
    /// <summary>
    /// 飞机的父类  抽象类
    /// </summary>
    abstract class PlaneFather : GameObject
    {
        private Image imgPlane;   //声明一个字段存储飞机的图片
        public PlaneFather(int x, int y, Image img, int speed, int life, Direction dir) :
            base(x, y, img.Width, img.Height, speed, life, dir)
        {
            this.imgPlane = img;
        }
        //我们的飞机父类不需要重写父类的Draw方法,因为玩家飞机和敌方飞机在绘制自己到窗体的时候,
        //方式各不一样

        //提供一个判断是否死亡的抽象函数,具体怎么死亡,由子类具体去实现 
        public abstract void IsOver();

       
    }
}
