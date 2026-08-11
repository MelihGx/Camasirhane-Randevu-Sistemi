# 🧺 Yurt Çamaşırhane Randevu Sistemi

Yurt Çamaşırhane Randevu Sistemi, yurtta kalan öğrencilerin çamaşır ve kurutma makinelerini daha düzenli kullanabilmesi amacıyla geliştirilmiş bir **C# Windows Forms masaüstü uygulamasıdır**.

Uygulama; kullanıcı girişi, öğrenci bilgilerinin görüntülenmesi, çamaşır/kurutma makinesi seçimi, randevu oluşturma ve yönetme, arıza bildirimi, teknik bakım bilgilerinin görüntülenmesi ve geri bildirim gönderme gibi temel çamaşırhane yönetim işlevlerini tek bir arayüzde toplar.

> Proje eğitim ve masaüstü uygulama geliştirme amacıyla hazırlanmıştır.

---

## 📌 Projenin Amacı

Ortak kullanılan yurt çamaşırhanelerinde en sık karşılaşılan problemlerden biri, makinelerin hangi saatlerde kullanılacağının belli olmaması ve öğrenciler arasında kullanım çakışmalarının yaşanabilmesidir.

Bu proje ile kullanıcıların:

* sisteme kişisel hesaplarıyla giriş yapabilmesi,
* çamaşır ve kurutma makinelerini görüntüleyebilmesi,
* seçilen makine için randevuları inceleyebilmesi,
* tarih ve saat belirleyerek randevu oluşturabilmesi,
* kendi randevularını takip edebilmesi,
* randevularını tamamlandı olarak işaretleyebilmesi veya silebilmesi,
* arızalı makineleri bildirebilmesi,
* makine ve bakım bilgilerini görüntüleyebilmesi,
* şikâyet ve geri bildirim gönderebilmesi

amaçlanmıştır.

---

## ✨ Özellikler

### 🔐 Kullanıcı Girişi

* TC kimlik numarası ve şifre ile giriş yapılır.
* Kullanıcı bilgileri SQL Server veritabanından kontrol edilir.
* Hatalı TC veya şifre girişinde kullanıcı bilgilendirilir.
* Başarılı girişten sonra kullanıcının profil bilgileri ana ekrana aktarılır.

### 👤 Kullanıcı Bilgileri

Giriş yapan kullanıcı için aşağıdaki bilgiler `Kullanici_Bilgi` tablosundan alınarak gösterilir:

* Ad
* Soyad
* Blok
* Oda numarası
* Yatak numarası
* TC bilgisi

### 🧺 Çamaşır Makineleri

Sistemde **10 adet çamaşır makinesi** tanımlanmıştır:

`ÇM-1` → `ÇM-10`

Kullanıcı bir makine seçtiğinde o makineye ait randevular tarih ve başlangıç saatine göre listelenir.

### ♨️ Kurutma Makineleri

Sistemde **10 adet kurutma makinesi** tanımlanmıştır:

`KM-1` → `KM-10`

Çamaşır makinelerinde olduğu gibi seçilen kurutma makinesinin mevcut randevuları görüntülenebilir ve yeni randevu oluşturulabilir.

### 📅 Randevu Oluşturma

Kullanıcı:

1. Çamaşır veya kurutma makinesini seçer.
2. Randevu tarihini belirler.
3. Başlangıç saatini seçer.
4. Bitiş saatini seçer.
5. Randevuyu onaylar.

Uygulamada randevu süresiyle ilgili bazı kontroller bulunmaktadır:

* Geçmiş bir tarih için randevu oluşturulamaz.
* Bir randevu **en fazla 2 saat** olabilir.
* Bir randevu **en az 20 dakika** olmalıdır.
* Bitiş saatinin başlangıç saatinden önce olması engellenir.
* Randevu kaydedilmeden önce kullanıcıdan onay alınır.

Çamaşır makinesi randevuları `CM_Randevu`, kurutma makinesi randevuları ise `KM_Randevu` tablosunda tutulur.

