# Etapa 1: Definir a imagem base (SDK para compilação)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Definir o diretório de trabalho
WORKDIR /src

# Copiar os arquivos do projeto
COPY ["API99/API99.csproj", "API99/"]

# Restaurar dependências
RUN dotnet restore "API99/API99.csproj"

# Copiar o restante do código
COPY . .

# Publicar a aplicação
RUN dotnet publish "API99/API99.csproj" -c Release -o /app/publish

# Etapa 2: Imagem para execução (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Definir o diretório de trabalho
WORKDIR /app

# Copiar a aplicação publicada
COPY --from=build /app/publish .

# Expor a porta que o app vai rodar
EXPOSE 80

# Comando para rodar a aplicação
ENTRYPOINT ["dotnet", "API99.dll"]
