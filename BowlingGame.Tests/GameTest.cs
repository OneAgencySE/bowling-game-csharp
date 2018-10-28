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
      ManyRolls(20, 0);
      Assert.Equal(game.GetScore(), 0);
    }

    [Fact]
    public void All_rolls_hit_one_pin() {
      ManyRolls(20, 1);
      Assert.Equal(game.GetScore(), 20);
    }

    [Fact]
    public void Rolls_one_spare() {
      RollSpare();
      game.Roll(3);
      ManyRolls(17, 0);
      Assert.Equal(game.GetScore(), 16);
    }

    [Fact]
    public void Rolls_one_strike() {
      RollStrike();
      game.Roll(4);
      game.Roll(3);
      ManyRolls(16, 0);
      Assert.Equal(game.GetScore(), 24);
    }

    [Fact]
    public void Rolls_perfect_game() {
      ManyRolls(20, 10);
      Assert.Equal(game.GetScore(), 300);
    }

    private void ManyRolls(int rolls, int pins) {
      for(int i = 0; i < rolls; i++) {
        game.Roll(pins);
      }
    }

    private void RollSpare() {
      game.Roll(5);
      game.Roll(5);
    }

    private void RollStrike() {
      game.Roll(10);
    }
  }
}
