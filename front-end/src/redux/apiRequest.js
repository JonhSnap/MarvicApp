import axios from "axios"
import { BASE_URL } from "../util/constants";
import { getProjectsStart, getProjectsError, getProjectsSuccess } from './projectsSlice'

export const getProjects = async(dispatch) => {
    dispatch(getProjectsStart);
    try {
        const resp = await axios.get(`${BASE_URL}/api/Project/GetAlls`);
        if(resp && resp.data.length > 0) {
            dispatch(getProjectsSuccess(resp.data));
        }
    }catch (err) {
        dispatch(getProjectsError());
    }
}