To make testing easier for us, we decided not to create a new Unit Tests project.
Performing all the tests inside the same project means we don't have to have references to game content
that isn't loaded unless the game runs.
Instead, our tests are defined in this folder and then instantiated and called in the Sprint2 class
if a boolean variable is set to true.
The tests all use assertions and so the game will not run if they aren't true.
We also print a success messages to the console for each test class success.