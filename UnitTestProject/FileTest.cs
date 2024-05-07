using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnitTestEx;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject
{
    [TestClass]
    public class FileTest
    {

        public const string SIZE_EXCEPTION = "Wrong size";
        public const string NAME_EXCEPTION = "Wrong name";
        public const string CONTENT_EXCEPTION = "Wrong content";
        public const string SPACE_STRING = " ";
        public const string FILE_PATH_STRING = "@D:\\JDK-intellij-downloader-info.txt";
        public const string CONTENT_STRING = "Some text";
        public double lenght;
        public string name;

        /* ПРОВАЙДЕР */
        //static object[] FilesData =
        //{
        //    new object[] {new File(FILE_PATH_STRING, CONTENT_STRING), FILE_PATH_STRING, CONTENT_STRING},
        //    new object[] { new File(SPACE_STRING, SPACE_STRING), SPACE_STRING, SPACE_STRING}
        //};
        public static IEnumerable<object[]> FilesData
        {
            get
            {
                return new[]
                {
                    new object[] { FILE_PATH_STRING, CONTENT_STRING },
                    new object[] { SPACE_STRING, SPACE_STRING },
                };
            }
        }

        /* Тестируем получение размера */
        [TestMethod]
        [DynamicData(nameof(FilesData))]
        public void GetSizeTest(string filename, string content)
        {
            File newFile = new File(filename, content);

            lenght = content.Length / 2;

            Assert.AreEqual(newFile.GetSize(), lenght, SIZE_EXCEPTION);
        }

        /* Тестируем получение имени */   
        [TestMethod]
        [DynamicData(nameof(FilesData))]
        public void GetFilenameTest(string filename, string content)
        {
            File newFile = new File(filename, content);

            Assert.AreEqual(newFile.GetFilename(), filename, NAME_EXCEPTION);
        }

        /* Тестируем получение контента */
        [TestMethod]
        [DynamicData(nameof(FilesData))]
        public void GetContentTest(string filename, string content)
        {
            File newFile = new File(filename, content);

            Assert.AreEqual(newFile.GetContent(), content, CONTENT_EXCEPTION);
        }
    }
}
