using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace 飞机大战
{
    class SingleObject
    {
        //单例设计模式
        //1.构造函数私有化
        private SingleObject() { }

        //2.声明全局唯一的对象
        private static SingleObject _single = null;
        //3.提供一个静态函数用于返回一个唯一的对象
        public static SingleObject GetSingle()
        {
            if (_single==null)
            {
                _single = new SingleObject();
            }
            return _single;
        }

        //存储的是背景在游戏中的唯一对象
        public BackGround BG
        { get; set; }
        //存储的是玩家飞机在游戏中的唯一对象
        public PlaneHero PH
        { get; set; }

        //记录分数
        public int Score
        { get; set; }
        
        //声明一个集合对象用来存储玩家子弹
        List<HeroZiDan> listHeroZiDan = new List<HeroZiDan>();

        //声明一个集合对象用来存储敌方飞机
        public List<PlaneEnemy> listPlaneEnemy = new List<PlaneEnemy>();

        //声明一个集合用来存储敌机爆炸图片
        public List<EnemyBoom> listEnemyBoom = new List<EnemyBoom>();

        //声明一个集合用来存储敌机的子弹
        public List<EnemyZiDan> listEnemyZiDan = new List<EnemyZiDan>();

        //声明一个集合用来存储玩家爆炸的对象
        public List<HeroBoom> listHeroBoom = new List<HeroBoom>();

        //下面,我们写一个函数,将我们创建的游戏对象,添加到我们的窗体中
        public void AddGameObject(GameObject go)
        {
            if (go is BackGround)
            {
                this.BG = go as BackGround;
            }
            else if (go is PlaneHero)
            {
                this.PH = go as PlaneHero;     //如果是玩家飞机,添加
            }
            else if(go is HeroZiDan)
            {
                listHeroZiDan.Add(go as HeroZiDan);  //如果是玩家子弹就添加
            }
            else if (go is PlaneEnemy)
            {
                listPlaneEnemy.Add(go as PlaneEnemy);  //如果是敌机就添加
            }
            else if (go is EnemyBoom)
            {
                listEnemyBoom.Add(go as EnemyBoom);  //如果是敌机爆炸图片就添加
            }
            else if (go is EnemyZiDan)
            {
                listEnemyZiDan.Add(go as EnemyZiDan);  //如果是敌机子弹就添加
            }
            else if (go is HeroBoom)
            {
                listHeroBoom.Add(go as HeroBoom);   //如果是玩家飞机爆炸图片添加
            }
        }


        //将游戏对象从游戏中移除
        public void RemoveGame(GameObject go)
        {
            //移除飞机
            if (go is PlaneEnemy)
            {
                listPlaneEnemy.Remove(go as PlaneEnemy);
            }
            //玩家子弹打出边界后,将玩家子弹同样移除
            else if (go is HeroZiDan)
            {
                listHeroZiDan.Remove(go as HeroZiDan);
            }
            else if (go is EnemyBoom)
            {
                listEnemyBoom.Remove(go as EnemyBoom);
            }
            else if (go is EnemyZiDan)
            {
                listEnemyZiDan.Remove(go as EnemyZiDan);
            }
            else if (go is HeroBoom)
            {
                listHeroBoom.Remove(go as HeroBoom);
            }
        }
        public void Draw(Graphics g)
        {
            this.BG.Draw(g);     //绘制背景
            this.PH.Draw(g);   //绘制玩家飞机
            //绘制英雄子弹
            for (int i = 0; i <listHeroZiDan.Count; i++)
            {
                listHeroZiDan[i].Draw(g);
            }
            //绘制敌机
            for (int i = 0; i < listPlaneEnemy.Count; i++)
            {
                listPlaneEnemy[i].Draw(g);
            }
            //绘制敌机爆作图片
            for (int i = 0; i <listEnemyBoom.Count; i++)
            {
                listEnemyBoom[i].Draw(g);
            }
            //绘制敌机子弹图片
            for (int i = 0; i < listEnemyZiDan.Count; i++)
            {
                listEnemyZiDan[i].Draw(g);
            }
            //绘制玩家飞机爆炸图片
            for (int i = 0; i < listHeroBoom.Count; i++)
            {
                listHeroBoom[i].Draw(g);
            }
        }


        public void PZJC()        //碰撞检测
        {
            #region 判断玩家的子弹是否打到了敌人的身上
            for (int i = 0; i < listHeroZiDan.Count; i++)
            {
                for (int j = 0; j < listPlaneEnemy.Count; j++)
                {
                    if (listHeroZiDan[i].GetRectangle().IntersectsWith      //判断是否相交
                        (listPlaneEnemy[j].GetRectangle()))
                    {
                        //如果条件成立,则说明发生了碰撞测试 ,也就是玩家的子弹打到了敌人的身上

                        //敌人的生命值应该减少
                        listPlaneEnemy[j].Life -= listHeroZiDan[i].Power;
                        //敌人生命值减少后,应该判断敌人是否死亡
                        listPlaneEnemy[j].IsOver();
                        //玩家子弹打到敌人身上后,应该将玩家子弹销毁
                        listHeroZiDan.Remove(listHeroZiDan[i]);
                        break;

                    }
                }
            }
            #endregion

            #region 判断敌人子弹是否打到了玩家身上
            for (int i = 0; i < listEnemyZiDan.Count; i++)
            {
                if (listEnemyZiDan[i].GetRectangle().IntersectsWith(this.PH.GetRectangle()))
                {
                    //让玩家发生爆炸,但不死亡
                    this.PH.IsOver();
                    break;
                }
            }
            #endregion

            #region 判断玩家飞机与敌方飞机是否碰撞
            for (int i = 0; i < listPlaneEnemy.Count; i++)
            {
                if (listPlaneEnemy[i].GetRectangle().IntersectsWith(this.PH.GetRectangle()))
                {
                    listPlaneEnemy[i].Life = 0;
                    listPlaneEnemy[i].IsOver();
                    break;
                }
            }

            #endregion
        }

    }
}
