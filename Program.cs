using System;

var service = new MoviesService();

while (true)
{
    Console.WriteLine("=================================================");
    Console.WriteLine("1. Show all movies");
    Console.WriteLine("2. Add movie");
    Console.WriteLine("3. Update movie");
    Console.WriteLine("4. Delete movie");
    Console.WriteLine("0. Exit");
    Console.WriteLine("=================================================");

    var action = Console.ReadLine();

    switch (action)
    {
           
        case "1":
            var movies = service.GetMovies();

            if (movies.Count == 0)
          {
            Console.WriteLine("No movies found");
          }
            else
          {
            foreach (var movie in movies)
          {
            Console.WriteLine($"{movie.Id} | {movie.Titel} | {movie.Director} | {movie.Yaer}");
          }

          }
            break;

        case "2":
            Console.Write("Enter title: ");
            var title = Console.ReadLine()!;

            Console.Write("Enter director: ");
            var director = Console.ReadLine()!;

            Console.Write("Enter year: ");
            var year = int.Parse(Console.ReadLine());

            var newMovie = new Movie
            {
                Titel = title,
                Director = director,
                Yaer = year
            };

            service.AddNewMovie(newMovie);
            break;

        case "3":
            Console.Write("Enter movie id: ");
            var updateId = int.Parse(Console.ReadLine());

            Console.Write("Enter new title: ");
            var newTitle = Console.ReadLine();

            Console.Write("Enter new director: ");
            var newDirector = Console.ReadLine();

            Console.Write("Enter new year: ");
            var newYear = int.Parse(Console.ReadLine());

            var updateMovie = new Movie
            {
                Id = updateId,
                Titel = newTitle,
                Director = newDirector,
                Yaer = newYear
            };

            service.UpdateMovie(updateMovie);
            break;

        case "4":
            Console.Write("Enter movie id: ");
            var deleteId = int.Parse(Console.ReadLine()!);

            service.DeleteMovie(deleteId);
            break;

        case "0":
            return;
    }

}