using System;
using System.Collections.Generic;
using System.Threading;

namespace Tamagotchi.Models
{
    public class Pet
    {
        public string Name {get; set;}
        public int Id {get; set;}
        public int Hunger {get; set;}
        public int Sleep {get; set;}
        public int Thirst {get; set;}
        public bool Dead {get; set;}
        public static List<Pet> Pets = new List<Pet> {};
        private Timer timer;

        public Pet (string name, int hunger = 80, int sleep = 80, int thirst = 80)
        {
            timer = new Timer(this.TimerTick, null, 0, 1000);

            Name = name;
            Hunger = hunger;
            Sleep = sleep;
            Thirst = thirst;
            Id = Pets.Count;
            Pets.Add(this);
            Dead = false;
        }
        private void TimerTick(Object stateInfo)
        {
            Time(1);
        }

        public static List<Pet> GetList()
        {
            return Pets;
        }

        public static int Clamp(int number, int min, int max)
        {
            if (number > max)
            {
                return max;
            }
            else if (number < min)
            {
                return min;
            }
            else
            {
                return number;
            }
        }

        public void ChangePetStatus(int water, int food, int sleep)
        {
            if (Dead == false) {
                Thirst = Clamp(Thirst += water, 0, 100);
                Hunger = Clamp(Hunger += food, 0, 100);
                Sleep = Clamp(Sleep += sleep, 0, 100);
            }
        }
        public static void Time(int hours)
        {
            foreach (Pet pet in Pets) {
                pet.ChangePetStatus(-hours,-hours,-hours);
                if (pet.Thirst <= 0 || pet.Hunger <= 0 || pet.Sleep <= 0)
                {
                    pet.Dead = true;
                }
            }
        }
    }
}
