# A-To_Do_List
It's a list of to do things

Once you save the Files in a folder and upload them into Visual Studio, you should be able to run the program with "F5".

Create a file on your desktop named "ToDoList.txt" and copy the path.
OR copy the location of the "ToDoList.txt" file you get from the repository. 
Place the path of the file on line 60 & line 126 between the quotation marks in ToDoListHandler.cs.
For example
C:\Users\User\Desktop\ToDoList.txt
becomes:<br>
string path = "C:\\Users\\User\\Desktop\\ToDoList.txt";<br>
(Note the double slashes - this is correct).

This program will allow you to write notes, view notes, and remove notes from your ToDoList.txt file, and it adds an ID number to each note for removal purposes.

When you intially load up the program and fix the string path in ToDoListHandler.cs, you will have the following options:
 Options
 1) View
 2) Add
 3) Save
 4) Remove
 To select "View", type "1"; to select "Add", type "2"; etc.
 
 "View" will pull up notes in the "ToDoList.txt" file, and notes you added though the "Add" option.
 "Add" allows you to add notes to the list it pulls from the text file. Type "exit" to finish adding(it's not case sensitive).
 Currently, notes are appended at the end of the list, so you cannot type a ToDo item, and place it at the beginning of the file.
 "Save" will write ALL notes to the "ToDoList.txt" file.
 "Remove" pulls up all notes in order with an ID number. Input ONLY the ID number to remove the note.
 
