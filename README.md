# Sözlük Sitesi Projesi 📖

Bu proje, **ASP.NET MVC** kullanılarak geliştirilmiş bir sözlük uygulamasıdır. Proje, katmanlı mimari (N-Tier Architecture) prensiplerine uygun olarak tasarlanmıştır ve **Business Layer**, **Data Access Layer**, **Entity Layer** ve **Presentation Layer** gibi katmanlardan oluşmaktadır.

---

## 📂 Proje Yapısı

Proje, aşağıdaki katmanlardan oluşmaktadır:

### 1. **Business Layer**
- **Abstract**: Servis arayüzleri (interfaces) bulunur.
  - `IAboutService.cs`- `ICategoryService.cs`- `IContentService.cs`- `IMessageService.cs`- `IWriterService.cs`
- **Concrete**: Servis sınıfları ve iş mantığı (business logic) bulunur.
  - `AboutManager.cs`- `CategoryManager.cs`- `ContentManager.cs`- `MessageManager.cs`- `WriterManager.cs`
- **ValidationRules_FluentValidation**: FluentValidation kütüphanesi ile doğrulama kuralları tanımlanır.

### 2. **Data Access Layer**
- **Abstract**: Veritabanı erişim arayüzleri (interfaces) bulunur.
  - `IAboutDal.cs`- `ICategoryDal.cs`- `IContentDal.cs`- `IMessageDal.cs`- `IWriterDal.cs`
- **Concrete**: Entity Framework kullanılarak veritabanı erişim sınıfları bulunur.
  - `EfAboutDal.cs`  - `EfCategoryDal.cs` - `EfContentDal.cs` - `EfMessageDal.cs` - `EfWriterDal.cs`
- **Migrations**: Veritabanı migrasyon dosyaları bulunur.
- 
### 3. **Entity Layer**
- **Concrete**: Veritabanı tablolarına karşılık gelen entity sınıfları bulunur.
  - `About.cs`-`Category.cs` - `Content.cs` - `Message.cs` - `Writer.cs`

### 4. **Presentation Layer (MVC)**
- **Controllers**: MVC controller sınıfları bulunur.
  - `AboutController.cs` - `CategoryController.cs` - `ContentController.cs` - `MessageController.cs`- `WriterController.cs`
- **Views**: Controller'lara karşılık gelen view dosyaları bulunur.
  - `About` - `Category`- `Content` - `Message`- `Writer`


---
## ✨ Yazar Paneli Giriş Sayfası
![Ekran görüntüsü 2025-02-15 133305](https://github.com/user-attachments/assets/57c32765-21c6-472b-88b9-a707e3c20955)

## ✨ Writer Panel (Yazar Paneli)

Writer Panel, yazarların sözlük içeriğini yönetebileceği bir kontrol panelidir. Bu panelde yazarlar, başlıklarını, mesajlarını ve yazılarını yönetebilir. Ayrıca siteye erişim ve çıkış yapma gibi işlemler de bu panel üzerinden gerçekleştirilir.

### **Writer Panel Özellikleri**

#### **Sol Taraftaki Menü**
- **Başlıklarım**: Yazarın oluşturduğu başlıkları listeler.
- **Tüm Başlıklar**: Sitedeki tüm başlıkları görüntüleme imkanı sunar.
- **Mesajlar**: Yazarın aldığı mesajları yönetebileceği bölüm.
- **Yazılarım**: Yazarın eklediği yazıları listeler ve düzenleme imkanı sunar.
- **Siteye Git**: Ana siteye hızlı erişim sağlar.
- **Çıkış Yap**: Yazar hesabından çıkış yapmayı sağlar.

 Writer Panel Ekran Görüntüsü!
 ![Ekran görüntüsü 2025-02-15 134021](https://github.com/user-attachments/assets/d9e4f1cb-acb4-4dd9-84b0-e9c9433dbc03)

 Bu WrıterLogın sayfası dışında Admin Login sayfası ve Admin Paneli de var!
 
## ✨ Admin Login Sayfası ve Admin Paneli

Admin paneli, sözlük sitesinin yönetimi için tasarlanmıştır. Adminler, iki farklı role sahiptir:

**Admin Rolleri**
1. **Rol A (Sınırlı Erişim)**:
   - Belirli sayfalara ve işlemlere erişim izni vardır.
   - Örneğin, yazıları görüntüleyebilir ancak silme veya düzenleme yetkisi yoktur.

2. **Rol B (Sınırsız Erişim)**:
   - Tüm sayfalara ve işlemlere tam erişim izni vardır.
   - Yazıları ekleme, düzenleme, silme ve kullanıcıları yönetme yetkisine sahiptir.
   

![Ekran görüntüsü 2025-02-15 134732](https://github.com/user-attachments/assets/2c2f1134-ea03-44a3-bf60-0c5167dcf4fa)



