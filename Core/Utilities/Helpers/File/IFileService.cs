using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Helpers.File;

public interface IFileService
{
    public IResult Upload(string source, string destination, string fileName);
    public IResult UploadWithGuid(string source,string destination);
    public IResult Delete(string file);
    public bool CreateDirectoryIfNotExists(string filepath);
}