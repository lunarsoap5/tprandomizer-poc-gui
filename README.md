# Twilight Princess Randomizer Seed Generator Proof-of-Concept (GUI)

The purpose of this project is to continue the progress made on the randomizer backend here: https://github.com/lunarsoap5/tprandomizer-poc/ while also implementing a basic interface to allow for real-time modification of settings.

# Goals of this project:
- Set a standard for the components of a gui.
- Using an Assumed Fill algorithm, randomize a given list of items in a given list of locations based on the settings selected.
- Create a stand-alone randomizer program that works seperate from the gui, allowing for a universal compatibility, assuming that the proper output is given by the generator.

# FAQ
- Where are the checks located?
  - Under "Randomizer/World/Checks"
- Is Glitched Logic planned?
  - Yes. Glitched Logic is currently being worked on by Chris and can be found [here](https://github.com/Chris-Is-Awesome/tprandomizer-poc-gui).  
- [thing] is missing!!
  - Features and fixes are being made almost daily. If you have any questions or suggestions, feel free to reach out to me. 
- I want to test this out! How do I do it?
  - This program currently only generates a text file spoiler log, for emulation purposes. To play around with it:
    -  Download the repository and extract it. 
    -  Download and install Microsoft .NETCore [here](https://dotnet.microsoft.com/download).
    -  Download and install Visual Studio Code [here](https://code.visualstudio.com/download).
    -  Open the folder in VS Code and debug it to run. You may need to install extra dependencies, such as Newtonsoft JSON, but google can help with that.
