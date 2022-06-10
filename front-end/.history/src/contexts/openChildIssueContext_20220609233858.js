import { createContext, useContext, useState } from "react";
const openChildIssueContext = createContext()

function UseCreateShow() {
    const [show, setShow] = useState(false);
    return [show, setShow]
}

function OpenIssueProvider({children}) {

    // const [listIssue, dispatch] = useReducer(listIssueReducer, initialIssues);
    const [show, setShow] = UseCreateShow(false);
    const [items, setItems] = useState([])
    const value = {open:[show,setShow],epicShow:[items,setItems]}
    return (
        <openChildIssueContext.Provider value={value}  >{children}</openChildIssueContext.Provider>
    )
}

const useOpenIssueContext = () => {
    const value = useContext(openChildIssueContext);
    if(typeof value === 'undefined') throw new Error('value must be used inside openIssueProvider')
    return value;
}

export {OpenIssueProvider, useOpenIssueContext}