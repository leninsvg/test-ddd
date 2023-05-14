namespace TestDDD.Domain.ValueObjects;

public record Identification()
{
    public string Value { get; }

    private Identification(string value) : this()
    {
        this.Value = value;
    }

    public static Identification Create(string value)
    {
        Validate(value);
        return new Identification(value);
    }


    private static void Validate(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException("El valor no puede ser nulo");
        }
        if (value.Length != 10)
        {
            throw new ArgumentNullException("El identificacion tiene que tener 10 digitos");
        }
    }
}