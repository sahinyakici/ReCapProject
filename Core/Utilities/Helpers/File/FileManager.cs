using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concretes;

namespace Core.Utilities.Helpers.File;

public class FileManager : IFileService
{
    public IResult Upload(string source, string destination, string fileName)
    {
        CreateDirectoryIfNotExists(destination);
        System.IO.File.Copy(source, Path.Combine(destination, fileName), true);
        return new SuccessResult();
    }

    public IResult UploadWithGuid(string source, string destination)
    {
        CreateDirectoryIfNotExists(destination);
        string newFileName = Guid.NewGuid() + Path.GetExtension(source);
        System.IO.File.Copy(source, Path.Combine(destination, newFileName), true);
        return new SuccessResult(newFileName);
    }

    public IResult Delete(string file)
    {
        if (System.IO.File.Exists(file))
        {
            System.IO.File.Delete(file);
            return new SuccessResult();
        }

        return new ErrorResult();
    }

    public bool CreateDirectoryIfNotExists(string filepath)
    {
        if (!Directory.Exists(filepath))
            Directory.CreateDirectory(filepath);
        return true;
    }
}