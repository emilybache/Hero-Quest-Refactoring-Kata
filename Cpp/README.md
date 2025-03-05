# Hero Quest Refactoring Kata in C / C++

**Variant:** The data is passed by reference, using pointers for all parameters.

The starting code is in C but we are using a C++ compiler and the files are already named .cpp so you can easily move to using C++.

**Scenario:** We are looking to migrate this code from C to C++. The basic part is done - we have a Cpp compiler in place. The more difficult part is to change the _style_ of the code and take advantage of C++ features like encapsulation.

* [ ] Run `main.cpp` and check the output looks ok 
  * Use the green arrow next to the function declaration
  * Confirmation: See the output showing data about Conan and the Amulet of Strength
* [ ] Run the unit tests in `quest_catch.cpp`
  * Use the green arrow next to the test case declaration
  * Confirmation: See the tests run and pass in the IDE test runner
* [ ] Identify Data Clump code smells
  * Read the method signatures in `quest.h`. Find global variables which clump together in function argument lists.
  * These data clumps will form the basis of C++ classes.
  * Confirmation: Two Data Clumps identified.
* [ ] Pick the simplest/smallest data clump and create a new C++ class for it
  * [ ] Create a new empty C++ class (use CLion - right click on the project 'new C++ class')
  * [ ] Name the new class - suggest you use a word used in the variable names of the data clump.
  * [ ] Add new public data fields for all the global variables we want to move to the class
  * Confirmation: the code compiles, including the new class. It is not yet being used anywhere
* [ ] Create a constructor and use it to create an instance of the class
  * [ ] Generate a constructor that will populate all the data fields (on the Code menu)
  * [ ] Add a new global variable in `quest.cpp` containing a new instance of the class. (Use the constructor)
  * [ ] Make the new global variable available in `quest.h` by declaring it there too as `extern`.
  * Confirmation: all the code compiles and the tests pass. New global is not used.
* [ ] Add the new class to all the method signatures alongside the data clump (Parallel Change)
  * [ ] Use 'change signature' refactoring.
  * [ ] Pass the new instance
  * Confirmation: all the code compiles. The new method parameter is not being used yet.
* [ ] Use the new class instance instead of the global variables
  * [ ] Use search and replace - a reference to x is replaced by instanceName.x
  * Confirmation: all the code compiles and the tests pass
* [ ] Remove the data clump from the method signature
  * [ ] Use 'change signature' refactoring
  * Confirmation: the global variables are unused and the tool confirms this when you 'search for references'. If there are further references, repeat the steps above to replace them with references to the new class.
* [ ] Remove the global variables that are replaced by the new class
  * Confirmation: the tests still pass and the output from main is still the same.
* [ ] Encapsulate the global data in the new class
  * [ ] Declare a new method on the class with the same name as the global function that uses it.
  * [ ] Call the global function from the new method
  * [ ] Update all the places that call the global function to instead call the class method
  * [ ] Inline the global function and remove the original
  * [ ] Repeat for any other functions using the class
  * Confirmation: the code compiles, the tests pass, and you can make the class's fields private.
* [ ] Repeat for the other data clump.
  * Confirmation: The only global data left is instances of two classes. All the original global variables are encapsulated inside these classes.
