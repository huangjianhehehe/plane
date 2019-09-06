using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace 飞机大战
{
    /// <summary>
    /// 这是所有游戏对象的父类,封装着所有子类所共有的成员
    /// </summary>
    /// 

   abstract class GameObject
    {
        #region x,y坐标,游戏对象的width以及height.游戏对象 移动的速度,方向,生命值
        public enum Direction             //方向用枚举
        {

           Up,
           Down,
           Left,
           Right
        }
            public int X          //x,y坐标
        {
            get;
            set;
        }
        public int Y
        {
            get;
            set;
        }
        public int Width
        { get; set; }
        public int Height
        { get; set; }
        public int Speed                 //速度
        { get; set; }
        public int Life                     //生命值
        { get; set; }
        public Direction Dir            //方向
        { get; set; }
        #endregion
        /// <summary>
        ///  构造函数
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="speed"></param>
        /// <param name="life"></param>
        /// <param name="dir"></param>
        public GameObject(int x,int y,int width,int height,int speed,int life,Direction dir)       
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Speed = speed;
            this.Life = life;
            this.Dir = dir;
        }
        public GameObject(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }

        //每个游戏对象在使用GDI+对象绘制自己到窗体的时候,绘制的方式都各不一样
        //所以我们要在父类中提供一个绘制对象的抽象方法
        public abstract void Draw(Graphics g);

        //再提供一个碰撞检测的函数  ,返回当前游戏对象的矩形
        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }
        /// <summary>
        /// 移动的虚方法,如果子类有不一样的,则重写该虚方法
        /// </summary>
         public virtual void Move()
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
            if (this.X>=400)
            {
                this.X = 400;
            }
            if (this.Y<=0)
            {
                this.Y = 0;
            }
            if (this.Y>=700)
            {
                this.Y = 700;
            }
        }   //Move()
      




    }
}
