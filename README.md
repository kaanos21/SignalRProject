SignalR, ASP.NET Core 6.0 kullanılarak geliştirilmiş bir yemek siparişi uygulamasıdır. Bu proje, kullanıcıların yemek siparişi vermesini sağlar ve gerçek zamanlı veri güncellemeleri ile etkileşimli bir kullanıcı deneyimi sunar. Projede N-Katmanlı Mimari, API Tüketimi, QR Kod Oluşturma, Kimlik Doğrulama ve E-posta Gönderimi gibi çeşitli özellikler bulunmaktadır.

Projeye Genel Bakış
👤 Arayüz: Kullanıcı dostu bir arayüz sunar. Kullanıcılar yemek siparişi verebilir ve sipariş durumlarını gerçek zamanlı olarak takip edebilirler. Dinamik ve yeniden kullanılabilir arayüz bileşenleri ile geliştirilmiştir.

Kullanılan Teknolojiler ve Uygulamalar
🤖 .NET Core 6.0: Web uygulamasının temel çerçevesi olarak kullanıldı. ✅

🔄 SignalR: Verilerin gerçek zamanlı olarak güncellenmesini sağlayarak kullanıcı deneyimini iyileştirir. ✅

🖼️ N-Katmanlı Mimari: Uygulama, iş mantığını, veri erişimini ve sunum katmanlarını ayırarak yapılandırılmıştır. ✅

📡 API Consume: N-Katmanlı Mimari'den gelen veriler front-end'de kullanılarak etkileşimli özellikler sunulmuştur. ✅

📊 QR Kod Oluşturma: Siparişlerin takibi ve ödemeler için QR kodları oluşturma teknolojisi kullanıldı. ✅

🔐 ASP.NET Core Identity: Kullanıcı kimlik doğrulama ve yetkilendirme işlemleri için kullanıldı. ✅

📧 MailKit: E-posta gönderimi için kullanıldı. Sipariş onayları ve diğer bildirimler için kullanıcılar e-posta alırlar. ✅

SOLID Prensipleri: Projede SOLID prensiplerine uygun olarak geliştirme yapılmıştır

