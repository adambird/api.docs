using System.Collections.Generic;
using System.Configuration;
using api.docs.data.Repository;
using NUnit.Framework;
using System.Data.SqlClient;

namespace api.docs.data.integrationtest
{
    [TestFixture]
    public class ResourceRepositoryTests
    {
        [SetUp]
        public void SetUp()
        {
            Purge();
        }

        [TearDown]
        public void TearDown()
        {
            //Purge();
        }

        private void Purge()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["api.docs.data"].ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("TRUNCATE TABLE Resource_Docs", connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SqlCommand("TRUNCATE TABLE Resources", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        [Test]
        public void ResourceCreate()
        {
            var resource = new Resource()
                               {
                                   Name = "Account",
                                   ResourceDocs = new List<ResourceDoc>()
                                              {
                                                  new ResourceDoc()
                                                      {
                                                          Language = "en",
                                                          Region = null,
                                                          Summary = "This is the default English summary"
                                                      },
                                                  new ResourceDoc()
                                                      {
                                                          Language = "en",
                                                          Region = "us",
                                                          Summary = "This is the English US summary"
                                                      }
                                              }
                               };

            using (var repository = new ResourceRepository())
            {
                repository.Add(resource);
                repository.SaveChanges();
            }

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["api.docs.data"].ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Id, Name FROM Resources", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        Assert.IsTrue(reader.Read());
                        Assert.AreEqual(resource.Name, reader.GetString(1));
                        Assert.IsFalse(reader.Read());
                    }
                }

                using (var command = new SqlCommand("SELECT Id, ResourceId, Language, Region, Summary FROM Resource_Docs", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            Assert.AreEqual(resource.Id, reader.GetInt32(1));
                            Assert.AreEqual(resource.ResourceDocs[i].Language, reader.GetString(2));
                            if (resource.ResourceDocs[i].Region == null)
                            {
                                Assert.IsTrue(reader.IsDBNull(3));
                            }
                            else
                            {
                                Assert.AreEqual(resource.ResourceDocs[i].Region, reader.GetString(3));
                            }
                            Assert.AreEqual(resource.ResourceDocs[i].Summary, reader.GetString(4));
                            i++;
                        }
                        Assert.AreEqual(i, resource.ResourceDocs.Count);
                    }
                }
            }
        }

        [Test]
        public void ResourceRead()
        {
            var resource = new Resource()
            {
                Name = "Account",
                ResourceDocs = new List<ResourceDoc>()
                                              {
                                                  new ResourceDoc()
                                                      {
                                                          Language = "en",
                                                          Region = null,
                                                          Summary = "This is the default English summary"
                                                      },
                                                  new ResourceDoc()
                                                      {
                                                          Language = "en",
                                                          Region = "us",
                                                          Summary = "This is the English US summary"
                                                      }
                                              }
            };

            using (var repository = new ResourceRepository())
            {
                repository.Add(resource);
                repository.SaveChanges();

                var actual = repository.GetById(resource.Id);

                Assert.AreEqual(resource.Name, actual.Name);
                Assert.AreEqual(resource.ResourceDocs.Count, actual.ResourceDocs.Count);
                for (int i = 0; i < resource.ResourceDocs.Count; i++)
                {
                    Assert.AreEqual(resource.ResourceDocs[i].Language, resource.ResourceDocs[i].Language);
                    Assert.AreEqual(resource.ResourceDocs[i].Region, resource.ResourceDocs[i].Region);
                    Assert.AreEqual(resource.ResourceDocs[i].Summary, resource.ResourceDocs[i].Summary);
                }
            }
        }

        [Test]
        public void ResourceDelete()
        {
            var resource = new Resource()
            {
                Name = "Account",
                ResourceDocs = new List<ResourceDoc>()
                                              {
                                                  new ResourceDoc()
                                                      {
                                                          Language = "en",
                                                          Region = null,
                                                          Summary = "This is the default English summary"
                                                      },
                                                  new ResourceDoc()
                                                      {
                                                          Language = "en",
                                                          Region = "us",
                                                          Summary = "This is the English US summary"
                                                      }
                                              }
            };

            using (var repository = new ResourceRepository())
            {
                repository.Add(resource);
                repository.SaveChanges();

                repository.DeleteById(resource.Id);
                repository.SaveChanges();
            }

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["api.docs.data"].ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Id, Name FROM Resources", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        Assert.IsFalse(reader.Read(), "Resources table");
                    }
                }

                using (var command = new SqlCommand("SELECT Id, ResourceId, Language, Region, Summary FROM Resource_Docs", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        Assert.IsFalse(reader.Read(), "Resource_Docs table");
                    }
                }
            }

        }

        [Test]
        public void ResourceUpdate()
        {
            var resource = new Resource()
            {
                Name = "Account",
                ResourceDocs = new List<ResourceDoc>()
                                              {
                                                  new ResourceDoc()
                                                      {
                                                          Language = "en",
                                                          Region = null,
                                                          Summary = "This is the default English summary"
                                                      },
                                                  new ResourceDoc()
                                                      {
                                                          Language = "en",
                                                          Region = "us",
                                                          Summary = "This is the English US summary"
                                                      }
                                              }
            };

            using (var repository = new ResourceRepository())
            {
                repository.Add(resource);
                repository.SaveChanges();
                resource.Name = "NewName";
                resource.ResourceDocs[1].Summary = "New Summary for New Name";
                repository.SaveChanges();
            }

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["api.docs.data"].ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Id, Name FROM Resources", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        Assert.IsTrue(reader.Read());
                        Assert.AreEqual(resource.Name, reader.GetString(1));
                        Assert.IsFalse(reader.Read());
                    }
                }

                using (var command = new SqlCommand("SELECT Id, ResourceId, Language, Region, Summary FROM Resource_Docs", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            Assert.AreEqual(resource.Id, reader.GetInt32(1));
                            Assert.AreEqual(resource.ResourceDocs[i].Language, reader.GetString(2));
                            if (resource.ResourceDocs[i].Region == null)
                            {
                                Assert.IsTrue(reader.IsDBNull(3));
                            }
                            else
                            {
                                Assert.AreEqual(resource.ResourceDocs[i].Region, reader.GetString(3));
                            }
                            Assert.AreEqual(resource.ResourceDocs[i].Summary, reader.GetString(4));
                            i++;
                        }
                        Assert.AreEqual(i, resource.ResourceDocs.Count);
                    }
                }
            }
        }
    }
}
