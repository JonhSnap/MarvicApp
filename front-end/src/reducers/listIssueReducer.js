import axios from "axios";
import { BASE_URL } from "../util/constants";
import { CHANGE_FILTERS_NAME, CREATE_ISSUE, GET_ISSUES, UPDATE_ISSUES } from "./actions";

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
// create issue
const createIssue = async(issuePost, dispatch) => {
    const resp = await axios.post(`${BASE_URL}/api/Issue/Create`, issuePost);
    if (resp.status === 200) {
        dispatch({
            type: CREATE_ISSUE,
            payload: issuePost
        })
    }   
}

const initialIssues = {
    issues: [],
    filters: {
        name: ''
    }
}

const listIssueReducer = (state, action) => {
    let stateCopy = {...state};
    switch (action.type) {
        case GET_ISSUES:
            const nameFilter = stateCopy.filters.name
            if(nameFilter) {
                const result = action.payload.filter(item => item.summary.toLowerCase().includes(nameFilter.toLowerCase()))
                state = {
                    ...state,
                    issues: [...result]
                }
            }else {
                state = {
                    ...stateCopy,
                    issues: action.payload
                }
            }
            break;
        case UPDATE_ISSUES:
            const index = stateCopy.issues.findIndex(item => item.id === action.payload.id);
            stateCopy.issues.splice(index, 1, action.payload);
            state = {...stateCopy};
            break;
        case CREATE_ISSUE:
            stateCopy = {
                ...stateCopy,
                issues: [...stateCopy.issues, action.payload]
            }
            state = {...stateCopy}
            break;
        case CHANGE_FILTERS_NAME:
            state = {
                ...state,
                filters: {
                    ...state.filters,
                    name: action.payload
                }
            }
            break;
        default:
            break
    }
    return state;
}
export { initialIssues, listIssueReducer, fetchIssue, updateIssues, createIssue}