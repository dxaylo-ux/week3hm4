using Dapper;
using Npgsql;

public class MoviesService
{
    private string connectionString ="Host=localhost;Port=5432;Database=Movies;Username=postgres;Password=1234";

    public List<Movie> GetMoviesDapper()
    {
        var conn = new NpgsqlConnection(connectionString);
        var quary = "select * from movies";
        var data = conn.Query<Movie>(quary).ToList();
        return data;

    }

    public void AddNewMovieDapper(Movie movie)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var res = conn.Execute("insert into movies(titel, director, yaer) values(@titel, @director, @yaer)" , new {movie.Titel, movie.Director, movie.Yaer});

        if (res > 0)
            Console.WriteLine("successfully added");
        else
            Console.WriteLine("smth went wrong");
    }



    public void UpdateMovieDapper(Movie movie)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var res = conn.Execute("update movies set titel=@titel, director=@director, yaer=@yaer where id=@id", new {titel = movie.Titel, director = movie.Director, yaer = movie.Yaer});

        if (res > 0)
            Console.WriteLine("updated");
        else
            Console.WriteLine("smth went wrong");
    }

    public void DeleteMovieDapper(int id)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var res = conn.Execute("delete from movies where id=@id" , id);

        if (res > 0)
            Console.WriteLine("deleted");
        else
            Console.WriteLine("smth went wrong");
    }
}