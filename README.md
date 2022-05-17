# StratosPattasAssesment
WPF app (.Net framework)

Login Window : use one single user, the credentials can be hard coded to check the input ones for the authentication.

Main Window :

Display the fields for just one record  customerid , first name, last name, address, phone, comments.

                               

Only field comments should be editable.

When ‘comments’ text is changed, a button ‘Save’ should be visible, and on button Save click, save the new value to DB.

                               

Display a field/Dropdown menu with available values : Result1, Result2, Result3
When a value is selected, automatically save it to Table2.

*On table2 use a unique id generated from the wpf app, and each record should be related to Table1.

 

Nice to have : Logging mechanism (e.g write to log file for each login, or when a value is inserted to a table) using NLog.

 

Ø  DB (SQL Server)

Use two tables one for basic contact information, and one to store the selected values from the Dropdown menu.
