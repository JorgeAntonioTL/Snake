using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace Snake
{
    class comida
    {
       


        public int generar(int n)
        {
            Random random = new Random();
            int num = random.Next(0, n) * 10;
            Console.WriteLine(num);

            return num;
        }

    }
}
