import axios from "axios";
import React, { useEffect, useState } from "react";
import { BASE_URL } from "../../util/constants";
import ArchiveSprint from "../archive/ArchiveSprint";
import TopDetail from "../project-detail/TopDetail";
import "./ContainerArchive.scss";

const ContainerArchive = ({ project }) => {
  //   console.log("project", project.id);
  const idProject = project?.id;
  const [archive, setArchive] = useState([]);
  useEffect(() => {
    const getArchive = async () => {
      await axios
        .get(`${BASE_URL}/api/Issue/GetIssuesArchive/${project.id}`)
        .then((res) => {
          setArchive(res.data);
        });
    };
    if (project && Object.entries(project).length > 0) {
      getArchive();
    }
  }, [project]);
  console.log("archive", archive);
  return (
    <div className="p-[40px]">
      <TopDetail project={project} />
      <div className="flex flex-col">
        {archive &&
          archive.length > 0 &&
          archive.map((item) => <ArchiveSprint></ArchiveSprint>)}
      </div>
    </div>
  );
};

export default ContainerArchive;
