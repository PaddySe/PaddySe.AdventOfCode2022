//var rucksackContents = new List<string>
//{
//	"vJrwpWtwJgWrhcsFMMfFFhFp",
//	"jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
//	"PmmdzqPrVvPwwTWBwg",
//	"wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
//	"ttgJtRGJQctTZtZT",
//	"CrZsJsPPZsGzwwsLwLmpwMDw"
//};

var rucksackContents = File.ReadAllLines("Input.txt");

var sumPriorities = 0;

/* ----- Part 1 ----- */

foreach (var contents in rucksackContents.Select(SplitIntoCompartments))
{
	var itemInBoth = contents.Item1.FirstOrDefault(contents.Item2.Contains);
	sumPriorities += GetPriority(itemInBoth);
}

Console.WriteLine($"[PART 1] The priority sum is {sumPriorities}.");


/* ----- Part 2 ----- */

sumPriorities = 0;
foreach (var group in rucksackContents.Chunk(3))
{
	var itemInAll = group[0].FirstOrDefault(item1 => group[1].Contains(item1) && group[2].Contains(item1));
	sumPriorities +=  GetPriority(itemInAll);
}

Console.WriteLine($"[PART 2] The priority sum is {sumPriorities}.");


static int GetPriority(char item) => char.IsLower(item) ? item - 'a' + 1 : item - 'A' + 27;

static (string, string) SplitIntoCompartments(string item)
{
	var split = item.Length / 2;
	return (item[..split], item[split..]);
}
