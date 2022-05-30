import axios from "axios";
import { BASE_URL } from "../util/constants";
import { CHANGE_FILTER_EPIC_BOARD, CHANGE_FILTER_NAME_BOARD, CHANGE_FILTER_TYPE_BOARD, GET_BOARD } from "./actions";

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
    boards: [],
    filters: {
        name: '',
        epics: [],
        types: []
    }
}

const boardReducer = (state, action) => {
    let stateCopy = { ...state };
    switch (action.type) {
        case GET_BOARD:
            // filter name
            const nameFilter = stateCopy.filters.name;
            // filter epics
            const epicFilter = stateCopy.filters.epics;
            // filter type
            const typeFilter = stateCopy.filters.types;
            stateCopy.boards = action.payload;
            // filter name
            if (nameFilter) {
                stateCopy.boards.forEach(board => {
                    board.listStage.forEach(stage => {
                        stage.listIssue = stage.listIssue.filter(issue => issue.summary.toLowerCase().includes(nameFilter.toLowerCase()))
                    })
                })
            }

            // filter epic
            if (epicFilter.length > 0) {
                if (epicFilter.includes('issues without epic')) {
                    stateCopy.boards.forEach(board => {
                        board.listStage.forEach(stage => {
                            stage.listIssue = stage.listIssue.filter(issue => {
                                return (
                                    !issue.id_Parent_Issue ||
                                    issue.id_Parent_Issue === "00000000-0000-0000-0000-000000000000"
                                )
                            })
                        })
                    })
                }
                stateCopy.boards.forEach(board => {
                    board.listStage.forEach(stage => {
                        stage.listIssue = stage.listIssue.filter(item => {
                            return epicFilter.includes(item.id_Parent_Issue)
                        })
                    })
                })
            } else {
                stateCopy = {
                    ...stateCopy
                }
            }

            // filter type
            if (typeFilter.length > 0) {
                stateCopy.boards.forEach(board => {
                    board.listStage.forEach(stage => {
                        stage.listIssue = stage.listIssue.filter(issue => typeFilter.includes(issue.id_IssueType))
                    })
                })
            } else {
                stateCopy = { ...stateCopy }
            }
            state = { ...stateCopy };
            break;
        case CHANGE_FILTER_NAME_BOARD:
            stateCopy.filters.name = action.payload;
            state = { ...stateCopy };
            break;
        case CHANGE_FILTER_EPIC_BOARD:
            let filtersEpic = stateCopy.filters.epics;
            if (filtersEpic.length > 0) {
                if (filtersEpic.includes(action.payload)) {
                    filtersEpic = filtersEpic.filter(item => item !== action.payload)
                } else {
                    filtersEpic = [...filtersEpic, action.payload]
                }
                stateCopy = {
                    ...stateCopy,
                    filters: {
                        ...stateCopy.filters,
                        epics: [...filtersEpic]
                    }
                }
            } else {
                stateCopy = {
                    ...stateCopy,
                    filters: {
                        ...stateCopy.filters,
                        epics: [...stateCopy.filters.epics, action.payload]
                    }
                }
            }
            state = { ...stateCopy }
            break;
        case CHANGE_FILTER_TYPE_BOARD:
            let typeFilterCopy = stateCopy.filters.types;
            if (typeFilterCopy.length > 0) {
                if (typeFilterCopy.includes(action.payload)) {
                    const newFilterType = typeFilterCopy.filter(item => item !== action.payload);
                    stateCopy = {
                        ...stateCopy,
                        filters: {
                            ...stateCopy.filters,
                            types: [...newFilterType]
                        }
                    }
                } else {
                    stateCopy = {
                        ...stateCopy,
                        filters: {
                            ...stateCopy.filters,
                            types: [...stateCopy.filters.types, action.payload]
                        }
                    }
                }
            } else {
                stateCopy = {
                    ...stateCopy,
                    filters: {
                        ...stateCopy.filters,
                        types: [action.payload]
                    }
                }
            }
            state = { ...stateCopy }
            break;
        default:
            break;
    }
    return state
}
export { initialValue, boardReducer, fetchBoard }