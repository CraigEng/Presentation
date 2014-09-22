using System.Collections.Generic;
using BabyGiftRegisterLibrary.Model;

namespace BabyGiftRegisterLibrary.Default
{
    public static class DataGenerator
    {
        public static List<RegisterItem> GetInitialRegisterItems()
        {
            var registerItems = new List<RegisterItem>();

            int id = 0;
            AddItem(registerItems, ++id, "4Moms Mamaroo", "MomsMamaroo", "R 2000", false, true);
            AddItem(registerItems, ++id, "Simba Play Gym", "SimbaPlayGym", "R 250", true, true);
            AddItem(registerItems, ++id, "Tolo First Friends Go-Kart", "ToloFirstFriendsGoKart", "R 100", false, true);
            AddItem(registerItems, ++id, "Tolo Pop-Up Dinosaurs", "ToloPopUpDinosaurs", "R 70", false, true);
            AddItem(registerItems, ++id, "Tolo Rolling Ball Shape", "ToloRollingBallShape", "R 80", false, true);
            AddItem(registerItems, ++id, "Tolo Shape Sorter Play", "ToloShapeSorterPlay", "R 150", false, false);
            AddItem(registerItems, ++id, "Tolo Wobbly Clown", "ToloWobblyClown", "R 120", false, false);
            AddItem(registerItems, ++id, "Yoyo Blue Rocking Pony", "YoyoBlueRockingPony", "R 1000", false, false);
            return registerItems;
        }

        private static void AddItem(List<RegisterItem> registerItems, int id, string name, string imageName,
            string price, bool sold, bool inRegister)
        {
            var item = new RegisterItem
            {
                Id = id,
                Name = name,
                ImageName = imageName,
                Sold = sold,
                InRegister = inRegister,
                Price = price
            };

            registerItems.Add(item);
        }
    }
}