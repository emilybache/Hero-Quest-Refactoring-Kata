---
name: data-clump-to-class
description: Refactor a repeated primitive parameter/field group into a class using Parallel Change
---

* Stack replies with emoji: 🍟
* Prefer a Parallel Change strategy over big-bang rewrites.

## Goal

Replace a repeated set of related primitives (a data clump) with a class while keeping behavior stable.

## Process

1. Find the clump
    * Identify fields/parameters that repeatedly appear together.
    * Name the domain concept they represent.

2. Introduce the class
    * Create a class with the clump members.
    * Keep original fields/parameters unchanged for now.
    * Test and Commit

3. Add parallel state
    * Instantiate the new class everywhere the old clump is currently instantiated.
    * Test and Commit

4. Pick one method that includes and old data clump and migrate it.
    * Refactor the method signature to add a new parameter for the new class.
    * Update all the call sites to pass a suitable instance of the new class
    * Any updates to the old data clump within that method should also update the new class. Continue to return the old data clump though.
    * Test and Commit

5. Repeat step 4 for other methods until all uses of the old data clump also use the new class

6. Cut over to also returning the new class
    * Everywhere it was using the old data, use the new class instead. Keep the old data clump around until it is no longer used anywhere, then delete it.
    * Test and commit

7. Verify
    * Evaluate whether the new design looks better than the old one, summarize your findings and ask the user for further instructions.

