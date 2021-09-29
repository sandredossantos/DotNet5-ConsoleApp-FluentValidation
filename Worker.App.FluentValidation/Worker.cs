using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Worker.App.FluentValidation.Entities;
using Worker.App.FluentValidation.Validation;

namespace Worker.App.FluentValidation
{
    public sealed class Worker
    {
        private readonly IValidator<User> _validator;
        public Worker(IValidator<User> validator)
        {
            _validator = validator;
        }
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Worker>().Run();
        }

        private void Run()
        {
            var user = new User(string.Empty, 0, 0, 0, "test@test.com", string.Empty);

            var result = _validator.Validate(user);

            foreach (var failure in result.Errors)
            {
                Console.WriteLine(
                    $"Property: {failure.PropertyName} " +
                    $"Severity: {failure.Severity}" +
                    $"Error Message: {failure.ErrorMessage}");
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<Worker>();
                    services.AddTransient<IValidator<User>, UserValidator>();
                });
        }
    }
}