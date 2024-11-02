// See https://aka.ms/new-console-template for more information
using videotoimage;
using ConsoleAppai;

Console.WriteLine("Hello, World!");
String[] files = Directory.GetFiles("C:\\Users\\ruben\\Videos\\wildcam 11-14 maart 2024");
List<List<Dictionary<string, float>>> batchresults = new List<List<Dictionary<string, float>>>();

for (int i = 0; i < files.Length; i++)
{
    Console.WriteLine(Path.GetFileName(files[i]));
    //Console.ReadLine();
    videotoimage.openCVversion.VideoToImage(files[i]);
    String[] images = Directory.GetFiles("frames");
    var filename = Path.GetFileNameWithoutExtension(files[i]);

    var filteredImages = images.Where(file => images.Any(image => image.ToLowerInvariant().Contains(Path.GetFileNameWithoutExtension(files[i]))));
    var t = images.Where(item => item.ToLowerInvariant().Contains(filename.ToUpperInvariant()));
    List<Dictionary<string, float>> videoresults = new List<Dictionary<string, float>>();
    var filteredResults = from image in images
                          where image.Contains(filename)
                          select image;
    int h = 0;
    foreach (var frame in filteredResults)
    {
        var imageBytes = File.ReadAllBytes(frame);
        AnimalSpotterAi.ModelInput sampleData = new AnimalSpotterAi.ModelInput()
        {
            ImageSource = imageBytes,
        };
        Dictionary<string, float> dictionary = new Dictionary<string, float>();
        // Make a single prediction on the sample data and print results.
        var sortedScoresWithLabel = AnimalSpotterAi.PredictAllLabels(sampleData);
        Console.WriteLine($"{"Class",-40}{"Score",-20}");
        Console.WriteLine($"{"-----",-40}{"-----",-20}");

        foreach (var score in sortedScoresWithLabel)
        {
            dictionary.Add(score.Key, score.Value);
            Console.WriteLine($"{score.Key,-40}{score.Value,-20}");
        }
        videoresults.Add(dictionary);
    }
    batchresults.Add(videoresults);
}