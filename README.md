# Project Demolition

This project is a Unity game based on the *Mission Demolition* tutorial from Bond Chapter 30 for the course **CS382 – Game Design, Development, and Technology**.

## Unity Version
Unity 2021.3.33f1

## Game Overview
The player uses a slingshot to launch projectiles and destroy castle structures. The objective is to knock down all castles across multiple levels. Each level introduces a more difficult castle design, requiring better aiming and strategy.

## Features Implemented

### Required Features
The following features were implemented as required by the assignment:

- Unity project uploaded to GitHub with the correct **Unity `.gitignore`**
- **Game Over screen** with a **Play Again** button
- **4 levels** with different castle structures arranged from **easy to difficult**
- **Slingshot rubber band** implemented using a **Line Renderer**
- **Sound effect** when the projectile is launched

### Enhancements (Making the Game Cooler)
In addition to the required features, several improvements were added to enhance gameplay and player feedback.

**Score System**
- A score system was added to reward the player for progressing through the game.
- Each time a castle is destroyed and the player advances to the next level, the score increases by **100 points**.
- The score is displayed on the game UI during gameplay.

**Projectile Trail**
- A visual trail follows the projectile after launch so the player can clearly see the path of the projectile.

**Improved Gameplay Flow**
- A structured progression system was implemented with increasing castle difficulty.
- The Game Over screen provides a clean end to the game with the option to restart.

## How to Play
1. Move the mouse over the slingshot.
2. Click and drag the projectile backwards to aim.
3. Release the mouse to launch the projectile.
4. Destroy the castle to move to the next level.
5. Each level increases in difficulty.
6. After clearing all levels, a **Game Over screen** appears.
7. Click **Play Again** to restart the game.

## Repository Structure
