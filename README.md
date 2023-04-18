# help_needed_unity_netcode

This is a POC to demonstrate how to spawn networkObject as a children during runtime. The Spawner should spawn 3 children and than oin everx 3 seconds all the childrens are teleported.
Using netcode 1.2.0:
 - host seems to be working
 - server seems to be working
 - client: The runtime spawned objects if spawned as child (using TrySetParent) is is not working, no objects are created
 - client: The runtime spawned objects as root (nat calling TrySetParent) is is working.

Using netcode 1.3.1 (from @hash 27176860f9f25eb089d807ae61413ed44b1bdd1a)
 - host seems to be working
 - server seems to be working
 - client spawns no objects in either case: spawned as root  or spawned as child using TrySetParent)

I've tried a few commbination of it but without any success.
