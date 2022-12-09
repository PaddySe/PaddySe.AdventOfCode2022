namespace PaddySe.AdventOfCode2022.Day2;

public class Move
{
	public Character Character { get; set; }

	private Move(Character character)
	{
		Character = character;
	}

	public static Move Create(char character)
	{
		return character switch
		{
			'A' => new(Character.Rock),
			'B' => new(Character.Paper),
			'C' => new(Character.Scissors),
			'X' => new(Character.Rock),
			'Y' => new(Character.Paper),
			'Z' => new(Character.Scissors),
			_ => new(Character.None)
		};
	}

	public int GetScore(Move myMove)
	{
		// Rock > Scissors
		// Scissors > Paper
		// Paper > Rock

		var baseValue = (int)myMove.Character;

		return myMove.Character switch
		{
			Character.Rock => Character switch
			{
				Character.Paper => baseValue + (int)Result.Loss,
				Character.Rock => baseValue + (int)Result.Draw,
				Character.Scissors => baseValue + (int)Result.Win,
				_ => throw new ArgumentOutOfRangeException()
			},
			Character.Paper => Character switch
			{
				Character.Paper => baseValue + (int)Result.Draw,
				Character.Rock => baseValue + (int)Result.Win,
				Character.Scissors => baseValue + (int)Result.Loss,
				_ => throw new ArgumentOutOfRangeException()
			},
			Character.Scissors => Character switch
			{
				Character.Paper => baseValue + (int)Result.Win,
				Character.Rock => baseValue + (int)Result.Loss,
				Character.Scissors => baseValue + (int)Result.Draw,
				_ => throw new ArgumentOutOfRangeException()
			},
			_ => throw new ArgumentOutOfRangeException()
		};
	}

	public int ScoreFor(char character)
	{
		return character switch
		{
			'X' => Character switch // Lose
			{
				Character.Rock => GetScore(new Move(Character.Scissors)),
				Character.Paper => GetScore(new Move(Character.Rock)),
				Character.Scissors => GetScore(new Move(Character.Paper)),
				_ => throw new ArgumentOutOfRangeException()
			},
			'Y' => GetScore(this), // Draw
			'Z' => Character switch // Win
			{
				Character.Rock => GetScore(new Move(Character.Paper)),
				Character.Paper => GetScore(new Move(Character.Scissors)),
				Character.Scissors => GetScore(new Move(Character.Rock)),
				_ => throw new ArgumentOutOfRangeException()
			},
			_ => throw new ArgumentOutOfRangeException()
		};
	}
}