using NasaMarsRover.Bussiness.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMarsRover.Bussiness.Concrete
{
    public class Ground
    {
        #region Constructor
        public Ground(int[] range)
        {
            if (range.RangeIsNullOrEmpty())
                throw new Exception("Range can not be null or empty!!");

            Width = range[0];
            Height = range[1];
        }
        #endregion

        #region Members
        public static int Width { get; set; }
        public static int Height { get; set; }
        #endregion
    }
}
