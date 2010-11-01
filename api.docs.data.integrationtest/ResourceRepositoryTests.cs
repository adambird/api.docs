using System;
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
                using (var command = new SqlCommand("TRUNCATE TABLE ResourceDocs", connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SqlCommand("TRUNCATE TABLE Resources", connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SqlCommand("TRUNCATE TABLE Fields", connection))
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
                                                          Summary = "This is the default English summary"
                                                      },
                                                  new ResourceDoc()
                                                      {
                                                          Language = "fr",
                                                          Summary = "This is the French summary"
                                                      }
                                              }

                               };

            resource.Fields = new List<Field>()
                                  {
                                      new Field()
                                          {
                                              Name = "Reference",
                                              FieldType = "string",
                                              Resource = resource
                                          },
                                      new Field()
                                          {
                                              Name = "EndOn",
                                              FieldType = "datetime",
                                              Resource = resource
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

                using (var command = new SqlCommand("SELECT Id, ResourceId, Language, Summary FROM ResourceDocs", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            var docs = new List<ResourceDoc>(resource.ResourceDocs);

                            Assert.AreEqual(resource.Id, reader.GetGuid(1));
                            Assert.AreEqual(docs[i].Language, reader.GetString(2));
                            Assert.AreEqual(docs[i].Summary, reader.GetString(3));
                            i++;
                        }
                        Assert.AreEqual(i, resource.ResourceDocs.Count);
                    }
                }

                using (var command = new SqlCommand("SELECT Id, ResourceId, Name, FieldType FROM Fields", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            var fields = new List<Field>(resource.Fields);

                            Assert.AreEqual(resource.Id, reader.GetGuid(1));
                            Assert.AreEqual(fields[i].Name, reader.GetString(2));
                            Assert.AreEqual(fields[i].FieldType, reader.GetString(3));
                            i++;
                        }
                        Assert.AreEqual(i, resource.Fields.Count);
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
                                                          Summary = "This is the default English summary"
                                                      },
                                                  new ResourceDoc()
                                                      {
                                                          Language = "fr",
                                                          Summary = "This is the French summary"
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

                var docs = new List<ResourceDoc>(resource.ResourceDocs);
                var actualDocs = new List<ResourceDoc>(actual.ResourceDocs);

                for (int i = 0; i < docs.Count; i++)
                {
                    Assert.AreEqual(docs[i].Language, actualDocs[i].Language);
                    Assert.AreEqual(docs[i].Summary, actualDocs[i].Summary);
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
                                                          Summary = "This is the default English summary"
                                                      },
                                                  new ResourceDoc()
                                                      {
                                                          Language = "fr",
                                                          Summary = "This is the French summary"
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

                using (var command = new SqlCommand("SELECT Id, ResourceId, Language, Summary FROM ResourceDocs", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        Assert.IsFalse(reader.Read(), "Docs table");
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
                                                          Summary = "This is the default English summary"
                                                      },
                                                  new ResourceDoc()
                                                      {
                                                          Language = "fr",
                                                          Summary = "This is the French summary"
                                                      }
                                              }
            };

            var docs = new List<ResourceDoc>(resource.ResourceDocs);

            using (var repository = new ResourceRepository())
            {
                repository.Add(resource);
                repository.SaveChanges();

                resource = repository.GetById(resource.Id);
                
                resource.Name = "NewName";
                docs[1].Summary = "New Summary for New Name";
                repository.Save(resource);
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

                using (var command = new SqlCommand("SELECT Id, ResourceId, Language, Summary FROM ResourceDocs", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            Assert.AreEqual(resource.Id, reader.GetGuid(1));
                            Assert.AreEqual(docs[i].Language, reader.GetString(2));
                            Assert.AreEqual(docs[i].Summary, reader.GetString(3));
                            i++;
                        }
                        Assert.AreEqual(i, resource.ResourceDocs.Count);
                    }
                }
            }
        }

    }
}
