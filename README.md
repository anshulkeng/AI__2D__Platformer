\# Unity 2D Platformer Game with Zombie AI and Bat Companion AI
## Demo Video

A short gameplay demo of the project is available here:

[Watch Gameplay Demo](https://drive.google.com/file/d/1kp0A6bNFiYw_eRBfcEYiT2-QDk5ufrd5/view?usp=sharing)

\## Project Overview



This project is a 2D platformer game developed in Unity. The game includes a controllable player, zombie enemy AI, and a bat companion AI. The player moves through the level, collects coins, avoids or defeats zombies, and survives enemy attacks.



The project demonstrates multiple AI behaviours in a Unity 2D environment. The zombie AI acts as an enemy agent that detects, chases, and attacks the player, while the bat companion AI supports the player during gameplay.



\## Features



\- 2D platformer player movement

\- Player jump and attack system

\- Zombie enemy AI

\- Bat companion AI

\- Player health system

\- Coin collection system

\- Health pickup system

\- Zombie spawning system

\- Level ending system

\- Camera follow system

\- UI display for health and coins

\- Unity 2D physics and collision handling



\## AI Systems



\### Zombie AI



The Zombie AI is designed as the main enemy system. It detects the player, moves toward the player, and attacks when the player is close enough.



Main behaviours:



\- Detects the player within a certain range

\- Chases the player after detection

\- Attacks the player at close range

\- Uses attack cooldown timing

\- Takes damage from the player

\- Works with the zombie health system

\- Can be spawned using the zombie spawner system



\### Bat Companion AI



The Bat Companion AI is designed as a support character for the player. It stays near the player and assists during gameplay.



Main behaviours:



\- Follows or stays near the player

\- Moves dynamically based on the player's position

\- Supports the player during enemy encounters

\- Adds companion-based AI behaviour to the game



\## Technologies Used



\- Unity

\- C#

\- Unity 2D Physics

\- Rigidbody2D

\- Collider2D

\- Animator

\- TextMeshPro

\- Unity UI System



\## Project Structure



```text

Assets/

├── Scenes/                         # Unity scene files

├── 2D Space Backgrounds/            # Background assets

├── 2DRPK/                           # 2D platformer asset pack

├── Hungry Bat/                      # Bat companion assets

├── Level 1 Monster Pack/            # Zombie/enemy sprite assets

├── Plugins/                         # Unity plugins and dependencies

├── Settings/                        # Unity render/settings assets

├── TextMesh Pro/                    # TextMeshPro UI assets

├── Simasart/                        # Additional imported art assets

├── NovaDevs/                        # Additional imported assets

├── AppFast/                         # Additional imported assets

├── 2D Platformer/                   # Main platformer-related assets

├── BatCompanionAI.cs                # Bat companion AI behaviour

├── CameraFollow.cs                  # Camera follow logic

├── Coin.cs                          # Coin pickup logic

├── CoinSpawner.cs                   # Coin spawning system

├── GameUIManager.cs                 # UI management for gameplay

├── HealthPickup.cs                  # Health pickup behaviour

├── LevelEnd.cs                      # Level completion logic

├── PlayerAttack.cs                  # Player attack system

├── PlayerHealth.cs                  # Player health and damage system

├── PlayerInteractions.cs            # Player interaction handling

├── Playermovement.cs                # Player movement logic

├── ZombieAI.cs                      # Zombie enemy AI behaviour

├── ZombieHealth.cs                  # Zombie health system

└── ZombieSpawner.cs                 # Zombie spawning system



Packages/

ProjectSettings/

README.md

.gitignore

```



\## Main Scripts



Important C# scripts used in this project include:



```text

BatCompanionAI.cs

CameraFollow.cs

Coin.cs

CoinSpawner.cs

GameUIManager.cs

HealthPickup.cs

LevelEnd.cs

PlayerAttack.cs

PlayerHealth.cs

PlayerInteractions.cs

Playermovement.cs

ZombieAI.cs

ZombieHealth.cs

ZombieSpawner.cs

```



\## Main Prefabs and Assets



The project includes important gameplay objects such as:



```text

Coin.prefab

HealthPickup.prefab

Zombie.prefab

PlayerAnimator.controller

HeroKnight\_BlockNoEffect\_0.controller

InputSystem\_Actions.inputactions

```



These assets are used for player control, enemy behaviour, pickups, animations, and gameplay interaction.



\## How to Run the Project



\### Requirements



Before running the project, install:



\- Unity Hub

\- Unity Editor

\- Recommended version: Unity 6 or newer



\### Run Instructions



1\. Clone or download this repository.

2\. Open Unity Hub.

3\. Click \*\*Add Project\*\*.

4\. Select the downloaded project folder.

5\. Open the project in Unity.

6\. Wait for Unity to import all assets.

7\. Open the main scene from the `Assets/Scenes` folder.

8\. Press the \*\*Play\*\* button in Unity.



\## Controls



| Action | Key / Input |

|---|---|

| Move Left | A / Left Arrow |

| Move Right | D / Right Arrow |

| Jump | Space |

| Attack | Left Mouse Button |



\## Gameplay Instructions



1\. Start the game from the main scene.

2\. Move the player through the platform environment.

3\. Collect coins to increase progress.

4\. Avoid zombie attacks.

5\. Attack zombies to defeat them.

6\. Collect health pickups to recover health.

7\. Use the bat companion support while progressing through the level.

8\. Reach the level end point to complete the level.



\## Project Purpose



The purpose of this project is to demonstrate Unity 2D game development and AI implementation. The project shows how enemy AI and companion AI can be used together to create more dynamic gameplay.



\## Learning Outcomes



This project demonstrates:



\- 2D player movement implementation

\- Enemy AI behaviour design

\- Companion AI behaviour design

\- Health and damage systems

\- Coin and pickup interaction

\- Zombie spawning logic

\- Camera follow implementation

\- UI management using Unity UI and TextMeshPro

\- Collision and trigger handling using Unity 2D physics

\- Scene, prefab, animation, and script organisation in Unity



\## Future Improvements



Possible future improvements include:



\- Adding more levels

\- Adding more enemy types

\- Improving bat companion decision-making

\- Adding sound effects and background music

\- Adding a main menu and pause menu

\- Adding checkpoints

\- Improving animations and visual effects

\- Adding difficulty settings



\## Author



Developed by Anshul Keng.

