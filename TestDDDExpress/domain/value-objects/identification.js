class Identification {
    value;

    constructor(value) {
        this.value = value
    }

    static create(value) {
        this.validate(value);
        return new Identification(value);
    }

    static validate(value) {
        if (!value) {
            throw new Error("El valor no puede ser nulo");
        }
        if (value.length !== 10) {
            throw new Error("El identificacion tiene que tener 10 digitos");
        }
    }
}

module.exports = {Identification}
