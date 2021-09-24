using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Joke
    {
        //Quick tip, to generate stuff instantly, hit tab twice
        public int Id { get; set; }
        public  string JokeQuestion { get; set; }
        public string JokeAnswer { get; set; }

        /* Type ctor, Tab Tab to generate a constructor */
        public Joke()
        {

        }
    }
}
