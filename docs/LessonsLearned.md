# Lessons Learned

- Get the architecture right the first time. 
  - Godot makes it difficlut to make changes.
- Disconnect events when objects are disposed.
  - Prevents reference to disposed object.
- Partial classes that extend Godot Nodes cannot be made static, or abstract.