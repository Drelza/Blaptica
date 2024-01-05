# Diagrams

This document contains diagrams using [mermaid](https://mermaid.js.org/)

## Scene Tree Diagram

Represents the scene structure of the game

```mermaid
flowchart LR
    Main --> Player --> Laser
    Main --> Stage --> Wave --> Spawner --> Enemies --> Laser
                                Spawner --> Boss
    Main --> UI
```
