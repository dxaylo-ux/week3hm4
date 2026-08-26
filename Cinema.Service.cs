using Dapper;
using Npgsql;

public class CinemaService
{
    private string connectionString = "Host=localhost;Port=5432;Database=Movies;Username=postgres;Password=1234";

    public List<Cinema> GetCinemaDapper()
    {
        using var conn = new NpgsqlConnection(connectionString);

        var select = "select * from cinemas";

        var data = conn.Query<Cinema>(select).ToList();

        return data;
    }


    public void AddNewCinemaDapper(Cinema cinema)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var res = conn.Execute("insert into cinemas (name, address, city, phone) values (@name, @address, @city, @phone)",new { cinema.name, cinema.address, cinema.city, cinema.phone });

        if (res > 0)
        {
            Console.WriteLine("successfully added");
        }
        else
        {
            Console.WriteLine("smth went wrong");
        }
    }


    public void UpdateCinemaDapper(Cinema cinema)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var res = conn.Execute("update cinemas set name=@name, address=@address, city=@city, phone=@phone where id=@id", new { cinema.id, cinema.name, cinema.address, cinema.city, cinema.phone });

        if (res > 0)
        {
            Console.WriteLine("successfully updated");
        }
        else
        {
            Console.WriteLine("smth went wrong");
        }
    }


    public void DeleteCinemaDapper(int id)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var res = conn.Execute("delete from cinemas where id=@id", new { id });

        if (res > 0)
        {
            Console.WriteLine("deleted");
        }
        else
        {
            Console.WriteLine("smth went wrong");
        }
    }
}