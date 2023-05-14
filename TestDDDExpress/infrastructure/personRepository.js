const {DataTypes, Sequelize} = require('sequelize');

class PersonRepository {
    sequelize = new Sequelize('TestDDD_DB', 'sa', 'Nada1234*', { host: 'localhost', dialect: 'mssql' });
    person = this.sequelize.define('persons', {
        identification: {
            type: DataTypes.STRING,
            primaryKey: true
        },
        firstNames: DataTypes.STRING,
        lastNames: DataTypes.STRING,
        age: DataTypes.STRING,
        gender: DataTypes.NUMBER,
    }, {
        timestamps: false
    });

    constructor() {
    }

    getPeople = async () => {
        return await this.person.findAll()
    }

    getPerson = async (identification) => {
        return await this.person.findOne({where: {identification}})
    }

    createPerson = async (person) => {
        return await this.person.create(person)
    }

    updatePerson = async (identification, person) => {
        const personEntity = await this.getPerson(identification);
        return await personEntity.update(person)
    }

    deletePerson = async (identification) => {
        return await this.person.destroy({where: {identification}});
    }
}

module.exports = { PersonRepository }
