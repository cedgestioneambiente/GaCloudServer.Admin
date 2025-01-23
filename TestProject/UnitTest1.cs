using System.Threading.Tasks;
using TestProject;
using Xunit;

public class AnagraficaServiceStandaloneTests
{
    [Fact]
    public async Task ValidateConsistentRegistryAsync_ReturnsSimilarityOrNot()
    {
        // Arrange
        var service = new AnagraficaServiceStandalone();

        // Dati di test per soggetto simile
        string cfPiva = "00443150065";
        string indirizzo = "VIA ROMA, 81";
        string ragSo = "COMUNE DI MOLINO DEI TORTI";
        long comuneId = 945;

        // Act: Test soggetto simile
        var result = await service.ValidateConsistentRegistryAsync(0, cfPiva, indirizzo, ragSo, comuneId);

        // Log dettagli
        Console.WriteLine($"Test soggetto simile: {result.Message}, Percentuale: {result.percent}, Soggetto:{result.Subject}");

        // Assert
        //Assert.NotNull(result);
        //Assert.Equal("Trovato soggetto simile", result.Message);
        //Assert.True(result.percent > 0);

        // Dati di esempio
        string ragioneSociale1 = "COMUNE DI MOLINO DEI TORTI";
        string indirizzo1 = "VIA ROMA, 81 - 15050 MOLINO DEI TORTI (AL)";
        string piva1 = "00443150065";
        int comuneId1 = 123;

        string ragioneSociale2 = "COMUNE DI MOLINO DEI TORTI";
        string indirizzo2 = "VIA Torino, 81";
        string piva2 = "00443150065";
        int comuneId2 = 123;

        // Calcolo similitudine
        double similarity = service.CalculateSimilarityV2(ragioneSociale1, indirizzo1, piva1, comuneId1, ragioneSociale2, indirizzo2, piva2, comuneId2);
        Console.WriteLine($"Similitudine: {similarity:F2}%");

        Assert.NotNull(similarity);
        Assert.Equal("Trovato soggetto simile", $"%{similarity}");
        Assert.True(similarity > 0);

    }
}
