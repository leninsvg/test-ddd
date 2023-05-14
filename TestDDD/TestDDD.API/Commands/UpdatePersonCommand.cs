namespace TestDDD.API.Commands;

public record UpdatePersonCommand(
    string firstNames,
    string lastNames,
    int age,
    string gender);