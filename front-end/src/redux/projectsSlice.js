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
        },
        updateProjectsStart(state) {
            state.pending = true;
            state.error = false;
        },
        updateProjectsError(state) {
            state.pending = false;
            state.error = true;
        },
        updateProjectsSuccess(state, action) {
            const index = state.projects.findIndex(item => item.id === action.payload.id);
            state.pending = false;
            state.error = false;
            state.projects.splice(index, 1, action.payload);
            console.log('ket thuc action');
        },
        deleteProjectsStart(state) {
            state.pending = true;
            state.error = false;
        },
        deleteProjectsError(state) {
            state.pending = false;
            state.error = true;
        },
        deleteProjectsSuccess(state, action) {
            const index = state.projects.findIndex(item => item.id === action.payload);
            state.pending = false;
            state.error = false;
            state.projects.splice(index, 1);
            console.log('ket thuc action');
        }
    }
})
export const { getProjectsStart, getProjectsError, getProjectsSuccess,
updateProjectsStart, updateProjectsError, updateProjectsSuccess,
deleteProjectsStart, deleteProjectsError, deleteProjectsSuccess } = projectsSlice.actions;
export default projectsSlice.reducer;