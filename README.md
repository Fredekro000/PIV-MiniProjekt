# PIV-MiniProjekt
A Mini Project in the course Programming of 3D Interactive Worlds

# Overview of the game:
The idea of the game to begin with, was to create a realistic looking modern world featuring a tank crew, where the player would be controlling the tank, whilst the crewmates would be talking, so it would be a calm tank crew driving through a forest. However, mid-way through I decided to make The Hunter (Not sure which one). This way I would keep the already built terrain, and only needed to implement a weapon, and a target. So essentially there would be one hunter, one weapon, one prey and one world.

## Main parts of the game:
- **Player**: A capsule controlled with WASD and LShift for walking and running.
- **Shooting**: Equipped with a crossbow, actions include tucking away with 'F', reloading on 'R', aiming on 'RMB', and shooting on 'LMB'.
- **Enemy**: Shooting a furry (the enemy) results in a slow death.
- **Camera**: Placed on the player for a first-person view, with mouse input controlling camera movement.
- **World**: A 1000x1000 terrain for player exploration.

## Game features:
Players can enjoy walking around in a calm spring morning atmosphere with bird chirping, wind whooshing, and a calm lake splashing water. A shader enhances the cozy atmosphere, and players can use a crossbow with realistic features.

## Running it:
- Download Unity >= 2022.3.8f1.
- Clone or download the project.
- Mouse and keyboard are required to play.

## Project parts:
**Disclaimer!** The scripts Movement, PlayerCamera, and MoveCamera were made by Dave (linked at the end), with values modified.  

### Scripts:
- **Movement**: Controls player movement (jumping, running, walking).  
- **PlayerCamera**: Moves the camera based on mouse input.  
- **MoveCamera**: Aligns the camera with the player's position.  
- **Crossbow**: Controls crossbow functions (shooting, aiming, reloading, playing sounds).  
- **Materials**: Created using textures from imported assets, so none were made by me.  
- **Levels**: Only one scene and world.  
- **Testing**: Game tested on a Windows PC.  

### Hierarchy objects:
- My own: ![](cat.jpg)
- Prefabs: ![](cat.jpg)
 

## Time Schedule:
Although not all time spent on the project is precisely tracked, the stated times are as close to the truth as possible.  

| Task | Time it took (In hours) |
|------|---------------------------|
| Gathering assets | 3 |
| Setting the scene up | 1.5 |
| Building the terrain | 11 |
| Scripting player movement (Got help) | 0.5 |
| Scripting the crossbow and the arrow | 5 |
| Finding appropriate sounds | 1.5 |
| Code documentation | 1 |
| Crying over Github and GitKraken like a \*bitch\* | 3 |
| Writing this report | 2.5 |
| Making readMe | 1 |
| **Time taking in total** | **30** |

## References for assets and scripts:
**Unity Terrain - URP Demo Scene by Unity Technologies**  
A major thanks to Unity Technologies for making the Unity Terrain asset pack free to use. This asset pack basically is my project. I used almost all the features they made, and implemented them into my own project. This includes their textures for the map, their brushes, their trees, grass, rocks, and their lake material. Most importantly of all thanks to their shader, my game looked as good as it did. 

**Also big thanks to:**  
- ice_screen for their Wooden Canopy
- Natural_Disbuster for their Cliff Shrub for Terrain
- SanForge Studio for their 3D Bush - 01
- Enterables for their enterable aaa next gen medieval fantasy city town house
- Background Sound Effects for their Bow & Arrow Sound Effect
- Youtube Sound Library for their Bow and Arrow Sound Effect [Free No Copyright]
- Pixabay for their lake wavelet
- Mixkit for their European spring forest ambience
- Dave / GameDevelopment for his FIRST PERSON MOVEMENT in 10 MINUTES - Unity Tutorial
- Vesper 3D for their Hoshi Avali Furry OC 3D Models
- AmeAngelofSin for their dying female sound

No 3D assets or sounds in this game were made by me. Everyone mentioned and their linked assets are the only assets which have been used.

