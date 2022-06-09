import React, {useEffect, useState} from 'react';
import {ListIssueProvider} from "../contexts/listIssueContext";
import {MembersProvider} from "../contexts/membersContext";
import Sidebar from "../components/sidebar/Sidebar";
import ContainerBacklog from "../components/containers/ContainerBacklog";
import {SprintProvider} from "../contexts/sprintContext";
import {useParams} from "react-router-dom";
import {useSelector} from "react-redux";
import ContainerArchive from "../components/archiveComponent/ContainerArchive";

const ArchiveIssuse = () => {
    const { key } = useParams();

    const { projects } = useSelector(state => state.projects);
    const [currentProject, setCurrentProject] = useState({});

    useEffect(() => {
        document.title = 'Marvic-backlog';
        const currProject = projects.find(item => item?.key === key);
        if (Object.entries(currProject).length > 0) {
            setCurrentProject(currProject);
        }
    }, [projects])
    return (
        <>
            <SprintProvider>
                <ListIssueProvider>
                    <MembersProvider>
                        <div className="flex overflow-hidden h-main-backlog">
                            <div className='basis-[20%] h-main-backlog'>
                                <Sidebar nameProject={currentProject.name}></Sidebar>
                            </div>
                            <div className='basis-[80%] h-main-backlog'>
                                <ContainerArchive project={currentProject}></ContainerArchive>
                            </div>
                        </div>
                    </MembersProvider>
                </ListIssueProvider>
            </SprintProvider>
        </>
    );
};

export default ArchiveIssuse;