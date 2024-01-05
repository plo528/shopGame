using System;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace shopGame
{
    class Item 
    {
        public string shopName;
        public string shopInfo;
        public int shopPrice;
        public int shopDef;
        public int shopAtk;
        public bool isEquip;
        public Item(string sname,int sdef,int satk, string sinfo, int sprice)
        {
            shopName = sname;
            shopDef = sdef;
            shopAtk = satk;
            shopInfo = sinfo;
            shopPrice = sprice;
            isEquip = false;
        }
    }
    internal class Program
    {
        static int choice;
        static bool firstStat = true;
        static Person p1;
        static int plus;
        static List<Item> inventory = new List<Item>();
        
        struct Person
        {
            public int level;
            public string name;
            public int atk;
            public int def;
            public int hp;
            public int gold;

            public void StatInfo()
            {
                Console.WriteLine($"LV. {level}\nChad ({name})\n공격력 : {atk}\n방어력 : {def}\n체력 : {hp}\nGold : {gold}\n");
            }
        }
        static void Main(string[] args)
        {
            
            p1.level = 1;
            p1.name = "전사";
            p1.atk = 10;
            p1.def = 5;
            p1.hp = 100;
            p1.gold = 1500;
            firstStat = false;
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("\n");
            Town();
        }
        static void Town()
        {
            Console.WriteLine("1. 상태보기\n2. 인벤토리\n3. 상점\n0. 종료");
            Console.WriteLine("\n");
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");
                
                string input = Console.ReadLine();
                Console.WriteLine("\n");
                if (string.IsNullOrWhiteSpace(input))
                {
                    choice = 9999;
                    continue;
                }
                else if (int.TryParse(input, out choice))
                {
                }
                else
                {
                    Console.WriteLine("숫자로 입력해주세요.");
                    continue;
                }
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("종료합니다");
                        return;
                    case 1:
                        stat();
                        break;
                    case 2:
                        inven();
                        break;
                    case 3:
                        Shop();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        continue;
                }
                break;
            }
        }
        static void stat()
        {
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("상태 보기");
            Console.ResetColor();
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("\n");
            p1.StatInfo();
            Console.WriteLine("0. 나가기\n");
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");

                string input = Console.ReadLine();
                Console.WriteLine("\n");
                if (string.IsNullOrWhiteSpace(input))
                {
                    choice = 9999;
                    continue;
                }
                else if (int.TryParse(input, out choice))
                {
                }
                else
                {
                    Console.WriteLine("숫자로 입력해주세요.");
                    continue;
                }
                switch (choice)
                {
                    case 0:
                        Town();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        continue;
                }
                break;
            }
        }
        static void inven()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("인벤토리");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("\n");
            Console.WriteLine("[아이템 목록]");
            foreach(var inv in inventory)
            {
                Console.Write("- ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{checkEquip(inv)}");
                Console.ResetColor();
                Console.Write($"{inv.shopName} | ");
                AtkOrDef(inv.shopDef, inv.shopAtk);
                Console.WriteLine($" | {inv.shopInfo}");
            }
            Console.WriteLine("1. 장착 관리\n0. 나가기");
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");

                string input = Console.ReadLine();
                Console.WriteLine("\n");
                if (string.IsNullOrWhiteSpace(input))
                {
                    choice = 9999;
                    continue;
                }
                else if (int.TryParse(input, out choice))
                {
                }
                else
                {
                    Console.WriteLine("숫자로 입력해주세요.");
                    continue;
                }
                switch (choice)
                {
                    case 0:
                        Town();
                        break;
                    case 1:
                        EqInven();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        continue;
                }
                break;
            }
        }
        static void EqInven()
        {
            int i = 0;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("\n");
            Console.WriteLine("[아이템 목록]");
            foreach (var inv in inventory)
            {
                Console.Write($"- {i+1}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{checkEquip(inv)}");
                Console.ResetColor();
                Console.Write($"{inv.shopName} | ");
                AtkOrDef(inv.shopDef, inv.shopAtk);
                Console.WriteLine($" | {inv.shopInfo}");
            }
            Console.WriteLine("0. 나가기");
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");

                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");
                if(choice == 0)
                {
                    inven();
                    break;
                }
                else if (choice > 0) 
                {
                    if (inventory[choice-1] == null)
                    {
                        Console.WriteLine("잘못된 입력 입니다.");
                        continue;
                    }
                    else
                    {
                        inventory[choice - 1].isEquip = !inventory[choice - 1].isEquip;
                        if (inventory[choice - 1].isEquip)
                        {
                            Console.WriteLine("장착했습니다.");
                            PlustEquip(choice - 1);
                            EqInven();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("장측을 해제했습니다.");
                            MinusEquip(choice - 1);
                            EqInven();
                            break;
                        }
                    }
                }
            }
        }
        static void PlustEquip(int i)
        {
            if (inventory[i].shopDef == 0)
            {
                p1.atk += inventory[i].shopAtk;
            }
            else if (inventory[i].shopAtk == 0)
            {
                p1.def += inventory[i].shopDef;
            }
        }
        static void MinusEquip(int i)
        {
            if (inventory[i].shopDef == 0)
            {
                p1.atk -= inventory[i].shopAtk;
            }
            else if (inventory[i].shopAtk == 0)
            {
                p1.def -= inventory[i].shopDef;
            }
        }
        static string checkEquip(Item item)
        {
            return item.isEquip ? "[E]" : " ";
        }
        static void Shop()
        {
            Item[] shopItem = new Item[]
            {
                new Item("수련자 갑옷", 5,0, "수련에 도움을 주는 갑옷입니다.", 1000),
                new Item("무쇠갑옷", 9,0, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000),
                new Item("스파르타의 갑옷", 15,0, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500),
                new Item("낡은 검",0, 2, "쉽게 볼 수 있는 낡은 검 입니다.", 600),
                new Item("청동 도끼",0, 5, "어디선가 사용됐던거 같은 도끼입니다.", 1500),
                new Item("스파르타의 창",0, 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 3000)
            };

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("상점");
            Console.ResetColor();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{p1.gold} G");
            Console.WriteLine("\n");
            Console.WriteLine("[아이템 목록]");

            foreach (var item in shopItem)
            {
                Console.Write($"- {item.shopName} | ");
                AtkOrDef(item.shopDef, item.shopAtk);
                Console.Write($" | {item.shopInfo} | ");
                if (InvenItem(item, inventory))
                {
                    Console.WriteLine("구매완료");
                }
                else
                {
                    Console.WriteLine($"{item.shopPrice} G");
                }

            }

            Console.WriteLine("1. 아이템 구매\n0. 나가기");
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");

                string input = Console.ReadLine();
                Console.WriteLine("\n");
                if (string.IsNullOrWhiteSpace(input))
                {
                    choice = 9999;
                    continue;
                }
                else if (int.TryParse(input, out choice))
                {
                }
                else
                {
                    Console.WriteLine("숫자로 입력해주세요.");
                    continue;
                }
                switch (choice)
                {
                    case 0:
                        Town();
                        break;
                    case 1:
                        Shoping();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        continue;
                }
                break;
            }
        }
        static void Shoping()
        {
            bool[] isBuy = new bool[6] {false,false,false,false,false,false};
            int i = 0;
            Item[] shopItem = new Item[]
            {
                new Item("수련자 갑옷", 5,0, "수련에 도움을 주는 갑옷입니다.", 1000),
                new Item("무쇠갑옷", 9,0, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000),
                new Item("스파르타의 갑옷", 15,0, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500),
                new Item("낡은 검",0, 2, "쉽게 볼 수 있는 낡은 검 입니다.", 600),
                new Item("청동 도끼",0, 5, "어디선가 사용됐던거 같은 도끼입니다.", 1500),
                new Item("스파르타의 창",0, 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 3000)
            };

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("상점 - 아이템 구매");
            Console.ResetColor();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{p1.gold} G");
            Console.WriteLine("\n");
            Console.WriteLine("[아이템 목록]");

            foreach (var item in shopItem)
            {
             
                Console.Write($"- {i+1} {item.shopName} | ");
                AtkOrDef(item.shopDef, item.shopAtk);
                Console.Write($" | {item.shopInfo} | ");
                if (InvenItem(item, inventory))
                {
                    Console.WriteLine("구매완료");
                    isBuy[i] = true;
                }
                else
                {
                    Console.WriteLine($"{item.shopPrice} G");
                }
                i++;

            }
            Console.WriteLine("0. 나가기");
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");

                string input = Console.ReadLine();
                Console.WriteLine("\n");
                if (string.IsNullOrWhiteSpace(input))
                {
                    choice = 9999;
                    continue;
                }
                else if (int.TryParse(input, out choice))
                {
                }
                else
                {
                    Console.WriteLine("숫자로 입력해주세요.");
                    continue;
                }
                switch (choice)
                {
                    case 0:
                        Shop();
                        break; 
                    case 1:
                        if(p1.gold < shopItem[choice-1].shopPrice)
                        {
                            Console.WriteLine("Gold가 부족합니다.");
                            continue;
                        }
                        else if (isBuy[choice - 1] == true)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                        else
                        {
                            Console.WriteLine("구매를 완료했습니다.");
                            p1.gold -= shopItem[choice - 1].shopPrice;
                            inventory.Add(shopItem[choice - 1]);
                        }
                        Shoping();
                        break;
                    case 2:
                        if (p1.gold < shopItem[choice - 1].shopPrice)
                        {
                            Console.WriteLine("Gold가 부족합니다.");
                            continue;
                        }
                        else if (isBuy[choice - 1] == true)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                        else
                        {
                            Console.WriteLine("구매를 완료했습니다.");
                            p1.gold -= shopItem[choice - 1].shopPrice;
                            inventory.Add(shopItem[choice - 1]);
                        }
                        Shoping();
                        break;
                    case 3:
                        if (p1.gold < shopItem[choice - 1].shopPrice)
                        {
                            Console.WriteLine("Gold가 부족합니다.");
                            continue;
                        }
                        else if (isBuy[choice - 1] == true)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                        else
                        {
                            Console.WriteLine("구매를 완료했습니다.");
                            p1.gold -= shopItem[choice - 1].shopPrice;
                            inventory.Add(shopItem[choice - 1]);
                        }
                        Shoping();
                        break;
                    case 4:
                        if (p1.gold < shopItem[choice - 1].shopPrice)
                        {
                            Console.WriteLine("Gold가 부족합니다.");
                            continue;
                        }
                        else if (isBuy[choice - 1] == true)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                        else
                        {
                            Console.WriteLine("구매를 완료했습니다.");
                            p1.gold -= shopItem[choice - 1].shopPrice;
                            inventory.Add(shopItem[choice - 1]);
                        }
                        Shoping();
                        break;
                    case 5:
                        if (p1.gold < shopItem[choice - 1].shopPrice)
                        {
                            Console.WriteLine("Gold가 부족합니다.");
                            continue;
                        }
                        else if (isBuy[choice - 1] == true)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                        else
                        {
                            Console.WriteLine("구매를 완료했습니다.");
                            p1.gold -= shopItem[choice - 1].shopPrice;
                            inventory.Add(shopItem[choice - 1]);
                        }
                        Shoping();
                        break;
                    case 6:
                        if (p1.gold < shopItem[choice - 1].shopPrice)
                        {
                            Console.WriteLine("Gold가 부족합니다.");
                            continue;
                        }
                        else if (isBuy[choice - 1] == true)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                        else
                        {
                            Console.WriteLine("구매를 완료했습니다.");
                            p1.gold -= shopItem[choice - 1].shopPrice;
                            inventory.Add(shopItem[choice - 1]);
                        }
                        Shoping();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        continue;
                }
                break;
            }

        }
        static bool InvenItem(Item item, List<Item> inventory)
        {
            foreach(var invenItem in inventory)
            {
                if(invenItem != null && invenItem.shopName == item.shopName)
                {
                    return true;
                }
            }
            return false;
        }
        static void AtkOrDef(int def, int atk)
        {
            
            if (def ==0)
            {
                plus = atk;
                Console.Write("공격력 +" + plus);
            }
            else if(atk == 0)
            {
                plus = def;
                Console.Write("방어력 +" + plus);
            }
        }
    }
}