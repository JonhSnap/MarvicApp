import React, {useEffect, useMemo} from 'react';
import {useListIssueContext} from "../../contexts/listIssueContext";
import {useMembersContext} from "../../contexts/membersContext";
import {NIL} from "uuid";
import {fetchIssue} from "../../reducers/listIssueReducer";
import TopDetail from "../project-detail/TopDetail";
import Loading from "../../loading/Loading";
import WrapperSprint from "../sprint/WrapperSprint";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faAngleDown} from "@fortawesome/free-solid-svg-icons";
import ButtonBacklogComponent from "../backlog/ButtonBacklogComponent";
import WrapperTask from "../backlog/WrapperTask";
import CreateComponent from "../CreateComponent";
import WrapperSprintArchive from "./WrapperSprintArchive";

const ContainerArchive = ({ project }) => {
    const [{ issueNormals, pending }, dispatchIssue] = useListIssueContext();
    const { state: { members } } = useMembersContext();
    const issueNoSprint = useMemo(() => {
        return issueNormals.filter(item => item.id_Sprint === NIL)
    }, [issueNormals])

    // useEffect get issues
    useEffect(() => {
        if (project && Object.entries(project).length > 0) {
            fetchIssue(project.id, dispatchIssue);
        }
    }, [project])

    return (
        <div className='container'>
            <TopDetail project={project} />
            {pending ?
                <Loading></Loading> :
                <div className="bottom have-y-scroll">
                    <div className='wrap-backlog'>
                        <div className='main-backlog'>
                            <WrapperSprintArchive members={members} project={project} />
                        </div>
                    </div>
                </div>}
        </div>
    )
};

export default ContainerArchive;