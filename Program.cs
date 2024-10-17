using System;
using TUGAS2.Classes;

namespace MAIN
{
    class Program
    {
        static void Main(string[] args)
        {
            // inisisasi robot
            // nama, energi, armor, serangan
            BosRobot morris = new BosRobot("Morris", 1000, 80, 100, 20); 
            NormalRobot lewis = new NormalRobot("Lewis",300, 100, 120);
            NormalRobot penny = new NormalRobot("Penny", 200, 30, 200);
            NormalRobot gus = new NormalRobot("Gus", 450, 70, 110);


            // game
            Console.WriteLine("PERTARUNGAN DIMULAI!");
            int round = 1;
            while (morris.isAlive == true)
            {
                Console.WriteLine($"Round : {round}");

                lewis.serang(morris);
                Console.WriteLine(morris.energi);
                if (morris.isAlive == false) { break; }

                penny.serang(morris);
                Console.WriteLine(morris.energi);
                if (morris.isAlive == false) { break; }

                gus.serang(morris);
                Console.WriteLine(morris.energi);
                if (morris.isAlive == false) { break; }

                morris.cetakInformasi();
                
                round++;
                Console.WriteLine();
            }

            Console.WriteLine("GAME COMPLETED!");
            Console.ReadLine();
        }
    }
}
