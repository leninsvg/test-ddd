const {PersonRepository} = require('../../infrastructure/personRepository');
const {Identification} = require('../../domain/value-objects/identification');

class PersonService {
    personRepository;

    constructor() {
        this.personRepository = new PersonRepository();
    }

    async getPeople() {
        return await this.personRepository.getPeople();
    }

    async getPerson(identification) {
        return await this.personRepository.getPerson(identification);
    }

    async createPerson(person) {
        const personEntity = {
            identification: Identification.create(person.identification).value,
            lastNames: person.lastNames,
            firstNames: person.firstNames,
            gender: person.gender,
            age: person.age
        };
        return this.personRepository.createPerson(personEntity);
    }

    async updatePerson(identification, person) {
        const personEntity = {
            lastNames: person.lastNames,
            firstNames: person.firstNames,
            gender: person.gender,
            age: person.age
        };
        return this.personRepository.updatePerson(identification, personEntity);
    }

    async deletePerson(identification) {
        return this.personRepository.deletePerson(identification);
    }
}

module.exports = { PersonService }
