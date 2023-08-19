List<string> TaskList = new List<string>();

int menuSelected = 0;
do
{
    menuSelected = ShowMainMenu();
    if ((Menu)menuSelected == Menu.Add)
    {
        ShowMenuAdd();
    }
    else if ((Menu)menuSelected == Menu.Remove)
    {
        ShowMenuRemove();
    }
    else if ((Menu)menuSelected == Menu.List)
    {
        ShowMenuTaskList();
    }
} while ((Menu)menuSelected != Menu.Exit);

int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string optionSelected = Console.ReadLine();
    return Convert.ToInt32(optionSelected);
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        ShowMenuTaskList(); // Acá estamos reutilizando el código para no repetir (DRY).

        string optionSelected = Console.ReadLine();
        // Remove one position because the array starts in 0
        int indexToRemove = Convert.ToInt32(optionSelected) - 1;

        if (indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
        {
            Console.WriteLine("El número de tarea seleccionada no es válido");
        }
        else
        {
            if (indexToRemove > -1 && TaskList.Count > 0) // Acá convertimos de doble if a un if con dos condiciones unidas con &&
            {
                string taskSelected = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {taskSelected} eliminada.");
            }
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string taskInput = Console.ReadLine();
        if (string.IsNullOrEmpty(taskInput) == true)
        {
            Console.WriteLine("Se requiere el nombre de la tarea.");
        }
        else
        {
            TaskList.Add(taskInput);
            Console.WriteLine("Tarea registrada.");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al intentar ingresar la tarea.");
    }
}

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0)
    {
        Console.WriteLine("----------------------------------------");
        var indexTask = 1;
        TaskList.ForEach(p => Console.WriteLine($"{indexTask++} . {p}"));
        Console.WriteLine("----------------------------------------");
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar.");
    }
}


public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}
