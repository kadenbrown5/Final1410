using System.Collections;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

namespace Final;
public class Game
{
    public User user = new User();
    bool TooMuch;
    int Damage;
    int NormalHealth;
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
            default:
                HomeMenu();
                break;
        }
    }
    void BlacksmithMenu()
    {
        Console.Clear();
        System.Console.WriteLine(
@$"Welcome To The Blacksmith
Gold: {user.Gold}

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
            default:
                BlacksmithMenu();
                break;

        }

    }

    void GunsmithMenu()
    {
        Console.Clear();
        System.Console.WriteLine(
@$"Welcome To The Gunsmith
Gold: {user.Gold}

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
            default:
                GunsmithMenu();
                break;
        }
    }
    void ShipMasterMenu()
    {
        HomeMenu();
    }
    void DockMenu()
    {
        Console.Clear();
        System.Console.WriteLine(
@"Welcome To The Docks

Take Off and Pick Your Fight

1) Bandits
0) Go Back
");
        switch (PlayerInput().Key)
        {
            case ConsoleKey.NumPad1:
            case ConsoleKey.D1:
                Fight(new Bandit());
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
            default:
                DockMenu();
                break;
        }
    }

    public void Fight(ICharacters enemy)
    {
        NormalHealth = user.Health;
        Console.Clear();
        System.Console.WriteLine(
@$"Player
Health:  {user.Health}            
Attack:  {user.Attack}            
Defense: {user.Defense}            

{enemy.Name}
Health:  {enemy.Health}
Attack:  {enemy.Attack}
Defense: {enemy.Defense}

A) Attack
0) Escape
");
        switch (PlayerInput().Key)
        {
            case ConsoleKey.A:
        enemy.Health -= user.Attack + user.MeleeWeapon.Damage + user.RangedWeapon.Damage - enemy.Defense - enemy.Armor.Armor;
        if(enemy.Health <= 0)
        {
            System.Console.WriteLine($"You Have Killed A(n) {enemy.Name} And Earned {enemy.Gold}");
            System.Console.WriteLine("Press Any Key To Continue");
            user.Gold += enemy.Gold;

            switch(PlayerInput().Key)
        {
            default:
                HomeMenu();
                break;
        }
        }
        else
        {
            user.Health -= enemy.Attack + enemy.MeleeWeapon.Damage + enemy.RangedWeapon.Damage - (user.Armor.Armor + user.Defense);
            CheckUserDeath();
        }
                Fight(enemy);
                break;
            case ConsoleKey.NumPad0:
            case ConsoleKey.D0:
                HomeMenu();
                break;
            default:
                Fight(enemy);
                break;
        }

    }

    void CheckUserDeath()
    {
        int lostGold = 0;
        if(user.Health <= 0)
        {
            if(user.Gold > 50)
            {
                user.Gold -= 50;
                lostGold = 50;
            }
            else if(user.Gold < 50 && user.Gold > 0)
            {
                lostGold = user.Gold;
                user.Gold = 0;
            }
            user.Health = NormalHealth;
            System.Console.WriteLine($"You Have Died And Ended Up At The Clinic And Cost You {lostGold} Gold");
        switch(PlayerInput().Key)
        {

            case ConsoleKey.NumPad0:
            case ConsoleKey.D0:
                HomeMenu();
                break;
            default:
                HomeMenu();
                break;
        }
        }
    }
    public void Buy(int cost, IItems item, IItems type)
    {
        if (user.Gold >= cost)
        {
            user.Gold -= cost;
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
