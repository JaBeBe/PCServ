# Aplikacja do obsługi serwisu - PCServ
### Opis aplikacji
Głównym celem aplikacji jest obsługa serwisu, przyjmowanie zgłoszeń napraw. Klient sam może dodać swoje zgłoszenie a firma obsłuży je na zasadzie door-to-door. Klient poprzez stronę ma dostęp na status swojej naprawy.

### Wymagania
* .NET Core SDK ^3.0
* node.js ^12.13.1
* Angular CLI ^8.3.19

### Uruchomienie
W terminalu otwieramy katalog z projektem, a następnie:
* przywracamy pakiety nuget `dotnet restore`
* wywołujemy migrację bazy danych `dotnet ef database update`
* uruchamiamy projekt `dotnet run`
Projekt zacznie budowanie, po otrzymaniu informacji `｢wdm｣: Compiled successfully.` można wejść na adres `https://localhost:5001`
W przypadku gdy adres nie działa szukamy w oknie konsoli linii opisanej `Now listening on: https://...` i wchodzimy pod wyświetlony tam adres.

## Zespół
* Jacek Bebak
* Damian Kręcisz
* Krzysztof Pytel
