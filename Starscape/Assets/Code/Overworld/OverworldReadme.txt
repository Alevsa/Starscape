						Overworld Documentation

					++	How to use various scripts	++
					
あ Enemy Behaviour あ

-> OverworldAggressive.cs

This script is placed on a gameObject, there must also be a collider attached to
the object for it to function properly. The gameObject will then patrol around until
it spots the player, at which point it will attempt to collide with the player. Remember to include
an empty gameObject as a child. It should have the tag pointer. This just tells the enemy which way
to face.

For the patrol part the script to work there must be gameObjects with the tag "Waypoint"
in the gameworld, these gameObjects must have colliders set as triggers attached to them 
and a kinematic rigidbody, there must be a rigidbody or OnTriggerEnter will never fire and 
the script will not work.

い　Environmental Scripts い

-> CelestialOrbit.cs

Orbits an object around another.

Simply attach the script to the object you want to orbit and set the focus. If you want to 
have an object orbit an object that is already orbitting another object, for example, a moon
that orbits about a planet that is orbitting a sun then you should make the moon a child of the
planet. 

-> PlanetaryRotation.cs

Just attach to gameObject you want to rotate. An important thing to note is that if you make the moon
a child of a rotating planet then the moon will be locked to the rotation of the planet. To prevent 
this one should make the model of the planet a separate object as a sibling of the moon. This object
will rotate independently while the parent container orbits both the moon and the planet correctly.

う　Player う

-> OverworldController.cs
-> OverworldMovement.cs
-> OverworldStats.cs

These scripts are intertwined so I will describe them together. The player gameObject should be tagged
as "Player" and contain OverworldMovement.cs and OverworldStats.cs