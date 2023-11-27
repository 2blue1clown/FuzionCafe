# After the Buzzer Realisation
I now realise that I did not apply the Dependency Injection principle as fully as I would have liked. Having my Waiter class depend on the Bill, Menu and ItemOrderInfo classes directly is not optimal. 

While it adds a fair bit more complexity... I could have injected the IMenu through the waiter's constructor. To inject the Bill and ItemOrderInfo classes I could have a IBillFactory that gets injected into the constructor gives access to an IBill, and the same with an IItemOrderInfoFactory to give access to IITemOrderInfoFactory.

# FuzionCafe

Time available: 2 hrs

The Problem: The Fuzion café is going digital! Write an application that allows the user to order 1 or
more items from a menu and give them the bill at the end.

Solution requirements: The solution should be written in C# (preferable), JavaScript or Python. Use
up only the available time to develop. And come with unit tests.
It is your choice what type of application to deliver (mobile, web, desktop, console, other) and how
simple or complex you make it, however we are looking for quality of design and code over complex
or copious features. As an example, make sure you’ve properly implemented unit tests on the simple
core before developing the next feature. 


I used a bit of extra time because Tim said I could use 4hrs if I really wanted (sorry)
