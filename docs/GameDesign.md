# Game Design

- The game is played in a series of stages.
- Each stage has a vast quantity of enemies in a specific pattern
- At the end of the stage the player is presented with a boss fight
- The player must defeat the boss to progress to the next stage
- The game is over if the too many enemies leave the screen too quickly
  - DDR style progress bar. Drains on missed enemy and fills on killed enemy
    - Fill ammount is less than the drain ammount for each enemy
      - Example: Fill = 1 x enemy value | Drain = 1.5 x enemy value
- The player earns points for each enemy killed
  - Various enemies are worth different ammounts of points.
- Missed enemies earn the player no points