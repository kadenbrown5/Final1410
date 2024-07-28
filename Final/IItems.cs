public interface IItems
{
    public string Name { get; }
    public int Damage { get; }
    public int Armor { get; }
}

public class Sword : IItems
{
    public string Name { get; } = "Sword";
    public int Damage { get; } = 1;
    public int Armor { get; }
}

public class RustedFlintlock : IItems
{
    public string Name { get; } = "Rusted Flintlock";
    public int Damage { get; } = 1;
    public int Armor { get; }
}

public class ChestPlate : IItems
{
    public string Name { get; } = "Chest Plate";
    public int Damage { get; }
    public int Armor { get; } = 1;
}

public class EmptyItem : IItems
{
    public string Name { get; }
    public int Damage { get; }
    public int Armor { get; }
}