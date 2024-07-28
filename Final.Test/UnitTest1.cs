using System.Diagnostics;

namespace Final.Test;

public class Tests
{

    Game game = new Game();
    RustedFlintlock RustedFlintlock = new RustedFlintlock();
    [Test]
    public void TestStore()
    {
        game.user.Gold = 15;
        game.Buy(15, RustedFlintlock, game.user.RangedWeapon);
        if(game.user.RangedWeapon == RustedFlintlock)
        Assert.Pass();
        else
        Assert.Fail();
    }
}