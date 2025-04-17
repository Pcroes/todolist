﻿var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var todos = new List<string>();

app.MapGet(""/"", () => todos);

app.MapPost(""/add"", (string task) =>
{
    todos.Add(task);
    return Results.Ok(todos);
});

app.MapDelete(""/delete/{index}"", (int index) =>
{
    if (index >= 0 && index < todos.Count)
    {
        todos.RemoveAt(index);
        return Results.Ok(todos);
    }

    return Results.BadRequest(""Invalid index"");
});

app.Run();
