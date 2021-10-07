using NasaMarsRover.Bussiness.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMarsRover.Bussiness.Extensions
{
    public static class ExtensionsMethods
    {
        public static Rotate CharToEnum(this char item)
        {
            switch (item)
            {
                case (char)Rotate.Left:
                    return Rotate.Left;
                    
                case (char)Rotate.Right:
                    return Rotate.Right;
                    
                case (char)Rotate.Move:
                    return Rotate.Move;
                    
                default:
                    return Rotate.Empty;
            }
        }

        public static bool RangeIsNullOrEmpty(this int[] ranges)
        {
            return ranges == null || ranges.Length == 0;
        }
    }
}
