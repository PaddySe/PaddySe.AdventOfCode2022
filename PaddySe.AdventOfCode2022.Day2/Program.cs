using PaddySe.AdventOfCode2022.Day2;

//var lines = new List<(char, char)>
//{
//	('A', 'Y'),
//	('B', 'X'),
//	('C', 'Z')
//};

var lines = File.ReadAllLines("Input.txt")
				.Select(line => (line[0], line[2]))
				.ToList();

var score = (from line in lines
			 let them = Move.Create(line.Item1)
			 let me = Move.Create(line.Item2)
			 select them.GetScore(me)).Sum();

Console.WriteLine($"[PART 1] Result: {score}");


score = (from line in lines
		 let them = Move.Create(line.Item1)
		 select them.ScoreFor(line.Item2)).Sum();

Console.WriteLine($"[PART 2] Result: {score}");
