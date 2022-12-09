var input = File.ReadAllText("Input.txt");

/* ----- Part 1 ----- */

Debug.Assert(FindMarker("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 4) == 7);
Debug.Assert(FindMarker("bvwbjplbgvbhsrlpgdmjqwftvncz", 4) == 5);
Debug.Assert(FindMarker("nppdvjthqldpwncqszvftbrmjlhg", 4) == 6);
Debug.Assert(FindMarker("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 4) == 10);
Debug.Assert(FindMarker("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 4) == 11);
Console.WriteLine($"[PART 1] Marker found at position {FindMarker(input, 4)}");


/* ----- Part 2 ----- */

Debug.Assert(FindMarker("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 14) == 19);
Debug.Assert(FindMarker("bvwbjplbgvbhsrlpgdmjqwftvncz", 14) == 23);
Debug.Assert(FindMarker("nppdvjthqldpwncqszvftbrmjlhg", 14) == 23);
Debug.Assert(FindMarker("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 14) == 29);
Debug.Assert(FindMarker("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 14) == 26);
Console.WriteLine($"[PART 2] Marker found at position {FindMarker(input, 14)}");


static int FindMarker(string input, int markerLength)
{
	for (var i = 0; i < input.Length - markerLength - 1; i++)
	{
		var part = input.Skip(i).Take(markerLength).ToList();
		if (part.All(c => part.Count(c2 => c2 == c) == 1))
		{
			return i + markerLength;
		}
	}

	return -1;
}
