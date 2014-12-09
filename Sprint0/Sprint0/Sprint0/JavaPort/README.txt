The java port does not compile in Microsoft VisualStudio, and the compiled executable is fairly large, as it has openGL libraries for 3 different OSes in it.
Thus, I will just explain how to turn the source code into compiled code, and link to a dropbox of the source code.
Libraries and Tools Used:
	Eclipse https://eclipse.org/ (IDE)
	LWJGL http://www.lwjgl.org/ (low level for Slick, Audio support)
	Slick2D http://slick.ninjacave.com/ (Various Analogs to XNA Classes)
	Jarsplice http://ninjacave.com/jarsplice (Packaging LWJGL libraries into executables)
Running:
	the file JavaYoshi.zip in the dropbox https://www.dropbox.com/sh/d09tnxymrm7virv/AABY5P6W93kZ0-JN7oWG9XBja?dl=0 (too large to reasonably put in XNA) contains the Contents folder and the windows .exe
		Notably, this .zip also contains a copy of the port changelog.
	the file JavaYoshi.jar in the same folder is a universal executable jar file that will run on Windows, Linux, or Mac.
	Unzip, leave the executable in the same folder as the Contents folder, and it will run. (Assuming Java is installed) 
Compiling:
	get Slick2D's zipped package from Slick2D's website.
	Load jinput.jar, lwjgl.jar, lwjgl_util.jar, and slick.jar from that zip into Eclipse as a local library.
	Load the source code, either from dropbox, or from the zip alongside this readme (they are the same zip file), into Eclipse
	It should compile without further hastle. To run in eclipse, ensure the Content folder exists in the same folder src is in.
Packaging:
	In eclipse select Export, select Runnable JAR File, set the 'library handling' option to 'extract required libraries into generated JAR.
	Run jarsplice, give it that generated jar, set the main class as MarioLevel.MainGame. Select all the .dll's and .so's in slick2d's zip package (or just .dll's if you just want a windows build or .so's for a linux build)
	Jarsplice can then generate either or both of an executable on any OS .jar, and a windows .exe. Package alongside the Content folder.