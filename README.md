# NCOBank

The program begins with the BankMenu class where the user has the options to create a new account or log in to a previously created account. BankMenu also contains a login option for access to admin features.
Once a user has been created, an instance of the user class is stored in a list in BankMenu. An instance of the admin class is also stored in a list in BankMenu.

After successfully logged in as user, the user is sent to the AccountManager class which list all available options for the user.
AccountManager stores the instances of the account classes in a dictionary together with the instance of the user class in order to keep track of the users accounts.  
AccountManager has the following options:
CreateAccount: Creates a personal, savings or currency account.
DisplayAccounts: Displays all of the users accounts as well as the account history for all accounts.
Transfer: Transfer a specified sum between the users accounts or to accounts belonging to a different user.
Loan: Option to apply for a loan.
Depending on the users choice, AccountManager calls the specific class which then completes the task and then return back to AccountManager.

If an admin is logged in as an admin, the admin is instead brougth to the AdminAccess class which gives the admin the following options:
AddUser: Adds a user to the user list.
UnlockUser: The user will be locked out after entering the wrong login details three times. This option resets the login attempts for the user.
SetBalance: When the user creates an account, the balance will be zero. This option allows the admin to change the balance of any of the users account.
UpdateExchangeRate: This option allows the admin to update the exchange rate for the currency accounts.

The TextColor class changes the text color as well as displaying the logo.

UML diagram: https://lucid.app/lucidchart/5ca6b83f-c6cb-4f55-99b4-f2e0c44d0df2/edit?invitationId=inv_753acb8f-43e9-4dbd-9d5f-f51acf0e197c

Authors: Christoffer Ottestig, Niklas Sendelbach and Oskar Åhling.
