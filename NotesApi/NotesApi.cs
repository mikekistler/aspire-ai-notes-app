
using Microsoft.AspNetCore.Http.HttpResults;

internal static class NotesApi
{
    private static Dictionary<int, Note> notes = new Note[]
    {
        new Note { Id = 1, Title = "First Note", Content = "This is the first note"},
        new Note { Id = 2, Title = "Second Note", Content = "This is the second note"},
    }.ToDictionary(note => note.Id);

    public static RouteGroupBuilder MapNotes(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/notes");

        group.WithTags("Notes");

        group.MapGet("/", () =>
        {
            return Results.Ok(notes);
        });

        group.MapGet("/{id}", (int id) =>
        {
            if (!notes.ContainsKey(id))
            {
                return Results.NotFound();
            }
            return Results.Ok(notes[id]);
        });

        group.MapPut("/{id}", (int id, Note Note) =>
        {
            notes[id] = Note;
            return Results.Ok(Note);
        });

        group.MapDelete("/{id}", (int id) =>
        {
            if (!notes.ContainsKey(id))
            {
                return Results.NotFound();
            }
            notes.Remove(id);
            return Results.NoContent();
        });

        return group;
    }
}