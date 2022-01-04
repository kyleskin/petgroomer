﻿using System;
using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace PetGroomer.Extensions
{
	public static class ServiceExtensions
	{
		public static void ConfigureCors(this IServiceCollection services) =>
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
				builder.AllowAnyOrigin()
					   .AllowAnyMethod()
					   .AllowAnyHeader());
			});

		public static void ConfigureIISIntegration(this IServiceCollection services) =>
			services.Configure<IISOptions>(options =>
			{
			});

		public static void ConfigureLoggerService(this IServiceCollection services) =>
			services.AddSingleton<ILoggerManager, LoggerManager>();

		public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
			services.AddDbContext<RepositoryContext>(opts =>
				opts.UseMySql(configuration.GetConnectionString("sqlConnection"), new MySqlServerVersion(new Version(8, 0, 27))));
	}
}

