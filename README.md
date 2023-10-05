# AccentureAssessment

Database: 
used ms sql server 
run the SQLQuery file to create database, tables and insert data.

Project:
used vs studio 2022
the solution contains 3 projects ( WebApi project, DevChallenge MVC project, DataLayer class project)
DataLayer project: stores/contains database classes
WebAPI rpoject: contains controllers that communicate with the database
DevChallenge project: this is the main project

To get the project up and running:
- update the connection string on Web.config file in WebAPI project to point to the database you created on your machine
- right click the solution and go on startup project. Start both DevChallenge and WebApi project
- build and run the solution
- NB: Both DevChallange and WebAIP project are gonna run from different windows/tabs. The WebAPI project is going to show some error, Please ignore that and keep it running as it provides the connection to db. Check the DevChallenge tab/window

Known possible issue:
when running the project, you may get the roslyn error
- run this in the Package Manager Console:
    Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
  
-build and run the project again


