using System.Collections.Generic;

public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public double Mag { get; set; }
    public string Place { get; set; }

    // Helper to get formatted string for this earthquake
    public string GetSummary()
    {
        // Format magnitude to 2 decimal places
        return $"{Place} - Mag {Mag:F2}";
    }
}
