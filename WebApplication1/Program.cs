using test;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/product{id}", (string id) =>
{
    using (NorthwindContext db = new())
    {
        Product? ans = db.Products.FirstOrDefault(u => u.ProductId==int.Parse(id));
        return Results.Json(ans);
    }
});

app.MapGet("/api/products", () =>
{
    using (NorthwindContext db = new())
    {
        List<Product> ans = new List<Product>();
        for (int i = 1; i < 101; i++)
        {
            Product? temp = db.Products.FirstOrDefault(u => u.ProductId == i);
            ans.Add(temp);
        }

        return ans;
    }
});

app.MapPut("/api/product", (MyProduct data) =>
{
    using (NorthwindContext db = new())
    {
        Product? ans = db.Products.FirstOrDefault(u => u.ProductId == data.id);
        ans.ProductName = data.name;
        int temp =db.SaveChanges();
        Console.WriteLine(temp);
        return Results.Json(ans);
    }
});

app.MapDelete("/api/product/{id}", (string id) =>
{
    using (NorthwindContext db = new())
    {
        Product? ans = db.Products.FirstOrDefault(u => u.ProductId == int.Parse(id));
        db.Products.Remove(ans);
        int temp =db.SaveChanges();
        Console.WriteLine(temp);
        return Results.Json(ans);
    }
});

app.Run();