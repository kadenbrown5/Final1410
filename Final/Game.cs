using System.Threading.Tasks.Dataflow;

namespace Final;

public class Game
{
    public void Start()
    {
        TextAnimationWriter(
@"Welcome to Marauders Beach
    A Pirates Game

Press Any Key to Start Game");

        Console.ReadKey();
        Console.Clear();

        TextAnimationWriter(
@"You awake an a cold beach as the tides roll over your damaged body
unaware of what happened the night before.

A man finds you and takes you into the town to bandage you up as you fall back into unconsciousness

Press Any Key to Continue");

        Console.ReadKey();
        Console.Clear();

        TextAnimationWriter(
@"When you wake up you have been nursed back to health as you meet the local doctor
Dr. Sponge Introduces himself and lets you know anytime you have been injured you can
Come to the Clinic to get healed up this first one is free but from now on it will cost
a small fee

You leave out to the town center ready look at your new town

Press Any Key to Continue");

        Console.ReadKey();
        Console.Clear();
    }

    public void TextAnimationWriter(string input)
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
