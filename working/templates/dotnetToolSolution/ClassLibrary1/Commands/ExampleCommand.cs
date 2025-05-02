namespace $PackageId$.Commands
{
    using $PackageId$.SystemCommandLine;

    internal class ExampleCommand : Command
    {
        public ExampleCommand() : 
            base(name: "example", description: "An example of a subcommand.")
        {
            AddOption(new Option<IFileInfoIO>(
                aliases: ["--example-package-file", "-epf"],
                description: "The path to the example package file that is mandatory and needs to exist.")
            {
                IsRequired = true
            }.LegalFilePathsOnly()!.ExistingOnly());

            AddOption(new Option<IDirectoryInfoIO?>(
                aliases: ["--example-output-directory", "-eod"],
                description: "The directory path for the output which is optional.")
            {
                IsRequired = false
            }.LegalFilePathsOnly());
        }
    }
    
    internal class ExampleCommandHandler(ILogger<ExampleCommandHandler> logger, IConfiguration configuration) : ICommandHandler
    {
        public required IFileInfoIO ExamplePackageFile { get; set; }

        public IDirectoryInfoIO? ExampleOutputDirectory { get; set; }

        public int Invoke(InvocationContext context)
        {
            // InvokeAsync is called in Program.cs
            return (int)ExitCodes.NotImplemented;
        }

        public async Task<int> InvokeAsync(InvocationContext context)
        {
            logger.LogDebug("Starting {method}...", nameof(ExampleCommand));

            try
            {
                // Retrieve user secrets/environment variables
                var exampleSecret = configuration["ExampleSecret"];

                // Create output directory if exists
                ExampleOutputDirectory?.Create();

                if (ExamplePackageFile.Length == 0)
                {
                    // If it needs to fail
                    return (int)ExitCodes.Fail;
                }

                // Readout file
                await using FileStream fileStream = ExamplePackageFile.OpenRead();

                logger.LogInformation("Informational message that by default will be shown.");

                return (int)ExitCodes.Ok;
            }
            catch (Exception e)
            {
                logger.LogError(e, "Failed the example command.");
                return (int)ExitCodes.UnexpectedException;
            }
            finally
            {
                logger.LogDebug("Finished {method}.", nameof(ExampleCommand));
            }
        }
    }
}