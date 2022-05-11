using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Rover
    {
        public int[] Pos { get; private set; }
        public char Heading { get; private set; }
        public Rover(int[] pos, char heading)
        {
            Pos = pos;
            Heading = heading;
        }
        /// <summary>
        /// Belirlenen sınırlar dışına çıkmayıp ilk pozisyonuna alır
        /// </summary>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        public void Limit(int maxX, int maxY)
        {
            if (Pos[0] > maxX)
            {
                Pos[0] = maxX;
            }
            if (Pos[1] > maxY)
            {
                Pos[1] = maxY;
            }
            if (Pos[0] < 0)
            {
                Pos[0] = 0;
            }
            if (Pos[1] < 0)
            {
                Pos[1] = 1;
            }
        }
        /// <summary>
        /// Sola dönüşlerde yönü günceller
        /// </summary>
        public void TurnLeft()
        {
            switch (Heading)
            {
                case 'N': Heading = 'W'; break;
                case 'W': Heading = 'S'; break;
                case 'S': Heading = 'E'; break;
                case 'E': Heading = 'N'; break;
                default: throw new ArgumentException("unknown heading");
            }
        }
        /// <summary>
        /// Sağa dönüşlerde yönü güncelleer
        /// </summary>
        public void TurnRight()
        {
            switch (Heading)
            {
                case 'N': Heading = 'E'; break;
                case 'E': Heading = 'S'; break;
                case 'S': Heading = 'W'; break;
                case 'W': Heading = 'N'; break;
                default: throw new ArgumentException("unknown heading");
            }
        }
        /// <summary>
        /// Yöne göre pozisyonu ileletir
        /// </summary>
        public void Forward()
        {
            switch (Heading)
            {
                case 'N': Pos[1]++; break;
                case 'E': Pos[0]++; break;
                case 'S': Pos[1]--; break;
                case 'W': Pos[0]--; break;
                default: throw new ArgumentException("unknown heading");
            }
        }

        public override string ToString()
        {
            return Pos[0] + " " + Pos[1] + " " + Heading;
        }
    }
}