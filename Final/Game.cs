using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

namespace Final;
public class Game
{
    User user = new User();
    bool TooMuch;
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
@"When you wake up you have been nursed back to health as you meet the local doctor,
Dr. Sponge Introduces himself and lets you know anytime you have been injured you can
Come to the Clinic to get healed up this first one is free but from now on it will cost
a small fee

You leave out to the town center ready look at your new town

Press Any Key to Continue");

        Console.ReadKey();
        HomeMenu();
    }

    void HomeMenu()
    {
        Console.Clear();
        System.Console.WriteLine(
@"Welcome To The Town Center

Where Would You Like To Go To

1) Blacksmith
2) Gunsmith
3) Ship Master
4) Ship Dock
0) Exit Game
");

        switch (PlayerInput().Key)
        {
            case ConsoleKey.NumPad1:
            case ConsoleKey.D1:
                BlacksmithMenu();
                break;
            case ConsoleKey.NumPad2:
            case ConsoleKey.D2:
                GunsmithMenu();
                break;
            case ConsoleKey.NumPad3:
            case ConsoleKey.D3:
                ShipMasterMenu();
                break;
            case ConsoleKey.NumPad4:
            case ConsoleKey.D4:
                DockMenu();
                break;
            case ConsoleKey.NumPad0:
            case ConsoleKey.D0:
                Exit();
                HomeMenu();
                break;
        }
    }
    void BlacksmithMenu()
    {
        Console.Clear();
        System.Console.WriteLine(
@$"Welcome To The Blacksmith
Gold: {user.Money}

1) Basic Sword 15 Gold
0) Go Back
");
        if (TooMuch)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Sorry You Don't Have Enough Gold");
            TooMuch = false;
        }
        switch (PlayerInput().Key)
        {
            case ConsoleKey.NumPad1:
            case ConsoleKey.D1:
                Buy(15, new Sword(), user.MeleeWeapon);
                break;
            case ConsoleKey.NumPad2:
            case ConsoleKey.D2:

                break;
            case ConsoleKey.NumPad3:
            case ConsoleKey.D3:

                break;
            case ConsoleKey.NumPad4:
            case ConsoleKey.D4:

                break;
            case ConsoleKey.NumPad0:
            case ConsoleKey.D0:
                HomeMenu();
                break;

        }

    }

    void GunsmithMenu()
    {
                Console.Clear();
        System.Console.WriteLine(
@$"Welcome To The Gunsmith
Gold: {user.Money}

1) Rusted Flintlock 10 Gold
0) Go Back
");
        if (TooMuch)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Sorry You Don't Have Enough Gold");
            TooMuch = false;
        }
        switch (PlayerInput().Key)
        {
            case ConsoleKey.NumPad1:
            case ConsoleKey.D1:
                Buy(10, new RustedFlintlock(), user.RangedWeapon);
                break;
            case ConsoleKey.NumPad2:
            case ConsoleKey.D2:

                break;
            case ConsoleKey.NumPad3:
            case ConsoleKey.D3:

                break;
            case ConsoleKey.NumPad4:
            case ConsoleKey.D4:

                break;
            case ConsoleKey.NumPad0:
            case ConsoleKey.D0:
                HomeMenu();
                break;

        }
    }
    void ShipMasterMenu()
    {

    }

    void DockMenu()
    {

    }

    public void Buy(int cost, IItems item, IItems type)
    {
        if (user.Money >= cost)
        {
            user.Money -= cost;
            if (type == user.MeleeWeapon)
            {
                user.MeleeWeapon = item;
            }
            else if (type == user.RangedWeapon)
            {
                user.RangedWeapon = item;
            }
            else if (type == user.Armor)
            {
                user.Armor = item;
            }

        }
        else
        {
            TooMuch = true;
            if (type == user.MeleeWeapon || type == user.Armor)
            {
                BlacksmithMenu();
            }
            else if (type == user.RangedWeapon)
            {
                GunsmithMenu();
            }
        }
    }
    public void Exit()
    {
        Console.Clear();
        System.Console.WriteLine(@"Are You Sure You Want To Exit?
0) Leave Game
Any Other Key) Go Back");
        switch (PlayerInput().Key)
        {
            case ConsoleKey.NumPad0:
            case ConsoleKey.D0:
                Environment.Exit(0);
                break;
            default:
                break;
        }
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
                    Console.Write(input.Substring(i + 1));
                    break;
                }
            }
        }
    }

    public ConsoleKeyInfo PlayerInput()
    {
        System.Console.WriteLine("Press The Corresponding Key To Do That Action");
        ConsoleKeyInfo input = Console.ReadKey();
        return input;
    }
}
