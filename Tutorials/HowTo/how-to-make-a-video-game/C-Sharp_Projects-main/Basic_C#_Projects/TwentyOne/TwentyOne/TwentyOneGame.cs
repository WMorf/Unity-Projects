﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class TwentyOneGame: Game, IWalkAway
    {
        public override void Play()
        {
            throw new NotImplementedException();
        }

        public override void ListPlayer()
        {
            Console.WriteLine("21 Players: ");
            base.ListPlayer();

        }

        public void WalkAway(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
