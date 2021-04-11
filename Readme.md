Jag har följt ”Datbase normalization” regler när jag har byggt min databas. Då är det blivit ganska lätt att lägga en ny station till hamsterdagis programmen. 

Jag har uppdaterat min extension seeding metod som heter ModelBuilderExtensions.cs jag har lagt följande; 

Under Entity<Activity>().HasData => new Activity { Id = 5, Name = "Spa" }

Under Entity<AreaType>().HasData => new AreaType { Id = 3, Name = "Spa" }

Under Entity<Area>().HasData => new Area { Id = 12, AreaTypeId = 3, StatusId = 1, Capacity = 4

På detta sätt jag har lagt ”Spa” station till under ”Area” tabellen. Efter uppdatering seeding extension metoden jag har använd ”add-migration” under packet manager console och på detta sätt jag har skapat migration fil för standard database informationen och när programmen körs och om fattas informationen då lägger informationen till databas och på detta sätt programmet kraschar inte. Efter detta jag har använde ”update-database” under packet manager console för att lägga seeding informationen till databas som fattas i databas. 

Sist jag har lagt metoden för att flytta till och från spastationen. 
