using System.Diagnostics;

namespace Final.Test;

public class Tests
{
    Game game = new Game();
    User user = new User();
    [Test]
    public void TestStore()
    {
        user.Money = 15;
        game.Buy(15, new RustedFlintlock(), user.RangedWeapon);
        if(user.RangedWeapon == new RustedFlintlock())
        Assert.Pass();
        else
        Assert.Fail();
    }
}