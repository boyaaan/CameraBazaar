namespace CameraBazaar.Service.Models
{
    using System.Collections.Generic;
    public class CameraPageModel
    {
        public int Id { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string Url { get; set; }
        public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;
        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
        public IEnumerable<AllCamerasModel> Cameras { get; set; }
    }
}
