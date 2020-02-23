using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleOfSand
{
    class ChangeDirectionEventArgs:EventArgs
    {
        public WalkingDirection WalkingDirection { get;private set; }
        public int IterUpFrame { get; private set; }
        public int IterDownFrame { get; private set; }
        public int IterRightFrame { get; private set; }
        public int IterLeftFrame { get; private set; }
        public ChangeDirectionEventArgs(WalkingDirection walkingDirection, int iterUpFrame, int iterDownFrame, int iterRightFrame, int iterLeftFrame)
        {
            WalkingDirection = walkingDirection;
            IterUpFrame = iterUpFrame;
            IterDownFrame = iterDownFrame;
            IterLeftFrame = iterLeftFrame;
            IterRightFrame = iterRightFrame;
        }
       
    }
}
