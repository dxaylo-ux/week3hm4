using Npgsql;

public class MoviesService
{
string connectionString = "Host=localhost; Port=5432; Database=Movies; Username=postgres; Password=1234";


public void ShowAllMovies()
{
using var conn = new NpgsqlConnection(connectionString);
conn.Open();

var cmd = new NpgsqlCommand("select * from movies" ,conn);
var data = cmd.ExecuteReader();
while (data.Read())
{
    System.Console.WriteLine(data["id"]+" "+data["titel"]+" "+data["director"]+" "+data["yaer"]);
}
}

public void AddNewMovies(string titel, string director, int yaer)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var command = new NpgsqlCommand(@"insert into movies (titel, director, yaer) values (@Titel, @Director, @Yaer)" ,conn);

        command.Parameters.AddWithValue("Titel", titel);
        command.Parameters.AddWithValue("Director", director);
        command.Parameters.AddWithValue("Year", yaer);

        var res = command.ExecuteNonQuery();

        if (res > 0)
            Console.WriteLine("successfully added");
        else
            Console.WriteLine("smth went wrong");
    }



public void UpdateMovies(int id, string titel, string director, int yaer)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var command = new NpgsqlCommand(@"update movies set titel=@Titel, director=@Director, year=@Year where id=@id" ,conn);

        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("Titel", titel);
        command.Parameters.AddWithValue("Director", director);
        command.Parameters.AddWithValue("Year", yaer);

        var res = command.ExecuteNonQuery();

        if (res > 0)
            Console.WriteLine("updated");
        else
            Console.WriteLine("smth went wrong");
    }


     public void DeleteMovies(int id)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var command = new NpgsqlCommand("delete from movies where id=@id",conn);

        command.Parameters.AddWithValue("@id", id);

        var res = command.ExecuteNonQuery();

        if (res > 0)
            Console.WriteLine("deleted");
        else
            Console.WriteLine("smth went wrong");
    }


}