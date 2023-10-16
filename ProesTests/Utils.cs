using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProesTests
{
    public static class Utils
    {

        public static IFormFile CreateBlankPicture()
        {
            //Arrange
            var pictureMock = new Mock<IFormFile>();

            using (var stream = new MemoryStream())
            {
                var writer = new StreamWriter(stream);
                writer.Write("test");
                writer.Flush();
                stream.Position = 0;

                var fileName = "testfile.png";

                pictureMock.Setup(f => f.OpenReadStream()).Returns(stream);
                pictureMock.Setup(f => f.FileName).Returns(fileName);
                pictureMock.Setup(f => f.Length).Returns(stream.Length);

                //Act
                return pictureMock.Object;
            }
        }

    }
}
