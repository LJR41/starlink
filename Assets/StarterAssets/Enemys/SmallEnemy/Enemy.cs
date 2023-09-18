using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starlink.Assets.StarterAssets.Enemys.SmallEnemy
{
    public class Enemy
    {

            
        //protected is use so that this var can be used by the class and its children (like simple enemy) but no other scrip can acces is it
        protected bool dead = false;



        //------- this bool defines how to delete enemy from game
        public bool Dead
        {
            get
            {
                return dead;
            }


        }

   



        
    }
}