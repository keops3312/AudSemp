using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudSemp.Models
{
    public class Rectangle
    {
        public double Length { get; set; }
        public double Breadth { get; set; }

        public double CalculateArea()
        {
            return Length * Breadth;
        }
    }
}
