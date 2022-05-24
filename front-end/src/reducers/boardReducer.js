import axios from "axios";
import { BASE_URL } from "../util/constants";
import { GET_BOARD } from "./actions";

// fetch board
const fetchBoard = async (dataGet, dispatch) => {
    try {
        const resp = await axios.get(`${BASE_URL}/api/Issue/GetIssueForBoard?idSprint=${dataGet?.idSprint}${dataGet?.idEpic ? `&idEpic=${dataGet.idEpic}` : ''}${dataGet?.type ? `&type=${dataGet.type}` : ''}`);
        if (resp.status === 200) {
            dispatch({
                type: GET_BOARD,
                payload: resp.data
            })
        }
    } catch (error) {
        console.log(error);
    }
}

const initialValue = {
    boards: []
}

const boardReducer = (state, action) => {
    const stateCopy = { ...state };
    switch (action.type) {
        case GET_BOARD:
            stateCopy.boards = action.payload;
            state = { ...stateCopy };
            break;

        default:
            break;
    }
    return state
}
export { initialValue, boardReducer, fetchBoard }