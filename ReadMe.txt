-- Overview of Project -- 

1) Startup.cs
	- Like most MVC/WebApplications, Startup.cs is literally used to set up the different services, collections, ... etc for your project. 
	  Here you will find documentation on where SQLServer is added, as well as general pointers on where to add things like identity.

2) .\Data\
	- In this folder you will find two things:
		- .\Models\DbModel.cs
			- These are the Database Model classes, since the project was created in a code-first approach using Entity Framework Core tools. 
			  In using existing data-sources, EFCore Tools provides the opportunity to "Scaffold Db" from an existing source given a connection
			  string. This will both Create the DB Classes for you, as well as create the below DbContext file.
		- .\SqlDbContext.cs
			- This is the Entity Framework Core implementation of a DbContext. All methods in this page are used after injecting the DbContext into a given
			  .razor page. As a result you will notice all methods have comments, since this is the central class for data operations. You will read your 
			  connection string here as part of the override of the OnConfiguring(optionsBuilder) method. Production scenarios would read from Key-Vault here. 

2) Coding Style Sheet (CSS)
	- Like any other Web Application using HTML, Blazor provides the opportunity to use CSS to provide styling to HTML components. 
	  In general Blazor provides flexibility for things like Javascript, Bootstrap, etc. You can find the CSS at .\wwwroot\css\site.css

3) .\Shared\
	- This folder contains partial views that can be used in conjunction with other pages. The examples you will see within the project are
	  MainLayout.razor, as well as NavMenu.razor

4) .\Pages\
	- .\DataEntry\
		- This folder contains views used to initially seed the database from UI. All data entry forms are very fundamental in nature, but specifically
		  you'll want to have a look @ CreateCabset.razor as well as NewRun.razor
	- Runs.razor
		- This is the entry point for RunEvaluation.razor, which take the RunId from a table in Runs.razor as a parameter to display all data across multiple tables that 
		  are related to a particular run. 