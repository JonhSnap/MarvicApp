import React, { useState, useEffect } from "react";
import axios from "axios";
import { BASE_URL } from "../util/constants";
import { v4 } from "uuid";
import YourWorkProject from "../components/your-work/YourWorkProject";
import "../components/your-work/YourWork.scss";
import YourWorkRecent from "../components/your-work/YourWorkRecent";
import projectStart from "../components/your-work/projectStart";
import { Swiper, SwiperSlide } from "swiper/react";
import "swiper/scss";
import YourWorkAssign from "../components/your-work/YourWorkAssign";

function YourWorkPage() {
  const [dataYourWork, setDataYourWork] = useState([]);
  const [projects, setProjects] = useState([]);
  const [assignToMe, setAssignToMe] = useState([]);
  const [isWorkOn, setIsWorkOn] = useState(true);
  const [isStart, setIsStart] = useState(false);
  const [isViewd, setIsViewd] = useState(false);
  const [isAssign, setIsAssign] = useState(false);
  const getYourWork = async () => {
    const resp = await axios.get(`${BASE_URL}/api/Issue/WorkedOn`);
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
  const getIssueAssignedToMe = async () => {
    const resp = await axios.get(`${BASE_URL}/api/Issue/GetIssuesAssignedToMe`);
    if (resp && resp.status === 200) {
      setAssignToMe(resp.data);
    } else {
      throw new Error("Error when fetch projects ");
    }
  };

  useEffect(() => {
    document.title = "Your work";
    getProject();
    getYourWork();
    getIssueAssignedToMe();
  }, []);
  const handleIsStart = () => {
    setIsStart(true);
    setIsWorkOn(false);
    setIsViewd(false);
    setIsAssign(false);
  };
  const handleIsWorkOn = () => {
    setIsWorkOn(true);
    setIsStart(false);
    setIsViewd(false);
    setIsAssign(false);
  };
  const handleIsViewd = () => {
    setIsViewd(true);
    setIsWorkOn(false);
    setIsStart(false);
    setIsAssign(false);
  };
  const handleIsAssigned = () => {
    setIsAssign(true);
    setIsViewd(false);
    setIsWorkOn(false);
    setIsStart(false);
  };

  console.log("assignToMe", assignToMe);

  return (
    <div className="w-[1320px] mx-auto flex flex-col mt-8 pb-24">
      <div className="flex flex-col">
        <h2 className="text-4xl font-semibold">Your work</h2>
        <div className="flex flex-col p-5 pl-6 mt-7 rounded-xl bg-slate-100">
          <h3 className="text-xl font-normal text-slate-600">
            Recent projects
          </h3>
          <div className="w-full yw-percent">
            <Swiper
              grabCursor={"true"}
              spaceBetween={40}
              slidesPerView={"auto"}
            >
              {projects &&
                projects.length > 0 &&
                projects.map((project) => (
                  <SwiperSlide key={v4()}>
                    <YourWorkRecent project={project}></YourWorkRecent>
                  </SwiperSlide>
                ))}
            </Swiper>
          </div>
        </div>
        <div className="p-2 mt-6 border-2 border-blue-200 rounded-xl">
          <div className="flex items-center p-2 mt-5 text-white workon-header rounded-2xl ">
            <div
              onClick={handleIsWorkOn}
              className={`${
                isWorkOn ? "border-b-2 border-white  " : ""
              } inline-block cursor-pointer mr-5 p-2 rounded-lg hover:bg-blue-600`}
            >
              <h3 className="text-xl font-semibold">Worked on</h3>
            </div>
            <div
              onClick={handleIsViewd}
              className={`${
                isViewd ? "border-b-2 border-white  " : ""
              } inline-block cursor-pointer mr-5 p-2 rounded-lg hover:bg-blue-600`}
            >
              <h3 className="text-xl font-semibold">Viewd</h3>
            </div>
            <div
              onClick={handleIsAssigned}
              className={`${
                isAssign ? "border-b-2 border-white  " : ""
              } inline-block cursor-pointer mr-5 p-2 rounded-lg hover:bg-blue-600`}
            >
              <h3 className="text-xl font-semibold">Assigned to me</h3>
            </div>
            <div
              onClick={handleIsStart}
              className={`${
                isStart ? "border-b-2 border-white  " : ""
              } inline-block cursor-pointer mr-5 p-2 rounded-lg hover:bg-blue-600`}
            >
              <h3 className="text-xl font-semibold">Starred</h3>
            </div>
          </div>
          {isWorkOn && (
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
          )}

          {isStart && (
            <div className="flex w-full">
              {assignToMe &&
                assignToMe.length > 0 &&
                assignToMe.map((item) => (
                  <YourWorkAssign key={v4()} dataAssign={item}></YourWorkAssign>
                ))}
            </div>
          )}
          {isViewd && <div>Viewd</div>}
          {isAssign && <div>Assigned to me</div>}
        </div>
      </div>
    </div>
  );
}

export default YourWorkPage;
