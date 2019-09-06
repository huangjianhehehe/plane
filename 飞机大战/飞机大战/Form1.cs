using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace 飞机大战
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitialGame();
        }
        static Random r = new Random();
        /// <summary>
        ///游戏初始化
        /// </summary>
       public void InitialGame()
        {
            //首先需要初始化的是我们的背景
            SingleObject.GetSingle().AddGameObject(new BackGround(0, -850,5));
            //初始化英雄飞机
            SingleObject.GetSingle().AddGameObject(new PlaneHero(100, 100, 5, 3, GameObject.Direction.Up));
          
            

        }
         //初始化敌方飞机
         public void InitialPlaneEnemy()
        {
            //初始人敌方飞机
            for (int i = 0; i < 4; i++)
            {
                SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, this.Width), -200,
                    r.Next(0, 2)));
            }
            //不应该每次都出现大飞机
            if (r.Next(0,100)>80)
            {
                SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, this.Width), -200,
                 2));
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //在窗体加载的时候,解决闪烁问题
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.AllPaintingInWmPaint, true);



        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //当窗口重绘时,我们就绘制我们的背景
            SingleObject.GetSingle().Draw(e.Graphics);
            string score = SingleObject.GetSingle().Score.ToString();
            //绘制玩家的分数
            e.Graphics.DrawString(score, new Font("宋体", 20, FontStyle.Bold),
                Brushes.Red, new Point(0, 0));
        }

        private void timerBG_Tick(object sender, EventArgs e)
        {
            this.Invalidate();     //每50毫秒刷新一次
            //不停的判断敌机的数量
            //获取敌方飞机的数量
            int count = SingleObject.GetSingle().listPlaneEnemy.Count;
            if (count<=1)
            {
                //再次对敌机进行初始化
                InitialPlaneEnemy();
            }
            //不停的进行碰撞检测
            SingleObject.GetSingle().PZJC();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //当鼠标在窗体移动的时候,让飞机跟着鼠标的移动而移动

            SingleObject.GetSingle().PH.MouseMove(e);  //调用玩家飞机的mouseMove方法

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //判断玩家是否按下了左键
            //如果玩家按下了左键,调用玩家飞机发射子弹的方法
            SingleObject.GetSingle().PH.Fire();

        }
    }
}
