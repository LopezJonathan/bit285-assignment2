--Student: Jonathan Lopez
--Course: BIT 285
--Date: Winter 2017

I've created 3 view Models: LoginViewModel, NewAccountViewModel, PasswordGeneratorViewModel.
As for Views there are 3 Views for the "Account" Folder. Each of these views are linked to the previous mentioned View Models. 

The Login.cshtml and LoginViewModel are to allow the User to log into the application with their Username and Password.
	If that user wants to create an account then the user could click on the 'need a new account' link located on the Login.cshtml page.
	
NewAccount.cshtml and NewAccountViewModel will provide a view that the user can input their New Account credentials to be passed into the database via NewAccountViewModel.

The Passwor.cshtml and PasswordGeneratorViewModel give the user the option to input their Lastname, Birthyear, and Favorite color for 5 suggested passwords.

I've also edited the AccountController to work with the Models and create the views.

--NOTE: Still having trouble with Login view and Password view. Both are throwing an Exception Error. May be some logical errors with in my AccountController.cs file and/or the views coding themselves.

*****Self-Assesment*****

* My code is Developing. Still have some debugging left to do to ensure that the application does what it needs to do.
* I feel the naming conventions used are as readable and understandable as possible. Simple enough and relatable to the procedures.
* Documentation is ok. I think there might be some areas that could use more documentation to explain procedures.

Overall Self-Grade - 6/12
I give myself a 2 points in each category for developing.