using System;
using System.Collections.Generic;

namespace Tamagotchi.Models
{
    public class Pet
    {
        public string Name {get; set;}
        public int Id {get; set;}
        public int Hunger {get; set;}
        public int Sleep {get; set;}
        public int Thirst {get; set;}

        public List<Pet> Pets = new List<Pet> {};

        private static Dictionary<string, Pet> _types = new Dictionary<string, Pet>()
        {
            {"Normal", new Pet(80,80,80)},
            {"Hungry", new Pet(50,80,80)},
            {"Sleepy", new Pet(80,50,80)},
            {"Thirsty", new Pet(80,80,50)}
        };

        public Pet (int hunger, int sleep, int thirst)
        {
            Hunger = hunger;
            Sleep = sleep;
            Thirst = thirst;
            Id = Pets.Count;
        }

        public static List<Pet> AdoptPet(string type, string name)
        {
            Pet referencePet = _types[type];
            Pet newPet = new Pet (referencePet.Hunger, referencePet.Sleep, referencePet.Thirst);
            Pet.Name = name;
            Pets.Add(newPet);
            return(Pets);
        }

        public void TimePass()
        {
            Hunger -= 10;
            Sleep -= 10;
            Thirst -= 10;
        }

        public void updatePet(int hunger, int sleep, int thirst)
        {
            Hunger += hunger;
            Sleep += sleep;
            Thirst += thirst;
        }

    }
}
