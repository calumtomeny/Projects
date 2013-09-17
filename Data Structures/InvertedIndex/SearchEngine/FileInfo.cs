using System;

namespace SearchEngine
{
    using System.IO;

    using SearchEngine.Models;

    internal class FileInfo
    {
        public static DocumentType GetType(string filename)
        {
            if (filename == null)
            {
                throw new ArgumentNullException("filename");
            }

            string extension = Path.GetExtension(filename);

            if (string.IsNullOrEmpty(extension))
            {
                return DocumentType.Unknown;
            }

            extension = Path.GetExtension(filename).ToLower();
            switch (extension)
            {
                case ".pdf":
                    return DocumentType.Pdf;

                case ".doc":
                case ".docx":
                case ".htm":
                case ".html":
                    return DocumentType.MicrosoftWord;

                case ".xls":
                case ".xlsx":
                case ".csv":
                    return DocumentType.MicrosoftExcel;

                case ".ppt":
                case ".pptx":
                    return DocumentType.MicrosoftPowerpoint;
                case ".rtf":
                    return DocumentType.Rtf;

                case ".txt":
                case ".text":
                    return DocumentType.Txt;

                case ".jpg":
                case ".bmp":
                case ".png":
                case ".tiff":
                case ".jpeg":
                case ".gif":
                    return DocumentType.Image;

                default:
                    return DocumentType.Unknown;
            }
        }
    }
}
