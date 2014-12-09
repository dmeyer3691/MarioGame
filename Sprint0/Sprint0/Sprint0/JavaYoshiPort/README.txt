For sprint 6, a port of the sprint 5 code to lwjgl and java was accomplished.
The 2 zip files in this folder are the windows binary for the compiled Java port of our group project with external Content folder, and the source code to compile this port.
In order to run the precompiled binary, it is simply necessary to have a somewhat current version of java and opengl.
This binary was tested on windows and linux. Other than minor changes to the controller, the application behaves identically to its XNA counterpart.

The following libraries and tools were used to develop, compile, and package this code:
   lwjgl http://www.lwjgl.org/ (Sound, underlying libraries to slick2d)
   eclipse 3.8 https://eclipse.org (development)
   slick2d http://slick.ninjacave.com/ (Image (like XNA's Texture2D) and BasicGame (like XNA's Game class)
   jarsplice http://ninjacave.com/jarsplice (packing lwjgl into the executable)
To compile the code, download slick2d, unpack it, load the jinput lwjgl lwjgl_util and slick jars, load the source code, and eclipse should compile it without further trouble.
To package the code, export a 'runnable JAR file' from eclipse, put the result and the .dll's and .so's into jarsplice, and the options to create a .exe and an executable .jar out of them will be presented. Both will work as expected on any platform.
To run the packaged code, place the compiled .jar or .exe in the same folder as the Content folder and run it. (Note that this Content folder has 1 difference from the XNA content folder, the main theme is a low bitrate .wav and not a .mp3 as .mp3 is a proprietary format not loadable in Slick.
