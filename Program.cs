var service = new MoviesService();

while (true)
{
    System.Console.WriteLine("============================================================");
    System.Console.WriteLine(@"1-Show all movies
2-Add new movies
3-Update movies description
4-Delete movies
0-Exit");

System.Console.WriteLine("============================================================");

var action = Console.ReadLine();

switch (action)
{
    case "1":
        service.ShowAllMovies();
        break;

    case "2":
        Console.Write("Enter movie title: ");
        var titel = Console.ReadLine();

        Console.Write("Enter director: ");
        var director = Console.ReadLine();

        Console.Write("Enter year: ");
        var year = Convert.ToInt32(Console.ReadLine());

        service.AddNewMovies(titel, director, year);
        break;

    case "3":
        Console.Write("Enter movie id: ");
        var id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter new movie title: ");
        var newTitel = Console.ReadLine();

        Console.Write("Enter new director: ");
        var newDirector = Console.ReadLine();

        Console.Write("Enter new year: ");
        var newYear = Convert.ToInt32(Console.ReadLine());

        service.UpdateMovies(id, newTitel, newDirector, newYear);
        break;

    case "4":
        Console.Write("Enter movie id: ");
        var idd = Convert.ToInt32(Console.ReadLine());

        service.DeleteMovies(idd);
        break;

    case "5":
        return;
}


}