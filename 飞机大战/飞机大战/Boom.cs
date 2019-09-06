using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace 飞机大战
{
   abstract class Boom : GameObject
    {
        public Boom(int x, int y) : base(x, y)
        {

        }

        //只需要调用父类的构造函数
        //在播放爆炸图片的时候,只需要知道爆炸图片应该播放的坐标就O啦

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
