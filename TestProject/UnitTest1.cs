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
        string cfPiva = "03083200109";
        string indirizzo = "STRADA SAVONESA, 8 - 15057 TORTONA (AL)";
        string ragSo = "RELIFE RECYCLING S.R.L.";
        long comuneId = 1196;

        // Act: Test soggetto simile
        var result = await service.ValidateConsistentRegistryAsync(0, cfPiva, indirizzo, ragSo, comuneId);

        // Log dettagli
        Console.WriteLine($"Test soggetto simile: {result.Message}, Percentuale: {result.percent}, Soggetto:{result.Subject}");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Trovato soggetto simile", result.Message);
        Assert.True(result.percent > 0);


    }
}
