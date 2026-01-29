using System.Reflection;
using System.Text.Json;

namespace Snailbird.Utilities;

public static class Environment<T> where T : struct, IEquatable<T>
{
    public static async Task<T> LoadOrCreate()
    {
        var environmentRoot = Path.Combine(Directory.GetCurrentDirectory(), "environment");

        if (!Directory.Exists(environmentRoot))
        {
            Directory.CreateDirectory(environmentRoot);
        }

        var path = Path.Combine(environmentRoot, $"{typeof(T).Name.ToLower()}.json");

        // Check if valid
        if (File.Exists(path))
        {
            await using Stream stream = File.OpenRead(path);

            T environment = await JsonSerializer.DeserializeAsync<T>(stream);

            return environment.Equals(Activator.CreateInstance<T>()) ? // do not allow a default file to be used 
                throw new Exception($"Must configure default environment file for {typeof(T).Name} at {path}.") :
                environment;
        }

        // Create a blank file for convenience and abort
        await using FileStream fs = File.Create(path);
        await JsonSerializer.SerializeAsync(
            fs, 
            Activator.CreateInstance<T>(), 
            new JsonSerializerOptions { WriteIndented = true }
        );
        
        throw new Exception($"""
                             Environment file for {typeof(T).Name} not found at {path}.
                             Creating default file for manual configuration.
                             """);
    }
}