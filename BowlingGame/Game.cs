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
        if (this.isStrike(frameIndex))
        {
          score += 10 + this.strikeBonus(frameIndex);
          frameIndex++;
        }
        else if (this.isSpare(frameIndex))
        {
          score += 10 + this.spareBonus(frameIndex);
          frameIndex += 2;
        }
        else
        {
          score += this.sumOfPinsInFrame(frameIndex);
          frameIndex += 2;
        }
      }
      return score;
    }

    private int sumOfPinsInFrame(int frameIndex)
    {
      return this.rolls[frameIndex] + this.rolls[frameIndex + 1];
    }

    private int strikeBonus(int frameIndex)
    {
      return this.rolls[frameIndex + 1] + this.rolls[frameIndex + 2];
    }

    private int spareBonus(int frameIndex)
    {
      return this.rolls[frameIndex + 2];
    }

    private bool isStrike(int frameIndex)
    {
      return this.rolls[frameIndex] == 10;
    }

    private bool isSpare(int frameIndex)
    {
      return this.rolls[frameIndex] + this.rolls[frameIndex + 1] == 10;
    }
  }
}
