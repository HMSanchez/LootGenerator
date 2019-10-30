using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC150_ConsoleMenu;
using LootGenerator.Characters;
using LootGenerator.Characters.Monsters;
using LootGenerator.Characters.Heroes;

namespace LootGenerator
{
    public class LootGenerator
    {
        

        public static Dictionary<string, Item> loot = new Dictionary<string, Item>();
             public static string[] randItemNames = new string[] {"Bucket", "Broom", "Fork", "Broken Music Box", "Dirty Shoe", "Broken Lamp", "Mop","Camera" };
        public static string[] nades = new string[] {"Flash","Frag","Incendiary","Smoke","Gas","Poison" };
        public static string[] darts = new string[] { "Light Toxicity", "Medium Toxicity", "Heavy Toxicity" };
        public static string[] steroidNames = new string[] { "Anadrol" ,"Oxandrin" ,"Dianabol", "Winstrol" ,"Deca-Durabolin",  "Equipoise" };
            public static string[] ArmorNames = new string[] { "Cardboard","Golden Fleece", "LightLeather", "Platemail", "Chainmail",  "Dragonskin", "Iron","Diamond" };
            public static string[] WeaponNames = new string[] {"Kunai", "Katana", "Frork","Gold Spoon", "Short Sword", "Bo Staff", "Nunchucks", "Hand Cannon", "Legendary Cutlass", "Silver Toothpick", "Flintlock Pistol" };
        public static string[] assassinNames = new string[] { "Connor","Edward","Ezio","Arno","Altair","Desmond","Aguilar", "Jacob","Evie","Aveline"};
        public static string[] templarNames = new string[] { "Haytham", "Shay", "Elise", "Lucy","Henry","Warren","Ransom","Benjamin","Alan"};

