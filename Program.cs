using System;
using System.Runtime.InteropServices;

namespace shopGame
{
    internal class Program
    {
        static int choice;
        static bool firstStat = true;
        static Person p1;
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
        struct ShopItem
        {

        }
        static void Main(string[] args)
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("\n");
            town();
        }
        static void town()
        {
            Console.WriteLine("1. 상태보기\n2. 인벤토리\n3. 상점");
            Console.WriteLine("\n");
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");
                
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        stat();
                        break;
                    case 2:
                        inven();
                        break;
                    case 3:
                        shop();
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
            if (firstStat==true) 
            {
                p1.level = 1;
                p1.name = "전사";
                p1.atk = 10;
                p1.def = 5;
                p1.hp = 100;
                p1.gold = 1500;
                firstStat = false;
            }
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

                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        town();
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
        }
        static void EqInven()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("\n");
        }
        static void shop()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("상점");
            Console.ResetColor();
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{p1.gold} G");

        }
    }
}