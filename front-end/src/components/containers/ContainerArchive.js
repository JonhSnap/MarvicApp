import axios from "axios";
import React, { useEffect, useState } from "react";
import { BASE_URL } from "../../util/constants";
import ArchiveSprint from "../archive/ArchiveSprint";
import TopDetail from "../project-detail/TopDetail";
import "./ContainerArchive.scss";
import { v4 } from "uuid";
import nullImg from "../../images/null.png";
import BreadcrumbsComp from "../project-detail/Breadcrumbs";

const ContainerArchive = ({ project }) => {
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
  return (
    <div className="p-[40px]">
      <div className="flex flex-col w-full">
        <BreadcrumbsComp />
        <h2 className="flex justify-center text-4xl font-semibold text-blue-500">
          Archive
        </h2>
        <div className="overflow-y-auto have-y-scroll h-[500px]">
          {archive && archive.length > 0 ? (
            archive.map((item) => (
              <ArchiveSprint
                project={project}
                key={v4()}
                ArchiveSprint={item}
              ></ArchiveSprint>
            ))
          ) : (
            <div className="flex flex-col justify-center w-full">
              <h2 className="text-xl font-semibold">
                No issues have been archived yet
              </h2>
              <div className="w-full flex  justify-center h-[100vh] ">
                <img
                  className="w-[200px] h-[200px] my-[40px] items-center"
                  src={nullImg}
                  alt=""
                />
              </div>
            </div>
          )}
        </div>
      </div>
    </div>
  );
};

export default ContainerArchive;
