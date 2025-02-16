using E_Learn.Common.Domain;

namespace E_Learn.Common.Application.Interface;

public interface IUploadService {
    string image(IFormFile file);

    VideoResponse video(IFormFile file);
}