import axios from "axios";
import { BASE_URL } from "../util/constants";
import { GET_SPRINT, CREATE_SPRINT, DELETE_SPRINT, UPDATE_SPRINT } from "./actions";

// fetch sprint
const fetchSprint = async (idProject, dispatch) => {
    try {
        const resp = await axios.get(`${BASE_URL}/api/Sprints/project/${idProject}`)
        if (resp.status === 200) {
            dispatch({
                type: GET_SPRINT,
                payload: resp.data
            })
        }
    } catch (error) {
        console.log(error);
    }
}
// create sprint
const createSprint = async (dataPost, dispatch) => {
    try {
        const resp = await axios.post(`${BASE_URL}/api/Sprints`, dataPost);
        if (resp.status === 200) {
            dispatch({
                type: CREATE_SPRINT,
                payload: resp.data
            })
        }
    } catch (error) {
        console.log(error);
    }
}
// delete sprint
const deleteSprint = async (idSprint, dispatch) => {
    try {
        const resp = await axios.delete(`${BASE_URL}/api/Sprints/${idSprint}`);
        if (resp.status === 200) {
            dispatch({
                type: DELETE_SPRINT,
                payload: idSprint
            })
        }
    } catch (error) {
        console.log(error);
    }
}
// update sprint
const updateSprint = async (dataPut, dispatch) => {
    try {
        const resp = await axios.put(`${BASE_URL}/api/Sprints/${dataPut.id}`, dataPut);
        if (resp.status === 200) {
            dispatch({
                type: UPDATE_SPRINT,
                payload: dataPut
            })
        }
    } catch (error) {
        console.log(error);
    }
}

const initialValue = {
    sprints: []
}

function sprintReducer(state, action) {
    let stateCopy = { ...state };
    switch (action.type) {
        case GET_SPRINT:
            stateCopy.sprints = [...action.payload];
            state = { ...stateCopy };
            break;
        case CREATE_SPRINT:

            break;
        case UPDATE_SPRINT:

            break;
        case DELETE_SPRINT:
            stateCopy.sprints = stateCopy.sprints.filter(item => item.id !== action.payload);
            state = { ...stateCopy }
            break;

        default:
            throw new Error('Action is not valid')
    }
    return state;
}
export { initialValue, sprintReducer, fetchSprint, createSprint, deleteSprint, updateSprint }