using System;
using NUnit.Framework;
using StoryQ;
using WatiN.Core;
using CassiniDev;

namespace api.docs.admin.integrationtest
{
    [TestFixture]
    public class ResourceEditingStories
    {
        private Feature _editResourceStory = new Story("EditResourceStory")
            .InOrderTo("document a resource")
            .AsA("API documentor")
            .IWant("to ne be able to edit the information about the resource");

        [Test]
        public void EditResourceStory()
        {
            _editResourceStory.WithScenario("Create a new translation for the resource documentation")
                            .Given(AResourceExists, true)
                            .When(IEditCompleteTheNewResourceDocFormOnTheEditResourcePage)
                            .Then(TheResourceDocRecordIsCreated)
                                .And(IAmShownTheEditPageWithTheNewResourceDocBeingDisplayed)
                .Execute();
        }

        private void AResourceExists(bool arg1)
        {
            throw new NotImplementedException();
        }

        private void IEditCompleteTheNewResourceDocFormOnTheEditResourcePage()
        {
            throw new NotImplementedException();
        }

        private void TheResourceDocRecordIsCreated()
        {
            throw new NotImplementedException();
        }

        private void IAmShownTheEditPageWithTheNewResourceDocBeingDisplayed()
        {
            throw new NotImplementedException();
        }

    }
}
