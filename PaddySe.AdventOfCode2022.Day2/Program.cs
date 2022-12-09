// "A", "X" == Rock
// "B", "Y" == Paper
// "C", "Z" = Scissors
// Loss == 0, Draw == 3, Win == 6
// Rock == 1, Paper == 2, Scissors = 3

var lines = new List<(char, char)>
{
	('A', 'Y'),
	('B', 'X'),
	('C', 'Z')
};

var score = 0;

foreach (var line in lines)
{
	bool? win = false; // false == loss, true == win, null == tie

	if (line.Item2 == 'X')
	{
		switch (line.Item1)
		{
			case 'A': break;
			case 'B': break;
			case 'C': break;
		}
	}
	else if (line.Item2 == 'Y')
	{
		
	}
	else if (line.Item2 == 'Z')
	{
		
	}
}

Console.WriteLine($"Result: {score}");
