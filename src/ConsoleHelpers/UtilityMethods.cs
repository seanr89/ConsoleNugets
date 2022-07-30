
namespace ConsoleHelpers;

public static class UtilityMethods
{
    /// <summary>
    /// Provides a Yes/No selection on console apps
    /// </summary>
    /// <param name="title">The text to display on the read message</param>
    /// <returns></returns>
    public static bool Confirm(string title)
    {
        ConsoleKey response;
        do
        {
            Console.Write($"{ title } [y/n] ");
            response = Console.ReadKey(false).Key;
            if (response != ConsoleKey.Enter)
            {
                Console.WriteLine();
            }
        } while (response != ConsoleKey.Y && response != ConsoleKey.N);
        return (response == ConsoleKey.Y);
    }

    //helper function that waits for any key to continue
    public static void WaitForAnyKeyPress(string msg)
    {
        Console.WriteLine($"\n{msg}");
        Console.ReadKey(true);
    }

    /// <summary>
    /// this method will handle the Ctrl+C event and will ask for confirmation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public static void cancelHandler(object sender, ConsoleCancelEventArgs e)
    {
        var isCtrlC = e.SpecialKey == ConsoleSpecialKey.ControlC;
        if (isCtrlC)
        {
            string confirmation = "";
            Console.Write("Are you sure you want to cancel the task? (y/n)");
            confirmation = Console.ReadLine() ?? "y";

            if (confirmation.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                e.Cancel = true;
                Environment.Exit(0);
            }
            else
            {
                Console.CancelKeyPress += new ConsoleCancelEventHandler(cancelHandler);
            }
        }
    }
}