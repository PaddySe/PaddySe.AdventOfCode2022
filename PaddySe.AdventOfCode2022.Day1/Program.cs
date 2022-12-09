var elfCounter = 0;
var calorieCount = 0;
var elfs = new Dictionary<int, int>();

using var fileStream = File.Open("Input.txt", FileMode.Open);
using var reader = new StreamReader(fileStream);

while (!reader.EndOfStream)
{
	var line = reader.ReadLine();
	if (int.TryParse(line, out var calories))
	{
		calorieCount += calories;
	}
	else
	{
		elfs.Add(elfCounter, calorieCount);
		elfCounter++;
		calorieCount = 0;
	}
}

// Part 1
var elfWithMostCalories = elfs.MaxBy(item => item.Value);
Console.WriteLine($"[PART 1] The Elf with most calories is {elfWithMostCalories.Key + 1}, and they have {elfWithMostCalories.Value} calories.");

// Part 2
var topThreeCalories = elfs.OrderByDescending(item => item.Value).Take(3).Sum(item => item.Value);
Console.WriteLine($"[PART 2] The top three Elves carry a total of {topThreeCalories} calories.");
