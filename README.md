# GameEngineDesignBonus
Shesh Gaur - 100786399
Calculation: 43 - Prime

Build located in releases.

Singleton: Power-Up Manager
Located in Assets/Scripts/Singleton/PowerUpManager.cs
My PowerUpManager has a static instance of itself, and makes sure it is the only one. In the awake function it checks if there's an instance, and if there's not it makes itself the main instance. If the instance is already set, a new PowerUpManager will delete itself.
It spawns a power-up prefab every 5 seconds. It has a function called PowerUpActivated(), that is called by the player.cs script when it detects it has collided with a power up. It then increases the speed of the player for 5 seconds, before reverting back. The manager being implemented as a singleton makes it easy for new power-ups to be implemented and expanded. It also makes it easier for other game systems to access it, like the player in this instance.

Observer Pattern
Located in Assets/Scripts/Observer/ScoreManager.cs & Subject.cs
For my observer, I decided to create a score manager. This observer can be set to observe certain game events, and add to it's score when pinged / notified. This score is presented in the top middle of the screen. This being an observer makes it easy for objects and systems to add to the score without needing a direct reference to the score manager. Can make events like the player dying, barrels being broken, and reaching Donkey Kong contribute to the score easily. (Flowchart on canvas)
