# Report

## Description: 
Rapid News Reports Web API, which has the following CRUD operations: 
* Get a single report
* Get of list of reports - filters to be added 
* Add a new report
* Update an existing report
* Delete a report

https://www.markdownguide.org/cheat-sheet

## Requirements 

* .NET version 6
* Markdown editor plugin


## Migrations 

### Creating Migration Scripts

* In Visual Studio, Click on the Tools -> Nuget Package Manager -> Package Manager Console
* First migration run the following

```bash
Add-Migration InitialMigration
```

* Verify migrations scripts are run successfully and Migrations folder is created

### Running Migrations Scripts

To run the migration, again open up the Package Manager Console and run the following:

```bash
Update-Database
```

## Running the project locally

Using Visual Studio: 
* Click the IIS express run button in visual studio
* Swagger UI can be accessed on  https://localhost:7011/swagger/index.html


## Coding to dos

* Put need to ensure date Post - set date modified date = date created 
* Publish field - IsPublished to be added to the db
* link from ui to report webapi for each of the crud functions and get return list
* filtering of HTTPget - all (mine), All reports (all mine and published other), Category

 



