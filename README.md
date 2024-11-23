## About
Virtual Lockdown is a VR escape room game designed for VR Cardboard, where players must search for password codes hidden within the room. Using hints scattered throughout the environment, players will piece together clues to uncover the correct code and unlock the room. 

<tbody>
    <tr>
      <td><img src="https://github.com/Swiper0/Swiper0/blob/main/GIF/VirtualLockdownDemo.gif"/></td>
    </tr>
  
<br>

## Scripts and Features
scripts:
|  Script       | Description                                                  | Development Time |
| ------------------- | ------------------------------------------------------------ | -------------- |
| `Autowalk.cs` | Handles automatic player movement in VR Cardboard based on trigger input or looking down past a threshold. | ≈ 2 hours |
| `ButtonInteract.cs` | Handles player interaction with buttons via raycasting and a reticle pointer, allowing selection and activation within a set distance by tapping the screen. | ≈ 3 hours |
| `DoorController.cs`  | Handles door animations by toggling the "isOpen" parameter in the Animator. Use OpenDoor to open the door and CloseDoor to close it. | ≈ 1 hours |
| `KeypadButton.cs`  | Handles keypad button interactions by sending the button's value to the KeypadManager when clicked. | ≈ 2 hours |
| `KeypadManager.cs`  | Manages the keypad input and checks if the entered code matches the correct code. If correct, it opens the door using the DoorController. | ≈ 3 hours |
| `ScreenController.cs`  | Handles scene transitions and quitting the application, allowing the change of scenes and closing the app through UI interactions. | ≈ 1 hours |
| `TVInteraction.cs`  | Handles interaction with a TV object, toggling the visibility of a TextMeshPro element when the player looks at it and presses a button. It also resets the size of the reticle pointer upon interaction. | ≈ 2 hours |
| `VRGazeInteraction.cs`  | Handles gaze-based interaction in VR, triggering actions when the player looks at an interactable object for a specified duration. It uses a raycast to detect objects and activates the interaction when the gaze timer reaches the set time or when the player presses a button. | ≈ 3 hours |
| `Win.cs`  | Handles scene transition upon player victory by triggering a level change when the player collides with a designated trigger. | ≈ 1 hours |
| `etc`  |  | ≈ 8 hours |


Post Processing used:
- Color Grading
- Bloom
- Ambient Occlusion
- Vignette

The game has:
- Automatic Movement
- Interactive Objects
- Gaze-Based Interaction
- Post Processing 

<br>

## Game controls
The following controls are bound in-game, for gameplay and testing.

| Key Binding       | Function          |
| ----------------- | ----------------- |
| Fire1 / Tap       | Interact objects  |

<br>

## Notes
this game is developed in **Unity Editor 2019.4.38f1**

Asset used:
- Map : https://assetstore.unity.com/packages/3d/environments/minimalist-archviz-bedroom-131093
- Skybox : https://assetstore.unity.com/packages/2d/textures-materials/sky/fantasy-skybox-free-18353
- Flashlight object : https://assetstore.unity.com/packages/3d/props/electronics/flashlight-18972
- Font : https://fontshub.pro/font/lumios-typewriter-download
