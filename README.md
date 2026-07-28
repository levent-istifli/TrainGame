# The Twelfth Stop

**Description:**

Train Game (stand in title for now) is a game intended to raise suicide awareness. It follows the protagonist: a female office worker that had aspirations to make it big in the world, but threw them away in hopes for stability and following the social norm. Unfortunately, she has undergone detrimental conditions that have caused her to mental stability to completely deteriorate. As she makes her way on her last train ride, she meets a variety of individuals (not all alive...) that have undergone similar experiences and encourage her to reconsider her actions.

**Link to Repository:**

https://github.com/levent-istifli/TrainGame

To compile Rust code, install Rust and run the command `cargo build` in the `rust` folder. This must be done before loading the game in the editor.

**Project Instructions/Functionality:**

* Move character with WASD
* From the starting cart, you can go two directions:
  * Going all the way to the left will take you to cart 3. If you wish to leave, go all the way to the right and it will take you to the middle cart (cart 1).
  * Going all the way to the right will take you to cart 2. If you wish to leave, go all the way to the left and it will take you to the middle cart (cart 1).
* NPC walk into the carts. To activate them, press T while in a cart.
  * When activated, NPCs spawn in an move towards a seat.
  * To activate the NPCs leaving, press Y.
 
* Click on the NPC with the exclamation point on the chair to activate the dialogue scene
  * Here, you click to go through the dialogue.
  * You are also presented with a dialogue option.
  * Click the back button to return to the previous screen.
 
**Bugs:**
* NPCs get deleted when moving across scenes
* NPCs will bump into player if in the way/player runs into them (potentially can get locked into an area)



Some people used Goose to help with learning about Godot and its syntax quicker. 

