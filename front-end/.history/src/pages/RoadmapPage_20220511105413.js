import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { useParams } from "react-router-dom";
import Roadmap from "../components/roadmap/Roadmap";
import Sidebar from "../components/sidebar/Sidebar";

function RoadmapPage() {
  const { key } = useParams();

  const { projects } = useSelector((state) => state.projects);
  const [currentProject, setCurrentProject] = useState({});

  // useEffect(() => {
  //   document.title = "Marvic-roadmap";
  //   const currProject = projects.find((item) => item?.key === key);
  //   if (Object.entries(currProject).length > 0) {
  //     setCurrentProject(currProject);
  //   }
  // }, [projects]);
  return (
    <div className="flex">
      <div className="basis-[20%]">
        <Sidebar></Sidebar>
      </div>
      <div className="basis-[80%]">
        <Roadmap></Roadmap>
      </div>
    </div>
  );
}

export default RoadmapPage;
