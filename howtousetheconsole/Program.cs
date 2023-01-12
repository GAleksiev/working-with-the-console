using System;

namespace WorkingWithTheConsole;

internal class Program {
    static void Main(string[] args) {
        WriteLineSample();
        // TODO: Go to the WriteLineExercise method body and write the exercise code
        WriteLineExercise();

        WriteSample();

        // Output two empty lines to separate WriteLine samples output and ReadLine samples
        Console.WriteLine();
        Console.WriteLine();

        ReadLineSample();

        ReadKeySample();

        ReadKeyExercise();
    }

    static void WriteLineSample() {
        Console.WriteLine("Console.WriteLine outputs (writes to the output - in this case the console) a text and automatically adds new line at the end");
        Console.WriteLine("The WriteLine method of the Console class automatically adds new line at the end of the text");
        Console.WriteLine("Text written to the console after it will appear on the next line");
        Console.WriteLine("Console.WriteLine without providing string parameter will output just a new empty line (useful when 'separator' between lines is needed)");
        // This outputs just a new empty  line
        Console.WriteLine();
        Console.WriteLine("Like the above 'Console.WriteLine();'");

        // Console.WriteLine with different types
        Console.WriteLine("Console.WriteLine accepts not only string parameter but also other types of data like booleans, single characters, integers, doubles etc.");
        Console.WriteLine("The below are boolean, single character, integer, double in that order written to the output (the console):");
        bool boolValue = true;
        Console.WriteLine(boolValue);
        char charValue = 'a';
        Console.WriteLine(charValue);
        int intValue = 123;
        Console.WriteLine(intValue);
        double doubleValue = 3.1415;
        Console.WriteLine(doubleValue);

        // Console.WriteLine with parameters
        string administratorName = "John Doe";
        int officeFloor = 3;
        Console.WriteLine("Console.WriteLine can format the provided text with placeholders for variables:");

        // For each "{.}" placeholder in the text a variable (or directly string, boolean, integer etc.) must be provided as parameter
        // The number in the "{.}" placeholder references which variable must be placed there
        // The first variable provided has number 0, the second variable has number 1 etc.
        Console.WriteLine("The administrator is named {0} and can be found at floor {1}", administratorName, officeFloor);

        // Instead of variables a constants can be provided although it does not make much sense
        Console.WriteLine("This kind of formatting does not have practical usage, {0} it uses constants like {1} instead of variables", "because", 123);

        // You can have one placeholder specified multiple times if needed:
        Console.WriteLine("The administrator is named {0} and can be found at floor {1} - again: {1}", administratorName, officeFloor);

        // You could also omit placeholder for some of the variables although this is considered a potential logical problem
        Console.WriteLine("The administrator can be found at floor {1}", administratorName, officeFloor);

        // Not related to Console.WriteLine but there is a better way to use placeholders
        // providing not the position of the parameter but its name directly
        // For this, the character $ must be placed before the opening " of the string
        // and inside {} you put the variable name, not its position in the parameters list.
        // Looks cleaner than usage of {0}, {1} etc.
        Console.WriteLine($"Using $ before the string to output variables like the name {administratorName} and the floor {officeFloor}");
    }

    static void WriteLineExercise() {
        Console.WriteLine("TODO: WriteLine exercise");
        // TODO: Use Console.WriteLine to output a text like this:
        // "We have ... items of the product ..."
        // Instead of the ... show content of int and string variables with values 5 and "keyboard"
        // Sample:
        // int count = ???;
        // string productName = ???;
        // Console.WriteLine(???);
        int count = 5;
        string productName = "keyboard";
        Console.WriteLine($"We have {count} items of the product : {productName}.");
    }