### 🔎 Tarihe Göre Randevu Filtreleme

Seçilen makinenin randevuları belirli bir tarihe göre filtrelenebilir.

Listeleme sırasında randevular:

1. işlem tarihine,
2. başlangıç saatine

göre sıralanır.

### 📋 Kullanıcının Tüm Randevuları

Kullanıcının çamaşır ve kurutma randevuları tek ekranda gösterilebilir.

Bu işlem SQL tarafında `CM_Randevu` ve `KM_Randevu` tablolarının `UNION ALL` ile birleştirilmesiyle gerçekleştirilir.

Görüntülenen bilgiler:

* Makine kodu
* Ad
* Soyad
* İşlem tarihi
* Başlangıç saati
* Bitiş saati
* Randevu durumu

### ✅ Randevuyu Tamamlama

Kullanıcı seçtiği randevuyu tamamlandı olarak işaretleyebilir.

İşlem sonucunda ilgili kaydın `Durum` alanı:

```text
Tamamlandı
```

olarak güncellenir.

### 🗑️ Randevu Silme

Kullanıcı kendi randevu listesinden bir kayıt seçerek randevuyu kaldırabilir.

Silme işlemi öncesinde kullanıcıdan onay alınır ve kayıt ilgili çamaşır veya kurutma randevu tablosundan kaldırılır.

### ⚠️ Arıza Bildirimi

Kullanıcı arıza ekranından bir makine seçerek arıza bildirimi oluşturabilir.

Seçilen makinenin veritabanındaki `Durum` alanı:

```text
Arızalı
```

olarak güncellenir.

Hem çamaşır hem de kurutma makineleri için arıza bildirimi desteklenmektedir.

### 🛠️ Teknik Bilgi ve Bakım Takibi

Teknik bilgi ekranında aşağıdaki veriler görüntülenebilir:

* Çamaşır makineleri
* Çamaşır makinelerinin bakım bilgileri
* Kurutma makineleri
* Kurutma makinelerinin bakım bilgileri

Bu ekran aşağıdaki tabloları kullanır:

* `Camasir_Makineleri`
* `Camasir_Makineleri_Bakım`
* `Kurutma_Makineleri`
* `Kurutma_Makineleri_Bakım`

### 💬 Şikâyet ve Geri Bildirim

Kullanıcı konu ve açıklama girerek geri bildirim oluşturabilir.

* Konu veya açıklama boş bırakılamaz.
* Bildirim tarihi otomatik olarak oluşturulur.
* Yeni kayıt `Geri_Bildirim` tablosuna eklenir.
* Daha önce oluşturulan geri bildirimler ekranda listelenebilir.

---

## 🛠️ Kullanılan Teknolojiler

| Teknoloji                           | Kullanım                                 |
| ----------------------------------- | ---------------------------------------- |
| **C#**                              | Uygulama geliştirme dili                 |
| **Windows Forms**                   | Masaüstü kullanıcı arayüzü               |
| **.NET Framework 4.7.2**            | Uygulama çalışma platformu               |
| **Microsoft SQL Server**            | Veritabanı yönetimi                      |
| **ADO.NET / System.Data.SqlClient** | Veritabanı bağlantıları ve SQL işlemleri |
| **Guna.UI2.WinForms 2.0.4.6**       | Modern WinForms arayüz bileşenleri       |
| **Visual Studio 2022**              | Proje geliştirme ortamı                  |

---

## 🗄️ Veritabanı Yapısı

Kod içerisinde aktif olarak kullanılan başlıca tablolar şunlardır:

