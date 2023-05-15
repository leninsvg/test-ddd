import {useEffect, useRef, useState} from 'react';
import {Person} from './Person.jsx';

const url = 'http://localhost:3000/person'

export const People = () => {
    const ref = useRef();
    const [people, setPeople] = useState([])
    const deletePerson = async (index) => {
        await fetch(url + `/${people[index].identification}`, {method: 'DELETE'});
        const auxPeople = [...people];
        auxPeople.splice(index, 1)
        setPeople(auxPeople)
    }

    const updatePerson = async (identification, person) => {
        await fetch(url + `/${identification}`, {
            method: 'PUT',
            headers: new Headers({'content-type': 'application/json'}),
            body: JSON.stringify(person)
        });
        await getPeople()
    }

    const createPerson = async (person) => {
        await fetch(url, {method: 'POST', headers: new Headers({'content-type': 'application/json'}), body: JSON.stringify(person)});
        await getPeople()
        personActionHandler('INSERT', null);
    }

    const personActionHandler = (action, person) => {
        ref.current.personActionHandler(action, person);
    }

    const getPeople = async () => {
        const people = await fetch(url, {method: 'GET'}).then((response) => response.json()).then();
        setPeople(people)
    }

    useEffect(() => {
        getPeople().then()
    }, []);
    return (<>
        <Person updatePerson={updatePerson} createPerson={createPerson} ref={ref}></Person>
        <table>
            <thead>
            <tr>
                <th>Accion</th>
                <th>Cedula</th>
                <th>Nombres</th>
                <th>Apellidos</th>
                <th>Genero</th>
                <th>Edad</th>
            </tr>
            </thead>
            <tbody>
            {people.map((person, index) => (
                <>
                    <tr>
                        <td>
                            <button type="button" onClick={() => personActionHandler('EDITH', person)}>Editar</button>
                            <button type="button" onClick={() => {
                                deletePerson(index)
                            }}>Eliminar
                            </button>
                        </td>
                        <td>{person.identification}</td>
                        <td>{person.firstNames}</td>
                        <td>{person.lastNames}</td>
                        <td>{person.gender}</td>
                        <td>{person.age}</td>
                    </tr>
                </>
            ))}
            </tbody>
        </table>
    </>)
}

