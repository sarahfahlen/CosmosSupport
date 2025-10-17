# Projektets formål

Denne aflevering er udarbejdet af **Frederik Søgaard Andersen og Sarah Fahlén** i faget cloud computing på 3. semester. 
Projektets formål er at øve vores færdigheder indenfor cloud computing, mere specifikt opsætning af **Cosmos database** og connection hertil fra en web-app. 

Helt konkret har vi *udarbejdet datamodeller baseret på kundehenvendelser, oprettet en cosmosdatabase, tilføjet objekter hertil og lavet frontend der kan vise og oprette nye henvendelser.*

Vi har brugt kommandoen **dotnet run --project Server** for at starte projektet.

# Oprettelse af databasen til løsningen
Vi startede med at oprette en ny ressourcegruppe med kommandoen:

1. az group create --name IBasSupportRG --location uksouth

Herefter oprettede vi en *CosmosDB konto* samt bashvariabler, som vi bandt til vores ressourcegruppe, og senere tilknyttede til vores nye database. 

Da databasen var oprettede gik vi videre med oprettelse af containere, som vi også lavede en **partitionkey** til (for at filtrere i databasen senere):
1. **az cosmosdb create --name DBACCOUNT --resource-group RESGRP --enable-free-tier true**
2. **az cosmosdb sql database create --account-name DBACCOUNT \ --resource-group RESGRP --name DATABASE**
3. **az cosmosdb sql container create --account-name DBACCOUNT \ --resource-group $RESGRP --database-name DATABASE \ --name CONTAINER --partition-key-path "/Kategori"**

(Kommandoerne indeholder dollartegn, som kan forsvinde i markdown-visning, men de skal naturligvis være der i terminalen.)


# Status for projektet
Status for projektet er at vi har oprettet og udfyldt databasen med henvendelser. 

Vi har derudover lavet de krævede sider i blazor, og tilføjet validering. Vi mangler at få validering på kunde til at virke.


### Mulighed for fremtidig udvikling
1. Mulighed for login, så kundeId bliver relevant og ikke blot fiktivt
2. Service der genererer Id så dette ikke er random
3. Forskellig visning baseret på om man er kunde eller admin
4. Kategori som drop-down menu, så man ikke kan skrive sine egne kategorier
