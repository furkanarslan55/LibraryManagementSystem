# 1. Aþama: ÝNÞAAT (Build)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# --- DEÐÝÞÝKLÝK BURADA BAÞLIYOR ---
# Sadece .sln dosyasýna güvenmek yerine, doðrudan proje dosyalarýný kopyalýyoruz.

COPY LibraryProject.API/*.csproj ./LibraryProject.API/
COPY LibraryProject.Business/*.csproj ./LibraryProject.Business/
COPY LibraryProject.DataAccess/*.csproj ./LibraryProject.DataAccess/
COPY LibraryProject.Entities/*.csproj ./LibraryProject.Entities/

# HATA ÇIKAN YERÝ DÜZELTTÝK:
# "dotnet restore" komutuna doðrudan hangi projeyi ayaða kaldýracaðýný söylüyoruz.
# Böylece "Hangi dosya? Ben bulamadým" diye sormaz.
RUN dotnet restore LibraryProject.API/LibraryProject.API.csproj

# ----------------------------------

# Þimdi kalan bütün kodlarý kopyala
COPY . .

# API projesini derle
WORKDIR /app/LibraryProject.API
RUN dotnet publish -c Release -o /app/out

# 2. Aþama: ÇALIÞTIRMA (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "LibraryProject.API.dll"]