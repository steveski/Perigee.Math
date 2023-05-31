namespace Perigee;

public static class Geographical
{
    // Code lifted from https://stormconsultancy.co.uk/blog/storm-news/the-haversine-formula-in-c-and-sql/
    public static double HaversineDistance(LatLng pos1, LatLng pos2, DistanceUnit unit)
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

    public class LatLng
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public LatLng()
        {
        }

        public LatLng(double lat, double lng)
        {
            this.Latitude = lat;
            this.Longitude = lng;
        }
    }

    public static double ToRadians(this double degrees)
    {
        double radians = (Math.PI / 180) * degrees;
        return (radians);
    }

}
