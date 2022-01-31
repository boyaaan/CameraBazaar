namespace CameraBazaar.Service
{
    using Models;
    using Data.Enums;
    using System.Collections.Generic;

    public interface ICameraService
    {
        void Create(
           MakeModelTypes make,
              string model,
              decimal price,
              int quantity,
              int minShutterSpeed,
              MinISO minISO,
              int maxISO,
              bool isFullFrame,
              string videoResolution,
              IEnumerable<LightMetering> lightMeterings,
              string description,
              string imageURL,
              string userId);

        void Destroy(int id);

        GetEditModel GetCamera(int id);
        void Edit(int id, MakeModelTypes make, string model, decimal price, int quantity, string imageUrl);
        IEnumerable<AllCamerasModel> GetAllCameras(int page = 1);
        CameraDetailsModel GetCameraDetail(int id);
        int Total();
    }
}
