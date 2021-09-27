using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDelivery.CommandLine
{
    public class Program
    {


        // our command line structure

        private static readonly RootCommand rootCommand = new RootCommand("a little food delivery app")
        {
            new Option<string>("--restaurant", "The restaurant to order food from")
            {
                IsRequired = true,
            },

            new Option<string>("--menu-item", "The menu items to order"),

            new Option<DeliveryService>("--service", "Which delivery service should be used"),

            new Option<int>("--price", "The expected price"),

            new Argument<string>(
                "time",
                getDefaultValue: () => "now",
                description: "When to order it, or \"now\""
            )
        };

        // Main Method

        public static async Task<int> Main(string[] args)
        {
            rootCommand.Handler = CommandHandler.Create(
                (string restaurant, string menuItem, DeliveryService service, int price, string time) =>
                {
                    Console.WriteLine($"Ordering from {restaurant}");
                }
            );

            // set up common functionality like --help, --version, and dotnet-suggest support
            var commandLine = new CommandLineBuilder(rootCommand)
                .UseDefaults() // automatically configures dotnet-suggest
                .Build();

            // invokes our handler callback and actually runs our application
            var result = await commandLine.InvokeAsync(args);
            return result;
        }
    }



    public enum DeliveryService
    {
        Grab,
        LineMan
    }
}
