using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using BookChescoDomain.Models;

namespace BookChescoInfrastructure.Services;

public class CloudinaryService : ICloudinaryService
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryService(Cloudinary cloudinary)
    {
        _cloudinary = cloudinary;
    }

    public async Task<Photo> UploadPhotoAsync(Stream fileStream, string entityName, string entityId, int order)
    {
        var publicId = $"{entityName}/{entityId}/{order}";

        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(publicId, fileStream),
            PublicId = publicId,
            Overwrite = true,
            Folder = entityName.ToLower()
        };

        var result = await _cloudinary.UploadAsync(uploadParams);

        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId,
                Order = order
            };
        }

        throw new Exception(result.Error?.Message ?? "Ошибка загрузки фото");
    }

    public async Task<bool> DeletePhotoAsync(string publicId)
    {
        var deletionParams = new DeletionParams(publicId);
        var result = await _cloudinary.DestroyAsync(deletionParams);
        return result.Result == "ok";
    }
}