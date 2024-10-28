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
        string cfPiva = "1492290067";
        string indirizzo = "EX STRADA STATALE 35 DEI GIOVI, 42 - 15057 Novi ligure (AL)";
        string ragSo = "Campione AMBIENTE srl";
        long comuneId = 1196;

        // Act: Test soggetto simile
        var result = await service.ValidateConsistentRegistryAsync(0, cfPiva, indirizzo, ragSo, comuneId);

        // Log dettagli
        Console.WriteLine($"Test soggetto simile: {result.Message}, Percentuale: {result.percent}");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Trovato soggetto simile", result.Message);
        Assert.True(result.percent > 0);


    }
}
