public class FilesOrganizer
{
    private readonly string _path;
    public FilesOrganizer(string path)
    {
        _path = path;
        if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
            throw new InvalidOperationException("The path is invalid");
    }

    private string CreateDirectory(string name)
    {
        var path = Path.Join(_path, name.ToString());
        Directory.CreateDirectory(path);
        return path;
    }

    public void SplitFilesToNewFoldersInSameDirectory(string subTitle)
    {
        var files = Directory.GetFiles(_path);

        if (files.Length == 0)
            return;

        var counter = 1;
        var newDirectoryPath = CreateDirectory(counter.ToString());
        foreach (var item in files)
        {
            if (item.Contains(subTitle))
            {

            }
            var newFilePath = Path.Join(newDirectoryPath, Path.GetFileName(item));
            File.Move(item, newFilePath);
            if (item.Contains(subTitle))
            {
                counter++;
                CreateDirectory(counter.ToString());
            }
        }
    }

}