using NasaMarsRover.Bussiness.Enums;
using NasaMarsRover.Bussiness.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMarsRover.Bussiness.Concrete
{
    public class MarsRover
    {
        public MarsRover(Ground _ground, Direction _target, int _x, int _y)
        {
            Ground = _ground;
            X = _x;
            Y = _y;
            Target = _target;
        }

        public Direction Target { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Ground Ground { get; set; }


        public void Run(char[] directions)
        {
            foreach (var item in directions)
            {
                switch (item.CharToEnum())
                {
                    case Rotate.Left:
                        Turn(true);
                        break;

                    case Rotate.Right:
                        Turn(false);
                        break;

                    case Rotate.Move:
                        Move();
                        break;

                    case Rotate.Empty:
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine($"Expected Output : {X} {Y} {Target}");
        }

        private void Move()
        {
            if (IsInside())
            {
                switch (Target)
                {
                    case Direction.N:
                        Y += 1;
                        break;

                    case Direction.S:
                        Y -= 1;
                        break;

                    case Direction.E:
                        X += 1;
                        break;

                    case Direction.W:
                        X -= 1;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Can not exit ground!!");
            }
        }

        private bool IsInside()
        {
            return X < Ground.Width && Y < Ground.Height;
        }

        public void Turn(bool isLeft)
        {
            switch (Target)
            {
                case Direction.N:
                    Target = isLeft ? Direction.W : Direction.E;
                    break;

                case Direction.S:
                    Target = isLeft ? Direction.E : Direction.W;
                    break;

                case Direction.E:
                    Target = isLeft ? Direction.N : Direction.S;
                    break;

                case Direction.W:
                    Target = isLeft ? Direction.S : Direction.N;
                    break;

                default:
                    Console.WriteLine("Invalid Direction!!!");
                    break;
            }
        }
    }
}
