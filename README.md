\# 📚 Library Management System (Backend)



Bu proje, modern yazılım geliştirme prensipleri ve \*\*N-Katmanlı Mimari (N-Tier Architecture)\*\* kullanılarak geliştirilmiş, ölçeklenebilir bir \*\*Kütüphane Yönetim Sistemi\*\* Backend projesidir. Proje, kurumsal kodlama standartlarına uygun olarak tasarlanmış ve \*\*Dockerize\*\* edilmiştir.



!\[.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat\&logo=dotnet\&logoColor=white)

!\[Docker](https://img.shields.io/badge/Docker-Enabled-2496ED?style=flat\&logo=docker\&logoColor=white)

!\[MSSQL](https://img.shields.io/badge/Database-MSSQL-CC2927?style=flat\&logo=microsoft-sql-server\&logoColor=white)

!\[Status](https://img.shields.io/badge/Status-Completed-success)



\## 🎯 Projenin Amacı

Kullanıcıların kitapları inceleyebileceği, ödünç alabileceği, favorilerine ekleyebileceği; yöneticilerin ise stok, kategori ve yazar yönetimi yapabileceği kapsamlı ve güvenli bir RESTful API sunmak.



\## 🏗️ Mimari ve Teknolojiler



Proje, \*\*Solid Prensipleri\*\* gözetilerek ve bağımlılıkları minimize etmek için \*\*Dependency Injection\*\* deseni kullanılarak geliştirilmiştir.



\* \*\*Framework:\*\* .NET 8.0 Core Web API

\* \*\*Mimari:\*\* N-Tier Architecture (Entity, DataAccess, Business, API)

\* \*\*Veritabanı:\*\* Microsoft SQL Server 2022

\* \*\*ORM:\*\* Entity Framework Core (Code First Approach)

\* \*\*Containerization:\*\* Docker \& Docker Compose

\* \*\*Auth:\*\* JWT (JSON Web Token) \& Role Based Authorization (Admin/User)

\* \*\*Loglama:\*\* Serilog (File \& Console Logging)

\* \*\*Validasyon:\*\* FluentValidation (Automatic Filter)

\* \*\*Mapping:\*\* AutoMapper



\## 🌟 Öne Çıkan Özellikler



\### 🔐 Güvenlik ve Yetkilendirme

\* \*\*JWT Authentication:\*\* Güvenli Token tabanlı giriş sistemi.

\* \*\*Role Based Access Control (RBAC):\*\*

&nbsp;   \* \*\*Admin:\*\* Kitap/Yazar Ekleme, Silme, Güncelleme yetkilerine sahiptir.

&nbsp;   \* \*\*User:\*\* Kitapları listeleme, ödünç alma ve favorilere ekleme yetkilerine sahiptir.



\### 📦 Gelişmiş Veri Yönetimi

\* \*\*Transaction Management:\*\* Ödünç alma (Loan) işlemlerinde veri tutarlılığını sağlamak için (ACID) transaction yapısı kurulmuştur.

\* \*\*Global Query Filter:\*\* `IsDeleted` (Soft Delete) mantığı ile silinen veriler otomatik filtrelenir.

\* \*\*Generic Repository Pattern:\*\* Kod tekrarını önlemek için merkezi veri erişim katmanı.



\### 📸 Dosya Yönetimi

\* \*\*Image Upload:\*\* Kitap kapak resimleri `IFormFile` ile sunucuya yüklenir ve GUID ile benzersiz isimlendirilerek saklanır.



\### 🐳 DevOps ve Dağıtım

\* \*\*Docker Integration:\*\* Proje, SQL Server ile birlikte tek komutla ayağa kalkacak şekilde Dockerize edilmiştir.

\* \*\*Auto-Migration:\*\* Konteyner başladığında veritabanı tabloları otomatik olarak oluşturulur.



---



\## 🚀 Kurulum ve Çalıştırma



Projeyi çalıştırmak için bilgisayarınızda \*\*Docker Desktop\*\* yüklü olması yeterlidir. SQL Server kurmanıza gerek yoktur.



\### Adım 1: Projeyi İndirin

```bash

git clone \[https://github.com/KULLANICI\_ADIN/LibraryManagementSystem.git](https://github.com/KULLANICI\_ADIN/LibraryManagementSystem.git)

cd LibraryManagementSystem

