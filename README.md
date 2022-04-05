# Inicijalne upute za prijavu projekta iz Programskog inženjerstva

Poštovane kolegice i kolege, 

čestitamo vam jer ste uspješno prijavili svoj projektni tim na kolegiju Programsko inženjerstvo, te je za vas automatski kreiran repozitorij koji ćete koristiti za verzioniranje vašega koda, ali i za pisanje dokumentacije.

Ovaj dokument (README.md) predstavlja **osobnu iskaznicu vašeg projekta**. Vaš prvi zadatak, ukoliko niste odabrali da želite raditi na projektu sa nastavnicima ili u sklopu WBL-a je **prijaviti vlastiti projektni prijedlog** na način da ćete prijavu vašeg projekta, sukladno uputama danim u ovom tekstu, napisati upravo u ovaj dokument, umjesto ovoga teksta.

Za upute o sintaksi koju možete koristiti u ovom dokumentu i kod pisanje vaše projektne dokumentacije pogledajte [ovaj link](https://guides.github.com/features/mastering-markdown/).
Sav programski kod potrebno je verzionirati u glavnoj **master** grani i **obvezno** smjestiti u mapu Software. Sve artefakte (npr. slike) koje ćete koristiti u vašoj dokumentaciju obvezno verzionirati u posebnoj grani koja je već kreirana i koja se naziva **master-docs** i smjestiti u mapu Documentation.

Nakon vaše prijave bit će vam dodijeljen mentor s kojim ćete tijekom semestra raditi na ovom projektu. A sada, vrijeme je da prijavite vaš projekt. Za prijavu vašeg projektnog prijedloga molimo vas koristite **predložak** koji je naveden u nastavku, a započnite tako da kliknete na *olovku* u desnom gornjem kutu ovoga dokumenta :) 

# FitZona


## Projektni tim

Ime i prezime | E-mail adresa (FOI) | JMBAG | Github korisničko ime
------------  | ------------------- | ----- | ---------------------
Tomislav Smetisko | tsmetisko@foi.hr | 0016143232 | tsmetisko
David Viljevac | dviljevac@foi.hr | 0016143211 | Spockz9877
Petar Šemiga | psemiga@foi.hr | 0016141857 | petarsemiga
Leon Špiranec | lspiranec@foi.hr | 0016144710 | leonspiranec19

## Opis domene
FitZona je aplikacija koja nam omogućava najam i rezervaciju sportskih prostora u nekom sportskom centru. Rad aplikacije započinje registracijom u sustav. Nakon uspješne registracije, korisnik prijavom pristupa aplikaciji. Početni zaslon aplikacije nam pruža uvid u sve sportske prostore koje aplikacija pokriva. Odabirom pojedinog prostora, korisnik može pregledati dostupnost i raspored odvijanja aktivnosti u tom prostoru. Ako korisnik želi rezervirati ili unajmiti prostor, potrebno je ispuniti podatke za rezervaciju. Također korisnik se može priključiti aktivnostima koje su na raspolaganju u određenom prostoru. Korisniku se nudi pregled te pisanje recenzija za određeni prostor te u svakom trenutku može promijeniti korisničke podatke (korisničko ime, lozinka). Aplikacija bi podržavala dvije uloge tj. administracija i zaposlenici.

## Specifikacija projekta
Umjesto ovih uputa opišite zahtjeve za funkcionalnošću programskog proizvoda. Pobrojite osnovne funkcionalnosti i za svaku naznačite ime odgovornog člana tima. Opišite buduću arhitekturu programskog proizvoda. Obratite pozornost da bi arhitektura trebala biti višeslojna s odvojenom (dislociranom) bazom podatka. Također uzmite u obzir da bi svaki član tima treba biti odgovorana za otprilike 3 funkcionalnosti, te da bi opterećenje članova tima trebalo biti ujednačeno. Priložite odgovarajuće dijagrame i skice gdje je to prikladno. Funkcionalnosti sustava bobrojite u tablici ispod koristeći predložak koji slijedi:

Oznaka | Naziv | Kratki opis | Odgovorni član tima
------ | ----- | ----------- | -------------------
F01 | Registracija | Za pristup aplikaciji potrebna je registracija korisnika (uloga u sustavu kao korisnik ili zaposlenik) svojim osobnim podacima.| Leon Špiranec
F02 | Prijava | Prije korištenja aplikacije se korisnik treba prijaviti kao obični korisnik ili zaposlenik | Leon Špiranec
F03 | Evidencija prostora | Zaposlenik može dodavati, ažurirati i brisati termine nekon prostora. | Petar Šemiga
F04 | Evidencija zaposlenika | Zaposlenici imaju mogućnost pregleda svih ostalih zaposlenika, mijenjanje uloga te evidenciju smjena. | Petar Šemiga
F05 | Rezervacija sportskih prostora | Korisnici mogu pregledati i rezervirati termin u željenom prostoru, ovisno žele li svoj termin ili se priključiti već postojećem. | David Viljevac
F06 | Plaćanje prostora | Korisnik odabire način plaćanja, ima opciju plačanja gotovinom u centru ili karticom preko aplikacije. | David Viljevac
F07 | Ažuriranje korisničkih podataka | Korisnik ima mogućnost mijenjaja osobnih podataka | Tomislav Smetiško
F08 | Izvješće | Izvješća o korištenosti pojedinih prostora | Tomislav Smetiško
F09 | Mjesečna članarina | Korisnik ima popuste i dodatne mogućnosti prilikom najma prostora | David Viljevac
F10 | Najam dodatne sportske opreme | Korisnik je u mogućnosti unajmiti sportske rekvizite (lopte, reketi, sprave i pomagala...) | Petar Šemiga 
F11 | Najam privatnog trenera | Korisnik najmom privatnog trenera ima mogućnost individualnih treninga | Tomislav Smetiško
F12 | Priključivanje zdravstvenim aktivnositima | Korisnik je u mogućnosti sudjelovati na terapijama i rehabilitacijama | Leon Špiranec 
F13 | Prijava za izradu vlastitih trening programa | Korisnik se može prijaviti za izradu vlastitog programa u koji se mogu uključiti ostali korisnici | David Viljevac 


## Tehnologije i oprema
Microsoft Visual Studio 2022, C# (.NET Framework), MySQL, Draw.io, GitHub, Microsoft Word
