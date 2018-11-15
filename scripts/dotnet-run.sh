#!/bin/bash
export ASPNETCORE_ENVIRONMENT=local
cd src/DShop.Services.Sales
dotnet run --no-restore
