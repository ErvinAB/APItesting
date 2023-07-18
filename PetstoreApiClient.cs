using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APITestingFramework
{
    public class PetstoreApiClient
    {
        // Rest of the code remains the same
        // ...
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://petstore.swagger.io/v2";

        public PetstoreApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Pet> CreatePet(Pet pet)
        {
            string url = $"{BaseUrl}/pet";
            string json = JsonConvert.SerializeObject(pet);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Pet>(responseContent);
        }

        public async Task<Pet> GetPetById(long petId)
        {
            string url = $"{BaseUrl}/pet/{petId}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Pet>(responseContent);
        }

        public async Task<Pet> UpdatePet(Pet pet)
        {
            string url = $"{BaseUrl}/pet";
            string json = JsonConvert.SerializeObject(pet);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Pet>(responseContent);
        }

        public async Task DeletePetById(long petId)
        {
            string url = $"{BaseUrl}/pet/{petId}";

            HttpResponseMessage response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }

    public class Pet
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }

    public class PetstoreApiTests
    {
        private readonly PetstoreApiClient _petstoreApiClient;

        public PetstoreApiTests()
        {
            _petstoreApiClient = new PetstoreApiClient();
        }

        public async Task CreatePetTest()
        {
            // Test data
            var newPet = new Pet { Id = 1, Name = "Fluffy", Status = "available" };

            // Test steps
            Pet createdPet = await _petstoreApiClient.CreatePet(newPet);

            // Assertion
            Console.WriteLine("Created Pet: " + JsonConvert.SerializeObject(createdPet));
            // Add assertions as needed
        }

        public async Task GetPetByIdTest()
        {
            // Test data
            long petId = 1;

            // Test steps
            Pet retrievedPet = await _petstoreApiClient.GetPetById(petId);

            // Assertion
            Console.WriteLine("Retrieved Pet: " + JsonConvert.SerializeObject(retrievedPet));
            // Add assertions as needed
        }

        public async Task UpdatePetTest()
        {
            // Test data
            var updatedPet = new Pet { Id = 1, Name = "Fluffy", Status = "sold" };

            // Test steps
            Pet updatedPetResult = await _petstoreApiClient.UpdatePet(updatedPet);

            // Assertion
            Console.WriteLine("Updated Pet: " + JsonConvert.SerializeObject(updatedPetResult));
            // Add assertions as needed
        }

        public async Task DeletePetByIdTest()
        {
            // Test data
            long petId = 1;

            // Test steps
            await _petstoreApiClient.DeletePetById(petId);

            // Assertion
            Console.WriteLine("Deleted Pet with ID: " + petId);
            // Add assertions as needed
        }
    }

    class Program
    {
        static async Task Main()
        {
            var petstoreTests = new PetstoreApiTests();

            await petstoreTests.CreatePetTest();
            await petstoreTests.GetPetByIdTest();
            await petstoreTests.UpdatePetTest();
            await petstoreTests.DeletePetByIdTest();
        }
    }



}

