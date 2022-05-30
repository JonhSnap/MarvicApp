import React, { useState } from "react";
import UserYourWork from "./UserYourWork";
import { v4 } from "uuid";
import { Swiper, SwiperSlide } from "swiper/react";
import "swiper/scss";
import useHover from "../../hooks/useHover";
import avtUser from "../../images/avt-user.png";
import useClickOutSide from "../../hooks/useClickOutSide";
import { useSelector } from "react-redux";

const YourWorkIssue = ({ dataIssue }) => {
  const isType2 = dataIssue.id_IssueType === 2;
  const isType3 = dataIssue.id_IssueType === 3;
  const isType4 = dataIssue.id_IssueType === 4;
  const isType1 = dataIssue.id_IssueType === 1;
  const [hoverRef, isHovered] = useHover();
  const [hoverRef1, isHovered1] = useHover();
  const { show, setShow, nodeRef } = useClickOutSide();
  console.log("dataIssue", dataIssue);
  const projects = useSelector((state) => state.projects.projects);
  const keyProject = projects.find(
    (project) => project.id === dataIssue.id_Project
  );
  return (
    <div className="flex items-center w-full p-1 rounded-lg cursor-pointer hover:bg-slate-200">
      <div>
        {isType2 && (
          <img
            src="http://localhost:3000/static/media/story.29b1ddadbd9c9361c80f.jpg"
            alt=""
            className="w-6"
          />
        )}
        {isType3 && (
          <img
            src="http://localhost:3000/static/media/task.b8da2cdd2f57bbd0748a.jpg"
            alt=""
            className="w-6"
          />
        )}
        {isType4 ||
          (isType1 && (
            <img
              src="http://localhost:3000/static/media/bug.28f77bb8e0d6412801e5.jpg"
              alt=""
              className="w-6"
            />
          ))}
      </div>
      <div className="flex items-center justify-between w-full ml-4">
        <div className="">
          <h4 className="text-xl font-semibold">{dataIssue.summary}</h4>
          <span className="text-base font-normal text-slate-600">
            {dataIssue.projectName}
          </span>
        </div>
        <div className="w-[450px] flex items-center justify-between pr-20">
          <span className="flex items-center text-base font-normal text-slate-500">
            {dataIssue.status}
          </span>
          <div className="flex justify-between ">
            <div className="flex">
              {dataIssue.users.length > 2 ? (
                <>
                  <div ref={hoverRef} className=" w-[40px] [h-40px] relative ">
                    {isHovered ? (
                      <span className="w-auto absolute z-10  bg-black text-white text-sm px-2 py-1  l-0 rounded-lg top-[100%]">
                        {dataIssue.users[0].userName}
                      </span>
                    ) : (
                      ""
                    )}

                    <img
                      src={dataIssue.users[0].avatar_Path || avtUser}
                      alt=""
                      className="w-[40px] h-[40px] border-2 border-white rounded-full"
                    />
                  </div>
                  <div ref={hoverRef1} className=" w-[40px] [h-40px] relative ">
                    {isHovered1 ? (
                      <span className="w-auto absolute z-10  bg-black text-white text-sm px-2 py-1  l-0 rounded-lg top-[100%]">
                        {dataIssue.users[1].userName}
                      </span>
                    ) : (
                      ""
                    )}

                    <img
                      src={dataIssue.users[1].avatar_Path || avtUser}
                      alt=""
                      className="w-[40px] h-[40px] border-2 border-white rounded-full"
                    />
                  </div>
                  <div className=" w-[40px] h-[40px] relative ">
                    <div
                      ref={nodeRef}
                      onClick={() => setShow(!show)}
                      className="absolute inset-0 z-10 flex items-center justify-center text-white bg-black rounded-full opacity-50 item-center"
                    >
                      + {dataIssue.users.length - 2}
                    </div>
                    <img
                      src={dataIssue.users[2].avatar_Path || avtUser}
                      alt=""
                      className="w-[40px] h-[40px] rounded-full"
                    />
                    {show && (
                      <div className="absolute shadow-lg flex flex-col top-[100%] p-2 z-[9999] bg-slate-50 rounded-lg">
                        {dataIssue.users.map((user) => (
                          <UserYourWork key={v4()} user={user}></UserYourWork>
                        ))}
                      </div>
                    )}
                  </div>
                </>
              ) : dataIssue.users.length === 1 ? (
                <div ref={hoverRef} className=" w-[40px] [h-40px] relative ">
                  {isHovered ? (
                    <span className="w-auto absolute z-10  bg-black text-white text-sm px-2 py-1  l-0 rounded-lg top-[100%]">
                      {dataIssue.users[0].userName}
                    </span>
                  ) : (
                    ""
                  )}

                  <img
                    src={dataIssue.users[0].avatar_Path || avtUser}
                    alt=""
                    className="w-[40px] h-[40px] border-2 border-white rounded-full"
                  />
                </div>
              ) : (
                <>
                  <div ref={hoverRef} className=" w-[40px] [h-40px] relative ">
                    {isHovered ? (
                      <span className="w-auto absolute z-10  bg-black text-white text-sm px-2 py-1  l-0 rounded-lg top-[100%]">
                        {dataIssue.users[0].userName}
                      </span>
                    ) : (
                      ""
                    )}

                    <img
                      src={dataIssue.users[0].avatar_Path || avtUser}
                      alt=""
                      className="w-[40px] h-[40px] border-2 border-white rounded-full"
                    />
                  </div>
                  <div ref={hoverRef1} className=" w-[40px] h-[40px] relative ">
                    {isHovered1 ? (
                      <span className="w-auto absolute z-10  bg-black text-white text-sm px-2 py-1  l-0 rounded-lg top-[100%]">
                        {dataIssue.users[1].userName}
                      </span>
                    ) : (
                      ""
                    )}
                    <img
                      src={dataIssue.users[1].avatar_Path || avtUser}
                      alt=""
                      className="w-[40px] h-[40px] rounded-full"
                    />
                  </div>
                </>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default YourWorkIssue;
