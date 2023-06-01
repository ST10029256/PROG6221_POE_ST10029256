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

1. Enter if you would like to listern to music, by entering yes or no.
2. Choose one of the 5 listed options, but in most cases you would choose option 1 to enter a recipe.
3. Enter how many ingredients you wish to create.
4. Enter the quantity of the number of ingredient.
5. Enter the unit of mesurement of the ingredient by typing in one of the following:
"cups", "cup", "tablespoons", "tablespoon", "teaspoons" , "teaspoon", "ml", "l", "gallon", "gallons".

6. Enter the name of the ingredient.
7. Enter the number of steps for your ingredient.
8. Enter instruction/s for your ingredient.
9. You are now able to display your ingredient by entering option 2 or scale your ingredient by choosing option 3 or enter a new recipe by entering number 4 or exit the program by entering number 5.
10. if you chose option 2, you will see your ingredient list with the instructions printed out.
11.if you chose option 3, you will be asked if you would like to scale the recipe 
11. if you enter yes in caps or lowercase, you will be greeted with a menu to "Half", "Double", "Tripple" or "Reset" your current ingredient list.
12. With choosing option 1 - 3 your ingredient/s will be converted to more accurite unit of mesurement.
13. By choosing option 4, your ingredient/s will be reset to the defaut value.
14. You will once again be able to display the new recipe with the quantity scale or default value if chosen option 4 in the previous step.
15. You are able to continue with repeating the steps or choose a new recipe if wanting to start over.
16. If not so, you can choose option 5 to exit the application

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
