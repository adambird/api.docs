using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using api.docs.Models;
using NUnit.Framework;

namespace api.docs.test.Models
{
    [TestFixture]
    public class ResourceViewModelTest
    {
        private ResourceViewModel _resource;

        [SetUp]
        public void SetUp()
        {
            _resource = new ResourceViewModel()
                               {
                                   Name = "Account",
                                   ResourceDocs = new List<ResourceDocViewModel>()
                                                      {
                                                          new ResourceDocViewModel()
                                                              {
                                                                  Language = "en",
                                                                  Summary = "This is the English summary"
                                                              },
                                                          new ResourceDocViewModel()
                                                              {
                                                                  Language = "fr",
                                                                  Summary = "This is the French summary"
                                                              }
                                                      }
                               };

        }

        [Test]
        public void GetDoc()
        {
            Assert.AreEqual("en", _resource.GetDoc("en").Language);
            Assert.AreEqual("fr", _resource.GetDoc("fr").Language);

            data.Configuration.DefaultLanguage = "en";

            // confirm default is retrieved
            Assert.AreEqual(data.Configuration.DefaultLanguage, _resource.GetDoc("es").Language);

        }
    }
}
