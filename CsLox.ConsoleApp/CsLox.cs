using System.Text;

namespace CsLox.ConsoleApp
{
    public class CsLox
    {
        static bool hadError = false;

        public static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                Console.WriteLine("Usage: cslox [script]");
                Environment.Exit(64);
            }
            else if (args.Length == 1)
                RunFile(args[0]);
            else
                RunPrompt();
        }

        private static void RunFile(string path)
        {
            byte[] bytes = File.ReadAllBytes(Path.GetFullPath(path));

            Run(Encoding.Default.GetString(bytes));

            if (hadError) Environment.Exit(65);
        }

        private static void RunPrompt()
        {
            TextReader reader = Console.In;

            while (true)
            {
                Console.Write("> ");
                string line = reader.ReadLine();

                if (line == null) break;

                Run(line);

                hadError = false;
            }
        }

        private static void Run(string source)
        {

        }

        public static void Error(int line, string message)
        {
            Report(line, "", message);
        }

        private static void Report(int line, string where, string message)
        {
            Console.WriteLine(
                $"[line {line}] Error {where}: {message}"
                );
        }
    }
}
