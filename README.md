# DungeonsAndDatabases

A restful API for managing campaigns for D&D and other RPGs.

------

Produced for Eleven Fifty Academy Software Development Blue Badge Final Project by Team Sleepy
##### Team Sleepy is:
* [Joseph Jurney](https://github.com/jajurney)
* [Josh Hambright](https://github.com/JoshHambright)
* [Samuel Ayorinde](https://github.com/sayorinde)

We set out to create a restful .NET WebAPI project to provide dungeonmasters and players tools to manage and track their campaigns.
Below you will find documentation for the API and how to clone, install and use the API.

### Features:
------
* Create, View, Edit and Delete your own player profile
* Create, View, Edit and Delete multiple characters per player
* Create, View, Edit and Delete items from you Characters Inventory
* Integrates the [DnD5EAPI](https://www.dnd5eapi.co/) to populate Race, Class, and Equipment details when avaiable.
* Create, View, Edit and Delete Campaigns as the Dungeon Master
* Track campaign membership and allow only your players and yourself to view your campaigns
* Keep track of home brew items and loot found by the party
* Players and DM's can keep virtual notes for each campaign
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

* **Player**
Allows you to store your individual player information. You are only allowed one player per login.
  * `POST api/Player` Creates a new player, limit one per user account. Requires a `PlayerName` string for the players name
  * `GET api/Player` Get all Players in the database
  * `GET api/Player{id}` Get details on a specific player based on their Player ID GUID.
  * `PUT api/Player{id}` Update a player name (body) based on player ID Guid in URI. Can only update your own account.
  * `Delete api/Player{id}` Deletes a player Account based on Player ID GUID. Can only delete your own account.
 
* **Character**
Stores basic information about a character, who owns the character and which campaigns they are a part of.
  * _You must create a player before you can create a character._
  * `POST api/Character` Creates a Character. Body of request should contain `Character Name`, `Race`, `Class`, and `Level`
  * `GET api/Character` Shows all of the characters associated with your Player ID
  * `GET api/Character/{id}` Shows the details on a specified `Character ID`
  * `PUT api/Character/{id}` Updates a Character based on a specified `Character ID`. Body of request should contain `Character Name`, `Race`, `Class`, and `Level`. You can only edit characters you created.
  * `DELETE api/Character/{id}` Deletes a character based on a specified `Character ID`. Can only delete characters you created.
* **Inventory**
Stores an inventory of items for a character. Designed to work with the [DnD5EAPI](https://www.dnd5eapi.co/).
  * _You Must create a character before adding inventory_
  * `POST api/Inventory` Creates an equipment item in specified characters inventory. Body of request must contain `Name` of the item, any `Notes` you would like to attach to the item , `CharacterID` of the character you'd like to add the item to(you must be the creator of this character to add an item to their inventory), and `EquipmentType` of either `Equipment` or `MagicItem`
  * `GET api/Inventory?characterid={characterid}` Shows the full inventory for a specific character based on the `characterID`
  * `GET api/Inventory/{id}` Returns the details on a specific inventory item.  Takes the name of the item and checks it against the [DnD5EAPI](https://www.dnd5eapi.co/) and includes what it finds there if anything in the results. You must have created the item in order to view its details.
  * `PUT api/Inventory/{id}` Updates an Equipment item based on the `id` of the item.  Body requires `name`, `notes` and `EquipmentType` of either `Equipment` or `MagicItem`. You must be the creator of the item to edit it.
  * `DELETE api/Inventory/{id}` Deletes an item based on the `id` corresponding to the ItemID of the item.  You must be the creator of an item to delete it.
  
* **Campaign**
Stores information about a specific campaign, who the DM is, who the players are, what game system the campaign is using, and any special loot the DM has added for the party.
  * _You must create a player before creating a campaign_
  * `POST api/Campaign` Create a new Campaign. Body of the request must contain a `Campaign Name` and `Game System`(Ex. DND5E, DND3.5, Pathfinder)
  * `GET api/Campaign` Get all campaigns you have created or are a member of
  * `GET api/Campaign/{id}` Get details on a specified `Campaign ID`
  * `PUT api/Campaign/{id}` Get details for a campaign based on a specified `Campaign ID`, body should contain `Campaign Name` and `Game System`. You can only edit campaigns you created.
  * `DELETE api/Campaign/{id}` Delete a campaign based on `Campaign ID`. You can only delete campaigns you've created.
 
* **Membership**
Manages character memberships for campaigns.  Only accessable to the DM of the campaign.
  * _You must have a campaign and atleast one character in the database to create a membership_
  * `POST api/Membership` Create a membership in a specified Campaign. Body must contain `Campaign ID` and `Character ID`. You can only add memberships to Campaigns you created.
  * `GET api/Membership` Returns all Memberships in the database
  * `GET api/Membership?campaignId={campaignId}&characterId={characterId}` Returns details on a specific Membership based on `Campaign ID` and `Character ID`. Can only be viewed if you created the specified Campaign
  * `Delete api/Membership?campaignId={campaignId}&characterId={characterId}` Deletes a character from a campaign based on `Campaign ID` and `Character ID`. Can only be performed if you created the campaign
 
 * **Campaign Loot**
 Campaign loot can be used to record campaign specific loot the party has acquired, examples are a rusty key to an unidentified door, or a homebrew specific treasure.
   * _You must have a campaign in the database you created to add campaign loot_
   * `POST api/CampaignLoot` Creates a new loot item for that campaign.  Body must contain a `Name`, `ValueInGP` (value of item in Gold Pieces), `Description` and the `CampaignID`.  You can only add loot if you are the Dungeon Master for a campaign
   * `GET api/CampaignLoot` Returns all loot associated with campaigns you are the DM
   * `GET api/CampaignLoot/{id}` Returns details on a specific loot item you have created
   * `PUT api/CampaignLoot/{id}` Updates a loot item, you are required to be the DM of the campaign to edit it.  Body must contain `Name`, `ValueInGP` (value of item in Gold Pieces), and `Description`
   * `DELETE api/CampaignLoot/{id}` Deletes a loot item from a campaign you are the DM of.
   
 * **Campaign Notes**
 Keep a log of notes related to your campaigns, specific to each character or DM in the campaign.
   * _You must have a campaign and a player to create notes_
   * `POST api/CampaignLog` Create a new Campaign Log Entry. Body requires a `Message` that contains the information you want to add to the log and a `CampaignID`. User must have a character that is a member of the Campaign or be the Dungeon Master for the campaign to create an entry.
   * `GET api/CampaignLog` Get all Campaign logs in the database for currently logged in user
   * `GET api/CampaignLog/{id}` Get details on a specific campaign log entry specified by the `ID`. You must be the creator of the log entry to view it.
   * `PUT api/CampaignLog/{id}` Update a specified campaign log by `id`. You must be logged in as the creator of a log to edit it. Body requires as `message` containing the body of the log.
   * `DELETE api/CampaignLog/{id}` Delete a specified campaign log by `id`. You must be logged in as the creator to delete the log entry.
   
 * **Dice**
 Dice Roller for RPG games
   * `GET api/Dice?D={D}` Roll a single Die, replace the `{D}` with the number of sides you'd like the die to have
   * `GET api/Dice?D={D}&N={N}` Rolls `{N}` number of `{D}` sided dice.  Return the individual rolls, the total, the highest and the lowest roll.

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
