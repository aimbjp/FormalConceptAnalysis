using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace FormalConceptAnalysis
{
    internal class Program
    {
        private static bool _flagStopExecution = false;
        /// <summary>
        /// Enterence in the program
        /// main communication with the user
        /// Menu; Info;
        /// </summary>
        internal static void Main()
        {
            FormalContext formalContext = null;
            while (!_flagStopExecution)
            {
                ShowMenu();
                ShowInfo();
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1': 
                        formalContext = InputFormalContext(); 
                        break;
                    case '2':
                        if (formalContext != null) ShowDiagramFormalContext(formalContext);
                        else formalContext = InputFormalContext();
                        break;
                    case '3':
                        if (formalContext != null) OutputFormalContext(formalContext);
                        else formalContext = InputFormalContext();
                        break;
                    case '4':
                        if (formalContext != null) SaveFormalContext(formalContext);
                        else formalContext = InputFormalContext();
                        break;
                    case 'e': 
                        _flagStopExecution = true; 
                        break;
                }
            }
        }

        private static void SaveFormalContext(FormalContext formalContext)
        {
            Console.WriteLine("Input file path + name (C:\\folder\\name)");
            var filePath = Console.ReadLine();
            filePath += ".json";
            Console.WriteLine("Saving formal context...");
            var ser = JsonConvert.SerializeObject(formalContext, Formatting.Indented);
            File.WriteAllText(@filePath, ser);
        }

        /// <summary>
        /// Show chosen diagram of the formal context 
        /// </summary>
        /// <param name="formalContext"></param>
        private static void ShowDiagramFormalContext(FormalContext formalContext)
        {
            var flagShowDiagram = true;
            Console.Clear();
            Console.WriteLine("Diagram of the formal context\n" +
                              "Choose algorithm\n" +
                              "AddAtom ( 'a' ) \n" +
                              "AddIntent ( 'i' )\n" +
                              "Both ( 'b' )\n" +
                              "Main menu ( 'm' )");
            switch (char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case 'a': ; break;
                case 'i': ; break;
                case 'b': ; break;
                case 'm': flagShowDiagram = false; break;
            }
            if (!flagShowDiagram) return;
        }

        /// <summary>
        /// Show information about the program
        /// </summary>
        private static void ShowInfo()
        {
            Console.WriteLine("SOME INFORMATION\n");
        }
        /// <summary>
        /// Show main menu of the program
        /// Input formal context; Show diagram; Show formal context;
        /// </summary>
        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Main menu of the program\n" +
                              "1) Input formal context ( 1 )\n" +
                              "2) Show diagram ( 2 )\n" +
                              "3) Show formal context ( 3 )\n" +
                              "4) Exit ( 'e' )\n");
        }
        /// <summary>
        /// Input formal context
        /// like ObjectNames: obj1, ..., objN
        /// AttributeNames: att1, ..., attN
        /// Incidence: 0: 1,2; ...; N: 2,3
        /// </summary>
        /// <returns>FormalContext object</returns>
        private static FormalContext InputFormalContext()
        {
            FormalContext fc = null;
            ShowInputMenu();
            switch (char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case '1':
                    fc = JSONInput();
                    break;
                case '2':
                    fc = ManualInput();
                    break;
                default:
                    fc = JSONInput();
                    break;
            }

            void ShowInputMenu()
            {
                Console.Clear();
                Console.WriteLine("Which method? JSON - 1; Manual - 2");
            }
            
            
            return fc;
        }

        private static FormalContext JSONInput()
        {
            Console.WriteLine("Input path to file (C:\\folder\\name)");
            var filePath = Console.ReadLine();
            filePath += ".json";
            Console.WriteLine("Uploading formal context...");
            var fileContent = File.ReadAllText(@filePath);
            var fc = JsonConvert.DeserializeObject<FormalContext>(@fileContent);
            var ser = JsonConvert.SerializeObject(fc, Formatting.Indented);
            File.WriteAllText(@"controlJSONInput.json", ser);
            return fc;
        }


        private static FormalContext ManualInput()
        {
            Console.Clear();
            
            Console.WriteLine("Input Formal Context\n" + "Input objects names ( obj1, ..., objN ): ");
            var objectsNames = Console.ReadLine();
            Console.WriteLine("Input attribute names ( attr1, ..., attrN ): ");
            var attributeNames = Console.ReadLine();
            Console.WriteLine("Input incidence ( 0: 1,3; ...; N:2,3 ): ");
            var incidence = Console.ReadLine();
            
            return new FormalContext(objectsNames.Replace(", ", ",").Split(separator: ','), attributeNames.Replace(", ", ",").Split(separator: ','), incidence.Replace(",", ".").Replace("; ", ";").Split(separator: ';'));
        }

        /// <summary>
        /// Output formal context to console
        /// like ObjectNames: obj1, ..., objN
        /// AttributeNames: att1, ..., attN
        /// Incidence: 0: 1,2;\n ...;\n N: 2,3;\n
        /// </summary>
        private static void OutputFormalContext(FormalContext formalContext)
        {
            Console.Clear();
            Console.WriteLine($"Output Formal Context\nObjects names: " +
                              $"{formalContext.ObjectsNames.Aggregate<string?, string?>(null, (current, var) => current + (var + ", "))}\n" +
                              $"Attribute names: " +
                              $"{formalContext.AttributeNames.Aggregate<string?, string?>(null, (current, var) => current + (var + ", "))}\n" +
                              $"Incidence: " +
                              $"{formalContext.Incidence.Aggregate<string?, string?>(null, (current, var) => current + (var + ";\n"))}\n" +
                              $"\nMain menu ( 'm' )");
        
            if (char.ToLower(Console.ReadKey(true).KeyChar) == 'm') return;
        }
    }
}