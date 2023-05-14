const express = require('express');
const {PersonService} = require('../applicationServices/personService');
const router = express.Router();

const personService = new PersonService();

/* GET users listing. */
router.get('/person/', async function (req, res, next) {
    const people = await personService.getPeople();
    res.json(people);
});
router.get('/person/:identification', async function (req, res, next) {
    const person = await personService.getPerson(req.params.identification);
    res.json(person);
});
router.post('/person', async function (req, res, next) {
    /*  #swagger.parameters['obj'] = {
           in: 'body',
           description: 'Create person',
           schema: {
                $identification: 'string',
                $firstNames: 'lenin',
                $lastNames: 'samaniego',
                $gender: 'masculino',
                $age: 12
            }
       } */
    try {
        await personService.createPerson(req.body);
        res.json(null);
    } catch (e) {
        res.status(400);
        res.json(e.message)
    }
});
router.put('/person/:identification', async function (req, res, next) {
    /*  #swagger.parameters['obj'] = {
          in: 'body',
          description: 'Update person',
          schema: {
               $firstNames: 'lenin',
               $lastNames: 'samaniego',
               $gender: 'masculino',
               $age: 12
           }
      } */
    try {
        await personService.updatePerson(req.params.identification, req.body);
        res.json(null);
    } catch (e) {
        res.status(400);
        res.json(e.message)
    }
});
router.delete('/person/:identification', async function (req, res, next) {
    try {
        await personService.deletePerson(req.params.identification);
        res.json(null);
    } catch (e) {
        res.status(400);
        res.json(e.message)
    }
});

module.exports = router;