| Tablo                      | Amaç                                         |
| -------------------------- | -------------------------------------------- |
| `kullanici`                | TC ve şifre ile kullanıcı doğrulama          |
| `Kullanici_Bilgi`          | Öğrenci profil ve yurt bilgileri             |
| `CM_Randevu`               | Çamaşır makinesi randevuları                 |
| `KM_Randevu`               | Kurutma makinesi randevuları                 |
| `Camasir_Makineleri`       | Çamaşır makinelerinin bilgileri ve durumları |
| `Kurutma_Makineleri`       | Kurutma makinelerinin bilgileri ve durumları |
| `Camasir_Makineleri_Bakım` | Çamaşır makinesi bakım kayıtları             |
| `Kurutma_Makineleri_Bakım` | Kurutma makinesi bakım kayıtları             |
| `Geri_Bildirim`            | Kullanıcı şikâyet ve geri bildirimleri       |

Proje içerisinde ayrıca SQL Server veritabanı dosyaları bulunmaktadır:

```text
CamasirhaneRandevu.mdf
CamasirhaneRandevu_log.ldf
```

---

## 📁 Proje Yapısı

```text
CamasirhaneRandevuSistemi_v1/
│
├── CamasirhaneRandevuSistemi_v1.sln
├── packages/
│   └── Guna.UI2.WinForms.2.0.4.6/
│
└── CamasirhaneRandevuSistemi_v1/
    ├── Program.cs
    ├── Form1.cs
    ├── AnaSayfa.cs
    ├── Ariza.cs
    ├── SikayetEkrani.cs
    ├── TeknikBilgi.cs
    ├── RandevuEkranı.cs
    │
    ├── CamasirhaneRandevu.mdf
    ├── CamasirhaneRandevu_log.ldf
    ├── App.config
    ├── packages.config
    ├── Resources/
    └── Properties/
```

### Temel Formlar

| Dosya              | Görevi                                                     |
| ------------------ | ---------------------------------------------------------- |
| `Form1.cs`         | Kullanıcı giriş ekranı                                     |
| `AnaSayfa.cs`      | Ana uygulama, makine seçimi ve randevu yönetimi            |
| `Ariza.cs`         | Makine arıza bildirimi                                     |
| `SikayetEkrani.cs` | Şikâyet ve geri bildirim yönetimi                          |
| `TeknikBilgi.cs`   | Makine ve bakım bilgilerinin görüntülenmesi                |
| `RandevuEkranı.cs` | Makine randevularını görüntülemek için hazırlanmış ek form |

---

## 🚀 Kurulum

### Gereksinimler

Projeyi çalıştırmak için önerilen ortam:

* Windows 10 veya Windows 11
* Visual Studio 2022
* .NET Framework 4.7.2 Developer Pack
* Microsoft SQL Server Express veya SQL Server LocalDB
* NuGet paket desteği

### 1. Projeyi Klonlayın

```bash
git clone <repository-url>
cd CamasirhaneRandevuSistemi_v1
```

### 2. Solution Dosyasını Açın

Visual Studio üzerinden:

```text
CamasirhaneRandevuSistemi_v1.sln
```

dosyasını açın.

### 3. NuGet Paketlerini Geri Yükleyin

Proje `Guna.UI2.WinForms` paketinin `2.0.4.6` sürümünü kullanmaktadır.

Visual Studio paketleri otomatik olarak geri yüklemezse:

```powershell
Update-Package -reinstall
```

veya NuGet Package Manager üzerinden:

```text
Guna.UI2.WinForms 2.0.4.6
```

paketini yükleyin.

### 4. Veritabanını Yapılandırın

Proje klasöründe `CamasirhaneRandevu.mdf` veritabanı dosyası bulunmaktadır.

Projede bazı bağlantı adresleri geliştirme bilgisayarına özel olarak sabit yazılmıştır. Bu nedenle uygulamayı farklı bir bilgisayarda çalıştırmadan önce connection string değerlerinin kendi SQL Server kurulumunuza göre düzenlenmesi gerekir.

Kodda iki farklı bağlantı yaklaşımı bulunmaktadır:

```text
(LocalDB)\MSSQLLocalDB + CamasirhaneRandevu.mdf
```

ve

