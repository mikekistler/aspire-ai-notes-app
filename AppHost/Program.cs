var builder = DistributedApplication.CreateBuilder(args);

var notesapi = builder.AddProject<Projects.NotesApi>("notesapi");

builder.AddProject<Projects.WebFrontend>("webfrontend")
    .WithReference(notesapi);

builder.Build().Run();