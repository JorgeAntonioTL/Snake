using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Objeto
    {
        protected int x, y, divLin;
        public Objeto()
        {
            int tama = 10;
            divLin = 600/tama;
        }
        public Boolean interseccion(Objeto o)
        {
            int difx = Math.Abs(this.x - o.x);
            int dify = Math.Abs(this.y - o.y);
            if (difx >= 0 && difx < divLin && dify >= 0 && dify < divLin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
