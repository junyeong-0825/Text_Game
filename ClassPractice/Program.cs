using System.Security.Cryptography.X509Certificates;

namespace ClassPractice
{
    internal class Program
    {

        static Player player;
        static Item[] items;

        static void Main(string[] args)
        {
            ///구성
            ///1.초기데이터값세팅
            ///2.로고 출력
            GameDataSetting();
            PrintStartLogo();
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
                    
                    break;
                
            }
        }
        static void GameDataSetting()
        {
            player = new Player("수", "탐험가", 1, 10, 5, 100, 1500);
            items = new Item[30];
            AddItem(new Item(1, "짱돌", 5, 0, 0, "주변에서 흔하게 볼 수 있는 돌."));
            AddItem(new Item(11, "두꺼운 겉옷", 0, 3, 20, "추운 날씨에 입기 안성맞춤인 두꺼운 겉옷."));
        }
        static void PrintStartLogo()
        {
            Console.Clear();

            Console.WriteLine(" ********                                                 **    ");
            Console.WriteLine("/**/////                         ******                  /**    ");
            Console.WriteLine("/**       **   ** *******       /**///**  ******   ******/**  **");
            Console.WriteLine("/******* /**  /**//**///**      /**  /** //////** //**//*/** ** ");
            Console.WriteLine("/**////  /**  /** /**  /**      /******   *******  /** / /****  ");
            Console.WriteLine("/**      /**  /** /**  /**      /**///   **////**  /**   /**/** ");
            Console.WriteLine("/**      //****** ***  /**      /**     //********/***   /**//**");
            Console.WriteLine("//        ////// ///   //       //       //////// ///    //  // ");

            Console.ReadKey();
        }
        static void DisplayMyInfo()
        {
            Console.Clear();

            Console.WriteLine("◆ 상태확인 ◆");
            Console.WriteLine("당신의 현재 정보를 표시합니다.");
            Console.WriteLine();
            PrintTextWithHighlights("LV. ", player.Level.ToString("00"));//01, 07 과 같이 10미만의 수도 두자리로 출력
            Console.WriteLine($"{player.Name} ({player.Job})");
            PrintTextWithHighlights("공격력 :", player.Atk.ToString());
            PrintTextWithHighlights("방어력 :", player.Def.ToString());
            PrintTextWithHighlights("체력 :", player.Hp.ToString());
            PrintTextWithHighlights("소지금 :", player.Gold.ToString());
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

            Showhighlightedtext("◆ 소지품 확인 ◆");
            Console.WriteLine("현재 가지고 있는 물건의 목록입니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for(int i = 0; i<Item.ItemCnt; i++)
            {
                items[i].PrintItemStatDescription();
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
                //case 1:
                //    ItemEquipment();
                //    break;
                
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
                Console.WriteLine($"지정된 범위의 숫자를 입력해 주세요.({min}~{max})");
            }
        }
        //static void itemequipment()//아이템 장착 여부 확인
        //{
        //    console.clear();

        //    console.writeline("장비 장착");
        //    console.writeline("소지하고 있는 장비를 장착하거나 해제합니다.");
        //    console.writeline();
        //    console.writeline("이름    |수치        |설명");
        //    if (!item.equipment)
        //    {
        //        console.writeline($"{item.name}    |{item.category} +{item.figure}|{item.explanation}");
        //    }
        //    else
        //    {
        //        console.writeline($"[e]{item.name}    |{item.category} +{item.figure}|{item.explanation}");
        //    }
        //    console.writeline($"1. {item.name}");
        //    console.writeline("0. 돌아가기");

        //    int input = checkvaildinput(0, 1);
        //    switch (input)
        //    {
        //        case 0:
        //            displayinventory();
        //            break;
        //        case 1:
        //            if (!item.equipment)
        //            {
        //                item.equipment = true;
        //                player.atk += item.figure;
        //            }
        //            else
        //            {
        //                item.equipment = false;
        //                player.atk -= item.figure;
        //            }
        //            itemequipment();
        //            break;

        //    }
        //}
        private static void Showhighlightedtext(string text)//해당 문장을 마젠타 색으로 출력
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        private static void PrintTextWithHighlights(string s1, string s2, string s3 = "")
        {
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(s2);
            Console.ResetColor();
            Console.WriteLine(s3);
        }
        static void AddItem(Item item)
        {
            if (Item.ItemCnt == 30) return; //인벤토리에 아이템이 31개 있는경우 아무일도 일어나지 않음
            items[Item.ItemCnt] = item; //0개 -> 0번 인덱스 / 1개 1번 인덱스
            Item.ItemCnt++;
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

        class Item
        {
            public bool Equipment { get; set; }// 장착여부
            public int ItemNumber { get; }//아이템 ID
            public string Name { get; }//아이템 이름
            public int Atk { get; }//아이템이 주는 공격력
            public int Def { get; }//아이템이 주는 공격력
            public int Hp { get; }//아이템이 주는 공격력
            public string Explanation {  get; }//아이템 설명
            
            public static int ItemCnt = 0; //아이템의 수

            public Item (int number, string name, int atk, int def, int hp, string explanation, bool equip= false)
            {
                Equipment = equip;
                ItemNumber = number;
                Name = name;
                Atk = atk;
                Def = def;
                Hp = hp;
                Explanation = explanation;
            }
            public void PrintItemStatDescription(bool withNumber = false, int idx = 0)
            {
                Console.Write("-");
                if (Equipment)
                {
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("E");
                    Console.ResetColor();
                    Console.Write("]");
                }
                Console.Write(Name);
                Console.Write(" | ");
                //(Atk >= 0 ? "+" : "") [조건 ? 조건이 참이면 : 조건이 거짓이면] 삼항연산자
                if (Atk != 0) Console.Write($"공격력 {(Atk >= 0 ? "+" : "")}{Atk}");
                if (Def != 0) Console.Write($"방어력 {(Def >= 0 ? "+" : "")}{Def}");
                if (Hp != 0) Console.Write($"체력 {(Hp >= 0 ? "+" : "")}{Hp}");

                Console.Write(" | ");

                Console.WriteLine(Explanation);
            }
        }

        
    }
}