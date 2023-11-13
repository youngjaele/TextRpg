using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    internal class Item
    {
        
        static List<Item> itemsAbility = new List<Item>
        {
            new Item(0, "│ 1.       낡은 검           │", 5, 0, "        │ 낡은 검이다.     │" ),
            new Item(1, "│ 2.       낡은 갑옷         │", 0, 8, "        │ 낡은 갑옷이다.   │" ),
            new Item(2, "│ 3.       폭탄              │", 1000, 0, "     │ 폭탄이다.        │" )
        };


        public int ItemNumber;
        public string ItemName;
        public int ItemAtk;
        public int ItemDef;
        public string Description;

        public bool EquipUse { get; set; }

        public Item(int _itemNumber, string _itemName, int _itematk, int _itemDef, string _description)
        {
            ItemNumber = _itemNumber;
            ItemName = _itemName;
            ItemAtk = _itematk;
            ItemDef = _itemDef;
            Description = _description;

            EquipUse = false;
        }

        // 아이템 종류


        // 인벤토리 화면
        public static void ShowInventory()
        {
          

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Program.WriteStartText("[인벤토리]", 1, 1);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Program.WriteStartText("보유 중인 아이템을 관리할 수 있습니다.", 10, 3);
            Console.ResetColor();


            Program.WriteStartText("│        [ 아이템 ]       │ [ ATK ]  [DEF] │ [ 설명 ]      │", 1, 6);

            // 인벤토리 목록 구현 해야함 //


            for (int i = 0; i < itemsAbility.Count; i++)
            {
                Item item = itemsAbility[i];

                Console.WriteLine();
                Console.Write($" {item.ItemName}");
                Console.Write($" {item.ItemAtk}  │ {item.ItemDef}");
                Console.WriteLine($" {item.Description}");
            }

            Program.WriteStartText("1. 장착 관리", 52, 22);
            Program.WriteStartText("0. 돌아가기", 52, 24);
            Program.WriteStartText("원하시는 행동을 입력해주세요.", 44, 26);
            Program.WriteStartText(">>                        <<", 44, 28);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(58, 28);
            Console.ResetColor();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "0")
                {
                    Program.GameDisplay();
                }
                else if (input == "1")
                {
                    //EquipItem();
                }
                else
                {
                    Program.WriteStartText("잘못된 입력입니다. 다시 입력해주세요.", 40, 27);
                }
            }
        }
        //static void EquipItem()
        //{
        //    Program.WriteStartText("장착할 장비를 선택해주세요.", 40, 27);

        //    bool equipUse = false;
        //    string input = Console.ReadLine();

        //    if (!equipUse)
        //    {
        //        if (input == "1")
        //        {

        //            equipUse = true;
        //            Console.ForegroundColor = ConsoleColor.Yellow;
        //            Program.WriteStartText("[E]", 5, 8);
        //            Console.ResetColor();
        //        }
        //        else if (input == "2")
        //        {
        //            equipUse = true;
        //            Console.ForegroundColor = ConsoleColor.Yellow;
        //            Program.WriteStartText("[E]", 5, 10);
        //            Console.ResetColor();
        //        }
        //        else
        //        {
        //            equipUse = false;
        //            Console.Write(" ");
        //            return;
        //        }
        //    }
        //}
    }
}
