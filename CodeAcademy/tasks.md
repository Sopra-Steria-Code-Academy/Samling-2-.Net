# Oppgaver
1. Enable OpenApi for .Net løsningen (Lag et car api)
- Definer en DTO som heter "CarDTO". Den skal ha feltene:
	- "Id" av typen int
	- "Brand" skal være enum med 3-4 forkjellige typer, f.eks. BMW og VW
	- "Name" av typen string, f.eks. "Passat"
	- "Price" av typen integer
	- "color" av typen string
- Lag et endepunkt som henter en bil basert på Id og returnerer CarDto. Legg på eksempler og gode responser av forskjellige http verdier
- Lag et endepunkt som returnerer en liste av CarDTO'er
- Lag et endepunkt som sletter en bil basert på en ID i queryParam
- Lag et endepunkt som oppdaterer felter på en bil, f.eks. color eller price basert på requestBody
- Lag et endepunkt som henter alle biler basert på en farge eller en maksimumspris. Bruk queryParam i endepunktet
- Lag et endepunkt som henter alle biler av typen BMW. Bruk enumen du laget tidligere
2. Legge til contact person, terms of condition og licence
3. Custom home page for developer portal
4. Legg til authentication og en ny controller som heter CarAuth