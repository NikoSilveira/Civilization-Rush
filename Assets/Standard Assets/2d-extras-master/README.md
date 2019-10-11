# 2d-extras

2d-extras is a repository containing helpful reusable scripts which you can use to make your games, with a slant towards 2D. Feel free to customise the behavior of the scripts to create new tools for your use case! 

Implemented examples using these scripts can be found in the sister repository [2d-techdemos](https://github.com/Unity-Technologies/2d-techdemos "2d-techdemos: Examples for 2d features").

All items in the repository are grouped by use for a feature and are listed below.

### Tilemap

For use with Unity 2017.2b02 onwards.

##### Brushes

- **Coordinate**: This Brush displays the cell coordinates it is targeting in the SceneView. Use this as an example to create brushes which have extra visualization features when painting onto a Tilemap.
- **Line**: This Brush helps draw lines of Tiles onto a Tilemap. The first click of the mouse sets the starting point of the line and the second click sets the ending point of the line and draws the lines of Tiles. Use this as an example to modify brush painting behaviour to making painting quicker with less actions.
- **Random**: This Brush helps to place random Tiles onto a Tilemap. Use this as an example to create brushes which store specific data per brush and to make brushes which randomize behaviour.
- **Prefab**: This Brush instances and places a randomly selected Prefabs onto the targeted location and parents the instanced object to the paint target. Use this as an example to quickly place an assorted type of GameObjects onto structured locations.
- **GameObject**: This Brush instances, places and manipulates GameObjects onto the scene. Use this as an example to create brushes which targets objects other than tiles for manipulation.
- **TintBrush**: Brush to edit Tilemap per-cell tint colors.
- **TintBrushSmooth**: Advanced tint brush for interpolated tint color per-cell. Requires the use of custom shader (see TintedTilemap.shader)

##### Tiles

- **Animated**: Animated Tiles are tiles which run through and display a list of sprites in sequence.
- **Pipeline**: Pipeline Tiles are tiles which take into consideration its orthogonal neighboring tiles and displays a sprite depending on whether the neighboring tile is the same tile.
- **Random**: Random Tiles are tiles which pseudo-randomly pick a sprite from a given list of sprites and a target location, and displays that sprite.
- **Terrain**: Terrain Tiles, similar to Pipeline Tiles, are tiles which take into consideration its orthogonal and diagonal neighboring tiles and displays a sprite depending on whether the neighboring tile is the same tile.
- **RuleTile**: Generic visual tile for creating different tilesets like terrain, pipeline, random or animated tiles.

##### Other

- **GridInformation**: A simple MonoBehaviour that stores and provides information based on Grid positions and keywords.