        public static Random rand = new Random();
        public static int PCT = 0;
        public static int ICT = 0;
        public static int WCT = 0;
        public static int ACT = 0;
        public static int SCT = 0;
        public static int PDCT = 0;
        public static int GCT = 0;
        public static void run()
        {

        
            bool valid = false;
            do
            {
                Console.WriteLine("Main Menu");
                int userIn;
                userIn = CIO.PromptForMenuSelection(new string[] { "Generate 1 Loot Item", "Generate Some Loot Items", "Generate n Loot Items", "Demonstrate Consumables" }, true);
                Console.WriteLine();
                switch (userIn)
                {
                    
                    case 1:
                        loot.Clear();
                        GenOneItem();
    
                        break;
                    case 2:
                        loot.Clear();
                        GenRandSetAmt(1, 10);

                        break;
                    case 3:
                        loot.Clear();
                        string userinput = "";
                        int num = 0;
                        bool Valid = false;
                        do
                        {
                            Console.WriteLine("How many Loot Items? ");
                            try
                            {
                                userinput = Console.ReadLine();
                                num = int.Parse(userinput);
                                Valid = true;

                            }
                            catch (FormatException fe)
                            {
                                Console.WriteLine("Not a int. Re-enter");
                                Valid = false;
                            }
                            catch (ArgumentNullException ane)
                            {
                                Console.WriteLine("NULL. Re-enter");
                                Valid = false;

                            }
                            catch (OverflowException oe)
                            {
                                Console.WriteLine("Larger than an int. Re-enter");
                            }
                            if (num < 1)
                            {
                               
                                Valid = false;
                            }

                            } while (!Valid);
                        GenNthAmt(1, num);

                            break;
                    case 4:
                        optFour();
                        //Weapon one = new Weapon(1,500,"Mjilnor",1400);
                        //Armor goat = new Armor(4, 5, 3, ArmorNames[2], 400);
                        //Steroid a = new Steroid(40,"hex", 40);
                        //Potion x = new Potion(50, "Heal", 200);
                        //Character ezio =new Assassin("goat",one,goat);
                        //Grenade g1 = new Grenade(200,"frag", 70);
                        //Console.WriteLine(g1);
                        //g1.Use(ezio);
                        //Console.WriteLine(ezio);

                        //Console.WriteLine(x);
                        //x.Use(ezio);
                        //Console.WriteLine(ezio);
                        //a.Use(ezio);
                        //Console.WriteLine(ezio);

                        break;
                    default:

                        valid = true;
                        break;
                }
            } while (!valid);
        }
        public static void GenOneItem()
        {
         
            int selection = rand.Next(1, 8);
       int randNum = rand.Next(10, 101);
            int consumableVal = rand.Next(1,76);
            int grenadeDMG = rand.Next(1,301);
            int dartDMG = rand.Next(75, 301);
            if (selection == 1)
            {
                Item p = new Potion((int)(randNum), "Health Potion", (int)(randNum * .10));

                loot["Potion" + PCT++] = p;
                Console.WriteLine("Potion" + PCT + ": " + p);

            }
            else if (selection == 2)
            {
                string randString = randItemNames[rand.Next(0, randItemNames.Length)];
                Item p = new Item(randString, rand.Next(0, 26));
                loot["Item" + ICT++] = p;
                Console.WriteLine("Item" + ICT + " : " + p);

            }
            else if (selection == 3)
            {
                string armorName = ArmorNames[rand.Next(0, ArmorNames.Length)];
                Item p = new Armor(rand.Next(8, 18), rand.Next(0, 11), rand.Next(-6, 1), armorName, rand.Next(10, 1501));

                loot["Armor" + ACT++] = p;
                Console.WriteLine("Armor" + ACT + ": " + p);

            }
            else if (selection == 4)
            {
                string weaponName = WeaponNames[rand.Next(0, WeaponNames.Length)];
                int weaponMax = rand.Next(1, 101);
                int weaponMin = rand.Next(1, 101);
                int weaponValue = rand.Next(1, 501);
                Item p = new Weapon(weaponMin, weaponMax, weaponName, weaponValue);
                loot["Weapon" + WCT++] = p;
                Console.WriteLine("Weapon" + WCT + ": " + p);

            }
            else if (selection == 5)
            {
                string steroidName = steroidNames[rand.Next(0, steroidNames.Length)];
                Item p = new Steroid(rand.Next(1,50), steroidName, consumableVal);
                loot["Steroid" + SCT++] = p;
                Console.WriteLine("Steroid" + SCT + ": " + p);

            }
            else if (selection == 6)
            {
                string grenadeName = nades[rand.Next(0, nades.Length)];
                Item p = new Grenade(grenadeDMG, grenadeName, consumableVal);
                loot["Grenade" + GCT++] = p;
                Console.WriteLine("Grenade" + GCT + ": " + p);
            }
            else if (selection == 7)
            {
                string dartName =darts[rand.Next(0, darts.Length)];
                Item p = new PoisonDart(dartDMG, dartName, consumableVal);
                loot["Poison Dart" + PDCT++] = p;
                Console.WriteLine("Poison Dart" + PDCT + ": " + p);

            }
        }
        public static void GenRandSetAmt(int min, int max)
        {
           

            if (min < 1)
            {
                
                min = 1;
            }
            PCT = 1;
            ICT = 1;
            WCT = 1;
            ACT = 1;
            int randomNum = rand.Next(min, max+1);
            int randNum = rand.Next(10, 101);
            int consumableVal = rand.Next(1, 76);
            int grenadeDMG = rand.Next(1, 301);
            int dartDMG = rand.Next(75, 301);
            int count = 0;
     
            //Console.WriteLine(randomNum);
            do
            {
                int select = rand.Next(1, 8);
                //Console.WriteLine("rand" +select);
                if (select == 1)
                {
                  

               
                 


                    Item a = new Potion(randNum, "Health Potion", (int)(randNum * .10));
                    loot["Potion" + PCT++] = a;
                    //Console.WriteLine(PCT);

                    count += 1;


                }
                else if (select == 2)
                {
                    
                    string randString = randItemNames[rand.Next(0, randItemNames.Length)];
                    Item b = new Item(randString, rand.Next(0, 26));
                    loot["Item" + ICT++] = b;
                    count += 1;


                }
                else if (select == 3)
                {
                    string armorName = ArmorNames[rand.Next(0, ArmorNames.Length)];
                    Item c = new Armor(rand.Next(8, 18), rand.Next(0, 11), rand.Next(-6, 1), armorName, rand.Next(10, 1501));

                    loot["Armor" + ACT++] = c;
                    count += 1;


                }
                else if (select == 4)


                {
                    string weaponName = WeaponNames[rand.Next(0, WeaponNames.Length)];
                    int weaponMax = rand.Next(1, 101);
                    int weaponMin = rand.Next(1, 101);
                    int weaponValue = rand.Next(1, 501);
                    Item d = new Weapon(weaponMin, weaponMax, weaponName, weaponValue);
                    loot["Weapon" + WCT++] = d;

                    count += 1;

                }
                else if (select == 5)
                {
                    string steroidName = steroidNames[rand.Next(0, steroidNames.Length)];
                    Item p = new Steroid(rand.Next(1, 50), steroidName, consumableVal);
                    loot["Steroid" + SCT++] = p;
                    count += 1;

                }
                else if (select == 6)
                {
                    string grenadeName = nades[rand.Next(0, nades.Length)];
                    Item p = new Grenade(grenadeDMG, grenadeName, consumableVal);
                    loot["Grenade" + GCT++] = p;
                    count += 1;

                }
                else if (select == 7)
                {
                    string dartName = darts[rand.Next(0, darts.Length)];
                    Item p = new PoisonDart(dartDMG, dartName, consumableVal);
                    loot["Poison Dart" + PDCT++] = p;
                    count += 1;

                }
                else
                {
                    string randString = randItemNames[rand.Next(0, randItemNames.Length)];
                    Item b = new Item(randString, rand.Next(0, 26));
                    loot["Item"] = b;
                    count += 1;

                }
                //Console.WriteLine(count);

            } while (count < randomNum);
            Dictionary<string, Item>.KeyCollection keysColl = loot.Keys;
            Dictionary<string, Item>.ValueCollection valColl = loot.Values;
            List<string> keys = new List<string>(loot.Keys);
            int counter = 1;

            foreach (string key in keysColl)
            {

                Console.WriteLine((counter++) + ". " + key + " : " + loot[key]);
                Console.WriteLine();


            }

        }
        public static void GenNthAmt(int min, int max)
        {
         
            if (min < 1)
            {

                min = 1;
            }
            PCT = 1;
            ICT = 1;
            WCT = 1;
            ACT = 1;
            int randNum = rand.Next(10, 101);
            int consumableVal = rand.Next(1, 76);
            int grenadeDMG = rand.Next(1, 301);
            int dartDMG = rand.Next(75, 301);
            int count = 0;

            //Console.WriteLine(randomNum);
            do
            {
                int select = rand.Next(1, 8);
                //Console.WriteLine("rand" +select);
                if (select == 1)
                {
                    Item a = new Potion(randNum, "Health Potion", (int)(randNum * .10));
                    loot["Potion" + PCT++] = a;
                    count += 1;


                }
                else if (select == 2)
                {
                    string randString = randItemNames[rand.Next(0, randItemNames.Length)];
                    Item b = new Item(randString, rand.Next(0, 26));
                    loot["Item" + ICT++] = b;
                    count += 1;


                }
                else if (select == 3)
                {
                    string armorName = ArmorNames[rand.Next(0, ArmorNames.Length)];
                    Item c = new Armor(rand.Next(8, 18), rand.Next(0, 11), rand.Next(-6, 1), armorName, rand.Next(10, 1501));

                    loot["Armor" + ACT++] = c;
                    count += 1;


                }
                else if (select == 4)


                {
                    string weaponName = WeaponNames[rand.Next(0, WeaponNames.Length)];
                    int weaponMax = rand.Next(1, 101);
                    int weaponMin = rand.Next(1, 101);
                    int weaponValue = rand.Next(1, 501);
                    Item d = new Weapon(weaponMin, weaponMax, weaponName, weaponValue);
                    loot["Weapon" + WCT++] = d;

                    count += 1;

                }
                else if (select == 5)
                {
                    string steroidName = steroidNames[rand.Next(0, steroidNames.Length)];
                    Item p = new Steroid(rand.Next(1, 50), steroidName, consumableVal);
                    loot["Steroid" + SCT++] = p;
                    count += 1;

                }
                else if (select == 6)
                {
                    string grenadeName = nades[rand.Next(0, nades.Length)];
                    Item p = new Grenade(grenadeDMG, grenadeName, consumableVal);
                    loot["Grenade" + GCT++] = p;
                    count += 1;

                }
                else if (select == 7)
                {
                    string dartName = darts[rand.Next(0, darts.Length)];
                    Item p = new PoisonDart(dartDMG, dartName, consumableVal);
                    loot["Poison Dart" + PDCT++] = p;
                    count += 1;

                }
                else
                {
                    string randString = randItemNames[rand.Next(0, randItemNames.Length)];
                    Item b = new Item(randString, rand.Next(0, 26));
                    loot["Item"] = b;
                    count += 1;

                }
                //Console.WriteLine(count);

            } while (count < max);
            Dictionary<string, Item>.KeyCollection keysColl = loot.Keys;
            Dictionary<string, Item>.ValueCollection valColl = loot.Values;
            List<string> keys = new List<string>(loot.Keys);
            int counter = 1;

            foreach (string key in keysColl)
            {

                Console.WriteLine((counter++) + ". " + key + " : " + loot[key]);
                Console.WriteLine();


            }

        }
        public static void optFour()
        {
            int randNum = rand.Next(10, 101);
            int consumableVal = rand.Next(1, 76);
            int grenadeDMG = rand.Next(1, 151);
            int dartDMG = rand.Next(75, 151);
            string weaponName = WeaponNames[rand.Next(0, WeaponNames.Length)];
            int weaponMax = rand.Next(1, 101);
            int weaponMin = rand.Next(1, 101);
            int weaponValue = rand.Next(1, 501);
            string randString = randItemNames[rand.Next(0, randItemNames.Length)];
            string armorName = ArmorNames[rand.Next(0, ArmorNames.Length)];
            string assassinName = assassinNames[rand.Next(0, assassinNames.Length)];
            string templarName = templarNames[rand.Next(0, templarNames.Length)];
            string steroidName = steroidNames[rand.Next(0, steroidNames.Length)];
            string grenadeName = nades[rand.Next(0, nades.Length)];
            string dartName = darts[rand.Next(0, darts.Length)];
            int itemCount = 1;
            int randStats1 = rand.Next(3,34);
            int randStats2= rand.Next(3, 34);
            int randStats3 = rand.Next(3, 34);

            int randMods1 = rand.Next(1,5);
            int randMods2 = rand.Next(1, 5);
            int randMods3 = rand.Next(1, 5);


            Console.WriteLine("************CONSUMABLES************");
            //Item[] lootItems = new Item[7];
            Potion a = new Potion(randNum, "Health Potion", (int)(randNum * .10));
            Console.WriteLine((itemCount++) + ". "+ a);
            //Item b = new Item(randString, rand.Next(0, 26));
            //Console.WriteLine((itemCount++) +". Item: " +b);
            //Weapon c = new Weapon(weaponMin, weaponMax, weaponName, weaponValue);
            //Console.WriteLine((itemCount++) +". Weapon: " + c);
            //Armor d = new Armor(rand.Next(8, 18), rand.Next(0, 11), rand.Next(-6, 1), armorName, rand.Next(10, 1501));
            //Console.WriteLine((itemCount++) + ". Armor: " +d);
            Steroid e = new Steroid(rand.Next(1, 50), steroidName, consumableVal);
            Console.WriteLine((itemCount++) + ". Steroid: " +e);
            Grenade f = new Grenade(grenadeDMG, grenadeName, consumableVal);
            Console.WriteLine((itemCount++) +". Grenade: " +f);
            PoisonDart g = new PoisonDart(dartDMG, dartName, consumableVal);
            Console.WriteLine((itemCount++) + ". Posion Dart: " + g);

            Console.WriteLine("************CHARACTERS************");
            Console.WriteLine();
            Weapon h1 = new Weapon(weaponMin, weaponMax, weaponName, weaponValue);
            Armor h2 = new Armor(rand.Next(8, 18), rand.Next(0, 11), rand.Next(-6, 1), armorName, rand.Next(10, 1501));
           Hero h = new Hero(assassinName,h1,h2, rand.Next(3, 34), rand.Next(3, 34), rand.Next(3, 34), rand.Next(1, 5), rand.Next(1, 5), rand.Next(1, 5));
            Console.WriteLine((itemCount++) + ". Assassin" + h );
            Weapon i1 = new Weapon(weaponMin, weaponMax, weaponName , weaponValue);
            Armor i2 = new Armor(rand.Next(8, 18), rand.Next(0, 11), rand.Next(-6, 1), armorName, rand.Next(10, 1501));
            Monster i = new  Monster(templarName, i1, i2, rand.Next(3, 34), rand.Next(3, 34), rand.Next(3, 34), rand.Next(1, 5), rand.Next(1, 5), rand.Next(1, 5));
            Console.WriteLine((itemCount++) + ". Templar" + i);
            Weapon j1 = new Weapon(weaponMin, weaponMax, "Wall", weaponValue);
            Armor j2 = new Armor(rand.Next(8, 18), rand.Next(0, 11), rand.Next(-6, 1), armorName, rand.Next(10, 1501));
            Monster j = new Monster("Donald Trump",j1,j2, rand.Next(3, 34), rand.Next(3, 34), rand.Next(3, 34), rand.Next(1, 5), rand.Next(1, 5), rand.Next(1, 5));
            Console.WriteLine((itemCount++) + "." + j);
            Console.WriteLine();
            Console.WriteLine("********TARGET IS TRUMP********");
            Console.WriteLine();
            Console.WriteLine(j);
            //Console.WriteLine("Grenade will be used against Trump");
            f.Use(j);
            Console.WriteLine("Description: " + f.GetDescription());
            Console.WriteLine("********AFTER GRENADE********");
            Console.WriteLine(j);
            //Console.WriteLine("Next Trump will use a steroid");
            e.Use(j);
            Console.WriteLine("Description: " + e.GetDescription());
            Console.WriteLine("********AFTER STEROID********");

            Console.WriteLine(j);
            //Console.WriteLine("Next Trump will use a Health Potion");
            a.Use(j);
            Console.WriteLine("Description: " + a.GetDescription());
            Console.WriteLine("********AFTER HEALTH POTION********");

            Console.WriteLine(j);
            //Console.WriteLine("Lastly, Trump will be hit with a Poison Dart");
            g.Use(j);
            Console.WriteLine("Description: " + g.GetDescription());
            Console.WriteLine("********AFTER POISON DART********");

            Console.WriteLine(j);
            int assassinATK = h.Attack();
            Console.WriteLine("Assassin's attack damage: " + assassinATK);
            j.TakeDamage(assassinATK);
            Console.WriteLine("********AFTER ASSASSIN ATTACKS TRUMP********");
            Console.WriteLine(j);
        }

    }
}
