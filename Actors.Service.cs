using Dapper;
using Npgsql;

public class ActorsService
{
    private string connectionString = "Host=localhost;Port=5432;Database=Movies;Username=postgres;Password=1234";

    public List<Actors> GetAciorsDapper()
    {
        using var conn = new NpgsqlConnection(connectionString);

        var select = "select * from actors";
        
        var data = conn.Query<Actors>(select).ToList();

        return data;
    }


    public void AddNewActorsDapper(Actors actors)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var res = conn.Execute("insert into actors (name, surname, country, gender) values (@name, @surname, @country, @gender)" , new {actors.name, actors.surname, actors.country, actors.gender});

        if (res > 0)
        {
            Console.WriteLine("successfully added");
        }
        else
        {
            Console.WriteLine("smth went wrong");
        }
    }


    public void UpdateActorsDapper(Actors actors)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var res = conn.Execute("update actors set name=@name, surname=@surname, country=@country, gender=@gender where id=@id" , new {actors.name, actors.surname, actors.country, actors.gender});

        if (res > 0)
        {
            Console.WriteLine("successfully added");
        }
        else
        {
            Console.WriteLine("smth went wrong");
        }
    }


    public void DeleteActorsDapper(int id)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var res = conn.Execute("delete from actors where id=@id" , new {id});

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