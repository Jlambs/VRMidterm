# Grabbing Hidden Objects and Stealing Them Simulator (G.H.O.S.T.S.)


## Game Overview

GHOSTS is a VR horror game that focuses on the interactions between VR-immersed players and “real-life” players who are not wearing a headset. These two teams are pitted against each other in a hide-and-seek style game which involves the VR players (the hiders) trying to protect a motion-tracked doll from being stolen by the non-VR players (the seekers). If the VR player notices the doll being taken, as it will be conspicuously floating from their perspective, they can try to tag the real-life players out. If the hider manages to tag out all of the seekers, the hider wins, but if the doll is successfully stolen (from the motion tracked space), the seeker(s) win.

## Core Gameplay Loop

At the start of a game, the VR hider player has 20 seconds to place the doll somewhere around the room and familiarize themselves with the haunted-house environment. After that time is up, the VR player is no longer allowed to touch the doll for the rest of the game. It should be noted that because the doll is motion-tracked it must remain within view of the tracking cameras, so it won’t be “hidden” so much as just placed on a table/shelf/floor. The seekers will then be allowed to enter the room, and must make their way towards the doll while never being touched by the VR player. The VR player will not be able to actually see the seekers, but any physical contact will count them as out so they must keep their distance.

To prevent the hider from simply camping around the doll, events take place around the room in an attempt to distract them from protecting it. The VR player dawns a flashlight, but the battery drains extremely quickly and the environment itself is intentionally difficult to see in, so powerups will spawn in random locations which provide precious battery life. More severely, the doll’s VR model will teleport to random locations around the room occasionally, giving the seekers a golden opportunity to swoop in. 

## VR vs Physical Environments

The key assumption for this game to be possible is an accurate correspondence between the virtual and physical environments. Even small discrepancies between locations in the VR and real worlds could have many consequences.

On the benign end of the spectrum it is slightly disorienting for the VR player expecting to reach physical barriers, such as desks or walls, and have them be slightly off from the expected location. This is especially problematic in the vertical direction, as the “walking up stairs in the dark” effect (when think there’s one more step than there really is and you temporarily plummet into the abyss, you know what I’m talking about) can make a player quite disoriented, even nauseous, over time.

More serious discrepancies could result in actual injury, as although quick movement is *discouraged* for obvious reasons, it generally arises anyway by instinct due to the time-dependent nature of catching seekers or powerups. Luckily there were no injuries during testing, however with time there may be “manual” rules banning fast-paced movement.

Additionally, the full-scale game was difficult to test outside of isolated components because of having to either modify the VR environment or the real-world environment whenever a change was made due to the other.

## Results, Conclusions, and Future Work

Overall the completed product turned out better than originally anticipated, thanks in part to the availability of high-quality free assets on the Unity Asset Store, although many of the core gameplay features originally proposed were modified or scrapped completely based on feasibility of implementation, which ended up limiting the final scope of the project. This ended up not being too big of an issue however, as the core gameplay features involving the tracking of objects (being the player, flashlight, and doll) were able to constitute the basic idea of the game. It was also interesting to study the relationship between detail and immersion; for the game to be actually *scary* there had to be a fairly convincing sense of realism. Although the finished product wouldn’t be considered in the same leagues as mainstream horror titles, with some small improvements in hardware and/or asset quality could make big strides in being able to actually scare the player.

As mentioned above, there are many potential extensions of this project that would greatly improve immersion and replayability. These could include having a more dynamic environment in which the game takes place in to avoid the difficulties previous discussed with creating good correspondence between the virtual and physical playing environments. Additionally, extensions to the core gameplay loop could be implemented such as multiple hiders (VR players), as well as more complex distraction mini-games. The original idea involved also tracking the seekers, but not actually making them wear headsets, to add certain hints in-game as to what their location might be (this was scrapped in part due to the difficulty in working with directional sounds). By far the most disappointing feature to cut out of the final product was explicit jump-scares arising from *fake* hints/distractions around the room that require the VR player to get very close to an object/corner, and then have a spooky asset pop out at them (this was scrapped due to every attempt at creating this being far more cringe-worthy and obvious than scary, as well as the scarce availability of assets).

## Asset Credits

https://assetstore.unity.com/packages/audio/sound-fx/horror-elements-112021
https://assetstore.unity.com/packages/3d/props/horror-assets-69717
https://assetstore.unity.com/packages/3d/props/furniture/horror-school-props-112589
https://assetstore.unity.com/packages/3d/environments/swamp-house-1-153759

## Game Trailer

https://youtu.be/4NBgyebw07A
