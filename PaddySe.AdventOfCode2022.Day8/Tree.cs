namespace PaddySe.AdventOfCode2022.Day8;

public class Tree
{
	public Tree(int height)
	{
		Height = height;
	}

	public int Height { get; }

	public int ScenicScore { get; set; }

	public bool Visible { get; set; }

	public override string ToString() => $"{Height}: {ScenicScore}";
}
