using System.Numerics;

namespace TextRpg
{
    internal class Program
    {
        public static void WriteStartText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

        private static Character player;
        private static Item item;

        // 메인
        static void Main(string[] args)
        {
            StartMenu();
        }
        

        // 이름 설정 및 직업 선택
        static void PlayerSetting()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            WriteStartText("플레이어의 이름을 입력해주세요 : ", 20, 10);
            Console.SetCursorPosition(53, 10);
            string playerName = Console.ReadLine();
            Console.ResetColor();

            if (playerName != null)
            {
                player = new Character($"{playerName}", "(직업)", 1, 10, 5, 100, 50, 3000);
                PlayerJob(playerName);
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
            }
            static void PlayerJob(string playerName)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                WriteStartText("직업을 선택해주세요.", 47, 2);
                Console.ResetColor();

                WriteStartText("1. 전사", 50, 8);
                WriteStartText("2. 마법사", 50, 10);
                WriteStartText("3. 도적", 50, 12);
                Console.ForegroundColor = ConsoleColor.Red;
                WriteStartText("0. 백수", 50, 14);
                Console.ResetColor();

                WriteStartText(" 원하시는 행동을 입력해주세요", 42, 23);
                WriteStartText(" >>                        <<", 42, 25);
                Console.SetCursorPosition(56, 25);
                while (true)
                {
                    string inputJob = Console.ReadLine();

                    if (inputJob == "1")
                    {
                        player = new Character($"{playerName}", "(전사)", 1, 50, 20, 500, 100, 3000);
                        GameDisplay();
                    }
                    else if (inputJob == "2")
                    {
                        player = new Character($"{playerName}", "(마법사)", 1, 80, 8, 200, 400, 3000);
                        GameDisplay();
                    }
                    else if (inputJob == "3")
                    {
                        player = new Character($"{playerName}", "(도적)", 1, 40, 10, 250, 150, 3000);
                        GameDisplay();
                    }
                    else if (inputJob == "0")
                    {
                        player = new Character($"{playerName}", "(백수)", 1, 1, 1, 10, 1000, 50000);
                        GameDisplay();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        WriteStartText("잘못된 입력입니다. 다시 입력해주세요.", 40, 27);
                        Console.ResetColor();
                    }
                }
            }
        }

        // 시작 화면
        static void StartMenu()
        {
            Console.Clear();

            int xOffset = 28;
            int yOffset = 5;

            Console.SetCursorPosition(xOffset, yOffset++);

            WriteStartText(" =========================================================", xOffset, yOffset++);
            WriteStartText("l                                                         l", xOffset, yOffset++);
            WriteStartText("l                                                         l", xOffset, yOffset++);
            WriteStartText("l                                                         l", xOffset, yOffset++);
            WriteStartText("l====================== 이딴게 던전? =====================l", xOffset, yOffset++);
            WriteStartText("l                                                         l", xOffset, yOffset++);
            WriteStartText("l                                                         l", xOffset, yOffset++);
            WriteStartText("l                                                         l", xOffset, yOffset++);
            
            WriteStartText(" =========================================================", xOffset, yOffset++);
            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteStartText("                     1.  GAME START", xOffset+=2, yOffset += 3);
            Console.ForegroundColor = ConsoleColor.Red;
            WriteStartText("                     0. 게임 종료", xOffset++, yOffset += 2);
            Console.ResetColor();

            WriteStartText(" 원하시는 행동을 입력해주세요", 43, 23);
            WriteStartText(" >>                        <<", 43, 25);

            Console.SetCursorPosition(57, 25);
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "1")
                {
                    PlayerSetting();
                }
                else if (input == "0")
                {
                    Console.ResetColor();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteStartText("잘못된 입력입니다. 다시 입력해주세요.", 40, 27);
                    Console.ResetColor();
                }
            }
        }

        // 캐릭터 상태, 인벤토리 선택
        public static void GameDisplay()
        {
            Console.Clear();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteStartText("1. 캐릭터 상태보기", 45, 10);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteStartText("2. 인벤토리", 45, 12);
            Console.ResetColor();

            Console.WriteLine();
            WriteStartText("원하시는 행동을 입력해주세요.", 44, 20);
            WriteStartText(">>                        <<", 44, 22);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(58, 22);

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "1")
                {
                    ShowCharacter();
                }
                else if (input == "2")
                {
                    Item.ShowInventory();
                }
                else
                {
                    WriteStartText("잘못된 입력입니다. 다시 입력해주세요.", 40, 27);
                }
            }
        }

        // 캐릭터 상태창
        static void ShowCharacter()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteStartText("[캐릭터 상태]", 1, 1);
            Console.ResetColor();

            WriteStartText($"Lv : {player.Level}", 50, 5);
            WriteStartText($"{player.Name} {player.Job}", 50, 7);
            WriteStartText($"공격력 : {player.Atk}", 50, 9);
            WriteStartText($"방어력 : {player.Def}", 50, 11);
            WriteStartText($"H P    : {player.Hp}", 50, 13);
            WriteStartText($"M P    : {player.Mp}", 50, 15);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            WriteStartText($"Gold   : {player.Gold}", 50, 17);
            Console.ResetColor();

            WriteStartText("0. 돌아가기", 52, 22);
            WriteStartText("원하시는 행동을 입력해주세요.", 44, 25);
            WriteStartText(">>                        <<", 44, 27);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(58, 27);

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "0")
                {
                    GameDisplay();
                }
                else
                {
                    WriteStartText("잘못된 입력입니다. 다시 입력해주세요.", 40, 27);
                }
            }
        }
    }
}