import React, { useEffect, useState } from 'react'
import { useSelector } from 'react-redux'
import { useParams } from 'react-router-dom';
import DashboardContainer from '../components/dashboard/DashboardContainer';
import Sidebar from '../components/sidebar/Sidebar'

function DashboardPage() {
    const [currentProject, setCurrentProject] = useState();
    const { projects } = useSelector(state => state.projects);
    const keyProject = useParams('key');
    useEffect(() => {
        document.title = 'Marvic-Dashboard'
        const currPro = projects.find(item => item.key === keyProject);
        console.log("currPro", currPro);
        if (currPro) {
            setCurrentProject(currPro);
        }
    }, [projects, keyProject])
    console.log("projects", projects);
    return (
        <div className="flex overflow-hidden h-main-backlog">
            <div className='basis-[20%] h-main-backlog'>
                <Sidebar nameProject={currentProject?.name}></Sidebar>
            </div>
            <div className='basis-[80%] h-main-backlog'>
                <DashboardContainer project={currentProject} />
            </div>
        </div>
    )
}

export default DashboardPage