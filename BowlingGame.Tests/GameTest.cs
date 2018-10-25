using System;
using Xunit;

namespace BowlingGame.Tests
{
  public class GameTest
  {
    private readonly Game game;

    public GameTest()
    {
      game = new Game();
    }

    [Fact]
    public void All_rolls_in_the_gutter()
    {
      for (int i = 0; i < 20; i++)
      {
        game.Roll(0);
      }

      Assert.Equal(game.GetScore(), 0);
    }
  }
}
