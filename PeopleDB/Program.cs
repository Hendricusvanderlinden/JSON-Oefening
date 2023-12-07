using PeopleDB;


/*
 * Opdracht: ga op zoek naar de comments die starten met TODO
 * en voeg daar de nodig code toe.
 * De opdrachten zitten in dit bestand, en in het bestand Group.cs
 */

Group group = new Group();
string filePath = "../../../database.json";

// try to load data
LoadFromDisk();

// Menu setup
Menu menu = new Menu();
menu.AddOption('1', "Set Group Name", SetGroupName);
menu.AddOption('2', "Add Person", AddPerson);
menu.AddOption('3', "Show Members", ShowMembers);

menu.Start();

// menu had ended. Save everything
SaveToDisk();


// Hier beginnen de opdrachten
void SetGroupName()
{
    Console.Write("Geef groepsnaam: ");
    string? groepsnaam = Console.ReadLine();
    group.Name = groepsnaam; 
}

void AddPerson()
{
    Person person = new Person();

    Console.Write("Geef de naam, leeftijd en de hobbies: ");

    person.Name = Console.ReadLine();

    person.Age = int.Parse(Console.ReadLine());

    string[] persoonshobbies = Console.ReadLine().Split(',');
    person.Hobbys.AddRange(persoonshobbies);

    group.People.Add(person);
}

void ShowMembers()
{
    Console.WriteLine($"groepsnaam: {group.Name}");
    Console.WriteLine("leden:");

    foreach (var person in group.People)
    {
        Console.WriteLine(person.ToString());
    }
}

void SaveToDisk()
{
    try
    {
        string json = group.Serialize();
        File.WriteAllText(filePath, json);
        Console.WriteLine("Data saved to disk.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error saving data to disk: {ex.Message}");
    }
}

void LoadFromDisk()
{
    try
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            group = Group.Deserialize(json);
            Console.WriteLine("Data loaded from disk.");
        }
        else
        {
            Console.WriteLine("No data file found. Starting with an empty group.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error loading data from disk: {ex.Message}");
    }
}


