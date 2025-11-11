using System.IO;

namespace WMSGlobal.Infrastructure.Helpers
{
    public static class ImagePathHelper
    {
        public static string BaseFolderPath => @"C:\images";

        public enum ImageType
        {
            User,
            Project,
            TaskAttachment
        }

        /// <summary>
        /// Obtiene la ruta completa de la carpeta para un tipo específico de archivo y tenant
        /// </summary>
        /// <param name="tenantId">ID del tenant</param>
        /// <param name="imageType">Tipo de archivo</param>
        /// <returns>Ruta completa de la carpeta</returns>
        public static string GetImageFolderPath(string tenantId, ImageType imageType)
        {
            string typeFolder = imageType switch
            {
                ImageType.User => "users",
                _ => throw new ArgumentException($"Tipo de archivo no válido: {imageType}")
            };

            return Path.Combine(BaseFolderPath, tenantId, typeFolder);
        }

        /// <summary>
        /// Obtiene la ruta completa del archivo
        /// </summary>
        /// <param name="tenantId">ID del tenant</param>
        /// <param name="imageType">Tipo de archivo</param>
        /// <param name="fileName">Nombre del archivo</param>
        /// <returns>Ruta completa del archivo</returns>
        public static string GetFullImagePath(string tenantId, ImageType imageType, string fileName)
        {
            string folderPath = GetImageFolderPath(tenantId, imageType);
            return Path.Combine(folderPath, fileName);
        }

        /// <summary>
        /// Crea el directorio si no existe
        /// </summary>
        /// <param name="tenantId">ID del tenant</param>
        /// <param name="imageType">Tipo de archivo</param>
        public static void EnsureDirectoryExists(string tenantId, ImageType imageType)
        {
            string folderPath = GetImageFolderPath(tenantId, imageType);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        /// <summary>
        /// Elimina un archivo si existe
        /// </summary>
        /// <param name="tenantId">ID del tenant</param>
        /// <param name="imageType">Tipo de archivo</param>
        /// <param name="fileName">Nombre del archivo</param>
        /// <returns>True si se eliminó correctamente, false si no existía</returns>
        public static bool DeleteImageFile(string tenantId, ImageType imageType, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return false;

            string fullPath = GetFullImagePath(tenantId, imageType, fileName);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Genera un nombre único para el archivo con la extensión especificada
        /// </summary>
        /// <param name="extension">Extensión del archivo (ej: ".jpg", ".pdf", ".txt")</param>
        /// <returns>Nombre único del archivo</returns>
        public static string GenerateUniqueFileName(string extension)
        {
            if (string.IsNullOrWhiteSpace(extension))
                throw new ArgumentException("La extensión no puede ser nula o vacía", nameof(extension));

            if (!extension.StartsWith("."))
                extension = "." + extension;

            return Guid.NewGuid().ToString() + extension;
        }

        /// <summary>
        /// Detecta la extensión del archivo basada en los bytes del contenido
        /// </summary>
        /// <param name="fileBytes">Bytes del archivo</param>
        /// <returns>Extensión detectada o ".bin" si no se puede determinar</returns>
        public static string DetectFileExtension(byte[] fileBytes)
        {
            if (fileBytes == null || fileBytes.Length < 4)
                return ".bin";

            return fileBytes switch
            {
                var bytes when bytes.Length >= 3 && bytes[0] == 0xFF && bytes[1] == 0xD8 && bytes[2] == 0xFF => ".jpg",
                var bytes when bytes.Length >= 8 && bytes[0] == 0x89 && bytes[1] == 0x50 && bytes[2] == 0x4E && bytes[3] == 0x47 => ".png",
                var bytes when bytes.Length >= 6 && bytes[0] == 0x47 && bytes[1] == 0x49 && bytes[2] == 0x46 => ".gif",
                var bytes when bytes.Length >= 4 && bytes[0] == 0x25 && bytes[1] == 0x50 && bytes[2] == 0x44 && bytes[3] == 0x46 => ".pdf",
                var bytes when bytes.Length >= 4 && bytes[0] == 0x50 && bytes[1] == 0x4B && (bytes[2] == 0x03 || bytes[2] == 0x05 || bytes[2] == 0x07) => ".zip",
                var bytes when bytes.Length >= 8 && bytes[0] == 0xD0 && bytes[1] == 0xCF && bytes[2] == 0x11 && bytes[3] == 0xE0 => ".doc",
                var bytes when bytes.Length >= 4 && bytes[0] == 0x50 && bytes[1] == 0x4B && bytes[2] == 0x03 && bytes[3] == 0x04 => ".docx",
                _ => ".bin"
            };
        }

        /// <summary>
        /// Genera un nombre único detectando automáticamente la extensión desde los bytes del archivo
        /// </summary>
        /// <param name="fileBytes">Bytes del archivo</param>
        /// <returns>Nombre único del archivo con extensión detectada</returns>
        public static string GenerateUniqueFileNameFromBytes(byte[] fileBytes)
        {
            string extension = DetectFileExtension(fileBytes);
            return GenerateUniqueFileName(extension);
        }
    }
}