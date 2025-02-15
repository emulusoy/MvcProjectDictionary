# Sözlük Sitesi Projesi 📖

Bu proje, **ASP.NET MVC** kullanılarak geliştirilmiş bir sözlük uygulamasıdır. Proje, katmanlı mimari (N-Tier Architecture) prensiplerine uygun olarak tasarlanmıştır ve **Business Layer**, **Data Access Layer**, **Entity Layer** ve **Presentation Layer** gibi katmanlardan oluşmaktadır.

---

## 📂 Proje Yapısı

Proje, aşağıdaki katmanlardan oluşmaktadır:

### 1. **Business Layer**
- **Abstract**: Servis arayüzleri (interfaces) bulunur.
  - `IAboutService.cs`
  - `ICategoryService.cs`
  - `IContentService.cs`
  - `IMessageService.cs`
  - `IWriterService.cs`
- **Concrete**: Servis sınıfları ve iş mantığı (business logic) bulunur.
  - `AboutManager.cs`
  - `CategoryManager.cs`
  - `ContentManager.cs`
  - `MessageManager.cs`
  - `WriterManager.cs`
- **ValidationRules_FluentValidation**: FluentValidation kütüphanesi ile doğrulama kuralları tanımlanır.

### 2. **Data Access Layer**
- **Abstract**: Veritabanı erişim arayüzleri (interfaces) bulunur.
  - `IAboutDal.cs`
  - `ICategoryDal.cs`
  - `IContentDal.cs`
  - `IMessageDal.cs`
  - `IWriterDal.cs`
- **Concrete**: Entity Framework kullanılarak veritabanı erişim sınıfları bulunur.
  - `EfAboutDal.cs`
  - `EfCategoryDal.cs`
  - `EfContentDal.cs`
  - `EfMessageDal.cs`
  - `EfWriterDal.cs`
- **Migrations**: Veritabanı migrasyon dosyaları bulunur.

### 3. **Entity Layer**
- **Concrete**: Veritabanı tablolarına karşılık gelen entity sınıfları bulunur.
  - `About.cs`
  - `Category.cs`
  - `Content.cs`
  - `Message.cs`
  - `Writer.cs`

### 4. **Presentation Layer (MVC)**
- **Controllers**: MVC controller sınıfları bulunur.
  - `AboutController.cs`
  - `CategoryController.cs`
  - `ContentController.cs`
  - `MessageController.cs`
  - `WriterController.cs`
- **Views**: Controller'lara karşılık gelen view dosyaları bulunur.
  - `About`
  - `Category`
  - `Content`
  - `Message`
  - `Writer`
- **Models**: View modelleri ve diğer yardımcı modeller bulunur.
- **Scripts**: JavaScript dosyaları bulunur.
- **Styles**: CSS dosyaları bulunur.

---

## 🛠️ Kurulum

Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin:

1. **Gereksinimler**:
   - .NET Framework 4.7.2 veya üzeri
   - Visual Studio 2019 veya üzeri
   - SQL Server (LocalDB veya başka bir SQL Server)

2. **Veritabanı Kurulumu**:
   - `DataAccessLayer/Migrations` klasöründeki migrasyon dosyalarını kullanarak veritabanını oluşturun.
   - `Update-Database` komutunu Package Manager Console'da çalıştırarak veritabanını güncelleyin.

3. **Projeyi Çalıştırma**:
   - Visual Studio'da projeyi açın.
   - `Ctrl + F5` tuşlarına basarak projeyi çalıştırın.

---

## ✨ Özellikler

- **Kategori Yönetimi**: Sözlük kategorileri ekleme, düzenleme ve silme.
- **İçerik Yönetimi**: Sözlük içeriklerini ekleme, düzenleme ve silme.
- **Yazar Yönetimi**: Yazar bilgilerini yönetme.
- **Mesaj Yönetimi**: Kullanıcılar arası mesajlaşma.
- **Hakkında Sayfası**: Site hakkında bilgilerin yönetimi.

---

## 📝 Katkıda Bulunma

Projeye katkıda bulunmak isterseniz, lütfen aşağıdaki adımları izleyin:
1. Bu depoyu forklayın.
2. Yeni bir branch oluşturun (`git checkout -b feature/AmazingFeature`).
3. Değişikliklerinizi commit edin (`git commit -m 'Add some AmazingFeature'`).
4. Branch'inize push yapın (`git push origin feature/AmazingFeature`).
5. Bir Pull Request açın.

---

## 📜 Lisans

Bu proje MIT lisansı ile lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasını inceleyin.

---
