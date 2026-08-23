using Npgsql;

public class MoviesService
{
    private string connectionString =   "Host=localhost;Port=5432;Database=Movies;Username=postgres;Password=1234";

    public List<Movie> GetMovies()
    {
        List<Movie> movies = new();

        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var cmd = new NpgsqlCommand("select * from movies", conn);
        var data = cmd.ExecuteReader();

        while (data.Read())
        {
            var movie = new Movie()
            {
                Id = data.GetInt32(0),
                Titel = data.GetString(1),
                Director = data.GetString(2),
                Yaer = data.GetInt32(3)
            };

            movies.Add(movie);
        }

        return movies;
    }

    public void AddNewMovie(Movie movie)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var command = new NpgsqlCommand(
            "insert into movies(titel, director, yaer) values(@titel, @director, @yaer)",
            conn);

        command.Parameters.AddWithValue("titel", movie.Titel);
        command.Parameters.AddWithValue("director", movie.Director);
        command.Parameters.AddWithValue("yaer", movie.Yaer);

        var res = command.ExecuteNonQuery();

        if (res > 0)
            Console.WriteLine("successfully added");
        else
            Console.WriteLine("smth went wrong");
    }

    public void UpdateMovie(Movie movie)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var command = new NpgsqlCommand(
            "update movies set titel=@titel, director=@director, yaer=@yaer where id=@id",
            conn);

        command.Parameters.AddWithValue("id", movie.Id);
        command.Parameters.AddWithValue("titel", movie.Titel);
        command.Parameters.AddWithValue("director", movie.Director);
        command.Parameters.AddWithValue("yaer", movie.Yaer);

        var res = command.ExecuteNonQuery();

        if (res > 0)
            Console.WriteLine("updated");
        else
            Console.WriteLine("smth went wrong");
    }

    public void DeleteMovie(int id)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var command = new NpgsqlCommand(
            "delete from movies where id=@id",
            conn);

        command.Parameters.AddWithValue("id", id);

        var res = command.ExecuteNonQuery();

        if (res > 0)
            Console.WriteLine("deleted");
        else
            Console.WriteLine("smth went wrong");
    }
}