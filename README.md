# PROG6221_POE_ST10029256

This program allows a user to to set up an ingredient list, where the user is able to convert different
measurements to create a more consistant ingredient list. This program is for anyone to create a recipe
and in this case for the lecturer that will mark the POE.

## Created by:

This prgram is created by Dylan Louis Miller ST10029256 second year student from Varcity College.

## Installation:

* Make sure that you have ".NET Framework 4.8" installed on your machine

The following is the process of installing the application:

1. Download the zip folder from GitHub or VC learn.
2. Unzip the folder.
3. Open the solution file "PROG6221_POE_ST10029256.sln" in  visual studio
4. Build the solution using the build menu.

## Running the program:

1. Navigate to the folder where you unzipped the project.
2. Open "PROG6221_POE_ST10029256".
3. Open bin folder.
5. Open default folder.
6. Open "PROG6221_POE_ST10029256.exe".

## Using the program:

1. You will be greeted with a "welcome to the application" message, press the Enter key to continue.
2. Enter if you would like to listern to music, by entering yes or no.
3. Choose one of the 5 listed options, but in most cases you would choose option 1 to enter a recipe.
4. Enter yes or no to enter a recipe.
5. Enter the name of the recipe.
6. Enter how many ingredients you wish to create.
7. Enter the quantity of the number of ingredient.
8. Enter the unit of mesurement of the ingredient by typing in one of the following: "cups", "cup", "tablespoons", "tablespoon", "teaspoons" , "teaspoon", "ml", "l", "gallon", "gallons".
9. Enter number of calories for the ingredient.
10. Select a food group from the list provided by entering a number between 0 and 9.
11. If number 8 is chosen you will be greeted with a screen to view a food group you wish to see more information on.
12. If any other number is chosen between the numbers provided at step 10 yu can enter the number of steps for your ingredient
13. You can add a recipe by entering yes and follow to same process as the steps provided above or you can continue by entering no.
14. If chosen no you will then be greeted with the MainMenu and can display, scale, clear the recipe or exit the application.
15. If option 2 is entered you will be asked to chosse which recipe you wish to display and if chosen which recipe to display your recipe will be printed out with all reletive information you entered.
16. Once again you will be greeted with the MainMenu and can repeat the above step for other recipes or continue.
17. If you chose option 3, you will be asked to choose which recipe to scale and to confirm if you would like to proceed scaling your recipe.
18. If you enter yes in caps or lowercase, you will be greeted with a menu to "Half", "Double", "Tripple" or "Reset" your current ingredient list.
19. With choosing option 1 - 3 your ingredient/s will be converted to more accurite unit of mesurement.
20. By choosing option 4, your ingredient/s will be reset to the defaut value.
21. You will once again be able to display the new recipe with the quantity scale or default value if chosen option 4 in the previous step.
22. You are able to continue with repeating the steps or clear a recipe by entering option 4 in the MainMenu.
23. If option 4 is chosen you are able to delete a recipe.
24. You will be asked to confirm this by entering yes or no, if chosen yes your recipe will be deleted and will be confirmed by a message stating "successfully cleared" and if no "clearing request cancelled".
25. You will then once again reverted to the MainMenu to enter a new ingredient or you can choose option 5 to exit the application and be dismisssed with a "Thank you for using the application" message.

## Feedback changes and why:

1. Added more info on what unit of measurement the user can enter, I've added this as this makes it more understandible for the user on what to enter.
2. Added a welcome, thank you and other display features like the "-", I've done this to improve my overall program experience and over all look of the application.
3. Added the user to confirm if the user wants to clear the data, I've done this to handle entering of data better.
4. Added more comments, I've done this to help others understand the logic and flow of my code better.
5. I added code to ensure that the program doesnt end after scaling, for the user to re-select an option from the menu.
6. I added code to the menu that will give the user an option to 'clear' a recipe, for the user to successfully clear the data and add a new recipe.
7. I lost marks for my ReadMe file, I dont agree with this statement as the feedback said "excellent" but 3 marks were deducted.
8. I lost marks for logical classes. I dont agree with this, as I made use of a step classto retrieve the steps, ingredient class to retrieve the ingredient details and worker class where all the calculations and displays are coded.
9. I lost marks by making use of gallons, I disagree, as why I made use of gallons is to convert the unit of measurement one step further. (12 teaspoons) x 2 = (8 tablespoons) x 2 = (1 Cup), but if the user enters (8 Cups) x 2 = (1 gallon).

## Feedback Part2 Changes and why

1. Be able to capture unlimimited number of everything. No need to ask the user how many elements to capture when using the generic collections , enter till stop, I could have implemented this better to make the user experience better.
2. Display all list details in alphabetic order , the chose to display one must work as it is. When displaying all, don’t just show the names, As a coder, it is crucial for the user to have the functionality to view all the details of a list in alphabetical order, while also being able to choose to display a single item in its entirety, rather than just showing the name when viewing all the items.
3. The 300-calorie notification is excellently implemented using a delegate. The program flow continues smoothly after the notification, 9/10 was given and from the feedback I am confused to why 9/10 and not full marks?
4. An excellent readme file is included that explains all the required details about running the app, same here 8/10 credited but excellent Readme file is implemented and app is running smoothly.



