namespace TestDDD.API.Commands;

public record CreatePersonCommand(
    string identification,
    string firstNames,
    string lastNames,
    int age,
    string gender);