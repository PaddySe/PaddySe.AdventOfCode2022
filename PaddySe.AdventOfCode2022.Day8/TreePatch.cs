namespace PaddySe.AdventOfCode2022.Day8;

public class TreePatch
{
	private Tree[,] _trees;

	private TreePatch(int width, int height)
	{
		_trees = new Tree[width, height];
	}

	public static TreePatch Create(IList<string> input)
	{
		var width = input[0].Length;
		var height = input.Count;

		var treePatch = new TreePatch(width, height);
		for (var y = 0; y < input.Count; y++)
		{
			var line = input[y];
			for (var x = 0; x < line.Length; x++)
			{
				var treeHeight = int.Parse($"{line[x]}");
				treePatch._trees[x, y] = new Tree(treeHeight);
			}
		}

		return treePatch;
	}

	public int Part1()
	{
		var visibleTrees = 0;

		var n = _trees.GetLength(0);
		var m = _trees.GetLength(1);

		for (var rotations = 0; rotations < 4; rotations++)
		{
			for (var i = 0; i < n; i++)
			{
				var highestSoFar = -1;

				for (var j = 0; j < m; j++)
				{
					var tree = _trees[i, j];
					if (tree.Height > highestSoFar)
					{
						highestSoFar = tree.Height;

						if (!tree.Visible)
						{
							visibleTrees++;
							tree.Visible = true;
						}
					}

					if (highestSoFar == -1)
					{
						highestSoFar = tree.Height;
					}
				}
			}

			Rotate();
			//Print();
		}

		return visibleTrees;
	}

	public int Part2()
	{
		var bestSceniceScore = 0;

		var gridSize = _trees.GetLength(0);

		for (var row = 1; row < gridSize - 1; row++)
		{
			for (var col = 1; col < gridSize - 1; col++)
			{
				var currentTree = _trees[row, col];

				var leftTrees = CountVisibleTreesFrom(currentTree, row, col, -1, 0, gridSize);
				var rightTrees = CountVisibleTreesFrom(currentTree, row, col, 1, 0, gridSize);
				var upTrees = CountVisibleTreesFrom(currentTree, row, col, 0, -1, gridSize);
				var downTrees = CountVisibleTreesFrom(currentTree, row, col, 0, 1, gridSize);

				currentTree.ScenicScore = leftTrees * upTrees * rightTrees * downTrees;
				if (currentTree.ScenicScore > bestSceniceScore)
				{
					bestSceniceScore = currentTree.ScenicScore;
				}
			}

		}

		//PrintScenic();
		return bestSceniceScore;
	}

	// I "borrowed" this from https://github.com/warriordog/advent-of-code-2022/blob/main/AdventOfCode/Day08/Day08Part2.cs
	// because I could simply not get my nested for loops to work :(
	private int CountVisibleTreesFrom(Tree currentTree, int row, int col, int rowIncrement, int colIncrement, int gridSize)
	{
		var treeCount = 0;

		do
		{
			row += rowIncrement;
			col += colIncrement;

			// Need to break early to avoid counting outside the edges
			if (row < 0 || row >= gridSize || col < 0 || col >= gridSize)
			{
				break;
			}

			treeCount++;
		} while (_trees[row, col].Height < currentTree.Height);

		return treeCount;
	}

	public void Rotate()
	{
		var n = _trees.GetLength(0);
		var newTrees = new Tree[n, n];
		for (var i = 0; i < n; i++)
		{
			for (var j = 0; j < n; j++)
			{
				newTrees[i, j] = _trees[n - j - 1, i];
			}
		}

		_trees = newTrees;
	}

	public void Print()
	{
		Console.WriteLine("-------------------------------------");
		for (var i = 0; i < _trees.GetLength(0); i++)
		{
			for (var j = 0; j < _trees.GetLength(1); j++)
			{
				var tree = _trees[j, i];
				Console.Write(tree.Height);
			}

			Console.Write("   ");
			for (var j = 0; j < _trees.GetLength(1); j++)
			{
				var tree = _trees[j, i];
				Console.Write(tree.Visible ? "X" : " ");
			}

			Console.WriteLine();
		}
	}
	public void PrintScenic()
	{
		Console.WriteLine("-------------------------------------");
		for (var i = 0; i < _trees.GetLength(0); i++)
		{
			for (var j = 0; j < _trees.GetLength(1); j++)
			{
				var tree = _trees[j, i];
				Console.Write(tree.Height);
			}

			Console.Write("   ");
			for (var j = 0; j < _trees.GetLength(1); j++)
			{
				var tree = _trees[j, i];
				Console.Write($"{tree.ScenicScore} ");
			}

			Console.WriteLine();
		}
	}
}