using System;

namespace BowlingGame
{
  public class Game
  {
    private readonly int[] rolls = new int[21];
    private int currentRoll = 0;

    public void Roll(int pins)
    {
      this.rolls[this.currentRoll++] = pins;
    }

    public int GetScore()
    {
      int score = 0;
      int frameIndex = 0;
      for (int frame = 0; frame < 10; frame++)
      {
        if (this.IsStrike(frameIndex))
        {
          score += 10 + this.StrikeBonus(frameIndex);
          frameIndex++;
        }
        else if (this.IsSpare(frameIndex))
        {
          score += 10 + this.SpareBonus(frameIndex);
          frameIndex += 2;
        }
        else
        {
          score += this.SumOfPinsInFrame(frameIndex);
          frameIndex += 2;
        }
      }
      return score;
    }

    private int SumOfPinsInFrame(int frameIndex)
    {
      return this.rolls[frameIndex] + this.rolls[frameIndex + 1];
    }

    private int StrikeBonus(int frameIndex)
    {
      return this.rolls[frameIndex + 1] + this.rolls[frameIndex + 2];
    }

    private int SpareBonus(int frameIndex)
    {
      return this.rolls[frameIndex + 2];
    }

    private bool IsStrike(int frameIndex)
    {
      return this.rolls[frameIndex] == 10;
    }

    private bool IsSpare(int frameIndex)
    {
      return this.rolls[frameIndex] + this.rolls[frameIndex + 1] == 10;
    }
  }
}
