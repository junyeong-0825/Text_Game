# Text_Game
반복문, 조건문, 클래스를 이용한 텍스트 게임

게임시작화면, 인벤토리, 장착관리, 상태보기 구현
```
using System.Security.Cryptography.X509Certificates;

namespace ClassPractice
{
    internal class Program
    {
        private static Player player;
        private static Inventory earlyItem;

        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGate();
           
        }
       

        static void DisplayGate()
        {
            Console.Clear();
            Console.WriteLine("ㅇㅇㅇ 놀이동산에 오신 당신을 환영합니다.");
            Console.WriteLine("이 앞으로 가시면 놀이동산을 충분히 즐기기 전까지 다시 나오실 수 없습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태확인");
            Console.WriteLine("2. 소지품 확인");
            Console.WriteLine("3. 나아간다");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력하세요.");

            int input = CheckVaildInput(1, 3);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;
                case 2:
                    DisplayInventory();
                    break;
                case 3:
                    DisplayGate();
                    break;
                
            }
        }
        static void GameDataSetting()
        {
            player = new Player("□□□", "탐험가", 1, 10, 5, 100, 1500);
            earlyItem = new Inventory(false,"001","짱돌","공격력", 5, "흔하게 널린 돌");
        }
        static void DisplayMyInfo()
        {
            Console.Clear();

            Console.WriteLine("상태확인");
            Console.WriteLine("당신의 현재 정보를 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"LV.{player.Level}");
            Console.WriteLine($"{player.Name} ({player.Job})");
            if (!earlyItem.Equipment)
            {
                Console.WriteLine($"공격력 : {player.Atk}");
            }
            else
            {
                Console.WriteLine($"공격력 : {player.Atk}  (+{earlyItem.Figure})");
            }
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.Hp}");
            Console.WriteLine($"소지금 : {player.Gold}");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int input = CheckVaildInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGate();
                    break;
                
            }
        }
        static void DisplayInventory()
        {
            Console.Clear();

            Console.WriteLine("소지품 확인");
            Console.WriteLine("현재 가지고 있는 물건의 목록입니다.");
            Console.WriteLine();
            Console.WriteLine("이름    |수치        |설명");
            if (!earlyItem.Equipment)
            {
                Console.WriteLine($"{earlyItem.Name}    |{earlyItem.Category} +{earlyItem.Figure}|{earlyItem.Explanation}");

            }
            else
            {
                Console.WriteLine($"[E]{earlyItem.Name}    |{earlyItem.Category} +{earlyItem.Figure}|{earlyItem.Explanation}");

            }
            Console.WriteLine();
            Console.WriteLine("1. 장착하기");
            Console.WriteLine("0. 나가기");

            int input = CheckVaildInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayGate();
                    break;
                case 1:
                    ItemEquipment();
                    break;
                
            }
        }
        static int CheckVaildInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if(ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
        static void ItemEquipment()
        {
            Console.Clear();

            Console.WriteLine("장비 장착");
            Console.WriteLine("소지하고 있는 장비를 장착하거나 해제합니다.");
            Console.WriteLine();
            Console.WriteLine("이름    |수치        |설명");
            if (!earlyItem.Equipment)
            {
                Console.WriteLine($"{earlyItem.Name}    |{earlyItem.Category} +{earlyItem.Figure}|{earlyItem.Explanation}");
            }
            else
            {
                Console.WriteLine($"[E]{earlyItem.Name}    |{earlyItem.Category} +{earlyItem.Figure}|{earlyItem.Explanation}");
            }
            Console.WriteLine($"1. {earlyItem.Name}");
            Console.WriteLine("0. 돌아가기");

            int input = CheckVaildInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayInventory();
                    break;
                case 1:
                    if (!earlyItem.Equipment)
                    {
                        earlyItem.Equipment = true;
                        player.Atk += earlyItem.Figure;
                    }
                    else
                    {
                        earlyItem.Equipment = false;
                        player.Atk -= earlyItem.Figure;
                    }
                    ItemEquipment();
                    break;

            }
        }
        class Player
        {
            public string Name { get; }
            public string Job { get; }
            public int Level { get; set; }
            public int Atk { get; set; }
            public int Def { get; set; }
            public int Hp { get; set; }
            public int Gold { get; set; }

            public Player (string name, string job, int level, int atk, int def, int hp, int gold)
            {
                Name = name;
                Job = job;
                Level = level;
                Atk = atk;
                Def = def;
                Hp = hp;
                Gold = gold;
            }
        }

        class Inventory
        {
            public bool Equipment { get; set; }// 장착여부
            public string ItemNumber { get; }//아이템 ID
            public string Name { get; }//아이템 이름
            public string Category { get; }//아이템 분류
            public int Figure { get; }//아이템이 주는 수치
            public string Explanation {  get; }//아이템 설명

            public Inventory (bool equip,string number, string name, string category, int figure, string explanation)
            {
                Equipment = equip;
                ItemNumber = number;
                Name = name;
                Category = category;
                Figure = figure;
                Explanation = explanation;
            }
        }

        class Item
        {
            public int ItemNumber { get; }
            public string Name { get; }
            public string Category { get; }
            public int Figure { get; }
            public string Explanation { get; }
        }
    }
}
```
