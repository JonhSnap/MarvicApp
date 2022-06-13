import React, { useState, useEffect } from "react";
import axios from "axios";
import { BASE_URL } from "../util/constants";
import { v4 } from "uuid";
import YourWorkProject from "../components/your-work/YourWorkProject";
function YourWorkPage() {
  const [dataYourWork, setDataYourWork] = useState([]);
  const [projects, setProjects] = useState([]);

  const getYourWork = async () => {
    const resp = await axios.get(`${BASE_URL}/api/WorkedOn`);
    if (resp && resp.status === 200) {
      log;
      setDataYourWork(resp.data.items);
    } else {
      throw new Error("Error when fetch get YourWork ");
    }
  };
  const getProject = async () => {
    const resp = await axios.get(`${BASE_URL}/api/Project/GetAlls`);
    if (resp && resp.status === 200) {
      setProjects(resp.data);
    } else {
      throw new Error("Error when fetch projects ");
    }
  };
  useEffect(() => {
    document.title = "Your work";
    getProject();
    getYourWork();
  }, []);
  console.log(dataYourWork.items);

  return (
    <div className="w-[1320px] mx-auto flex flex-col mt-8">
      <div className="flex flex-col">
        <h2 className="text-base font-semibold">Recent Project</h2>
        <div className="flex">
          {projects &&
            projects.length > 0 &&
            projects.map((item) => (
              <YourWorkProject key={v4()} projects={projects}></YourWorkProject>
            ))}
        </div>
      </div>
    </div>
  );
}

export default YourWorkPage;
