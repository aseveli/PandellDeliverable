# PandellDeliverable
My Approach

First thing I did was try to figure out how to solve the core of the problem in the most efficient way possible.  
In my mind the core issue was how to randomize the list of sequential integers in the least amount of space and time (processing) possible.

My naive approach was to have two integer lists.  The first list, let's call it the sequential list, would be filled with integers from 1 to 10000 sequentially.
The second list, let's call it the randomized list, would be used to hold the integers I randomally selected from the sequential list.  

My initial thought was to randomly choose an index between 1 and the end of the sequential list (10000 intially).
I would then remove this element from the sequential list and add it to the randomized list.
I would then repeat this process of randomly choosing an index between 1 and the end of the sequential list until there were no further
elements left in the sequential list to process, and the randomized list would contain all the original elements but in a randomized order.

I then did a little bit of research to see if my approach was the best or not.
I came across the Fisher-Yates algorithm which I thought was a clever approach to this type of shuffle.
I changed my code so the randomized list was not necessary and the randomization was done in place on the sequential list itself.

The way the algorithm works is that a index is selected between 1 and the end of the list.
That element is then swapped with the last element of the list, and the end of the list is decremented by one.  This continues until all elements have been processed resulting in the elements being shuffled in place randomly with no need for an extra list.  I felt this was a better approach to my intial attempt.

Next I thought about the final implementation of this problem as a whole and how to present it.  Since I was using C# to code this problem, my first thought was to create an extension method which would allow me to add this functionality using generics to any list object implementing the IList interface.  This would make it more useful in the long run as I could use this code on any object implementing IList regardless of the data type being used.  I also created a second extension method that allowed me to swap two elements in any object that implemented the IList interface which I felt helped improve the readability of my code and gave me some extra functionality not available in the IList interface.

This now was the probably the hardest part of the problem :) I thought about not using extension methods and instead creating an abstract base class that contained the generic code I had already created.  I could then create an inheriting class that would implement the integer type specific to the problem.  You could then also create other inheriting classes for other specific data types but I felt this wasn't as useful as it could be and would just be over-engineering the problem. So I stuck with my original approach of using extension methods.

The functionality I created is more of a utility piece of code that could be used to enhance the already existing IList interface.

The only other thing of note is that the pseudorandom number generator used in the extension class uses a singleton type approach.  It's only created once when the static extension class is referenced.  The reason for this approach is that the RNG (random number generator) can produce identical sequences of random numbers if multiple instances are instantiated in a tight loop. The better approach is to only instantiate one RNG object and use sequential calls to it for generating random numbers.

Thank you for taking the time to view my submission.

Todd Pinel.
