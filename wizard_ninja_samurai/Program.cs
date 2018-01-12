using System;

namespace wizard_ninja_samurai
{
    public class Human {
        public string name;

        //The { get; set; } format creates accessor methods for the field specified
        //This is done to allow flexibility
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }

        public Human(string person)
        {
            name = person;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }
        public Human(string person, int str, int intel, int dex, int hp)
        {
            name = person;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }
        public void attack(object obj)
        {
            Human enemy = obj as Human;
            if(enemy == null)
            {
                Console.WriteLine("Failed Attack");
            }
            else
            {
                enemy.health -= strength * 5;
            }
        }
    } // end Human class

    public class Wizard : Human {
        public int health = 50;
        public int intelligence = 50;

        public Wizard(string person) : base(person){

        }

        public Wizard(string person, int str, int intel, int dex, int hp) :base(person, str, intel, dex, hp)
        {

        }
        public void Heal() {
            this.intelligence *= 10;
        }

        public void Fireball(Human enemy) {
            Random rand = new Random();
            enemy.health -= rand.Next(20,50);
        }
    }

    public class Ninja : Human {
        public int dexterity = 175;

        public Ninja(string person) : base(person){
            
        }

        public Ninja(string person, int str, int intel, int dex, int hp) :base(person, str, intel, dex, hp)
        {

        }
        public void Steal() {
            this.health += 10;
        }

        public void GetAway() {
            this.health -= 15;
        }
    } // end Ninja class
    
    public class Samurai : Human {
        public int health = 200;
        public static int samuraiCount = 0;

        public Samurai(string person) : base(person){
            
        }

        public Samurai(string person, int str, int intel, int dex, int hp) :base(person, str, intel, dex, hp)
        {

        }
        public void DeathBlow(Human enemy) {
            if (enemy.health < 50) {
                enemy.health = 0;
            }
        }

        public void Meditate() {
            this.health = 200;
        }

        public static void HowMany() {
            samuraiCount++;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
