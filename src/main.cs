
internal class Program
{
    private static int Main(string[] args)
    {
        while (true)
        {
            Console.Write("$ ");
            var prompt = Console.ReadLine();

            (int exitCode, bool shouldExit) = Handleprompt(prompt);
            if (shouldExit)
            {
                return exitCode;
            }
        }
    }

    private static (int exitCode, bool shouldExit) Handleprompt(string prompt)
    {
        var tokens = prompt.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        var command = tokens.FirstOrDefault();

        if (tokens.Length == 0)
        {
            return (0, false);
        }
        else if (command == "exit")
        {
            return (0, true);
        }
        else if (command == "echo")
        {
            Console.WriteLine(string.Join(' ', tokens.Skip(1)));
            return (0, false);
        }
        else
        {
            Console.WriteLine($"{command}: command not found");
            return (0, false);
        }
    }
}