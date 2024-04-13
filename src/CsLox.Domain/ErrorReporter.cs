namespace CsLox.Domain
{
    public class ErrorReporter
    {
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
