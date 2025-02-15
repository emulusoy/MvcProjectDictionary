Business Layer
Abstract: Servis arayüzleri (interfaces) bulunur.

IAboutService.cs

ICategoryService.cs

IContentService.cs

IMessageService.cs

IWriterService.cs

Concrete: Servis sınıfları ve iş mantığı (business logic) bulunur.

AboutManager.cs

CategoryManager.cs

ContentManager.cs

MessageManager.cs

WriterManager.cs

ValidationRules_FluentValidation: FluentValidation kütüphanesi ile doğrulama kuralları tanımlanır.

2. Data Access Layer
Abstract: Veritabanı erişim arayüzleri (interfaces) bulunur.

IAboutDal.cs

ICategoryDal.cs

IContentDal.cs

IMessageDal.cs

IWriterDal.cs

Concrete: Entity Framework kullanılarak veritabanı erişim sınıfları bulunur.

EfAboutDal.cs

EfCategoryDal.cs

EfContentDal.cs

EfMessageDal.cs

EfWriterDal.cs

Migrations: Veritabanı migrasyon dosyaları bulunur.

3. Entity Layer
Concrete: Veritabanı tablolarına karşılık gelen entity sınıfları bulunur.

About.cs

Category.cs

Content.cs

Message.cs

Writer.cs

4. Presentation Layer (MVC)
Controllers: MVC controller sınıfları bulunur.

AboutController.cs

CategoryController.cs

ContentController.cs

MessageController.cs

WriterController.cs

Views: Controller'lara karşılık gelen view dosyaları bulunur.

About

Category

Content

Message

Writer
