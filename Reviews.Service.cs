using Dapper;
using Npgsql;

public class ReviewsService
{
    private string connectionString = "Host=localhost;Port=5432;Database=Movies;Username=postgres;Password=1234";

    public List<Reviews> GetReviewsDapper()
    {
        using var conn = new NpgsqlConnection(connectionString);

        var select = "select * from  reviews";

        var data = conn.Query<Reviews>(select).ToList();

        return data;
    }

    public void AddNewReviewsDapper(Reviews reviews)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var res = conn.Execute("insert into reviews (username, comment, status) values (@username, @comment, @status)" , new {reviews.username, reviews.comment, reviews.status});

        if (res > 0)
            Console.WriteLine("successfully added");
        else
            Console.WriteLine("smth went wrong");
    }


    public void UpdateReviewsDapper(Reviews reviews)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var res = conn.Execute("update reviews set username=@username, comment=@comment, status=@status where id=@id" , new {reviews.id, reviews.username, reviews.comment, reviews.status});

        if (res > 0)
            Console.WriteLine("updated");
        else
            Console.WriteLine("smth went wrong");
    }

    public void DeleteReviewsDapper(int id)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var res = conn.Execute("delete from reviews where id=@id" , new {id});
    }
}