public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    // ======== CODE ======== //  (by Jéssica Seniw)

    // Problem 5 – Earthquake JSON Data
    // Before:
    // - JSON deserialization was not working correctly.
    // - The class structure did not match the JSON format from the API.
    // - Resulting data could not be accessed properly.
    
    // Fix:
    // - Created FeatureCollection, Feature, and Properties classes.
    // - Mapped the JSON structure to C# objects correctly.
    // - Enabled case-insensitive property mapping.
    // - Extracted 'place' and 'mag' values from each feature.
    // - Formatted output as "Place - Mag X".
    
    // After:
    // - JSON data is correctly deserialized.
    // - The function returns formatted earthquake data.
    // - All unit tests pass successfully.

    public List<Feature> Features { get; set; } = new();
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public string Place { get; set; }
    public double? Mag { get; set; }
}