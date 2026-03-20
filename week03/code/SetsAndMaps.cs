using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE

        // ======== CODE ======== //  (by Jéssica Seniw)

        // Problem 1 – FindPairs
        // Before:
        // - The function did not contain any implementation.
        // - No logic existed to find symmetric word pairs.
    
        // Fix:
        // - Used a HashSet to store previously seen words for O(1) lookup.
        // - Iterated through the list and checked for reversed word pairs.
        // - Ignored invalid cases such as words with identical characters (e.g., "aa").
    
        // After:
        // - The function correctly returns all symmetric word pairs.
        // - The solution runs in O(n) time complexity.

        // Using HashSet to allow O(1) lookup and ensure O(n) overall complexity
        var seen = new HashSet<string>();

        // List to store the resulting symmetric pairs
        var result = new List<string>();

        foreach (var word in words)
        {
            // Skip words with identical characters (e.g., "aa")
            // This follows the problem constraint that such cases should not match anything
            if (word[0] == word[1])
                continue;

            // Create the reversed version of the word
            var reversed = $"{word[1]}{word[0]}";

            // If the reversed word was already seen, we found a symmetric pair
            if (seen.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
            }

            // Add current word to the set for future comparisons
            seen.Add(word);
        }

        // Return the result as an array
        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            // TODO Problem 2 - ADD YOUR CODE HERE

            // ======== CODE ======== //  (by Jéssica Seniw)

            // Problem 2 – SummarizeDegrees
            // Before:
            // - The function did not process or store degree information.
            // - No logic existed to summarize the dataset.

            // Fix:
            // - Read each line from the input file.
            // - Extracted the degree from the 4th column.
            // - Used a Dictionary to count occurrences of each degree.

            // After:
            // - The function returns a dictionary with correct counts for each degree.
            // - The implementation passes all unit tests.

            // Extract degree from column 4 (index 3)
            var degree = fields[3].Trim();

            // If degree already exists, increment its count
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                // Otherwise, initialize the count to 1
                degrees[degree] = 1;
            }

        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE

        // ======== CODE ======== //  (by Jéssica Seniw)
        // Problem 3 – IsAnagram
        // Before:
        // - The function did not correctly validate anagrams.
        // - It did not ignore spaces or handle case sensitivity.
        
        // Fix:
        // - Converted all characters to lowercase.
        // - Ignored spaces in both input strings.
        // - Used a Dictionary to track character frequencies.
        // - Decreased counts while processing the second word.
        // - Validated that no character count became negative.
        
        // After:
        // - The function correctly identifies anagrams under all required conditions.
        // - The solution runs efficiently in O(n) time.

        // Dictionary to store character frequencies
        var counts = new Dictionary<char, int>();

        int count1 = 0;
        int count2 = 0;

        // Process first word
        for (int i = 0; i < word1.Length; i++)
        {
            char c = word1[i];

            // Ignore spaces
            if (c == ' ') continue;

            // Normalize to lowercase
            c = char.ToLower(c);
            count1++;

            // Increment frequency count
            if (counts.TryGetValue(c, out int value))
                counts[c] = value + 1;
            else
                counts[c] = 1;
        }

        // Process second word
        for (int i = 0; i < word2.Length; i++)
        {
            char c = word2[i];

            // Ignore spaces
            if (c == ' ') continue;

            // Normalize to lowercase
            c = char.ToLower(c);
            count2++;

            // If character not found, not an anagram
            if (!counts.TryGetValue(c, out int value))
                return false;

            value--;

            // If count goes negative, not an anagram
            if (value < 0)
                return false;

            counts[c] = value;
        }

        // If total number of characters differs, it cannot be an anagram
        if (count1 != count2)
            return false;

        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);

        var json = reader.ReadToEnd();

        // Ignore case differences when mapping JSON properties to C# classes
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        // ======== CODE ======== //  (by Jéssica Seniw)

        // List to store formatted earthquake information
        var result = new List<string>();

        // Ensure the deserialized object is not null
        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                if (feature?.Properties == null)
                    continue;

                var place = feature.Properties.Place;
                var mag = feature.Properties.Mag;

                // Format output as required: "Place - Mag X"
                result.Add($"{place} - Mag {mag}");
            }
        }

        // Return the final array of formatted strings
        return result.ToArray();
    }
}