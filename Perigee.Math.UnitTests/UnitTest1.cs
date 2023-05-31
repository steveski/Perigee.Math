namespace Perigee.Math.UnitTests;

public class HaversineTests
{
    [Fact]
    public void Test1()
    {
        // Check answers here https://www.vcalc.com/wiki/vCalc/Haversine+-+Distance
        var distance1 = Geographical.HaversineDistance(
            new Geographical.LatLng(-35.281136, 149.148521),
            new Geographical.LatLng(-37.823783, 144.958100),
            Geographical.DistanceUnit.Kilometers);


        var distance2 = Geographical.HaversineDistance(
            new Geographical.LatLng(-37.823783, 144.958100),
            new Geographical.LatLng(-35.281136, 149.148521),
            Geographical.DistanceUnit.Kilometers);

    }
}

