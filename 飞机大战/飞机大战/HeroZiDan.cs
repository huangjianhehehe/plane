using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using 飞机大战.Properties;

namespace 飞机大战
{
    class HeroZiDan : ZiDan
    {
        private static Image imgHero = Resources.zidan;
        public HeroZiDan(PlaneFather pf,  int speed, int power) : 
            base(pf, imgHero, speed, power)
        {
        }
    }
}
