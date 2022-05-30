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

function YourWorkPage() {
  const [dataYourWork, setDataYourWork] = useState([]);
  const [projects, setProjects] = useState([]);
  const [isWorkOn, setIsWorkOn] = useState(true);
  const [isStart, setIsStart] = useState(false);
  const [isViewd, setIsViewd] = useState(false);
  const [isAssign, setIsAssign] = useState(false);
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

  return (
    <div className="w-[1320px] mx-auto flex flex-col mt-8">
      <div className="flex flex-col">
        <h2 className="text-4xl font-semibold">Your work</h2>
        <div className=" mt-7 flex  flex-col rounded-xl bg-slate-100 p-5">
          <h3 className="text-slate-600 text-xl font-normal">
            Recent projects
          </h3>
          <div className="yw-percent w-full">
            <Swiper
              grabCursor={"true"}
              spaceBetween={40}
              slidesPerView={"auto"}
            >
              {projects &&
                projects.length > 0 &&
                projects.map((project) => (
                  <SwiperSlide>
                    <YourWorkRecent
                      key={v4()}
                      project={project}
                    ></YourWorkRecent>
                  </SwiperSlide>
                ))}
            </Swiper>
          </div>
        </div>
        <div className="p-2 border-2 border-blue-200 rounded-xl mt-6">
          <div className="workon-header p-2 text-white rounded-2xl flex items-center mt-5 ">
            <div
              onClick={handleIsWorkOn}
              className={`${
                isWorkOn ? "border-b-2 border-white  " : ""
              } inline-block cursor-pointer mr-5 p-2 rounded-lg hover:bg-blue-600`}
            >
              <h3 className="text-xl font-semibold">Worked on</h3>
            </div>
            <div
              className={`${
                isViewd ? "border-b-2 border-white  " : ""
              } inline-block cursor-pointer mr-5 p-2 rounded-lg hover:bg-blue-600`}
            >
              <h3 className="text-xl font-semibold">Viewd</h3>
            </div>
            <div
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
              <h2>Starred</h2>
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
