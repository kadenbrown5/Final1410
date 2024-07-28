public interface ICharacters
{
    public int Health { get; }
    public int Attack { get; }
    public int Defense { get; }
    public IItems MeleeWeapon { get; }
    public IItems RangedWeapon { get; }
    public IItems Armor { get; }
}

public class User : ICharacters
{
    public int Money { get; set; }  
    public int Health { get; }
    public int Attack { get; }
    public int Defense { get; }
    public IItems MeleeWeapon { get; set;}
    public IItems RangedWeapon { get; set;}
    public IItems Armor { get; set;}
}

public class Enemy : ICharacters
{
    public int Health { get; }
    public int Attack { get; }
    public int Defense { get; }
    public IItems MeleeWeapon { get; }
    public IItems RangedWeapon { get; }
    public IItems Armor { get; }
}