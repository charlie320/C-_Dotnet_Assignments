using System;

namespace human
{
    public class Human {
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health;

        public Human(string name) {

        }

        public Human(string name, int strength, int intelligence, int dexterity, int health) {

        }

        public void Attack(Human victim) {
            victim.strength = 5 * this.strength;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
