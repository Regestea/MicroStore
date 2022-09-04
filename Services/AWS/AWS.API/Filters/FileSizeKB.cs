using System.ComponentModel.DataAnnotations;

namespace AWS.API.Filters
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FileSizeKBAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        private readonly int _minFileSize;
        public FileSizeKBAttribute(int minFileSize, int maxFileSize)
        {
            _minFileSize = minFileSize;
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            if (value is IFormFile formFile)
            {
                if (formFile.Length > _maxFileSize * 1024 || formFile.Length < _minFileSize * 1024)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            else if (value is IFormFileCollection formFileCollection)
            {
                foreach (var file in formFileCollection)
                {
                    if (file.Length > _maxFileSize * 1024 || file.Length < _minFileSize * 1024)
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
                }
            }
            else if (value is string base64File)
            {
                if (base64File.Length > _maxFileSize * 1024 || base64File.Length < _minFileSize * 1024)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            else if (value is ICollection<string> collection)
            {
                foreach (var file in collection)
                {
                    if (file.Length > _maxFileSize * 1024 || file.Length < _minFileSize * 1024)
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
                }
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return string.Format("Allowed file size is between {0} KB and {1} KB", _minFileSize,
                _maxFileSize);
        }
    }
}
