import React, { useState, useEffect } from "react";
import axios from "axios";
import { BASE_URL } from "../util/constants";
import { v4 } from "uuid";
import YourWorkProject from "../components/your-work/YourWorkProject";
import "../components/your-work/YourWork.scss";
import YourWorkRecent from "../components/your-work/YourWorkRecent";
import { Swiper, SwiperSlide } from "swiper/react";
import "swiper/scss";
import YourWorkAssign from "../components/your-work/YourWorkAssign";
import YourWorkStarred from "../components/your-work/YourWorkStarred";
import useLoading from "../hooks/useLoading";
import { Skeleton } from "@mui/material";

function YourWorkPage() {
  const [isLoading] = useLoading();
  const [dataYourWork, setDataYourWork] = useState([]);
  const [projects, setProjects] = useState([]);
  const [assignToMe, setAssignToMe] = useState([]);
  const [starred, setStarred] = useState([]);
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
    const resp = await axios.get(`${BASE_URL}/api/Project/GetByLoginUser`);
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
  const getStarred = async () => {
    const resp = await axios.get(`${BASE_URL}/api/Project/GetStarredProject`);
    if (resp && resp.status === 200) {
      setStarred(resp.data);
    } else {
      throw new Error("Error when fetch projects ");
    }
  };

  useEffect(() => {
    document.title = "Your work";
    getProject();
    getYourWork();
    getIssueAssignedToMe();
    getStarred();
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

  const totalAssignDone = assignToMe[0]?.items.length || 0;
  const totalAssignInprogress = assignToMe[1]?.items.length || 0;
  const totalAssignView = assignToMe[2]?.items.length || 0;
  const totalAssign = totalAssignDone + totalAssignInprogress + totalAssignView;

  let totalWorkon = 0;
  for (let index = 0; index < dataYourWork?.length; index++) {
    const totalAssign = dataYourWork[index];
    totalWorkon += totalAssign?.items.length;
    console.log("total", totalWorkon);
  }

  console.log("dataYourWork", dataYourWork?.length);
  return (
    <div className="w-[1320px] mx-auto flex flex-col mt-8 pb-24">
      <div className="flex flex-col">
        <h2 className="text-3xl font-semibold">Your work</h2>
        <div className="flex flex-col p-5 pl-6 mt-7 rounded-xl bg-slate-100">
          <h3 className="text-xl font-normal text-slate-600">
            Recent projects
          </h3>
          {isLoading ? (
            <>
              <div className="w-full flex gap-x-6">
                {projects.length > 0 &&
                  projects.map((item) => (
                    <div
                      key={item.id}
                      className="w-[240px] h-[200px] flex flex-col p-2 rounded bg-white"
                    >
                      <div className="w-full flex gap-x-3 items-center mb-5">
                        <div className="w-[40px] h-[40px]">
                          <Skeleton
                            style={{ backgroundColor: "#f4f5f7" }}
                            variant="circular"
                            animation="wave"
                            width="100%"
                            height="100%"
                          />
                        </div>
                        <div className="grow flex flex-col gap-y-2">
                          <div className="w-[30%] h-[15px]">
                            <Skeleton
                              style={{
                                backgroundColor: "#f4f5f7",
                                borderRadius: 4,
                              }}
                              variant="rectangular"
                              animation="wave"
                              width="100%"
                              height="100%"
                            />
                          </div>
                          <div className="w-full h-[15px]">
                            <Skeleton
                              style={{
                                backgroundColor: "#f4f5f7",
                                borderRadius: 4,
                              }}
                              variant="rectangular"
                              animation="wave"
                              width="100%"
                              height="100%"
                            />
                          </div>
                        </div>
                      </div>
                      <div className="grow w-full flex items-center gap-x-[20px]">
                        <div className="grow h-full flex flex-col justify-between">
                          {Array(3)
                            .fill(0)
                            .map(() => (
                              <div key={v4()} className="w-full h-[30px]">
                                <Skeleton
                                  style={{
                                    backgroundColor: "#f4f5f7",
                                    borderRadius: 4,
                                  }}
                                  variant="rectangular"
                                  animation="wave"
                                  width="100%"
                                  height="100%"
                                />
                              </div>
                            ))}
                        </div>
                        <div className="w-[30px] h-[30px]">
                          <Skeleton
                            style={{
                              backgroundColor: "#f4f5f7",
                              borderRadius: 4,
                            }}
                            variant="rectangular"
                            animation="wave"
                            width="100%"
                            height="100%"
                          />
                        </div>
                      </div>
                    </div>
                  ))}
              </div>
            </>
          ) : (
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
          )}
        </div>
        <div className="p-2 mt-6 border-2 border-blue-200 rounded-xl">
          <div className="flex items-center p-2 mt-5 text-white workon-header rounded-2xl ">
            <div
              onClick={handleIsWorkOn}
              className={`${
                isWorkOn ? "border-b-2 border-white  " : ""
              } inline-block cursor-pointer mr-5 p-2 rounded-lg hover:bg-blue-600`}
            >
              <h3 className="flex items-center text-xl font-semibold">
                Worked on
                <span className="flex items-center justify-center w-5 h-5 ml-3 text-black rounded-full bg-yellow-50">
                  {total}
                </span>
              </h3>
            </div>

            <div
              onClick={handleIsAssigned}
              className={`${
                isAssign ? "border-b-2 border-white  " : ""
              } inline-block cursor-pointer mr-5 p-2 rounded-lg hover:bg-blue-600`}
            >
              <h3 className="flex items-center text-xl font-semibold">
                Assigned to me{" "}
                <span className="flex items-center justify-center w-5 h-5 ml-3 text-black rounded-full bg-yellow-50">
                  {totalAssign}
                </span>
              </h3>
            </div>
            <div
              onClick={handleIsStart}
              className={`${
                isStart ? "border-b-2 border-white  " : ""
              } inline-block cursor-pointer mr-5 p-2 rounded-lg hover:bg-blue-600`}
            >
              <h3 className="flex items-center text-xl font-semibold">
                Starred
                <span className="flex items-center justify-center w-5 h-5 ml-3 text-black rounded-full bg-yellow-50">
                  {starred.length}
                </span>
              </h3>
            </div>
          </div>
          {isWorkOn && (
            <div
              id="style-15"
              className="flex flex-col w-full h-[400px] overflow-y-auto pb-10"
            >
              <h2 className="my-5 text-xl font-semibold text-slate-400">
                IN THE LAST MONTH
              </h2>
              <>
                {isLoading ? (
                  <div className="flex flex-col gap-y-3">
                    {Array(5)
                      .fill(0)
                      .map(() => (
                        <div
                          key={v4()}
                          className="w-full h-[50px] p-4 bg-white flex justify-between"
                        >
                          <div className="w-[100px] h-full">
                            <Skeleton
                              style={{
                                backgroundColor: "#f4f5f7",
                                borderRadius: 4,
                              }}
                              variant="rectangular"
                              animation="wave"
                              width="100%"
                              height="100%"
                            />
                          </div>
                          <div className="w-[40px] h-full">
                            <Skeleton
                              style={{
                                backgroundColor: "#f4f5f7",
                                borderRadius: 4,
                              }}
                              variant="rectangular"
                              animation="wave"
                              width="100%"
                              height="100%"
                            />
                          </div>
                          <div className="w-[80px] h-full flex justify-between">
                            <div className="w-[35px] h-[35px]">
                              <Skeleton
                                style={{ backgroundColor: "#f4f5f7" }}
                                variant="circular"
                                animation="wave"
                                width="100%"
                                height="100%"
                              />
                            </div>
                            <div className="w-[35px] h-[35px]">
                              <Skeleton
                                style={{ backgroundColor: "#f4f5f7" }}
                                variant="circular"
                                animation="wave"
                                width="100%"
                                height="100%"
                              />
                            </div>
                          </div>
                        </div>
                      ))}
                  </div>
                ) : (
                  <>
                    {dataYourWork &&
                      dataYourWork.length > 0 &&
                      dataYourWork.map((item) => (
                        <YourWorkProject
                          key={v4()}
                          dataYourWork={item}
                        ></YourWorkProject>
                      ))}
                  </>
                )}
              </>
            </div>
          )}

          {isStart && (
            <div className="flex flex-col w-full p-4 mb-4">
              {" "}
              {assignToMe &&
                starred.length > 0 &&
                starred.map((item) => (
                  <YourWorkStarred
                    key={v4()}
                    dataStarred={item}
                  ></YourWorkStarred>
                ))}
            </div>
          )}
          {isAssign && (
            <div className="flex flex-col w-full p-4 mb-4">
              {assignToMe &&
                assignToMe.length > 0 &&
                assignToMe.map((item) => (
                  <YourWorkAssign key={v4()} dataAssign={item}></YourWorkAssign>
                ))}
            </div>
          )}
        </div>
      </div>
    </div>
  );
}

export default YourWorkPage;
