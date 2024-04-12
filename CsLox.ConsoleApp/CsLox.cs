using System.Text;

namespace CsLox.ConsoleApp
{
    public class CsLox
    {
        static bool hadError = false;

        /// <summary>
        /// The entry point for the CsLox interpreter. It processes command line arguments to determine
        /// whether to execute a given script file or to start an interactive prompt.
        /// </summary>
        /// <param name="args">Command line arguments passed to the application.
        /// Expected usage:
        /// - No arguments: starts the CsLox in interactive mode.
        /// - One argument: expects the path to a Lox script file to execute.
        /// - More than one argument: displays usage information and exits.
        /// </param>
        public static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                Console.WriteLine("Usage: cslox [script]");

                Environment.Exit(64); // Exit code for command line usage error (common UNIX practice)
            }
            else if (args.Length == 1)
                RunFile(args[0]); // Executes the Lox script file specified by the user.
            else
                RunPrompt(); // Starts the interpreter in interactive mode.
        }

        /// <summary>
        /// Runs the Lox program from a given file.
        /// </summary>
        /// <param name="path">The path to the Lox source file.</param>
        private static void RunFile(string path)
        {
            byte[] bytes = File.ReadAllBytes(Path.GetFullPath(path));

            Run(Encoding.Default.GetString(bytes));

            if (hadError) Environment.Exit(65);
        }

        /// <summary>
        /// Starts a Lox REPL (Read-Eval-Print Loop) on the command line.
        /// </summary>
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

        /// <summary>
        /// Executes the Lox program given a string source of code. This method scans the source input,
        /// tokenizes it, and then prints each token. Future implementations should execute the parsed code.
        /// </summary>
        /// <param name="source">The source code of the Lox program as a string.</param>
        private static void Run(string source)
        {
            Scanner scanner = new Scanner(source);

            List<Token> tokens = scanner.ScanTokens();

            // Iterate over each token and print it to the console
            // TODO: Implement execution logic to interpret or compile the tokens
            foreach (Token token in tokens)
                Console.WriteLine(token);
        }

        /// <summary>
        /// Reports an error at a specific line in the source code.
        /// </summary>
        /// <param name="line">The line number where the error occurred.</param>
        /// <param name="message">The error message to display.</param>
        public static void Error(int line, string message)
        {
            Report(line, "", message);
        }

        /// <summary>
        /// Outputs an error message to the console with details about where and what the error is.
        /// This method is used internally for formatting and displaying error messages.
        /// </summary>
        /// <param name="line">The line number at which the error occurred.</param>
        /// <param name="where">A specific location or context in the source where the error occurred. This could be empty if the location is not specified or not applicable.</param>
        /// <param name="message">The detailed error message describing what went wrong.</param>
        private static void Report(int line, string where, string message)
        {
            Console.WriteLine(
                $"[line {line}] Error {where}: {message}"
                );
        }
    }
}
