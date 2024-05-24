namespace OnlineShopWebApp.Helpers
{
    public class ImagesProvider
    {
        private readonly IWebHostEnvironment appEnvironment;
        public ImagesProvider(IWebHostEnvironment appEnvironment)
        {
            this.appEnvironment = appEnvironment;
        }

        public List<string> SaveFiles(IFormFile[] files, ImageFolders folder)
        {
            var imagesPaths = new List<string>();
            foreach (var file in files)
            {
                var imagePath = SaveFile(file, folder);
                imagesPaths.Add(imagePath);
            }
            return imagesPaths;
        }

        public string SaveFile(IFormFile file, ImageFolders folder)
        {
            if (file is null)
                return null;
            var folderPath = Path.Combine(appEnvironment.WebRootPath + "/images/" + folder);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            var fileName = Guid.NewGuid() + "." + file.FileName.Split('.').Last();
            string path = Path.Combine(folderPath, fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return "/images/" + folder + "/" + fileName;
        }

        public void DeleteFile(string fileName, ImageFolders folder)
        {
            var folderPath = Path.Combine(appEnvironment.WebRootPath + "/images/" + folder);
            File.Delete(folderPath + "/" + fileName);
        }
    }
}
