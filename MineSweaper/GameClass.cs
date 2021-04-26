using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweaper
{
    class GameClass
    {
        private readonly static GameClass _instance = new GameClass();

        private GameClass()
        {
        }

        public static GameClass Instance()
        {
            return _instance;
        }

        public  delegate void delegateScanNear();



        public void scanRange(int x,int y ,int X, int Y,out int minx,out int maxx,out int miny,out int maxy)
        {
            minx = (x == 0) ? 0 : x - 1;
            maxx = (x == X - 1) ? X - 1 : x + 1;
            miny = (y == 0) ? 0 : y - 1;
            maxy = (y == Y - 1) ? Y - 1 : y + 1;
        }



        public  void scanMine(int X, int Y,int[,] a)
        {
            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    int minx = (x == 0) ? 0 : x - 1;
                    int maxx = (x == X - 1) ? X - 1 : x + 1;
                    int miny = (y == 0) ? 0 : y - 1;
                    int maxy = (y == Y - 1) ? Y - 1 : y + 1;
                    if (a[x,y] <0)
                    {
                        for (int j = miny; j <= maxy; j++)
                        {
                            for (int i = minx; i <= maxx; i++)
                            {
                                a[i, j] += 1;
                            }
                        }
                    }
                }
            }
        }

        public void setMine(int[,] a)
        {
            a[2, 6] = -9;
            a[4, 6] = -9;
            a[0, 8] = -9;
            a[8, 0] = -9;
            a[8, 8] = -9;
        }

        public void autoFlip(int X,int Y, int[,] a,Button[,]b)
        {
            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    int minx = (x == 0) ? 0 : x - 1;
                    int maxx = (x == X - 1) ? X - 1 : x + 1;
                    int miny = (y == 0) ? 0 : y - 1;
                    int maxy = (y == Y - 1) ? Y - 1 : y + 1;
                    if (a[x, y] == 0)
                    {
                        for (int j = miny; j <= maxy; j++)
                        {
                            for (int i = minx; i <= maxx; i++)
                            {
                                b[i, j].Enabled = false ;
                            }
                        }
                    }
                }
            }
        }
    }
}
