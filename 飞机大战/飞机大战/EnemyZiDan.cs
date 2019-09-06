using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using 飞机大战.Properties;
namespace 飞机大战
{
    class EnemyZiDan:ZiDan
    {

            private static Image imgHero = Resources.enemyzidan;
            public EnemyZiDan(PlaneFather pf, int speed, int power) :
                base(pf, imgHero, speed, power)
            {
            }
        
    }
}
