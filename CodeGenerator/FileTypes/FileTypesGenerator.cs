using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.FileTypes
{
    public class FileTypesGenerator
    {
        private string[] FileTypeList;

        public FileTypesGenerator(string[] fileTypeList)
        {
            FileTypeList = fileTypeList;
        }

        public IEnumerable<FileType> GetFileTypes()
        {
            if (FileTypeList == null)
                return GetDefaultTypes();

            if (FileTypeList.Any() == false)
                return GetDefaultTypes();

            return GetSpecificTypes();
        }

        private IEnumerable<FileType> GetSpecificTypes()
        {
            foreach (var fileTypeName in FileTypeList)
            {
                FileType fileType;
                if (Enum.TryParse<FileType>(fileTypeName, out fileType))
                {
                    yield return fileType;
                }
            }
        }

        private static IEnumerable<FileType> GetDefaultTypes()
        {
            return new List<FileType>() {
                    FileType.DAL,
                    FileType.DALTest,
                    FileType.Entity,
                    FileType.Logic,
                    FileType.LogicTest
                };
        }
    }
}
