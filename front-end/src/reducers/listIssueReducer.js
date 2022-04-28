import axios from "axios";
import { BASE_URL } from "../util/constants";
import { GET_ISSUES, UPDATE_ISSUES } from "./actions";

// fetch issue
const fetchIssue = async(projectId, dispatch) => {
    const resp = await axios.get(`${BASE_URL}/api/Issue/GetIssuesByIdProject?idProject=${projectId}`)
    if(resp && resp.status === 200) {
      dispatch({
          type: GET_ISSUES,
          payload: resp.data
      })
    }else {
        throw new Error('Error when fetch issues')
    }
  }
// update issue
const updateIssues = async(issueUpdate, dispatch) => {
    const resp = await axios.put(`${BASE_URL}/api/Issue/Update`, issueUpdate)
    if(resp && resp.status === 200) {
        dispatch({
            type: UPDATE_ISSUES,
            payload: issueUpdate
        })
    }else {
        throw new Error('Error when update issues')
    }
}

const initialIssues = [];

const listIssueReducer = (state, action) => {
    let stateCopy = [...state];
    switch (action.type) {
        case GET_ISSUES:
            stateCopy = [...action.payload];
            state = [...stateCopy];
            break;
        case UPDATE_ISSUES:
            const index = stateCopy.find(item => item.id === action.payload.id);
            stateCopy.splice(index, 1, action.payload);
            state = [...stateCopy];
            break;
        default:
            break
    }
    return state;
}
export { initialIssues, listIssueReducer, fetchIssue, updateIssues}