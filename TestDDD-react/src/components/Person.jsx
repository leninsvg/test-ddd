import {forwardRef, useImperativeHandle, useState} from 'react';
import PropTypes from 'prop-types';

const newPerson = {
    identification: '',
    firstNames: '',
    lastNames: '',
    gender: '',
    age: 0
};
// eslint-disable-next-line react/display-name
export const Person = forwardRef((
    {updatePerson, createPerson}, ref
) => {
    const [personForm, setPersonForm] = useState(newPerson);
    const [personAction, setPersonAction] = useState('INSERT');
    const {identification, firstNames, lastNames, gender, age} = personForm

    const onInputChange = ({target}) => {
        const {name, value} = target;
        setPersonForm({
            ...personForm,
            [name]: value
        })
    }

    const personActionHandler = (action, payload) => {
        setPersonAction(action)
        if (payload) {
            setPersonForm(payload)
        } else {
            setPersonForm(newPerson)
        }
    }

    useImperativeHandle(ref, () => ({
        personActionHandler
    }))

    return (<>
        <h1>{personAction}</h1>
        <div>
            <label htmlFor="">Cedula</label>
            <input type="text" name="identification"
                   value={identification} onChange={onInputChange}/>
        </div>
        <div>
            <label htmlFor="">Nombres</label>
            <input type="text" name="firstNames" value={firstNames} onChange={onInputChange}/>
        </div>
        <div>
            <label htmlFor="">Apellidos</label>
            <input type="text" name="lastNames" value={lastNames} onChange={onInputChange}/>
        </div>
        <div>
            <label htmlFor="">Genero</label>
            <input type="text" name="gender" value={gender} onChange={onInputChange}/>
        </div>
        <div>
            <label htmlFor="">Edad</label>
            <input type="number" name="age" value={age} onChange={onInputChange}/>
        </div>
        <div>
            {
                personAction === 'INSERT' ? <button onClick={() => {
                    createPerson(personForm)
                }}>Registrar</button> : null
            }
            {
                personAction === 'EDITH' ? (<>
                        <button onClick={() => updatePerson(identification, personForm)}>Actualizar</button>
                        <button onClick={() => {
                            personActionHandler('INSERT', newPerson)
                        }}>cancelar
                        </button>
                    </>
                ) : null
            }
        </div>


    </>)
})

Person.propTypes = {
    updatePerson: PropTypes.string.updatePerson,
    createPerson: PropTypes.string.createPerson,
}

Person.defaultProps = {}


