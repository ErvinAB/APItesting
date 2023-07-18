using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace APITestingFramework
{
    [Binding]
    public class PetstoreApiSteps
    {
        private readonly PetstoreApiClient _petstoreApiClient;
        private Pet _newPet;
        private Pet _updatedPet;
        private Pet _retrievedPet;

        public PetstoreApiSteps()
        {
            _petstoreApiClient = new PetstoreApiClient();
        }

        [Given(@"I have a pet with the following details:")]
        public void GivenIHaveAPetWithTheFollowingDetails(Table table)
        {
            _newPet = table.CreateInstance<Pet>();
        }

        [Given(@"I have a pet with the ID (.*)")]
        public void GivenIHaveAPetWithTheId(long petId)
        {
            _newPet = new Pet { Id = petId };
        }

        [Given(@"I have a pet with the ID (.*) and updated details:")]
        public void GivenIHaveAPetWithTheIdAndUpdatedDetails(long petId, Table table)
        {
            _updatedPet = table.CreateInstance<Pet>();
            _updatedPet.Id = petId;
        }

        [When(@"I send a request to create the pet")]
        public async Task WhenISendARequestToCreateThePet()
        {
            _retrievedPet = await _petstoreApiClient.CreatePet(_newPet);
        }

        [When(@"I send a request to get the pet by ID")]
        public async Task WhenISendARequestToGetThePetById()
        {
            _retrievedPet = await _petstoreApiClient.GetPetById(_newPet.Id);
        }

        [When(@"I send a request to update the pet")]
        public async Task WhenISendARequestToUpdateThePet()
        {
            _retrievedPet = await _petstoreApiClient.UpdatePet(_updatedPet);
        }

        [When(@"I send a request to delete the pet by ID")]
        public async Task WhenISendARequestToDeleteThePetById()
        {
            await _petstoreApiClient.DeletePetById(_newPet.Id);
        }

        [Then(@"the pet is created successfully")]
        public void ThenThePetIsCreatedSuccessfully()
        {
            Console.WriteLine("Created Pet: " + JsonConvert.SerializeObject(_retrievedPet));
            // Add assertions as needed
        }

        [Then(@"the pet details are retrieved successfully")]
        public void ThenThePetDetailsAreRetrievedSuccessfully()
        {
            Console.WriteLine("Retrieved Pet: " + JsonConvert.SerializeObject(_retrievedPet));
            // Add assertions as needed
        }

        [Then(@"the pet is updated successfully")]
        public void ThenThePetIsUpdatedSuccessfully()
        {
            Console.WriteLine("Updated Pet: " + JsonConvert.SerializeObject(_retrievedPet));
            // Add assertions as needed
        }

        [Then(@"the pet is deleted successfully")]
        public void ThenThePetIsDeletedSuccessfully()
        {
            Console.WriteLine("Deleted Pet with ID: " + _newPet.Id);
            // Add assertions as needed
        }
    }
}