```text
Melih\SQLEXPRESS + CamasirhaneRandevuSistemi
```

Özellikle aşağıdaki dosyalardaki bağlantılar kontrol edilmelidir:

* `Form1.cs`
* `AnaSayfa.cs`
* `Ariza.cs`
* `SikayetEkrani.cs`
* `TeknikBilgi.cs`
* `RandevuEkranı.cs`

Daha taşınabilir bir yapı için bağlantı adresinin tek bir `App.config` connection string'i üzerinden yönetilmesi önerilir.

### 5. Uygulamayı Çalıştırın

Visual Studio'da projeyi **Startup Project** olarak seçin ve:

```text
F5
```

ile uygulamayı başlatın.

Uygulamanın başlangıç ekranı `Form1` giriş formudur.

---

## 🔄 Uygulama Akışı

```text
Kullanıcı Girişi
      │
      ▼
Kullanıcı Bilgilerinin Getirilmesi
      │
      ▼
Ana Sayfa
      │
      ├── Çamaşır Makinesi Seç
      │       └── Randevu Görüntüle / Oluştur
      │
      ├── Kurutma Makinesi Seç
      │       └── Randevu Görüntüle / Oluştur
      │
      ├── Randevularım
      │       ├── Tamamlandı Olarak İşaretle
      │       └── Randevuyu Sil
      │
      ├── Arıza Bildir
      │
      ├── Teknik / Bakım Bilgileri
      │
      └── Şikâyet / Geri Bildirim
```

---

## 🖼️ Arayüz

Uygulama klasik Windows Forms kontrollerinin yanında **Guna.UI2** bileşenlerini kullanarak daha modern bir masaüstü arayüz sunar.

Projede kullanılan görsel kaynaklar ve bazı ekran görüntüleri:

```text
CamasirhaneRandevuSistemi_v1/Resources/
```

klasöründe bulunmaktadır.

---

## ⚠️ Mevcut Sürüm İçin Teknik Notlar

Bu proje mevcut haliyle eğitim/prototip seviyesinde değerlendirilmelidir. İleride geliştirilmesi önerilen başlıca noktalar:

* Connection string değerlerini kod içerisinden çıkarıp `App.config` içine taşımak.
* Kullanıcı şifrelerini düz metin yerine güvenli bir parola hash algoritmasıyla saklamak.
* SQL sorgularında mümkün olan her yerde tamamen parametreli sorgu kullanmak.
* Aynı makine için zaman aralığı çakışan randevuları veritabanı seviyesinde engellemek.
* Veritabanı işlemlerini ayrı bir data-access/service katmanına taşımak.
* Hata mesajlarında gerçek exception bilgisini log dosyasına kaydetmek.
* `.vs/`, `bin/` ve `obj/` klasörlerini Git deposuna dahil etmemek.

---

## 🔮 Gelecekte Eklenebilecek Özellikler

* Yönetici paneli
* Randevu çakışma kontrolü
* Makine doluluk durumu göstergesi
* Kullanıcı bazlı günlük/haftalık kullanım limiti
* Arızalı makinelere randevu verilmesinin otomatik engellenmesi
* E-posta veya uygulama içi randevu hatırlatmaları
* QR kod ile makine doğrulama
* Makine kullanım istatistikleri
* Bakım zamanı yaklaşan makineler için uyarılar
* Yetkilendirme ve rol sistemi

---

## 📄 Lisans

Bu proje eğitim amaçlı geliştirilmiştir. Bir lisans eklemek isterseniz repository'ye `LICENSE` dosyası ekleyerek MIT, Apache-2.0 veya tercih ettiğiniz başka bir lisansı kullanabilirsiniz.

---

## ⭐ Proje Özeti

Bu proje; **C#, Windows Forms, SQL Server, ADO.NET ve masaüstü arayüz geliştirme** konularını bir araya getiren, gerçek bir yurt kullanım senaryosunu temel alan bir çamaşırhane randevu ve takip uygulamasıdır.
