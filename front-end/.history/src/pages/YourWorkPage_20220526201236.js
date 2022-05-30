import React, { useState, useEffect } from "react";
import axios from "axios";
import { BASE_URL } from "../util/constants";
import { v4 } from "uuid";
import YourWorkProject from "../components/your-work/YourWorkProject";
import "../components/your-work/YourWork.scss";
function YourWorkPage() {
  const [dataYourWork, setDataYourWork] = useState([]);
  const [projects, setProjects] = useState([]);

  const getYourWork = async () => {
    const resp = await axios.get(`${BASE_URL}/api/WorkedOn`);
    if (resp && resp.status === 200) {
      setDataYourWork(resp.data);
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
  return (
    <div className="w-[1320px] mx-auto flex flex-col mt-8">
      <div className="flex flex-col">
        <h2 className="text-4xl font-semibold">Your work</h2>
        <div></div>
        <div className="p-2 border-2 border-blue-200 rounded-xl">
          <div className="workon-header p-2 text-white rounded-2xl flex items-center mt-5 ">
            <div className="border-b-2 border-white inline-block cursor-pointer mr-5 p-2 rounded-lg hover:bg-blue-600">
              <h3 className="text-xl font-semibold">Worked on</h3>
            </div>
            <div className="inline-block cursor-pointer mr-5 p-2 rounded-lg hover:bg-blue-600">
              <h3 className="text-xl font-semibold">Viewd</h3>
            </div>
            <div className="inline-block cursor-pointer mr-5 p-2 rounded-lg hover:bg-blue-600">
              <h3 className="text-xl font-semibold">Assigned to me</h3>
            </div>
            <div className="inline-block cursor-pointer mr-5 p-2 rounded-lg hover:bg-blue-600">
              <h3 className="text-xl font-semibold">Starred</h3>
            </div>
          </div>
          <div className="flex w-full">
            {dataYourWork &&
              dataYourWork.length > 0 &&
              dataYourWork.map((item) => (
                <YourWorkProject
                  key={v4()}
                  dataYourWork={item}
                ></YourWorkProject>
              ))}
          </div>
        </div>
      </div>
    </div>
  );
}

export default YourWorkPage;
