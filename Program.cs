//OM SARAVANABAVA

/*
Folder Maker
Creates folders using iteration
Get user input for the directory where the folders needs to be created.
Gets folder name, and a start number and end number to suffix
by default start number is 1 and the end number should be greater than the start number for the code to continue.
Folders will be created with the name and suffix.
if folder exists, prompts for skip or replace, based on the user input action will be taken
*/

using System.Reflection.Emit;
using System.Runtime.CompilerServices;

Console.OutputEncoding = System.Text.Encoding.UTF8; //Displays unicode characters on the console

Console.WriteLine("\nHello! Welcome to folder maker 😀");
Console.WriteLine("This application, lets you to create series of folders quickly.");
Console.WriteLine("You can exit the application at any point by pressing ctrl+c\n");
bool run = true;

do
{
    Console.WriteLine("Enter/Paste the directory where you need to create the folders. (Use ctrl+ \u21E7shift +v to paste or copy the path and right click on the console)\n"
    //U+21E7 is the unicode for ⇧ shift key
    + $"Example: {Directory.GetCurrentDirectory()}");
    string? directory = GetValidDirectory();

    Console.Write("Enter the name of the folder: ");
    string? folderName = Console.ReadLine();
    Console.WriteLine();
    folderName = folderName == null ? "" : folderName;
    Console.WriteLine($"Do you want to start from 1?\nexample: {folderName} 1 will be name of the first folder:");

    List<string> options = ["y", "n", "Y", "N"];
    Console.Write($"Enter Y to continue or N to enter a different start number.(Y/N): ");
    string userOption = GetValidOption(options).ToLower();


    int startNumber = 1;
    if (userOption == "n")
    {
        Console.Write("Enter the start number: ");
        startNumber = GetValidNumber();
    }

    Console.Write("Enter the end number: ");

    int endNumber = 0;
    do
    {
        endNumber = GetValidNumber();
    } while (endNumber < startNumber);

    for (int folderNumber = startNumber; folderNumber <= endNumber; folderNumber++)
    {
        var folder = Path.Combine(directory, $"{folderName} {folderNumber}");
        if (Directory.Exists(folder))
        {
            options = ["s", "r", "S", "R"];
            Console.Write($"{folderName} {folderNumber} exists, Enter 'S' to skip or 'R' to Replace (S/R): ");
            userOption = GetValidOption(options);
            string option = userOption.ToLower();
            if (option == "s")
                continue;
        };
        Directory.CreateDirectory(Path.Combine(directory, $"{folderName} {folderNumber}"));

    }
    Console.WriteLine("Folders created successfully!!! Please check the directory.\n");

    Console.Write("Enter 0 to exit the application or 1 to rerun (0/1): ");
    options = ["0", "1"];
    userOption = GetValidOption(options);
    if (userOption == "0")
    {
        run = false;
        Environment.Exit(0);
    }
    else if (userOption == "1")
        Console.Clear();

} while (run);


static int GetValidNumber() //gets a valid integer from the user
{
    bool NumberValidty = false;
    int number = 0;
    while (NumberValidty == false)
    {
        string? NumberByUser = Console.ReadLine();
        NumberValidty = int.TryParse(NumberByUser, out number);

        if (NumberValidty == false)
            Console.WriteLine("Enter a valid number.");
    }
    return number;
}

static string GetValidOption(List<string> options) //gets a valid option from the user
{
    bool optionValidty = false;
    string? optionByUser = " ";
    while (optionValidty == false)
    {
        optionByUser = Console.ReadLine();
        if (optionByUser != null)
            optionValidty = options.Contains(optionByUser.Trim());

        if (optionValidty == false)
            Console.WriteLine("Enter a valid option.");
    }
    if (optionByUser != null)
        return optionByUser;
    else
        return options[0];
}

static string GetValidDirectory() //gets a valid option from the user
{
    bool doesDirectoryExist = false;
    string? userDirectory = "";
    while (doesDirectoryExist == false)
    {
        userDirectory = Console.ReadLine();
        if (userDirectory != null)
            doesDirectoryExist = Directory.Exists(userDirectory);

        if (doesDirectoryExist == false)
            Console.WriteLine("Enter a valid Directory.");
    }
    if (userDirectory != null)
        return userDirectory;
    else
        return Directory.GetCurrentDirectory();
}