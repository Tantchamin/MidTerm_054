using System;
using System.Collections.Generic;

namespace _054_Hangman
{
    // สร้าง enum ขึ้นมาเพื่อใช้ในการกำหนด menu
    enum Menu
    {
        Play = 1,
        Exit
    }

    class Program
    {
        // กำหนดเอาไว้เพื่อใช้เป็นตัวแปร global และเตรียมคำศัพท์ในการเล่น
        public static int lostCounter = 0;
        public static int WinCounter = 0;
        public static string word = RandomWord();
        public static char[] secretWord = new char[word.Length];
        public static int lost = 0;

        static void Main(string[] args)
        {
            PrepareSecretWord();
            MainMenu();

        }

        // เตรียม array _ _ _ _ _ _ ในการเล่น
        static void PrepareSecretWord()
        {
            for (int m = 0; m < word.Length; m++)
            {
                secretWord[m] = '_';
            }
        }
        
        // หน้า menu ตอนเริ่มโปรแกรม
        static void MainMenu()
        {
            ShowWelcomeHeader();
            ShowWelcomeMenu();
            InputMenu();
        }

        // คำเปรยส่วนหัวของหน้า menu
        static void ShowWelcomeHeader()
        {
            Console.WriteLine("Welcome to Hangman Game");
            Console.WriteLine("-----------------------");
        }

        // ตัวเลือกเมนู
        static void ShowWelcomeMenu()
        {
            Console.WriteLine("1. Play game");
            Console.WriteLine("2. Exit");
        }

        // เลือกเมนู
        static void InputMenu()
        {
            Console.Write("Plese Select Menu : ");
            Menu menu = (Menu)int.Parse(Console.ReadLine());

            CheckInputMenu(menu);
        }

        // เช็กเมนูที่จะไป
        static void CheckInputMenu(Menu menu)
        {
            // ไปหน้าเล่นเกม
            if (menu == Menu.Play)
            {
                Console.Clear();
                PlayGameMenu();
            }
            // ออกจากเกม
            else if (menu == Menu.Exit)
            {
                
            }
            // คำสั่งผิดผลาด กลับไปหน้าหลัก
            else
            {
                Console.Clear();
                ShowInputError();
            }
        }

        // ผิดผลาด ไปหน้าหลัก
        static void ShowInputError()
        {
            MainMenu();
        }

        // เริ่มเล่นเกม
        static void PlayGameMenu()
        {
            PlayHeader();
            IncorrectCount();
            HangmanUnderline();
            InputAlphabet();
        }

        // คำเปรยหน้าเล่นเกม
        static void PlayHeader()
        {
            Console.WriteLine("Play Game Hangman");
            Console.WriteLine("-----------------");
        }

        // แสดงจำนวน counter คำผิด
        static void IncorrectCount()
        {
            Console.WriteLine("Incorrect Score : {0}", lostCounter);

        }

        // ฟังก์ชันสำหรับสุ่มคำศัพท์ในการเล่นเกม
        static string RandomWord()
        {
            Random random = new Random();
            int resultRandom = random.Next(0, 3);

            string[] Hangman = new string[3];
            Hangman[0] = "Tennis";
            Hangman[1] = "Football";
            Hangman[2] = "Badminton";

            string word = Hangman[resultRandom];

            return word;
        }

        // สร้าง _ _ _ _ _ _ _ _ ตามจำนวนตัวอักษรของคำ
        static void HangmanUnderline()
        {
            for (int i = 0; i < word.Length; i++)
            {
                Console.Write(secretWord[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        // ใส่อักษรที่จะตอบ
        static void InputAlphabet()
        {
            Console.WriteLine("Input letter alphabet: ");
            char answer = (char)Console.Read();

            CheckAnswer(answer);
            CheckScore();

        }
        
        // ตรวจสอบคำตอบ
        static void CheckAnswer(char answer)
        {
            char[] guessWordArray = word.ToCharArray();
            
            for (int k = 0; k < guessWordArray.Length; k++)
            {

                // ถ้าถูกจะเปลี่ยน _ ให้การเป็นตัวอักษรที่ตอบ
                if (answer == guessWordArray[k])
                {
                    secretWord[k] = answer;
                    WinCounter++;
                    
                }
                else
                {
                    lost++;
                }
                
                Console.Clear();
            }
        }

        // เช็กจำนวนคะแนนว่าจะชนะ หรือแพ้ตอนไหน
        static void CheckScore()
        {
            if (WinCounter == word.Length)
            {
                Console.WriteLine("Your Win!!");
            }
            else if (lostCounter >= 6)
            {
                Console.WriteLine("Game Over");
            }
            else
            {
                PlayGameMenu();
            }
        }
    }
}
