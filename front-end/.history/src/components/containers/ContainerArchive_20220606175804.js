import axios from "axios";
import React, { useEffect, useState } from "react";
import { BASE_URL } from "../../util/constants";
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
  console.log("archive", idProject);
  return (
    <div className="p-[40px]">
      <TopDetail project={project} />
    </div>
  );
};

export default ContainerArchive;
