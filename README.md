# PayCore-Bootcamp-Final-Project
# Proje ayağa kalkması için gereksinimler

### create DATABASE "DatabaseName" sql de komut çalıştırılır.

![image](https://user-images.githubusercontent.com/108563288/191586122-f3947e41-7ff9-4bbe-ad05-74ba99f227f0.png)


### Tablolar otomatik oluşacaktır.

### appsetting.json dosyasında kendi konfigrasyon adreslerimiz yazılır.

![image](https://user-images.githubusercontent.com/108563288/191586214-e1b1bb48-ba6c-4a9d-98a4-00d40ee5de2b.png)

![image](https://user-images.githubusercontent.com/108563288/191586274-a258bce5-0059-4419-ba88-efbf9e9d6dbc.png)


### frontEnd için npm install komutu ile bağımlılıklar yüklenir.

![image](https://user-images.githubusercontent.com/108563288/191586434-3c8bdef1-8008-4239-805c-1132531e648d.png)


### npm start ile React projesi Localhostta kaldırılır.

![image](https://user-images.githubusercontent.com/108563288/191586369-8c225f14-acde-4253-a3cb-aab207871f3f.png)

### üyelik kaydı oluşturarak işlemler yapmaya başlayabilirsiniz.

### Proje 
Untitled
Patika.dev & Paycore .Net Bootcamp Bitirme Projesi

### Üye Ol Detayları

● Kullanıcılar sisteme üye olabilmeli. Kayıt işleminde alınan bilgiler eksiksiz olmali
ve validate edilmeli. Email bilgisi gecerli olmali.

● Kayıt sırasında kullanici sifresi şifrelenmiş şekilde databasede saklanmali.

● Şifreler geri çözülemeyecek şekilde şifrelenip saklanmali.

● Email valid olmalı

● En az 8 ve en fazla 20 karakter uzunluğunda bir password girilmeli

### Üye Girişi Detayları

● Kullanıcılar burden üye girişi yapabilmeli

● Email ve Password alanları zorunlu alanlar olmali. Boş ya da geçersiz gönderilirse
uyari verilmeli.

● Email ve Password alanlarının validasyonu yapılmalı

● Email valid olmalı ve en az 8 ve en fazla 20 karakter uzunluğunda bir password
girilmeli

● İşlem başarısız ise kullanıcıya hata mesajı gösterilmeli

● İşlem başarılı ise API'de JWT token üretilmeli ve tüm authentication gerektiren
requestlerde header'a Bearer token olarak eklenmeli.


### Kategori Detayları

● Tüm kategoriler listelenmeli

● Yeni kategori eklenebilmeli veya mevcut olan güncellenebilmeli.


### Ürün Detayları

● Teklif Ver apisi üründen gelen data içerisindeki isOfferable alanına göre control
edilmeli.

● isOfferable durumunun sağlanmadığı takdirde teklif verilememeli.

● Teklif Ver apisi ile kullanıcı kendisi teklif girebilmeli. Teklif girme alanı number
olmalı ve buraya validasyon eklenmeli

● Kullanıcı teklif yapmadan bir ürünü direk satın alabilir. Kullanıcı ürünü satın alınca,
ilgili ürün datası içerisindeki isSold alanının değeri güncellenmeli.


### Hesabım Detayları

● Kullanıcının yaptığı offer lar listelenmeli.

● Kullanicinin urunleri icin aldigi offer lar listelenmeli.

● Alınan tekliflere Onayla ve Reddet ile cevap verilebilmeli(2 farkli api olarak teklif ler
onaylanmali yada red edilmeli.)

● Verilen teklif onaylandığında satin alma icin uygun duruma getirilmeli. (Teklif
onaylandiktan sonra kullanici satin almali.)

● Ürün detay daki gibi Satın Al tetiklenince statu güncellenmeli. Satın Al'a
tetiklenince Teklif Verdiklerim listesindeki ürünün durumu güncellenmeli


### Ürün Ekleme Detayları

● İlgili validasyonlar eklenmeli:

● Ürün Adı alanı maksimum 100 karakter uzunluğunda olmalı ve zorunlu bir alan
olmalı

● Açıklama alanı maksimum 500 karakter uzunluğunda olmalı ve zorunlu bir alan
olmalı

● Kategori alanı ilgili endpointten listelemeli ve CategoryId olarak olarak kullanilmali.
Urun icin tek kategori bilgisi olmali. Bu alan zorunlu bir alan olmalı

● Renk alanı string zorunlu bir deger olmali.

● Marka alanı string zorunlu bir deger olmali.

● Fiyat alanı number olmalı ve zorunlu bir alan olmalı


### Email Servisi

Proje içerisinde bilgilendirme amacı ile gerekli gordugunuz yerlerde kullanıcılara email
gönderecek bir yapi kurunuz. (Hos geldiniz mesaji, teklif alindi, teklif onaylandi vs...)

● Email gonderme islemlerini Sync olarak gonderecek bir tasarim yapmayiniz.

● Email ler bir kuyruk tablosunda toplanmali ve bir process ordan email gönderimi
yapmali.

● Database,kafka, rabbitmq vs üzerinde kuyruklama işlemi yapabilirsiniz.

● Hangfire gibi servisler kullanarak da yapabilirsiniz.

● Kuyruga gelen her email in en gec 2 sn icerisinde process edilmeli.

● Gönderilen email ler in status durumunu güncelleyiniz.

● Try count ile basarisiz olmasi durumunda tekrar göndermesini saglayiniz.

● 5 kez deneyip basarisiz olan kayitlari Farkli bir statüye cekerek güncelleyiniz
Ek Proje Gereksinimleri:



PayCore ve Patika.dev düzenlediği .Net Core Bootcamp bitirme projesidir.
-Projenin Back-End tarafı .Net Core 6.0 ile yazılmıştır.

-Proje Katmanlı mimari kurgulanarak yazılmıştır.

-7 katmanda tamamlanmıştır.

-API katmanı kontrellerin ve haberleşemin yapıldığı katmandır.

-Base katmanı, en alt katmandır tüm katmanlara referans olması için yazılmıitır.

-Data katmanı, veri tabanı tabloları mapleri ve Repository Interface ve Concrote klasörünü tutar.

-Dto katmanı, dto klasörlerini ve sınıfları tutan katmandır.

-Service katmanı, iş katmanıdır CRUD işlemleri şifreleme işlemleri token üretme işlemleri bu katmanda tanımlanmıştır.

-NUnit katmanı Nunit testlerinin yazıldığı katmandır.

-XUnit katmanı XUnit testlerinin yazıldığı katmandır.


Bağımlılıklar Dependency Injection ile eklenmiştir.

API katmanında ExtensionService yazılarak bağımlılıklar enjekte edilmiş ve ayrı class tanımlanarak StartUp classı temiz tutulmuştur.

Projede kullanılmış keyler,  veri tabanı bağlnatı adresleri, SMTP adresi, RabbitMQ adresi API katmanındaki appsettings.json klasörü içindedir.

kendi adresinizi kullanarak projeyi ayağa kaldırdığınızda veri tabanı ve tabloları otomatik olarak oluşacaktır.






-Veri tabanı olarak PostgreSQL kullanılmıştır.

-ORM aracı olarak NHibernate kullanılmıştır.

-Projede kullanılan kütüphaneler ve Teknolojiler;

-RabbitMQ EMail kuruk sistemi için kullanılmıştır.

-SMTP Mail gönderim aracı olarak kullanılmıştır.

-AutoMapper veri tabanı tablolarını Dto'lar arası dönüşüm için kullanılmıştır.

-FLuent NHibernate, NHibernate, Npgsql veri tabanı konfigrasyonu için kuallanılmıştır.

-Serilog loglamaları yapmak ve kaydetmek için kullanılmıştır.

-Fluent Validation doğrulama işlemleri için kullanılmıştır.

-JwtBearer Jwt oluşturma konfigrasyonları yapmak için kullanılmııştır.

-Projede XUnit test yazılmıştır. 

-Proje testleri için kütüphaneler;

-Moq, controlleri moqlamak için kullanılmıştır.

### Proje düzeni

![image](https://user-images.githubusercontent.com/108563288/191568611-01d2102d-a3d5-4cac-a001-8a90f91cf984.png)

![image](https://user-images.githubusercontent.com/108563288/191568811-2f3c784c-5e0b-4ced-994e-83404d5d6f61.png)

![image](https://user-images.githubusercontent.com/108563288/191568887-e8a1d684-8116-467d-9ee1-fa07c7fd8de4.png)

![image](https://user-images.githubusercontent.com/108563288/191568942-4260af5d-b806-41c4-b4b2-59c41f2abdf5.png)

![image](https://user-images.githubusercontent.com/108563288/191569009-7821f8c0-17b2-473f-93ad-1fe116b87880.png)

![image](https://user-images.githubusercontent.com/108563288/191569064-1988ed27-baf7-4d78-9f00-ef32192e9707.png)

![image](https://user-images.githubusercontent.com/108563288/191569175-403c1531-799c-40cb-a304-e76dca414474.png)

![image](https://user-images.githubusercontent.com/108563288/191569241-2f4a8100-4609-4fe7-bf0f-e08156372c0a.png)


### Swagger Ekran Görüntüsü
![image](https://user-images.githubusercontent.com/108563288/191569669-31bac7e7-3f44-4208-a2f8-523b71e5768c.png)

![image](https://user-images.githubusercontent.com/108563288/191569727-44cf640e-f9c3-4110-8076-d36ef03eceb1.png)


### Account Swagger
![image](https://user-images.githubusercontent.com/108563288/191569823-52430952-7c6c-406c-ab4e-e9e400ace594.png)

![image](https://user-images.githubusercontent.com/108563288/191569908-684126e3-975c-4a2d-a475-19b2189f8453.png)

### Category Swagger
![image](https://user-images.githubusercontent.com/108563288/191570026-2362cbc9-1647-4b46-a0c9-f041c0ea96b3.png)

![image](https://user-images.githubusercontent.com/108563288/191570090-1a2acb18-8132-4f51-a272-7ebce6d01698.png)

![image](https://user-images.githubusercontent.com/108563288/191570123-59c81255-d034-414c-bbc5-c06f5250a60c.png)


### Login Swagger
![image](https://user-images.githubusercontent.com/108563288/191570186-e6295364-7df7-4ccf-aadc-510c8989cbfe.png)


### Offer Swagger
![image](https://user-images.githubusercontent.com/108563288/191570248-9a320cd4-0c80-489d-ac42-3962e5740d3c.png)

### Order Swagger
![image](https://user-images.githubusercontent.com/108563288/191570320-6eaf4425-80fb-4b72-b943-7cde9322b33e.png)


### Product Swagger
![image](https://user-images.githubusercontent.com/108563288/191570393-ad7a3907-0f63-403b-8078-c9e6930367e9.png)

![image](https://user-images.githubusercontent.com/108563288/191570430-cbb56c9f-376d-4290-a704-5981c7e9b2a4.png)

### Register Swagger 
![image](https://user-images.githubusercontent.com/108563288/191570475-68e3bebd-8d5c-4a15-bb19-3d6a006e27bd.png)



### Projenin Front-End tarafı React ile yazılmıştır.

### Bağımlılıkları npm install komutunu çalıştırarak yükleyebilirsiniz.

-npm start komutunu çalıştırarak Localhostta projeyi ayağa kaldırabilirsiniz.

-API ile haberleşme için Axios kütüphanesi kullanılmıştır.

-Tasarım olarak Bootstrap kütüphanesi kullanılmıştır.

-Yönlendirmeler, linklemeler için React-Router kullanılmıştır.

-İconlar için react-icons kütüphanesi kullanılmıştır.

-Validasyonlar için React-Validations kullanılmıştır.
### Proje Düzeni
![image](https://user-images.githubusercontent.com/108563288/191570703-02586f02-46d5-4877-b78a-b645a50b4a18.png)

![image](https://user-images.githubusercontent.com/108563288/191570792-691b2094-0aed-4206-885b-c44fcbea03c2.png)


![image](https://user-images.githubusercontent.com/108563288/191570883-ab32e5af-d4d9-453a-8ef7-c439145c5e5f.png)


### FrontEnd Ekranı

![image](https://user-images.githubusercontent.com/108563288/191571166-b1df8636-42c1-4618-8387-7a45ba5a91e8.png)

![image](https://user-images.githubusercontent.com/108563288/191571300-4438031f-aefa-41cb-9ee9-fb4fb60bf9fa.png)

![image](https://user-images.githubusercontent.com/108563288/191571362-004a9f68-b4f4-4d2e-b086-f124dbb7e0f6.png)

![image](https://user-images.githubusercontent.com/108563288/191571477-0110ec35-ec99-41ad-9737-a56f91e03719.png)

![image](https://user-images.githubusercontent.com/108563288/191571496-a47f7f42-6cfa-437c-ae0c-60f7bf6f279c.png)


![image](https://user-images.githubusercontent.com/108563288/191571535-f33ebebf-6269-4a79-bf6a-10f61668931a.png)


![image](https://user-images.githubusercontent.com/108563288/191571573-095bba4d-881a-4623-8d65-55d8c08d2fc0.png)


![image](https://user-images.githubusercontent.com/108563288/191571605-7123ff0b-1aa2-4c2d-86fe-6df4046f2630.png)


![image](https://user-images.githubusercontent.com/108563288/191571688-474c7878-160c-4c89-880d-337f7ccf1027.png)





