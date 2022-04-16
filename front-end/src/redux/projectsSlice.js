import { createSlice } from '@reduxjs/toolkit'

const projectsSlice = createSlice({
    name: 'projects',
    initialState: {
        projects: [],
        pending: false,
        error: false
    },
    reducers: {
        getProjectsStart(state) {
            state.pending = true;
            state.error = false;
        },
        getProjectsError(state) {
            state.pending = false;
            state.error = true;
        },
        getProjectsSuccess(state, action) {
            state.pending = false;
            state.error = false;
            state.projects = action.payload;
        }
    }
})
export const { getProjectsStart, getProjectsError, getProjectsSuccess } = projectsSlice.actions;
export default projectsSlice.reducer;