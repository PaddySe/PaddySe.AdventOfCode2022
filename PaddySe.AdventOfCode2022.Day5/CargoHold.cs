namespace PaddySe.AdventOfCode2022.Day5;

public class CargoHold
{
	public List<Stack<char>> Columns { get; set; }

	public CargoHold(int columnCount)
	{
		Columns = new List<Stack<char>>();
		//Columns.AddRange(Enumerable.Repeat(new Stack<char>(), columnCount));

		for (var i = 0; i < columnCount; i++)
		{
			Columns.Add(new Stack<char>());
		}
	}

	public void MoveWithCrateMover9000(Move move)
	{
		for (var i = 0; i < move.CratesToMove; i++)
		{
			Columns[move.ToColumn - 1].Push(Columns[move.FromColumn - 1].Pop());
		}
	}

	public void MoveWithCrateMover9001(Move move)
	{
		var stack = new Stack<char>();

		for (var i = 0; i < move.CratesToMove; i++)
		{
			stack.Push(Columns[move.FromColumn - 1].Pop());
		}

		while (stack.TryPop(out var c))
		{
			Columns[move.ToColumn - 1].Push(c);
		}
	}

	public static CargoHold Parse(List<string> cargoholdDescription)
	{
		var columnCount = int.Parse(cargoholdDescription.Last().Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());

		var cargohold = new CargoHold(columnCount);

		var lines = cargoholdDescription.Take(cargoholdDescription.Count - 1).Reverse();
		foreach (var line in lines)
		{
			var strippedLine = line.Replace("[", string.Empty).Replace("]", string.Empty);

			var columnCounter = 0;

			for (var i = 0; i < strippedLine.Length; i++)
			{
				var c = strippedLine[i];
				if (c == ' ')
				{
					i += 3;
					columnCounter++;
					continue;
				}

				cargohold.Columns[columnCounter].Push(c);
				i++; // Skip the space
				columnCounter++;
			}
		}

		return cargohold;
	}
}
