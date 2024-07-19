using System.Threading.Tasks.Dataflow;

namespace Final;

public class Game
{
    public void Start()
    {
        TextWriter(
@"Welcome to Marauders Beach
    A Pirates Game

Press Any Key to Start Game");

        Console.ReadKey();
        Console.Clear();

        TextWriter(
@"You awake an a cold beach as the tides roll over your damaged body
unaware of what happened the night before.

A man finds you and takes you into the town to bandage you up as you fall back into unconsciousness

Press Any Key to Continue");

        Console.ReadKey();
        Console.Clear();

    }

    public void TextWriter(string input)
    {
        for (int i = 0; input.Length > i; i++)
        {
            Console.Write(input[i]);
            Thread.Sleep(10);

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter || keyInfo.Key == ConsoleKey.Spacebar)
                {
                    Console.Write(input.Substring(i));
                    break;
                }
            }
        }
    }
}
