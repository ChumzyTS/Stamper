# Stamper

**A 2D platform adventure developed in Unity for the SGDA 2025 Summer Game Jam.**

Play the game here: [https://chumzy.itch.io/stamper](https://chumzy.itch.io/stamper)

Stamper is a character-driven platforming game that combines movement-based challenges with interactive characters, dialogue, and a distinctive stamping mechanic. Players explore the game world, meet characters, progress through conversations, and collect stamps to advance.

Developed in C# with Unity, the project brings together custom player movement, interactive dialogue, checkpoint-based respawning, UI animations, and scene transitions.

## Contributors

__James Hawkins (ChumzyTS)__ - Programming Work, Project Planning

__Aris Palin__ - Programming

__Taylor Klinsky__ - Art

__Landon Ho (BrightCerulean)__ - Art

__Lazarus Avila Fisher (AdhucSomni)__ - Level Design

## Gameplay Features

- **Platforming and movement:** Navigate the environment with horizontal movement, jumping, and aerial gliding.
- **Stamping mechanic:** Use a ground-pound-style stamp action, with a timed opportunity to perform a boosted jump afterward.
- **Character interactions:** Approach characters to initiate dialogue and progress through multiple conversations.
- **Stamp collection:** Stamp character portraits and track progress toward the level's completion requirement.
- **Dialogue-driven progression:** Support character-specific dialogue, name reveals, portrait changes, and mail delivery sequences.
- **Checkpoints and respawning:** Activate checkpoint signs to establish respawn locations throughout the level.
- **Audio and animation:** Integrate background music, sound effects, character animations, and UI transitions.
- **Polished presentation:** Include a main menu, pause and options interfaces, camera bounds, animated scene transitions, and procedural background clouds.

## Technology Stack

| Technology | Purpose |
|---|---|
| C# | Gameplay systems and interaction logic |
| Unity 6 (6000.0.54f1) | Game engine and scene development |
| Unity 2D Physics | Player movement, collisions, and triggers |
| Unity Input System package | Input-related project configuration |
| TextMesh Pro | Dialogue and interface text |
| Unity Animator | Character, stamping, and UI animations |
| Unity Audio | Background music and sound effects |

## Technical Highlights

### Custom Player Movement

`PlayerMovement.cs` implements the core character controller, including horizontal movement, jumping, additional jumps, gliding, and stamping.

The controller combines Rigidbody2D physics with configurable movement parameters, ground detection, coyote time, jump input buffering, and a stamp-triggered jump boost. These mechanics give the player multiple ways to navigate the platforming environment.

### Character Dialogue System

The dialogue system separates character-specific conversation data from the component responsible for presenting dialogue.

- `FriendDialogue.cs` manages conversation sequences, character information, and interaction progression.
- `Dialogue.cs` displays dialogue with a typewriter effect and handles advancing conversations.
- Character interactions can trigger stamping sequences, reveal hidden names, and display mail at configured points in a conversation.

This structure supports multiple characters and conversations without requiring each character to implement its own dialogue presentation system.

### Stamp Collection and Progression

`StampFace.cs` manages the stamping interaction, including character-specific stamp artwork, positioning, and rotation.

`StampTracker.cs` maintains the stamp counter and opens the progression gate when the required total is reached. In the configured implementation, the threshold is seven stamps.

### Checkpoints and Recovery

The checkpoint system uses trigger-based interactions to update the player's respawn anchor. The player controller handles recovery after falling or encountering hazards, returning the character to the active checkpoint or the initial spawn position when no checkpoint has been selected.

### Modular Environment and Presentation

Separate components handle camera boundaries, cloud generation, sound effects, menu interactions, and scene transitions. This organization keeps key gameplay responsibilities distributed across focused scripts and reusable Unity components.

## Controls

The default controls configured in the player scripts are:

| Action | Control |
|---|---|
| Move | A/D or Left/Right Arrow |
| Jump | Space |
| Glide | W or Up Arrow |
| Stamp | S or Down Arrow |
| Interact / advance dialogue | F |
| Respawn | R |
| Pause | Escape |

Some controls and interactions depend on the current game state.

## Getting Started

### Requirements

- Unity Hub
- Unity Editor **6000.0.54f1** (the version recorded in the project)

### Open the Project

Clone the repository:

```bash
git clone https://github.com/ChumzyTS/Stamper.git
cd Stamper
```

Open Unity Hub and select **Add project from disk**. Choose the cloned `Stamper` directory and open it using the project version listed above.

Allow Unity to import the project assets and resolve the required packages.

### Run the Game

1. Open the project in Unity.
2. Locate the game's starting scene under `Assets/Scenes`.
3. Open the appropriate starting scene.
4. Press **Play** in the Unity Editor.

For a standalone build, configure the relevant scenes under **File → Build Profiles** (or the equivalent build settings in your Unity version), select a target platform, and build the project.

## Project Structure

```text
Assets/
├── Audio/
│   ├── Music/
│   └── SFX/
├── Main Menu/
├── Scenes/
├── Scripts/
│   ├── Aesthetics/
│   ├── Dialogue/
│   ├── Friends/
│   ├── Interactables/
│   ├── Player/
│   └── Sound/
├── TextMesh Pro/
└── Prefabs and animation assets
```

The project includes the Unity scenes, scripts, sprites, audio, animation controllers, prefabs, and configuration needed to develop and run the game.

## Development Context

Stamper was developed for the **Student Game Developer Association (SGDA) 2025 Summer Game Jam**.

The project demonstrates the integration of platforming mechanics, character-driven interactions, progression systems, and visual and audio feedback within a Unity game.

## Repository

[View the source code on GitHub](https://github.com/ChumzyTS/Stamper)

---

*Built with Unity and C# for the SGDA 2025 Summer Game Jam.*
