import axios from "axios";
import { BASE_URL } from "../util/constants";
import { GET_STAGE, UPDATE_STAGE } from "./actions";

// fetchStage
const fetchStage = async (idProject, dispatch) => {
    try {
        const resp = await axios.get(`${BASE_URL}/api/Stages/project/${idProject}`);
        if (resp.status === 200) {
            dispatch({
                type: GET_STAGE,
                payload: resp.data
            })
        }
    } catch (error) {
        console.log(error);
    }
}
// update stage
const updateStage = async (idStage, dataPut, dispatch) => {
    try {
        const resp = await axios.put(`${BASE_URL}/api/Stages/${idStage}`, dataPut);
        if (resp.status === 200) {
            dispatch({
                type: UPDATE_STAGE,
                payload: dataPut
            })
        }
    } catch (error) {
        console.log(error);
    }
}

// init value
const initialValues = {
    stages: []
}

const stageReducer = (state, action) => {
    const stateCopy = { ...state };
    switch (action.type) {
        case GET_STAGE:
            stateCopy.stages = [...action.payload];
            state = { ...stateCopy }
            break;
        case UPDATE_STAGE:
            const index = stateCopy.stages.findIndex(item => item.id === action.payload.id);
            stateCopy.stage.splice(index, 1, action.payload);
            state = { ...stateCopy };
            break;

        default:
            throw new Error('Invalid action!')
    }
    return state
}
export {
    initialValues,
    stageReducer,
    fetchStage,
    updateStage
}