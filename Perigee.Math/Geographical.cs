namespace Perigee;

public class Geographical
{
    // Code lifted from https://stormconsultancy.co.uk/blog/storm-news/the-haversine-formula-in-c-and-sql/
    public static double HaversineDistance(Location pos1, Location pos2, DistanceUnit unit)
    {
        double R = (unit == DistanceUnit.Miles) ? 3960 : 6371;
        var lat = (pos2.Latitude - pos1.Latitude).ToRadians();
        var lng = (pos2.Longitude - pos1.Longitude).ToRadians();
        var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
                      Math.Cos(pos1.Latitude.ToRadians()) * Math.Cos(pos2.Latitude.ToRadians()) *
                      Math.Sin(lng / 2) * Math.Sin(lng / 2);
        var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));
        return R * h2;
    }

    public enum DistanceUnit { Miles, Kilometers };

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location(double lat, double lng)
        {
            this.Latitude = lat;
            this.Longitude = lng;
        }
    }

    public static double? GetDistance(double fromLat, double fromLong, double toLat, double toLong)
    {
        if (fromLat == 0 || fromLong == 0 || toLat == 0 || toLong == 0)
            return null;

        var distance = Geographical.HaversineDistance(
            new Geographical.Location(fromLat, fromLong),
            new Geographical.Location(toLat, toLong),
            Geographical.DistanceUnit.Kilometers);

        return distance;
    }

}

internal static class GeographicalExtensions
{
    public static double ToRadians(this double degrees)
    {
        double radians = (Math.PI / 180) * degrees;
        return (radians);
    }
}
