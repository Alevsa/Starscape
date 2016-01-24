Currently the character names in the dialogue may be hardcoded in but
it is my intention for them to be set in the registry and moddable by
whatever means. To this end there are certain magic words that are 
replaced by a characters name when spotted in the text by the string
processor. These names are currently in the the SaveLoadController 
with the exception of the players name which is saved to the registry
when the game is started. (Going to read in the NPC names from a text
file instead at some point)
|
|        Name code       |           Character           |
|________________________|_______________________________|
|                        |                               |
|        @charname       |           The player          |
|________________________|_______________________________|
|                        |                               |
|        @buddy          |       Player's sidekick       |
|________________________|_______________________________|
|    `                   |                               |
|        @crew1          |       Weapon's engineering    |
|________________________|_______________________________|
|   `                    |                               |
|        @crew2          |      FTL drive mechanic       |
|________________________|_______________________________|