import { createContext, useContext, useState } from "react";
const openChildIssueContext = createContext()


function openIssueProvider({children}) {
    // const [listIssue, dispatch] = useReducer(listIssueReducer, initialIssues);
    const [show, setShow] = useState();
    return (
        <openChildIssueContext.Provider value={[show, setShow]}  >{children}</openChildIssueContext.Provider>
    )
}

const useListIssueContext = () => {
    const value = useContext(openChildIssueContext);
    if(typeof issuesContext === 'undefined') throw new Error('value must be used inside openIssueProvider')
    return value;
}

export {openIssueProvider, useListIssueContext}