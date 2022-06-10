import axios from "axios";
import React, { useEffect, useState } from "react";
import { BASE_URL } from "../../util/constants";
import ArchiveSprint from "../archive/ArchiveSprint";
import TopDetail from "../project-detail/TopDetail";
import "./ContainerArchive.scss";
import { v4 } from "uuid";
import nullImg from "../../images/null.png";

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
      {/* <TopDetail project={project} /> */}
      <div className="flex flex-col w-full">
        <h2 className="flex justify-center text-blue-500 text-4xl font-semibold">
          Archive
        </h2>
        <div className="overflow-y-auto have-y-scroll h-[100vh]">
        {archive && archive.length > 0 ? (
          archive.map((item) => (
            <ArchiveSprint key={v4()} ArchiveSprint={item}></ArchiveSprint>
          ))
        ) : (
          <div className="flex justify-center flex-col w-full">
            <h2 className="text-xl font-semibold">Is not archive</h2>
            <div className="w-full flex  justify-center h-[100vh] ">
              <img
                className="w-[200px] h-[200px] my-[40px] items-center"
                src={nullImg}
                alt=""
              />
            </div>
          </div>
        )}
        {archive && archive.length > 0 ? (
          archive.map((item) => (
            <ArchiveSprint key={v4()} ArchiveSprint={item}></ArchiveSprint>
          ))
        ) : (
          <div className="flex justify-center flex-col w-full">
            <h2 className="text-xl font-semibold">Is not archive</h2>
            <div className="w-full flex  justify-center h-[100vh] ">
              <img
                className="w-[200px] h-[200px] my-[40px] items-center"
                src={nullImg}
                alt=""
              />
            </div>
          </div>
        )}
        {archive && archive.length > 0 ? (
          archive.map((item) => (
            <ArchiveSprint key={v4()} ArchiveSprint={item}></ArchiveSprint>
          ))
        ) : (
          <div className="flex justify-center flex-col w-full">
            <h2 className="text-xl font-semibold">Is not archive</h2>
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
