import { createContext } from "react";


const openChildIssueProvider = createContext()


function openIssueProvider({children}) {
    // const [listIssue, dispatch] = useReducer(listIssueReducer, initialIssues);
    // const value = [listIssue, dispatch];
    return (
        <openChildIssueProvider.Provider value={value}>{children}</openChildIssueProvider.Provider>
    )
}