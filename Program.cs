using System;

var service = new MoviesService();
var servicee = new CinemaService();
var serviceee = new ReviewsService();
var serviceeee = new ActorsService();


while (true)
{
    Console.WriteLine("=================================================");
    Console.WriteLine("1. Show all movies");
    Console.WriteLine("2. Add movie");
    Console.WriteLine("3. Update movie");
    Console.WriteLine("4. Delete movie");
    Console.WriteLine("5. Show all cinema");
    Console.WriteLine("6. Add cinema");
    Console.WriteLine("7. Update cinema");
    Console.WriteLine("8. Delete cinema");
    Console.WriteLine("9. Show all reviews");
    Console.WriteLine("10. Add reviews");
    Console.WriteLine("11. Update reviews");
    Console.WriteLine("12. Delete reviews");
    Console.WriteLine("13. Show all movies");
    Console.WriteLine("14. Add movie");
    Console.WriteLine("15. Update movie");
    Console.WriteLine("16. Delete movie");
    Console.WriteLine("0. Exit");
    Console.WriteLine("=================================================");

    var action = Console.ReadLine();

    switch (action)
    {
           
        case "1":
            var movies = service.GetMoviesDapper();

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

            service.AddNewMovieDapper(newMovie);
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

            service.UpdateMovieDapper(updateMovie);
            break;

        case "4":
            Console.Write("Enter movie id: ");
            var deleteId = int.Parse(Console.ReadLine()!);

            service.DeleteMovieDapper(deleteId);
            break;

        case "5":
            var cinemas = servicee.GetCinemaDapper();

            foreach (var cinema in cinemas)
            {
                Console.WriteLine( $"{cinema.id} | {cinema.name} | {cinema.address} | {cinema.city} | {cinema.phone}"
                );
            }
            break;

             case "6":
            Console.Write("Enter name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter address: ");
            string? address = Console.ReadLine();

            Console.Write("Enter city: ");
            string? city = Console.ReadLine();

            Console.Write("Enter phone: ");
            string? phone = Console.ReadLine();

            Cinema newCinema = new Cinema
            {
                name = name,
                address = address,
                city = city,
                phone = phone
            };

            servicee.AddNewCinemaDapper(newCinema);
            break;

             case "7":
            Console.Write("Enter cinema id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter new name: ");
            string? newName = Console.ReadLine();

            Console.Write("Enter new address: ");
            string? newAddress = Console.ReadLine();

            Console.Write("Enter new city: ");
            string? newCity = Console.ReadLine();

            Console.Write("Enter new phone: ");
            string? newPhone = Console.ReadLine();

            Cinema updateCinema = new Cinema
            {
                id = id,
                name = newName,
                address = newAddress,
                city = newCity,
                phone = newPhone
            };

            servicee.UpdateCinemaDapper(updateCinema);
            break;

        case "8":
            Console.Write("Enter movie id: ");
            var deleteIdd = int.Parse(Console.ReadLine()!);

            service.DeleteMovieDapper(deleteIdd);
            break;
       
        case "9":
            var reviews = serviceee.GetReviewsDapper();

            foreach (var review in reviews)
            {
            Console.WriteLine( $" {review.id} | {review.username} | {review.comment} | {review.status}");
            }
            break;


        case "10":
            Console.Write("Enter username: ");
            string? username = Console.ReadLine();

            Console.Write("Enter comment: ");
            string? comment = Console.ReadLine();

            Console.Write("Enter status: ");
            string? status = Console.ReadLine();

            Reviews newReview = new Reviews
            {
                username = username,
                comment = comment,
                status = status
            };

            serviceee.AddNewReviewsDapper(newReview);
            break;


        case "11":
            Console.Write("Enter review id: ");
            int idd = int.Parse(Console.ReadLine()!);

            Console.Write("Enter new username: ");
            string? newUsername = Console.ReadLine();

            Console.Write("Enter new comment: ");
            string? newComment = Console.ReadLine();

            Console.Write("Enter new status: ");
            string? newStatus = Console.ReadLine();

            Reviews updateReview = new Reviews
            {
                id = idd,
                username = newUsername,
                comment = newComment,
                status = newStatus
            };

            serviceee.UpdateReviewsDapper(updateReview);
            break;


        case "12":
            Console.Write("Enter review id to delete: ");
            int deleteIddd = int.Parse(Console.ReadLine()!);

            serviceee.DeleteReviewsDapper(deleteIddd);
            break;

        case "13":
            var actors = serviceeee.GetAciorsDapper();

            foreach (var actor in actors)
            {
                Console.WriteLine($"{actor.id} | {actor.name} | {actor.surname} | {actor.country} | {actor.gender}" );
            }
            break;


        case "14":
            Console.Write("Enter name: ");
            string? namme = Console.ReadLine();

            Console.Write("Enter surname: ");
            string? surname = Console.ReadLine();

            Console.Write("Enter country: ");
            string? country = Console.ReadLine();

            Console.Write("Enter gender: ");
            string? gender = Console.ReadLine();

            Actors newActor = new Actors
            {
                name = namme,
                surname = surname,
                country = country,
                gender = gender
            };

            serviceeee.AddNewActorsDapper(newActor);
            break;


        case "15":
            Console.Write("Enter actor id: ");
            int actorId = int.Parse(Console.ReadLine()!);

            Console.Write("Enter new name: ");
            string? newNname = Console.ReadLine();

            Console.Write("Enter new surname: ");
            string? newSurname = Console.ReadLine();

            Console.Write("Enter new country: ");
            string? newCountry = Console.ReadLine();

            Console.Write("Enter new gender: ");
            string? newGender = Console.ReadLine();

            Actors updateActor = new Actors
            {
                id = actorId,
                name = newNname,
                surname = newSurname,
                country = newCountry,
                gender = newGender
            };

            serviceeee.UpdateActorsDapper(updateActor);
            break;


        case "16":
            Console.Write("Enter actor id to delete: ");
            int deleteIid = int.Parse(Console.ReadLine()!);

            serviceeee.DeleteActorsDapper(deleteIid);
            break;

        case "0":
            return;
    }

}