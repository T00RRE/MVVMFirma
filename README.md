# MVVMFirma - System Zarządzania Hurtownią Budowlaną

## Opis Projektu
MVVMFirma to kompleksowy system ERP (Enterprise Resource Planning) zaprojektowany dla hurtowni budowlanej. Zbudowany w architekturze MVVM, system zapewnia efektywne zarządzanie magazynem, obsługę dokumentacji, zarządzanie relacjami z kontrahentami oraz szczegółową analitykę biznesową.

## Funkcjonalności
# MVVMFirma - System Zarządzania Firmą

## Opis Projektu
MVVMFirma to kompleksowa aplikacja desktopowa stworzona w architekturze MVVM (Model-View-ViewModel), służąca do zarządzania procesami biznesowymi w firmie. System umożliwia pełną obsługę dokumentów, zarządzanie magazynem, pracownikami oraz generowanie raportów analitycznych.

## Funkcjonalności

### Zarządzanie Dokumentami
- Faktury (NowaFakturaView)
- Dostawy (WszystkieDostawyView)
- Zamówienia hurtowe (ZamowieniaHurtoweView)
- Reklamacje (WszystkieReklamacjeView)
- Promocje (WszystkiePromocjeView)

### Zarządzanie Kontrahentami i Pracownikami
- Kontrahenci (NowyKontrahentView, WszyscyKontrahenciView)
- Pracownicy (NowyPracownikView, WszyscyPracownicyView)
- Adresy (NowyAdresView, WszystkieAdresyView)

### Zarządzanie Magazynem
- Stany magazynowe (NowyStanMagazynowyView, WszystkieStanyMagazynoweView)
- Magazyny (NowyMagazynView, WszystkieMagazynyView)
- Towary (NowyTowarView, WszystkieTowaryView)

### Raporty Analityczne
- Raport sprzedaży (RaportSprzedazyView)
- Raport stanu magazynu (RaportStanuMagazynuView)
- Raport zamówień klienta (RaportZamowienKlientaView)

### Funkcje Pomocnicze
- Zarządzanie statusami (NowyStatusView, WszystkieStatusyView)
- Zarządzanie rodzajami (NowyRodzajView, WszystkieRodzajeView)
- Obsługa sposobów płatności (NowySposobPlatnosciView, WszystkieSposobyPlatnosciView)

## Struktura Projektu

### Zarządzanie Magazynem
- Ewidencja towarów budowlanych
- Śledzenie stanów magazynowych w czasie rzeczywistym
- Automatyczne powiadomienia o niskim stanie magazynowym
- Zarządzanie lokalizacją towarów w magazynie
- Obsługa wielu kategorii produktów budowlanych

### System Fakturowania
- Wystawianie faktur VAT
- Faktury korygujące
- Różne formy płatności
- Automatyczne numerowanie dokumentów
- Historia transakcji
- Eksport faktur do PDF

### Zarządzanie Kontrahentami
- Baza dostawców i odbiorców
- Historia współpracy
- Limity kredytowe
- Terminy płatności
- Rabaty i ceny indywidualne

### Raporty i Analityka
- Raport Utargu Dziennego/Miesięcznego
- Analiza Stanów Magazynowych
- Raport Rotacji Towarów
- Analiza Sprzedaży wg Kategorii
- Zestawienia Finansowe
- Raporty Zadłużenia Kontrahentów

## Technologie
- .NET Framework 4.8
- WPF (Windows Presentation Foundation)
- Entity Framework 6.2.0
- MVVM (Model-View-ViewModel)
- Microsoft SQL Server
- Material Design

