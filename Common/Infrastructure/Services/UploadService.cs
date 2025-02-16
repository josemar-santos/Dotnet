using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;
using E_Learn.Common.Application.Interface;
using E_Learn.Common.Domain;

namespace E_Learn.Common.Infrastructure;

public class UploadService : IUploadService
{

    private readonly Cloudinary cloudinary;
    private readonly IDictionary<string, string> env = DotEnv.Read();

    public UploadService() {
        cloudinary = new Cloudinary(env["CLOUDINARY_URL"]);
    }

    public string image(IFormFile file)
    {
        var fileStream = file.OpenReadStream();
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(file.FileName, fileStream),
            UseFilename = true,
            UniqueFilename = false,
            Overwrite = true
        };

        ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);

        return uploadResult.SecureUrl.ToString();
    }

    public VideoResponse video(IFormFile file) {
         var fileStream = file.OpenReadStream();
        var uploadParams = new VideoUploadParams()
        {
            File = new FileDescription(file.FileName, fileStream),
            UseFilename = true,
            UniqueFilename = false,
            Overwrite = true,
        };

        VideoUploadResult uploadResult = cloudinary.Upload(uploadParams);

        return new VideoResponse(uploadResult.SecureUrl.ToString(), uploadResult.Bytes, uploadResult.Duration);
    }
}