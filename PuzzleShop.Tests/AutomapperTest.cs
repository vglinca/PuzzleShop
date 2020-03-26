using System;
using AutoMapper;
using NUnit.Framework;
using PuzzleShop.Core.Profiles;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Tests
{
    [TestFixture]
    public class AutomapperTest
    {
        [TestCase()]
        public void AutomapperConfigurationIsValid()
        {
            var cfg = new MapperConfiguration(mc => 
                mc.AddProfile(new PuzzleProfile()));
            var mapper = cfg.CreateMapper();
        }
    }
}