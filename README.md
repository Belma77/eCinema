# eCinema

eCinema je aplikacija za kino i sastoji se od desktop dijela namijenjenog za administraciju, i mobilnog dijela namijenjenog krajnjem korisniku.
Desktop dio je rađen u windows formama, a služi za upravljanje filmovima, projekcijama, rezervacijama, korisnicima kao i za izvještavanje.
Mobilni dio je namijenjen krajnjim korisnicima s opcijama pregleda svih trenutno prikazivanih projekcija, pregled rasporeda prikazivanja tih projekcija, 
rezervaciju karata, kao i plaćanje karata upotrebom online payment servisa. Korisnik također ima opciju učlanjivanja u loyalty club kao i pregled i editovanje svog korisničkog profila. 

Kredencijali za pristup desktop aplikaciji:  
username: Admin  
password: pass123

Kredencijali za pristup mobilnoj aplikaciji:  
username:Customer  
password:pass123  

Testni podaci za Stripe payment:  
Broj kartice: 4242 4242 4242 4242

Pokretanje aplikacija: 

1. Nakon kloniranja repozitorija otvoriti komandnu liniju, navigirati do foldera gdje je kloniran repozitorij te pokrenuti dockerizovani api i bazu prilikom cega se izvrsava i skripta za seeding podataka:  

docker-compose up --build  

 Mobile aplikacija:  
 1. flutter pub get (za dobavljanje dependencies)  
 2. flutter run  (pokretanje aplikacije)  
 Za promjenu vrijednosti Stripe keys, kucati komandu: flutter run --dart-define stripePublishableKey=primjerPublishableKljuca --dart-define 
 stripeSecretKey=primjerSecretKeya  
 Za promjenu vrijednosti baseUrl-a, kucati komandu flutter run --dart-define baseUrl=VasUrl

 Desktop aplikacija:  
 Otvoriti solution unutar Visual studija, postaviti Startup projekat na eCinema.WinUI te pokrenuti. 

