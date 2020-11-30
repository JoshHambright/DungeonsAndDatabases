# DungeonsAndDatabases

A restful API for managing campaigns for D&D and other RPGs and games.

------

Produced for Eleven Fifty Academy Software Development Blue Badge Final Project by Team Sleepy
##### Team Sleepy is:

Joseph Jurney

Josh Hambright

Samuel Ayorinde

We set out to create a restful .NET WebAPI project to provide dungeonmasters and players tools to manage and track their campaigns.
Below you will find documentation for the API and how to clone, install and use the API.

### Feature:
------
* Create, View, Edit and Delete your own player profile
* Create, View, Edit and Delete multiple characters per player
* Create, View, Edit and Delete Campaigns as the Dungeon Master
* Track campaign membership and allow only your players and yourself to view your campaigns
* Keep track of home brew items and loot found by the party
* Roll virtual dice

### Built using:
* Visual Studio Community 2019
* C# 8.0

#### Planning Documents:
Blue Badge Project Planning Template:

https://docs.google.com/document/d/1_OL7EoPAYQE6-TZxTV9paDbur9s-55JawFOgC8CTpsU/edit?usp=sharing

Shared Planning Document (Classes, Database Map, notes, ect)

https://docs.google.com/spreadsheets/d/1xNM_71ofTtODEWjgcrIGpvlBVMqzXfuPnGHaNpzu3bo/edit?usp=sharing

Trello board for AGILE project planning and execution

https://trello.com/b/p2DQ82v9

-------

### Cloning the project:

Project is hosted on Github at:

https://github.com/JoshHambright/DungeonsAndDatabases

You can clone it locally using SSH or HTTPS

HTTPS: https://github.com/JoshHambright/DungeonsAndDatabases.git

SSH: git@github.com:JoshHambright/DungeonsAndDatabases.git

To get started register your account and then create a player.  Once you have a player you can begin by setting up your campaign or creating characters.


### Installing the project

Program is built in Visual Studio 2019 version  16.7.6 
Simply open the solution file in Visual Studio and run the WebAPI project.

------

## API End Points:

This project also includes the **swashbuckler/swagger** package which allows for testing of endpoints from the API, simply goto the
API address when it loads and add `\swagger` to the URL

!!!DOCUMENT ALL ENDPOINTS HERE!!!


------
### List of Resources Used to complete this project

* **5E SRD** for general inspiration about 5E Rules 
  * https://www.5esrd.com/

* **Open5e** more inspiration about rules and building classes 
  * https://open5e.com/

* **DND 5E API** Open API for the basic 5e Rules, looking to potentially integrate this API in the future
  * https://www.dnd5eapi.co/

* **Stack Overflow** a wealth of information when you can find the right question and answer, here are a few we found helpful
  * https://stackoverflow.com/questions/4950245/in-entity-framework-code-first-how-to-use-keyattribute-on-multiple-columns
  * https://stackoverflow.com/questions/26986436/multiple-actions-were-found-that-match-the-request-webapi
  * https://stackoverflow.com/questions/15454696/entity-framework-multiple-column-as-primary-key-by-fluent-api
  * https://stackoverflow.com/questions/35011656/async-await-in-linq-select
  * https://stackoverflow.com/questions/23111031/what-actually-happens-when-using-async-await-inside-a-linq-statement/23113336#23113336
  *https://stackoverflow.com/questions/24284413/webapi-help-page-description
* **Microsoft Developer Docs** always useful!
  * https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-5.0
* **C# Corner** Help understanding how to consume an outside API within our project
  * https://www.c-sharpcorner.com/blogs/consume-webapi-using-webclient-in-c-sharp
* **ScottLilly.com** Help with better random number generation for dice roller
  * https://scottlilly.com/create-better-random-numbers-in-c/
* **DotNet Falcon** Customize WebAPI documentation
  * https://dotnetfalcon.com/stackoverflow-adventures-add-custom-info-to-web-api-help-page/
* **Awaiting Bits** using Swagger to assist with documenting endpoints
  * https://blog.zhaytam.com/2018/09/23/generate-aspnetcore-web-api-doc-swagger/
* **GitHub Guides** help making this beuatiful Readme you are reading now
  * https://guides.github.com/features/mastering-markdown/
