# Lessons Learned

- Get the architecture right the first time. 
  - Godot makes it difficlut to make changes.
- Disconnect events when objects are disposed.
  - Prevents reference to disposed object.
- Partial classes that extend Godot Nodes cannot be made static, or abstract.
- Scene inheritance is inidicated on the child scene
  - Example: `[ext_resource type="PackedScene" uid="uid://cuoifcp2ofdea" path="res://Scenes/Ship.tscn" id="1_44hq2"]`
- Track when enemies have left the screen with `VisibleOnScreenNotifier2D` Node `ScreenExited` Event
- Wrapping PackedSenes in a custom Resourse help enforce type safety