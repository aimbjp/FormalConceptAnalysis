

namespace FormalConceptAnalysis
{
    internal class Program
    {
        private static bool _flagStopExecution = false;
        /// <summary>
        /// Enterence in the program
        /// main communication with the user
        /// Menu; Info; Input; Output;
        /// </summary>
        private static void Main(string[] args)
        {
            while (!_flagStopExecution)
            {
                ShowMenu();
                ShowInfo();
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1': FormalContext.InputFormalContext(); break;
                    case '2': FormalContext.ShowDiagramFormalContext(); break;
                    case '3': FormalContext.OutputFormalContext(); break;
                    case 'e': _flagStopExecution = true; break;
                }
            }
        }
        /// <summary>
        /// Show information about the program
        /// </summary>
        private static void ShowInfo()
        {
            Console.WriteLine("SOME INFORMATION");
        }
        /// <summary>
        /// Show main menu of the program
        /// </summary>
        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Main menu of the program\n" +
                              "1) Input formal context; input 1\n" +
                              "2) Show diagram; input 2\n" +
                              "3) show formal context; input 3\n" +
                              "4) exit; input e\n");
        }
    }
}