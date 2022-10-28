namespace LineCounter {
    public class LineCounter {
        public static string BasePath = System.AppContext.BaseDirectory;
        public static int LineCount = 0;
        public static List<string> FilesFound = new();
        public static List<string>? FileExtensions;
        public static List<string> IgnoredDirectories = new();

        /// <summary>
        /// The starting point of the program.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args) {

            try {
                FileExtensions = args.ToList<string>();
            } catch (IndexOutOfRangeException) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("It appears you did not specify any file types to count lines for.");
                Console.ResetColor();
                Console.WriteLine("\nBelow is an example of how to use this program.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("line-counter.exe .py .c .cpp");
                Console.ResetColor();
                Console.WriteLine("This will make the program count lines for all Python, C, and C++ files in the current directory (and all its child folders).");
                return;
            }

            List<string> directories = Enumerable.Concat(
                new List<string>() { BasePath },
                Directory.GetDirectories(
                    BasePath, "*", new EnumerationOptions() { RecurseSubdirectories = true }
                ).ToList()
            ).ToList<string>();

            foreach (string directory in directories) {
                if (!IgnoredDirectories.Any(x => directory.Contains(x))) {
                    List<string> files = Directory.GetFiles(directory).ToList<string>();

                    files.ForEach(x => {
                        if (FileExtensions.Any(y => x.EndsWith(y))) {
                            FilesFound.Add(Path.GetFileName(x));
                            LineCount += File.ReadAllText(x).Split("\n").Length;
                        }
                    });
                }
            }

            Console.WriteLine($"Number of lines in project {new DirectoryInfo(BasePath).Name} is {LineCount}");
        }
    }
}