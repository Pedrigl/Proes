using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using ProesBack.Infrastructure.Data.Common;
using ProesBack.Infrastructure.Web;
using SkiaSharp;
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
            // Arrange
            var pictureMock = new Mock<IFormFile>();

            // Create a blank white PNG
            var width = 100;
            var height = 100;
            var color = SKColors.White;

            var stream = new MemoryStream();
                using (var surface = SKSurface.Create(width, height, SKImageInfo.PlatformColorType, SKAlphaType.Premul))
                {
                    var canvas = surface.Canvas;
                    canvas.Clear(color);

                    using (var image = surface.Snapshot())
                    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                    using (var skStream = data.AsStream())
                    {
                        skStream.CopyTo(stream);
                    }
                }

                stream.Position = 0;

                var fileName = "white_background.png";

                pictureMock.Setup(f => f.OpenReadStream()).Returns(stream);
                pictureMock.Setup(f => f.FileName).Returns(fileName);
                pictureMock.Setup(f => f.Length).Returns(stream.Length);

                // Act
                return pictureMock.Object;
            }

        public static Mapper GetMapper()
        {
            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            }));

            return mapper;
        }


        public static ProesContext GetFakeDbContext()
        {
            var options = new DbContextOptionsBuilder<ProesContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new ProesContext(options);

            return context;
        }

        public static IConfiguration GetConfiguration()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
            return configuration;
        }

    }
}
