namespace Amazon.Server.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Amazon.Server.Data.Models;

    public class CountriesSeeder : ISeeder
    {
        public async Task SeedAsync(AmazonDbContext dbContext, IServiceProvider serviceProvider)
        {
            var countryNames =
                "Afghanistan\r\nAlbania\r\nAlgeria\r\nAndorra\r\nAngola\r\nAntigua and Barbuda\r\nArgentina\r\nArmenia\r\nAustralia\r\nAustria\r\nAzerbaijan\r\nBahamas\r\nBahrain\r\nBangladesh\r\nBarbados\r\nBelarus\r\nBelgium\r\nBelize\r\nBenin\r\nBhutan\r\nBolivia\r\nBosnia and Herzegovina\r\nBotswana\r\nBrazil\r\nBrunei \r\nBulgaria\r\nBurkina Faso\r\nBurundi\r\nCôte d'Ivoire\r\nCabo Verde\r\nCambodia\r\nCameroon\r\nCanada\r\nCentral African Republic\r\nChad\r\nChile\r\nChina\r\nColombia\r\nComoros\r\nCongo (Congo-Brazzaville)\r\nCosta Rica\r\nCroatia\r\nCuba\r\nCyprus\r\nCzechia (Czech Republic)\r\nDemocratic Republic of the Congo\r\nDenmark\r\nDjibouti\r\nDominica\r\nDominican Republic\r\nEcuador\r\nEgypt\r\nEl Salvador\r\nEquatorial Guinea\r\nEritrea\r\nEstonia\r\nEswatini\r\nEthiopia\r\nFiji\r\nFinland\r\nFrance\r\nGabon\r\nGambia\r\nGeorgia\r\nGermany\r\nGhana\r\nGreece\r\nGrenada\r\nGuatemala\r\nGuinea\r\nGuinea-Bissau\r\nGuyana\r\nHaiti\r\nHoly See\r\nHonduras\r\nHungary\r\nIceland\r\nIndia\r\nIndonesia\r\nIran\r\nIraq\r\nIreland\r\nIsrael\r\nItaly\r\nJamaica\r\nJapan\r\nJordan\r\nKazakhstan\r\nKenya\r\nKiribati\r\nKuwait\r\nKyrgyzstan\r\nLaos\r\nLatvia\r\nLebanon\r\nLesotho\r\nLiberia\r\nLibya\r\nLiechtenstein\r\nLithuania\r\nLuxembourg\r\nMadagascar\r\nMalawi\r\nMalaysia\r\nMaldives\r\nMali\r\nMalta\r\nMarshall Islands\r\nMauritania\r\nMauritius\r\nMexico\r\nMicronesia\r\nMoldova\r\nMonaco\r\nMongolia\r\nMontenegro\r\nMorocco\r\nMozambique\r\nMyanmar (formerly Burma)\r\nNamibia\r\nNauru\r\nNepal\r\nNetherlands\r\nNew Zealand\r\nNicaragua\r\nNiger\r\nNigeria\r\nNorth Korea\r\nNorth Macedonia\r\nNorway\r\nOman\r\nPakistan\r\nPalau\r\nPalestine State\r\nPanama\r\nPapua New Guinea\r\nParaguay\r\nPeru\r\nPhilippines\r\nPoland\r\nPortugal\r\nQatar\r\nRomania\r\nRussia\r\nRwanda\r\nSaint Kitts and Nevis\r\nSaint Lucia\r\nSaint Vincent and the Grenadines\r\nSamoa\r\nSan Marino\r\nSao Tome and Principe\r\nSaudi Arabia\r\nSenegal\r\nSerbia\r\nSeychelles\r\nSierra Leone\r\nSingapore\r\nSlovakia\r\nSlovenia\r\nSolomon Islands\r\nSomalia\r\nSouth Africa\r\nSouth Korea\r\nSouth Sudan\r\nSpain\r\nSri Lanka\r\nSudan\r\nSuriname\r\nSweden\r\nSwitzerland\r\nSyria\r\nTajikistan\r\nTanzania\r\nThailand\r\nTimor-Leste\r\nTogo\r\nTonga\r\nTrinidad and Tobago\r\nTunisia\r\nTurkey\r\nTurkmenistan\r\nTuvalu\r\nUganda\r\nUkraine\r\nUnited Arab Emirates\r\nUnited Kingdom\r\nUnited States of America\r\nUruguay\r\nUzbekistan\r\nVanuatu\r\nVenezuela\r\nVietnam\r\nYemen\r\nZambia\r\nZimbabwe";

            var countries = countryNames
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(countryName => new Country { Name = countryName })
                .ToList();

            await dbContext.Countries.AddRangeAsync(countries);
            await dbContext.SaveChangesAsync();
        }
    }
}
