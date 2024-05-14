#!/bin/bash

echo "Creating .NET Minimal API"
dotnet new web -o MyMinimalApi

echo "Creating .NET XUnit Test Project"
dotnet new xunit -o MyMinimalApi.Tests

echo "Adding Minimal API to Test Project"
dotnet add MyMinimalApi.Tests reference MyMinimalApi

echo "Creating solution file"
dotnet new sln -n MyMinimalApi

echo "Adding projects to solution"
dotnet sln MyMinimalApi.sln add MyMinimalApi MyMinimalApi.Tests

echo "Adding NuGet Packages"
dotnet add MyMinimalApi.Tests package Microsoft.AspNetCore.Mvc.Testing
dotnet add MyMinimalApi package MiniValidation

