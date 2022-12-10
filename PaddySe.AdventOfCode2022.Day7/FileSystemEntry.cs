namespace PaddySe.AdventOfCode2022.Day7;

public class FileSystemEntry
{
	private readonly List<FileSystemEntry> _entries = new();
	private readonly int _size;

	private FileSystemEntry(string name, int size, FileSystemEntry? parent)
	{
		Name = name;
		_size = size;
		IsDirectory = size == 0;
		Parent = parent ?? this;
	}

	public bool IsDirectory { get; }

	public string Name { get; }

	public FileSystemEntry Parent { get; }

	public int Size => _size + _entries.Sum(item => item.Size);

	public IEnumerable<FileSystemEntry> AllDirectories()
	{
		var directories = new List<FileSystemEntry>();
		if (IsDirectory && Name != "/")
		{
			directories.Add(this);
		}

		directories.AddRange(_entries.Where(item => item.IsDirectory).SelectMany(item => item.AllDirectories()));

		return directories;
	}

	public static FileSystemEntry CreateRoot() => new("/", 0, null);

	public void ParseAndAdd(string line)
	{
		var split = line.Split(' ');
		_entries.Add(new(split[1], split[0] == "dir" ? 0 : int.Parse(split[0]), this));
	}

	public static FileSystemEntry ParseDirectoryStructure(IList<string> input)
	{
		var root = CreateRoot();
		var currentFolder = root;

		for (var i = 0; i < input.Count; i++)
		{
			var split = input[i].Split(' ');
			switch (split[1])
			{
				case "cd":
					currentFolder = split[2] switch
					{
						"/" => root,
						".." => currentFolder.Parent,
						_ => currentFolder._entries.First(item => item.Name == split[2])
					};
					break;
				case "ls":
					{
						foreach (var entry in input.Skip(i + 1).TakeWhile(item => item[0] != '$'))
						{
							currentFolder.ParseAndAdd(entry);
							i++;
						}

						break;
					}
			}
		}

		return root;
	}

	public override string ToString() => IsDirectory ? $"{Name} (dir, size={Size})" : $"{Name} (file, size={_size}";
}
