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
	using var reader = new StringReader(input);
	int latest;
	var buffer = new List<char>();

	var position = 0;

	while ((latest = reader.Read()) != -1)
	{
		position++;

		buffer.Add((char)latest);

		if (buffer.Count < markerLength)
		{
			// We don't have enough data in the buffer for a whole marker yet.
			continue;
		}

		if (buffer.All(c => buffer.Count(c2 => c2 == c) == 1))
		{
			return position;
		}

		buffer.RemoveAt(0);
	}

	// Fallback, no marker found.
	return -1;
}
