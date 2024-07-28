using System.Reflection.Metadata.Ecma335;

public interface ICharacters
{
    public int Gold {get; set;}
    public string Name {get; }
    public int Health { get; set;}
    public int Attack { get; }
    public int Defense { get; }
    public IItems MeleeWeapon { get; }
    public IItems RangedWeapon { get; }
    public IItems Armor { get; }
}

public class User : ICharacters
{
    public string Name {get;} = "User";
    public int Gold { get; set; }  = 0;
    public int Health { get; set; } = 5;
    public int Attack { get; } = 1;
    public int Defense { get; } = 1;
    public IItems MeleeWeapon { get; set;} = new EmptyItem();
    public IItems RangedWeapon { get; set;} = new EmptyItem();
    public IItems Armor { get; set;} = new EmptyItem();
}

public class Bandit : ICharacters
{
    public string Name {get;}= "Bandit";
    public int Gold {get; set;} = 5;
    public int Health { get; set;} = 5;
    public int Attack { get; } = 1;
    public int Defense { get; } = 0;
    public IItems MeleeWeapon { get; } = new EmptyItem();
    public IItems RangedWeapon { get; } = new EmptyItem();
    public IItems Armor { get; } = new EmptyItem();

}