    static void WriteSample() {
        Console.Write("Console.Write is much like Console.WriteLine - it outputs the specified text but does not add new line at the end.");
        // The below lines will output 12345 - each string provided to Console.Write will be shown one after the other
        Console.Write("1");
        Console.Write("2");
        Console.Write("3");
        Console.Write("4");
        Console.Write("5");

        Console.Write("Console.Write can be used with booleans, single characters, integers, doubles etc.:");
        bool boolValue = true;
        Console.Write(boolValue);
        char charValue = 'a';
        Console.Write(charValue);
        int intValue = 123;
        Console.Write(intValue);
        double doubleValue = 3.1415;
        Console.Write(doubleValue);

        Console.Write("Console.Write can format the provided text with placeholders for variables the same way Console.WriteLine does it.");
    }

    static void ReadLineSample() {
        // Console.ReadLine() waits something to be written to the console that ends with new line
        // In our case the user will write to the console by typing on the keyboard
        // Console.ReadLine() will collect all the characters the user types and when the user presses ENTER key
        // Console.ReadLine() will return a string representing what the user has typed
        Console.WriteLine("Enter some text and press ENTER");
        // The type "string?" means it is either a string or null - this is what the Console.ReadLine() returns
        // We can use just "string line = Console.ReadLine();" but we could get (depending on a setting) a warning in Visual Studio:
        // Warning: "Converting null literal or possible null value to non-nullable type"
        // The program will not continue with the lines after the call to Console.ReadLine()
        // Until ENTER key is pressed
        string? line = Console.ReadLine();
        // At this point (after the Console.ReadLine()) we know the ENTER key was pressed and we can use the result in the variable "line"
        Console.WriteLine("You have typed:");
        Console.WriteLine(line);
    }

    static void ReadKeySample() {
        Console.WriteLine("Press a key (you can also try to hold SHIFT, ALT, CTRL or even more than one of them at the same time before pressing). Also try 'non-printable' keys like functional key F1 - F12, arrow keys etc.");
        // Console.ReadKey() waits a single key to be written to the console
        // In our case the user will write to the console by typing on the keyboard
        // Console.ReadKey() returns structure of type ConsoleKeyInfo
        // This is something that contains information for the key like the character typed,
        // whether SHIFT/CTRL/ALT or combination of them were held while the key was pressed
        // The program will not continue with the lines after the call to Console.ReadKey()
        // Until a key is pressed (holding SHIFT/CTRL/ALT does not count as key press - they are called "Modifiers")
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        // At this point (after the Console.ReadKey()) we know the user pressed a key and we can use the result in the variable "keyInfo"
        Console.WriteLine();
        // The KeyChar property of the result (in our case we named the variable that holds the result "keyInfo")
        // contains the char representation of the key
        Console.WriteLine("You pressed {0} (char code {1})", keyInfo.KeyChar, (int)keyInfo.KeyChar);
        // The Modifiers property contains whether SHIFT, ALT or CTRL (or a combination of them) were held when the key was pressed
        Console.WriteLine("The modifiers (SHIFT/CTRL/ALT) were {0}", keyInfo.Modifiers);
        // The Key property is of type ConsoleKey - it is an "enum" type having all possible keys
        // It is useful to know whether some "non-printable" character key was pressed like functional key F1 - F12, 
        Console.WriteLine("The ConsoleKey was {0}", keyInfo.Key);
        // Sample check if the key F1 was pressed
        if (keyInfo.Key == ConsoleKey.F1) {
            Console.WriteLine("You pressed F1");
        }
    }

    static void ReadKeyExercise() {
        Console.WriteLine("TODO: ReadKey exercise");
        // TODO: Call Console.ReadKey() and inspect the key that was pressed and if it is 'x', show something with Console.WriteLine
        // If it is not 'x', show something else with Console.WriteLine
        // Sample:
        // ConsoleKeyInfo cki = Console.ReadKey();
        // if (cki.??? == 'x') {
        //     Console.WriteLine("You pressed 'x'");
        // } else {
        //     Console.WriteLine("You did not press 'x'"); 
        // }
        // ANSWER
        ConsoleKeyInfo wonder = Console.ReadKey();
        if (wonder.KeyChar == 'x ') {
            Console.WriteLine("  You pressed 'x'");
        } else { Console.WriteLine("  You did not press 'x'"); }
    }
}
 