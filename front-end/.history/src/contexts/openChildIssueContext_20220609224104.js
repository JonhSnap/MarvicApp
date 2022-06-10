import { createContext, useContext } from "react";
const openChildIssueContext = createContext()


function openIssueProvider({children}) {
    // const [listIssue, dispatch] = useReducer(listIssueReducer, initialIssues);
    // const value = [listIssue, dispatch];
    return (
        <openChildIssueContext.Provider >{children}</openChildIssueContext.Provider>
    )
}

const useListIssueContext = () => {
    const value = useContext(openChildIssueContext);
    if(typeof issuesContext === 'undefined') throw new Error('value must be used inside openIssueProvider')
    return value;
}

export {openIssueProvider, useListIssueContext}