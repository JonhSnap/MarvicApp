import axios from "axios";
import { BASE_URL } from "../util/constants";
import { GET_STAGE } from "./actions";

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

        default:
            throw new Error('Invalid action!')
    }
    return state
}
export {
    initialValues,
    stageReducer,
    fetchStage
}